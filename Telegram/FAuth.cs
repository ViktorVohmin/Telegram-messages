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

            // ������ �� ��������� ���� �����������
            codeHash = GetCodeHash(phoneNumber, apiId, apiHash);

            // ��������� ���������� ��������� codeHash
            if (!string.IsNullOrEmpty(codeHash))
            {
                // ������� �������� codeHash, ��������� � ���������� ����
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
                            // ������� code_hash �� ������ �������
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
                // ��������� ����������, ��������, ����� ��������� �� ������ � ��� ��� ����������� null
                return null;
            }
        }
        private void entry_Click(object sender, EventArgs e)
        {

            // ������� ���������� ��� �����������
            code = CodeTextBox.Text;

            // ������ �� �����������
            string authToken = GetAuthToken(phoneNumber, codeHash, code, apiId, apiHash);

            AuthTokenLabel.Text = "����������� �������. ����� �����������: " + authToken;
            Application.Run(new FMain(authToken));
        }

        private string GetAuthToken(string phoneNumber, string codeHash, string code, string apiId, string apiHash)
        {
            string url = $"https://my.telegram.org/auth/login?phone={phoneNumber}&code_hash={codeHash}&code={code}&api_id={apiId}&api_hash={apiHash}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string result = reader.ReadToEnd();
                            MessageBox.Show(result);

                            int startIndex = result.IndexOf("\"auth_token\":\"");
                            if (startIndex >= 0)
                            {
                                startIndex += 14; // ��������� ����� ��������� "\"auth_token\":\""
                                int endIndex = result.IndexOf("\"", startIndex);
                                if (endIndex >= 0)
                                {
                                    string authToken = result.Substring(startIndex, endIndex - startIndex);
                                    return authToken;
                                }
                                else
                                {
                                    // ��������� ������: ����������� ������� �� �������
                                    MessageBox.Show("������: ����������� ������� ��� auth_token �� �������.");
                                    return null; // ��� ��������� ����������, ���� ��� ����� ���������� �������
                                }
                            }
                            else
                            {
                                // ��������� ������: ��������� auth_token �� �������
                                MessageBox.Show("������: ��������� auth_token �� �������.");
                                return null; // ��� ��������� ����������, ���� ��� ����� ���������� �������
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ��������� ������ ��� ���������� �������
                MessageBox.Show($"������ ��� ���������� �������: {ex.Message}");
                return null; // ��� ��������� ����������, ���� ��� ����� ���������� �������
            }
        }
        
    }
}