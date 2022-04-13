using Newtonsoft.Json;

namespace Homework2
{
    public partial class Form1 : Form
    {
        HttpClient client;
        string Code = "";
        public Form1()
        {
            client = new HttpClient(); 
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChoseBox.Text == "USD")
                Code = "USD";
        }

        private void ValueBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Convert_Click(object sender, EventArgs e)
        {
            double value;
            if (!double.TryParse(ValueBox.Text, out value)) 
            {
                MessageBox.Show("Empty Value!");
            }

            var strQuery = $"https://localhost:7183/My/GetPrice?Code={ChoseBox.Text}&value={value}";
            var response = client.GetAsync(strQuery).Result;
            var resultStr = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Currency>(resultStr);

            textBox2.Text = result?.Price.ToString();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}