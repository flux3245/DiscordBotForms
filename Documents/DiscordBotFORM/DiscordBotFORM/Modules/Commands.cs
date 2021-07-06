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
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient _client;


        static ulong TakeId()
        {


            StreamReader l = new StreamReader(@"data.txt");





            string a = l.ReadLine();




            return ulong.Parse(a);


        }







        [Command("ping")]
        public async Task Ping()
        {

            await ReplyAsync("pong");
        }

        [Command("user")]
        public async Task User(SocketGuildUser user = null)
        {

            if (user == null)
            {
                var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithTitle("Informacion del Usuario")
                
                .WithColor(new Discord.Color(171, 56, 68))

                .AddField("ID", Context.User.Id, true)
                .AddField("Cuenta Creada", Context.User.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Se Unio a el Servidor el", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                .WithCurrentTimestamp();
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var builder = new EmbedBuilder()
                .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                .WithDescription("Informacion del Usuario")
                .WithColor(new Discord.Color(171, 56, 68))
                
                .AddField("ID", user.Id, true)
                .AddField("Cuenta Creada", user.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Se Unio a el Servidor el", user.JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                .AddField("Roles", string.Join(" ", user.Roles.Select(x => x.Mention)))
                .WithCurrentTimestamp();

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }





        }



        [Command("say")]
        public async Task Say(string mj)
        {

            await Context.Channel.SendMessageAsync(mj);
        }




        [Command("server")]
        public async Task Server()
        {
            var builder = new EmbedBuilder()

                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle("Informacion del Servidor")
                .WithDescription($"**{Context.Guild.Name}**")
                .WithColor(new Discord.Color(171, 56, 68))
                .AddField("ID", Context.Guild.Id, true)
                .AddField("Creado el", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Miembros", (Context.Guild as SocketGuild).MemberCount + " Miembors", true)
                .AddField("Miembros Online", (Context.Guild as SocketGuild).Users.Where(x => x.Status != UserStatus.Offline).Count() + " Miembros", true)
                .AddField("Owner", (Context.Guild as SocketGuild).Owner.Mention, true)
                .AddField("Canales de Texto", (Context.Guild as SocketGuild).TextChannels.Count + " Canales de Texto")
                .AddField("Canales de Voz", (Context.Guild as SocketGuild).VoiceChannels.Count + " Canales de Voz", true)
                .WithCurrentTimestamp();
                


            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }




        [Command("clear")]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "No Tienes Permiso para Eliminar Mensajes!")]
        public async Task Clear(int cantidad)
        {
            var builder = new EmbedBuilder()

                .WithTitle($"Se han elimnado **{cantidad}** mensajes!")
                .WithColor(new Discord.Color(54, 115, 45))
                .WithCurrentTimestamp();
            var embed = builder.Build();

            var mensajes = await Context.Channel.GetMessagesAsync(cantidad + 1).FlattenAsync();



            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(mensajes);


            var mesj = await Context.Channel.SendMessageAsync(null, false, embed);
            await Task.Delay(3000);
            await mesj.DeleteAsync();
        }





    }
}
