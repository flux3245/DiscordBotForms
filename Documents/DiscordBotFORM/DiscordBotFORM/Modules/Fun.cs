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
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace DiscordBotFORM.Modules
{
    public class Fun : ModuleBase<SocketCommandContext>
    {

        private DiscordSocketClient _client;


        [Command("meme")]
        [Alias("reddit")]
        public async Task Meme(string subreddit = null)
        {
            var cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync($"https://reddit.com/r/{subreddit ?? "SpanishMeme"}/random.json?limit=1");
            if (!resultado.StartsWith("["))
            {
                var builder1 = new EmbedBuilder()
    
                .WithColor(new Discord.Color(255, 0, 0))
                .WithTitle($"El Subreddit **{subreddit}** no Existe!");
                
                var embed1 = builder1.Build();

                await Context.Channel.SendMessageAsync(null, false, embed1);
                return;
            }


            JArray arr = JArray.Parse(resultado);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());
            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(new Discord.Color(171, 56, 68))
                .WithTitle(post["title"].ToString())
                .WithUrl("https://redit.com" + post["permalink"].ToString())
                .WithFooter($"🗨 {post["num_comments"]} ⏫ {post["ups"]} ");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);

        }


    }
}
