namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out var x) && int.TryParse(textBox2.Text, out var y))
            {
                var url = "http://localhost:5266/kiruha/calc";
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
                        textBox3.Text = sum.ToString();
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