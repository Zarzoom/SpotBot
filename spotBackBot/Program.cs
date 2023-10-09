using Autofac;
using Autofac.Extensions.DependencyInjection;
using spotBackBot;
using DSharpPlus;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new SpotBackBotModule(null)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// var discord = new DiscordClient(new DiscordConfiguration()
// {
//     Token = "First Token",
//     TokenType = TokenType.Bot,
//     Intents = DiscordIntents.AllUnprivileged
// });
//
// await discord.ConnectAsync();
// await Task.Delay(-1);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
