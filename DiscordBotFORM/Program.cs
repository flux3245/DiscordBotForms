using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;


namespace DiscordBotFORM
{
    class Program
    {


        public static DiscordTools mainWindow;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new DiscordTools();
            Application.Run(mainWindow);
        }





        public static int Suma()
        {
            return 4 + 4;
        }





    }
}
