using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DiscordBotFORM
{
    public class Moderation : ModuleBase<SocketCommandContext>

    {

        private DiscordSocketClient _client;

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "No Tienes Permiso para Eliminar Mensajes!")]
        public async Task BanMember(IGuildUser user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                var builder = new EmbedBuilder()


                .WithTitle("Introduzca un Usuario!")
                .WithColor(new Discord.Color(255, 0, 0));

                var embed1 = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed1);
            }
            if (reason == null) reason = ".";

            await Context.Guild.AddBanAsync(user, 1, reason);

            var builder1 = new EmbedBuilder()


                .WithTitle("El Usuario ha sido Baneado")
                .WithDescription($"{user}")
                .WithColor(new Discord.Color(0, 255, 0));

            var embed2 = builder1.Build();
            await Context.Channel.SendMessageAsync(null, false, embed2);


        }






    }
}
