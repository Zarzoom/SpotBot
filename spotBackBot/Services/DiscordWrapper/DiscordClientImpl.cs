using DSharpPlus;
using DSharpPlus.Entities;
using spotBackBot.Interfaces;
using spotBackBot.Interfaces.DiscordWrapper;

namespace spotBackBot.Services.DiscordWrapper;

public class DiscordClientImpl: IDiscordClient
{
    public static implicit operator DiscordClient(DiscordClientImpl currentClient)
    {
        return currentClient._discordClient;
    }

    private DiscordClient _discordClient;

    public DiscordClientImpl(DiscordConfiguration SpotBotConfig)
    {
        _discordClient = new DiscordClient(SpotBotConfig);
    }

    public Task<IReadOnlyList<DiscordConnection>> GetConnectionAsync()
    { 
        return ( _discordClient.GetConnectionsAsync() );
    }

    public void Dispose()
    {
        _discordClient.Dispose();
    }

    public Task<DiscordChannel> GetChannelAsync(ulong newChannelNumber)
    {
        return (_discordClient.GetChannelAsync(newChannelNumber));
    }

    public Task ConnectAsync(DiscordActivity activity = null, UserStatus? status = null, DateTimeOffset? idlesince = null)
    {
        return (_discordClient.ConnectAsync(activity, status, idlesince));
    }
}