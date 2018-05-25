using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord;
using System.Threading.Tasks;

namespace AnimooBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]
        public async Task Echo([Remainder] string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Echoed Messaged by " + Context.User.Username);
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 255));
            embed.WithThumbnailUrl("https://cdn.discordapp.com/avatars/"+ Context.User.Id + "/" + Context.User.AvatarId + ".png");
            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("pick")]
        public async Task PickOne([Remainder] string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            Random rand = new Random();

            string selection = options[rand.Next(0,options.Length)];
            var embed = new EmbedBuilder();
            embed.WithTitle(Context.User.Username + ", I pick this one:");
            embed.WithCurrentTimestamp();
            embed.WithDescription(selection);
            embed.WithColor(new Color(rand.Next(0,256), rand.Next(0, 256), rand.Next(0, 256)));
            
            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("secret")]
        public async Task Secret([Remainder] string arg = "")
        {
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
            await dmChannel.SendMessageAsync(Utilities.getAlert("Secret"));
        }
    }
}
