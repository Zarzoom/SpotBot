using Autofac;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using DSharpPlus;

namespace spotBackBot;

public class SpotBackBotModule: Autofac.Module
{
    private IConfiguration _configuration;

    public SpotBackBotModule(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        DiscordConfiguration discordConfig = new()
        {
            Token = _configuration.GetValue<string>("DiscordAPIToken"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged
        };
        builder.RegisterInstance(discordConfig);
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(SpotBackBotModule))).Where(p => p.Namespace.Contains("Services") && !p.IsInterface).AsImplementedInterfaces().SingleInstance();
    }
}