global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using VeterinarSite.Client;
using VeterinarSite.Client.Services;
using VeterinarSite.Client.Services.Authentication;
using VeterinarSite.Client.Services.BiroulExecutiv;
using VeterinarSite.Client.Services.Comision;
using VeterinarSite.Client.Services.ComisionService;
using VeterinarSite.Client.Services.ScienceAndResearch;
using VeterinarSite.Shared.Services;
using VeterinarSite.Shared.Services.ComisiaDeDenotologiesilitigii;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAutenticationProvider>();
builder.Services.AddScoped<IUserAuthentication, AuthenticationService>();
builder.Services.AddScoped<ICurrentUser, GetCurrentAuthenticatedUsername>();
builder.Services.AddScoped<IMedicalWorker, MedicalWorkerServices>();
builder.Services.AddScoped<IBiroulExecutivService,BiroulExecutivService>();
builder.Services.AddScoped<ICenzors,CenzorService>();
builder.Services.AddScoped<IScieneceAndResearchService,ResearchService>();
builder.Services.AddScoped<IComisionService,ComisionService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();
