using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Void.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        Utilities util = new Utilities();

        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Message by " + Context.User.Username);
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("tomquote")]
        public async Task TomQuote()
        {
            await Context.Channel.SendMessageAsync(util.GetTomQuote());
        }

        [Command("hi")]
        public async Task Hi()
        {
            await Context.Channel.SendMessageAsync("HULLOOOOOOOOO");
        }

        [Command("help")]
        public async Task Help() //Inplemented
        {
         
        }

        public async Task Help([Remainder]string message) //Inplemented
        {

        }

        [Command("remember")]
        public async Task Remember([Remainder]string message)
        {
            util.SetRememberQuote(message);
            await Context.Channel.SendMessageAsync("Remembered");
        }

        [Command("recall")]
        public async Task Recall()
        {
            await Context.Channel.SendMessageAsync(util.GetQuote());
        }

        [Command("pick")]
        public async Task PickOne([Remainder]string message)
        {
            string[] options = message.Split('|', StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("Choice for " + Context.User.Username);
            embed.WithDescription(selection);
            embed.WithColor(new Color(255, 255, 0));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
