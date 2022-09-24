using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace RoCord
{
    class Backend
    {
        private DiscordSocketClient Client;

        public async Task RunBot(string token)
        {
            IHost IHost = Host.CreateDefaultBuilder().ConfigureServices((Singleton) => Singleton
            .AddSingleton<Interaction>()
            .AddSingleton(new CommandService())
            .AddSingleton(new DiscordSocketClient())
            .AddSingleton(InteractionService => new InteractionService(InteractionService.GetRequiredService<DiscordSocketClient>()))).Build();
            await LoadBot(token, IHost);
        }

        private async Task LoadBot(string token, IHost ihost)
        {
            IServiceScope Service = ihost.Services.CreateScope();
            IServiceProvider Provider = Service.ServiceProvider;

            var Commands = Provider.GetRequiredService<InteractionService>();
            Client = Provider.GetRequiredService<DiscordSocketClient>();
            await Provider.GetRequiredService<Interaction>().InitializeAsync();
            Client.Ready += async () => {
                Console.WriteLine("[DEBUG]", Console.ForegroundColor = ConsoleColor.DarkGray);
                await Commands.RegisterCommandsGloballyAsync(false);
                Console.WriteLine("[SUCCESS]: Loaded bot!", Console.ForegroundColor = ConsoleColor.Green);
                Console.Title = $"RoCord | Token: {(string)Config.Read("token")}";
                Console.Clear();
                Console.WriteLine(Index.ConsoleLogo, Console.ForegroundColor = ConsoleColor.DarkMagenta);
            };
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();
            await Client.SetGameAsync($"RoCord - {Index.GitHub}");
            await Task.Delay(-1);
        }
    }
}