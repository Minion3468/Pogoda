using System.Text.Json;

namespace pogoda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string dziala = client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=54.35&longitude=18.65&hourly=temperature_2m&current_weather=true&timezone=Europe%2FBerlin").Result;
            JsonDocument document = JsonDocument.Parse(dziala);
            JsonElement elemt = document.RootElement.GetProperty("current_weather");
            label1.Text = elemt.GetProperty("temperature").ToString();
            label2.Text = elemt.GetProperty("windspeed").ToString();
            int rodzaj = int.Parse(elemt.GetProperty("weathercode").ToString());
            if (rodzaj == 0) { label3.Text = " Clear sky"; }
            else if (rodzaj == 1) { label3.Text = "Mainly clear"; }
            else if (rodzaj == 2) { label3.Text = " partly cloudy"; }
            else if (rodzaj == 3) { label3.Text = " overcast/pochmurny"; }





        }
    }
}
