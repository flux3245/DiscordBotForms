using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Windows.Forms;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBotFORM
{
 public partial class DiscordTools : MetroFramework.Forms.MetroForm
 {
   private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public DiscordTools()
   {
       InitializeComponent();
   }





        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            _client.JoinedGuild += OnJoinedGuild;
            _client.ReactionAdded += OnReactionAdded;


        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            if (arg3.MessageId != 861760555882905600) return;

            if (arg3.Emote.Name != "✅") return;

            var role = (arg2 as SocketGuildChannel).Guild.Roles.FirstOrDefault(x => x.Id == 861761509742739476);
            await (arg3.User.Value as SocketGuildUser).AddRoleAsync(role);

        }

        private async Task OnJoinedGuild(SocketGuild arg)
        {

            var builder = new EmbedBuilder()


                .WithTitle("Gracias por Usar mi bot de Discord!")
                .WithColor(new Discord.Color(54, 115, 45));

            var embed1 = builder.Build();
            //await Context.Channel.SendMessageAsync(null, false, embed1);


            await arg.DefaultChannel.SendMessageAsync(null, false, embed1);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {



            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix(metroTextBox6.Text, ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) ;
                if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }



        async private void Form1_Load(object sender, EventArgs e)
   {
            

            _client = new DiscordSocketClient();
            _commands = new CommandService();


            

            _services = new ServiceCollection()
               .AddSingleton(_client)
               .AddSingleton(_commands)
               .BuildServiceProvider();



           






    }


        public async void button1_Click_1(object sender, EventArgs e)
        {
            
            

            try
            {
                await RegisterCommandsAsync();

                await _client.LoginAsync(TokenType.Bot, metroTextBox1.Text);

                await _client.StartAsync();

                metroPanel3.Enabled = true;
                metroPanel6.Enabled = true;
                metroPanel1.Enabled = true;
                metroPanel9.Enabled = true;

                MessageBox.Show("Iniciaste Sesion correctamente");

            }
            catch(Exception)
            {
                MessageBox.Show("Token Incorrecto");
            }

            
                    

            

        }

        static string TakeId()
        {
            return Program.mainWindow.metroTextBox11.Text;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
   {




   }

   private void metroToggle1_CheckedChanged(object sender, EventArgs e)
   {
       
   }

   private void metroLabel1_Click(object sender, EventArgs e)
   {
       
   }

        private async void metroButton2_Click(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

           

            try
            {
                foreach (SocketTextChannel c in guild.TextChannels)
                {
                    await c.DeleteAsync();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Introduzca ID de Servidor valida!");

            }


        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));



            try
            {
                foreach (SocketVoiceChannel cv in guild.VoiceChannels)
                {
                    await cv.DeleteAsync();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Introduzca ID de Servidor valida!");

            }

        }

        private async void metroButton3_Click(object sender, EventArgs e)
        {


            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

            string cantidad = metroTextBox2.Text;

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {
                    await guild.CreateVoiceChannelAsync(TakeId());
                    
                }

                catch (Exception)
                {
                    MessageBox.Show("Introduzca ID de Servidor valida!");

                }

            }

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private async void metroButton4_Click(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));



            try
            {
                foreach (SocketTextChannel c in guild.TextChannels)
                {
                    await c.DeleteAsync();
                }

                foreach (SocketVoiceChannel cv in guild.VoiceChannels)
                {
                    await cv.DeleteAsync();
                }

                foreach (SocketCategoryChannel ca in guild.CategoryChannels)
                {
                    await ca.DeleteAsync();
                }


                string cantidad = metroTextBox2.Text;

                for (int i = 0; i < int.Parse(cantidad); i++)
                {
                    try
                    {
                        await guild.CreateVoiceChannelAsync(metroTextBox3.Text);

                    }

                    catch (Exception)
                    {


                    }

                }


                for (int i = 0; i < int.Parse(cantidad); i++)
                {
                    try
                    {
                        await guild.CreateTextChannelAsync(metroTextBox3.Text);

                    }

                    catch (Exception)
                    {


                    }

                }





            }
            catch (Exception)
            {
                MessageBox.Show("Introduzca ID de Servidor valida!");

            }









        }

        private void metroToolTip2_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private async void metroButton5_Click(object sender, EventArgs e)
        {
            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));



            try
            {
                foreach (SocketCategoryChannel ca in guild.CategoryChannels)
                {
                    await ca.DeleteAsync();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Introduzca ID de Servidor valida!");
            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async void metroTextBox6_Click(object sender, EventArgs e)
        {


        }




        private async void metroButton7_Click(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

            try
            {



                metroLabel9.Text = "ID : " + guild.Id.ToString();
                metroLabel8.Text = "Cantidad de Canales (Voz): " + guild.VoiceChannels.Count().ToString();
                metroLabel11.Text = "Cantidad de Canales (Texto): " + guild.TextChannels.Count().ToString();
                metroLabel7.Text = "Creado el: " + guild.CreatedAt.ToString();
                metroLabel10.Text = "Cantidad de Miembros: " + guild.MemberCount.ToString();
                if (guild.IconUrl == null)
                {
                    pictureBox1.Load("https://img1.freepng.es/20180423/jaq/kisspng-x-mark-cross-computer-icons-clip-art-cartoon-geometry-5ade5d7e22b151.6725815015245223661421.jpg");
                }
                else
                {
                    pictureBox1.Load(guild.IconUrl.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Introduzca ID de Servidor valida!");
            }


        }

        private async void metroButton8_Click(object sender, EventArgs e)
        {
            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));



            try
            {
                foreach (SocketTextChannel c in guild.TextChannels)
                {
                    await c.DeleteAsync();
                }

                foreach (SocketVoiceChannel cv in guild.VoiceChannels)
                {
                    await cv.DeleteAsync();
                }

                foreach (SocketCategoryChannel ca in guild.CategoryChannels)
                {
                    await ca.DeleteAsync();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Introduzca ID de Servidor valida!");

            }

        }

        private async void metroButton6_Click(object sender, EventArgs e)
        {
            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

            string cantidad = metroTextBox5.Text;

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {
                    await guild.CreateTextChannelAsync(metroTextBox4.Text);

                }

                catch (Exception)
                {

                    MessageBox.Show("Introduzca ID de Servidor valida!");
                }

            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {

        }

        private async void metroButton4_Click_1(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));



            try
            {
                foreach (SocketTextChannel c in guild.TextChannels)
                {
                    await c.DeleteAsync();
                }

                foreach (SocketVoiceChannel cv in guild.VoiceChannels)
                {
                    await cv.DeleteAsync();
                }

                foreach (SocketCategoryChannel ca in guild.CategoryChannels)
                {
                    await ca.DeleteAsync();
                }

            }
            catch (Exception)
            {


            }

            string cantidad = metroTextBox8.Text;

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {
                    await guild.CreateVoiceChannelAsync(metroTextBox7.Text);
                    ;
                   

                }

                catch (Exception)
                {


                }

            }

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {

                    await guild.CreateTextChannelAsync(metroTextBox7.Text);
                }

                catch (Exception)
                {


                }

            }

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {
                    await guild.CreateCategoryChannelAsync(metroTextBox7.Text);


                }

                catch (Exception)
                {
                   

                }

            }



        }

        private async void metroButton9_Click_1(object sender, EventArgs e)
        {
            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

            string cantidad = metroTextBox10.Text;

            for (int i = 0; i < int.Parse(cantidad); i++)
            {
                try
                {
                    await guild.CreateCategoryChannelAsync(metroTextBox9.Text);

                }

                catch (Exception)
                {
                    MessageBox.Show("Error!");

                }

            }
        }
        private  async void metroButton10_Click(object sender, EventArgs e)
        {

            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));


            metroLabel17.Text = "Nombre: " + guild.CurrentUser.Username.ToString() + guild.CurrentUser.Discriminator.ToString();
            metroLabel20.Text = "ID: " + guild.CurrentUser.Id.ToString();
            metroLabel11.Text = "Cantidad de Canales (Texto): " + guild.TextChannels.Count().ToString();
            metroLabel19.Text = "Unido el: " + guild.CurrentUser.JoinedAt.ToString();
            metroLabel18.Text = "Creado el: " + guild.CurrentUser.CreatedAt.ToString();
            metroLabel21.Text = "Permisos: " + guild.CurrentUser.GuildPermissions.ToString();

            

            if (guild.CurrentUser.AvatarId == null)
            {
                pictureBox2.Load("https://img1.freepng.es/20180423/jaq/kisspng-x-mark-cross-computer-icons-clip-art-cartoon-geometry-5ade5d7e22b151.6725815015245223661421.jpg");
            }
            else
            {
                var test = guild.CurrentUser.GetAvatarUrl();


                pictureBox2.Load(test);
            }

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

        }

        public void metroTextBox11_Click(object sender, EventArgs e)
        {

        }

        public string ids { get => metroTextBox11.Text; }

        private async void metroButton11_Click_1(object sender, EventArgs e)
        {
            var guild = _client.GetGuild(Convert.ToUInt64(TakeId()));

            try
            {
                foreach (SocketUser user in guild.Users)
                {
                
                    while (true)
                    {
                        await guild.AddBanAsync(user, 0, "raid");
                    }
                    
                }
                

            }
            catch (Exception)
            {


            }
        }
    }

}