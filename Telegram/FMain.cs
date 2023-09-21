using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;

namespace Telegram
{
    public partial class FMain : Form
    {
        private string authToken; // Токен будет передаваться при открытии формы

        public FMain(string authToken)
        {
            InitializeComponent();
            this.authToken = authToken;
        }
        private async void FMain_Load(object sender, EventArgs e)
        {
            try
            {
                var chatList = await GetChatListAsync();

                foreach (var chat in chatList)
                {
                    var chatNode = new TreeNode(chat.Title);
                    chatNode.Tag = chat.Id; // Сохраняем ID чата в Tag узла
                    treeView1.Nodes.Add(chatNode);
                }

                // Обработчик события выбора узла в первом TreeView
                treeView1.AfterSelect += async (s, args) =>
                {
                    var selectedNode = args.Node;
                    if (selectedNode != null)
                    {
                        var chatId = (long)selectedNode.Tag;
                        var messages = await GetMessagesAsync(chatId);

                        // Очищаем второй TreeView от предыдущих сообщений
                        treeView2.Nodes.Clear();

                        foreach (var message in messages)
                        {
                            var messageNode = new TreeNode(message.Text);
                            treeView2.Nodes.Add(messageNode);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении чатов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<List<Chat>> GetChatListAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.telegram.org");

                // Установка заголовка с auth_token
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

                var response = await client.GetStringAsync("/v1/me/chats");
                var result = JsonConvert.DeserializeObject<TelegramApiResponse>(response);

                var chatList = new List<Chat>();

                foreach (var chat in result.Chats)
                {
                    chatList.Add(chat);
                }

                return chatList;
            }
        }
        private async Task<List<Message>> GetMessagesAsync(long chatId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.telegram.org");

                // Установка заголовка с auth_token
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");

                var response = await client.GetStringAsync($"/v1/chats/{chatId}/messages");
                var result = JsonConvert.DeserializeObject<TelegramMessageApiResponse>(response);

                var messageList = new List<Message>();

                foreach (var message in result.Messages)
                {
                    messageList.Add(message);
                }

                return messageList;
            }
        }
    }
    class TelegramApiResponse
    {
        public List<Chat> Chats { get; set; }
    }

    class Chat
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    class TelegramMessageApiResponse
    {
        public List<Message> Messages { get; set; }
    }

    class Message
    {
        public string Text { get; set; }
    }
}
