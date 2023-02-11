using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VeterinarSite.Data.Persistance;
using VeterinarSite.Data.Persistance.Entities;
using VeterinarSite.Shared.Models.User;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Server.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    
    public UserController(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    [HttpGet("get-token/{username}")]
    public async Task<string> GetAccesTokenFromDataBase(string username)
    {
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(sr => sr.Username == username);
            return user.RefreshToken;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register( UserRegistrationModel user)
    {
        var dbuser = new User();
        try
        {
             dbuser = _dbContext.Users.FirstOrDefault(sr=>sr.Username == user.Username);
            if (dbuser != null)
            {
                return BadRequest("Username already exists");
            }
            else
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    dbuser = new User
                {
                    Username = user.Username,
                    Password = passwordHash,
                    PasswordSalt = passwordSalt,
                    Phone = user.Phone,
                    Email = user.Email,
                    Role = user.Role
                };
                _dbContext.Users.Add(dbuser);
                await _dbContext.SaveChangesAsync();
                return Ok("User registered successfully");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            
        }
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserLogInModel request)
    {
        try
        {
            var user = _dbContext.Users.FirstOrDefault(sr=>sr.Username == request.Username);
                if (user.Username != request.Username)
                {
                    return BadRequest("User not found.");
                }

                if (!VerifyPasswordHash(request.Password, user.Password, user.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }

                string token = CreateToken(user);

                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(refreshToken,user);

                return Ok(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }
    private RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            AccessToken = new Token(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64))),
            ConsumedTime = DateTime.Now.AddDays(7),
            CreationTime = DateTime.Now
        };

        return refreshToken;
    }
    
    private void SetRefreshToken(RefreshToken newRefreshToken,User user)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = newRefreshToken.ConsumedTime
        };
        Response.Cookies.Append("refreshToken", newRefreshToken.AccessToken.ToString(), cookieOptions);

        user.RefreshToken = newRefreshToken.AccessToken.ToString();
        user.TokenCreated = newRefreshToken.ConsumedTime.Value;
        user.TokenExpires = newRefreshToken.CreationTime;
    }
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new  Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.MobilePhone,user.Phone)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
