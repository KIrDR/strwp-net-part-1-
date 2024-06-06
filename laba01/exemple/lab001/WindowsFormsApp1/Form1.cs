using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonSum_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxA.Text, out var x) && int.TryParse(textBoxB.Text, out var y))
            {
                var url = "https://localhost:7046/ex.sum";
                using (var client = new HttpClient())
                {
                    var postData = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("X", x.ToString()),
                        new KeyValuePair<string, string>("Y", y.ToString())
                    });
                    
                    var response = await client.PostAsync(url, postData);
                    var responseText = await response.Content.ReadAsStringAsync();
                    
                    if (int.TryParse(responseText, out var sum))
                    {
                        textBoxSum.Text = sum.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid response");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
