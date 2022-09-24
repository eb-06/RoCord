using Discord;
using Discord.Interactions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RoCord
{
    public class General : InteractionModuleBase<SocketInteractionContext>
    {
        EmbedBuilder Embed = new EmbedBuilder();
        ComponentBuilder Builder = new ComponentBuilder();

        [SlashCommand("help", "Get a list of commands supported by RoCord.")]
        public async Task Help()
        {
            Embed.WithTitle("RoCord");
            Embed.WithDescription("Supported RoCord commands:");
            Embed.AddField("/attach", "Attaches RoCord to ROBLOX using WeAreDevs API.");
            Embed.AddField("/exec `code`", "Execute lua code to ROBLOX from Discord.");
            Embed.AddField("/execfile `attachment`", "Execute lua/txt files to ROBLOX from Discord.");
            Embed.AddField("/listscripts", "List all lua and txt files from the 'scripts' folder.");
            Embed.AddField("/viewscript `file`", "View code from lua or txt files from the 'scripts' folder.");
            Embed.AddField("/execscript `file`", "Execute lua or txt files from the 'scripts' folder.");
            Embed.AddField("/help", "Get a list of commands supported by RoCord.");
            Embed.AddField("/wrd", $"Redirects you to [WeAreDevs.net]({Index.WeAreDevs}).");
            Embed.AddField("/github", $"Redirects you to the offical [RoCord GitHub Repository]({Index.GitHub}).");
            Embed.AddField("/close", "Closes RoCord and disconnects you from the bot.");
            Embed.WithThumbnailUrl(Index.Logo);
            Embed.WithColor(Color.Purple);
            Embed.WithFooter("RoCord", Index.Icon).WithTimestamp(DateTimeOffset.Now);
            await RespondAsync(embed: Embed.Build());
        }

        [SlashCommand("wrd", "Redirects you to WeAreDevs.net.")]
        public async Task WeAreDevs()
        {
            Embed.WithTitle("RoCord");
            Embed.WithDescription($"Redirecting you to: {Index.WeAreDevs}");
            Embed.WithThumbnailUrl(Index.Logo);
            Embed.WithColor(Color.Purple);
            Embed.WithFooter("RoCord", Index.Icon).WithTimestamp(DateTimeOffset.Now);
            Builder.WithButton(label: "WeAreDevs", style: ButtonStyle.Link, url: Index.WeAreDevs);
            await RespondAsync(embed: Embed.Build(), components: Builder.Build());
            Process.Start(Index.WeAreDevs);
        }

        [SlashCommand("github", "Redirects you to the offical RoCord GitHub Repository.")]
        public async Task GitHub()
        {
            Embed.WithTitle("RoCord");
            Embed.WithDescription($"Redirecting you to: {Index.GitHub}");
            Embed.WithThumbnailUrl(Index.Logo);
            Embed.WithColor(Color.Purple);
            Embed.WithFooter("RoCord", Index.Icon).WithTimestamp(DateTimeOffset.Now);
            Builder.WithButton(label: "GitHub", style: ButtonStyle.Link, url: Index.GitHub);
            await RespondAsync(embed: Embed.Build(), components: Builder.Build());
            Process.Start(Index.GitHub);
        }

        [SlashCommand("close", "Closes RoCord and disconnects you from the bot.")]
        public async Task Close()
        {
            Embed.WithTitle("RoCord");
            Embed.WithDescription("Closing RoCord...");
            Embed.WithThumbnailUrl(Index.Logo);
            Embed.WithColor(Color.Orange);
            Embed.WithFooter("RoCord", Index.Icon).WithTimestamp(DateTimeOffset.Now);
            await RespondAsync(embed: Embed.Build());
            Environment.Exit(1);
        }
    }
}