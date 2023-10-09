using DSharpPlus.Entities;

namespace spotBackBot.Interfaces.DiscordWrapper;

public interface IDiscordClient: IDisposable
{
    Task<IReadOnlyList<DiscordConnection>> GetConnectionAsync();

    Task<DiscordChannel> GetChannelAsync(ulong newChannelNumber);

    Task ConnectAsync(DiscordActivity activity = null, UserStatus? status = null, DateTimeOffset? idlesince = null);

    // ToDo: wrap the DiscordChannel and DiscordConnection type


}