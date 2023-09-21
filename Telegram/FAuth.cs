using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace Telegram
{
    public partial class FAuth : Form
    {
        string apiId = "";
        string apiHash = "";
        string codeHash = "";
        string code = "";
        string phoneNumber = "";
        public FAuth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            phoneNumber = PhoneNumber.Text;

            // Запрос на получение кода авторизации
            codeHash = GetCodeHash(phoneNumber, apiId, apiHash);

            // Проверяем успешность получения codeHash
            if (!string.IsNullOrEmpty(codeHash))
            {
                // Успешно получили codeHash, переходим к следующему табу
                int currentIndex = tabControl1.SelectedIndex;
                int nextIndex = currentIndex + 1;

                if (nextIndex < tabControl1.TabCount)
                {
                    tabControl1.SelectedIndex = nextIndex;
                }
            }
        }

        private string GetCodeHash(string phoneNumber, string apiId, string apiHash)
        {
            try
            {
                string url = $"https://my.telegram.org/auth/send_password?phone={phoneNumber}&api_id={apiId}&api_hash={apiHash}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string result = reader.ReadToEnd();
                            MessageBox.Show(result);
                            // Парсинг code_hash из ответа сервера
                            int startIndex = result.IndexOf("\"code_hash\":\"") + 13;
                            int endIndex = result.IndexOf("\"", startIndex);
                            string codeHash = result.Substring(startIndex, endIndex - startIndex);
                            return codeHash;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения, например, вывод сообщения об ошибке в лог или возвращение null
                return null;
            }
        }
        private void entry_Click(object sender, EventArgs e)
        {

            // Введите полученный код авторизации
            code = CodeTextBox.Text;

            // Запрос на авторизацию
            string authToken = GetAuthToken(phoneNumber, codeHash, code, apiId, apiHash);

            AuthTokenLabel.Text = "Авторизация успешна. Токен авторизации: " + authToken;
            Application.Run(new FMain(authToken));
        }

        private string GetAuthToken(string phoneNumber, string codeHash, string code, string apiId, string apiHash)
        {
            string url = $"https://my.telegram.org/auth/login?phone={phoneNumber}&code_hash={codeHash}&code={code}&api_id={apiId}&api_hash={apiHash}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        // Парсинг auth_token из ответа сервера
                        int startIndex = result.IndexOf("\"auth_token\":\"") + 14;
                        int endIndex = result.IndexOf("\"", startIndex);
                        string authToken = result.Substring(startIndex, endIndex - startIndex);
                        return authToken;
                    }
                }
            }
        }

    }
}