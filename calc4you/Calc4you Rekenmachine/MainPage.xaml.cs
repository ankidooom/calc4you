using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calc4you_Rekenmachine
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        bool Knopplus;
        bool Knopmin;
        bool Knopkeer;
        bool Knopdelen;
        bool Knopmod;
        public string connection = "Data Source=calculater.database.windows.net;User ID=calculater;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Nummers van rekenmachine.
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 1;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 2;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 3;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 4;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 5;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 6;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 7;
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 8;
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 9;
        }
        private void button0_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += 0;
        }
        #region  komma en procenten onder de cijfer van rekenmachine.
        private void buttonPunt_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = TextBox.Text + ".";
            buttonPunt.IsEnabled = false;
        }
        private void buttonProcent_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #endregion

        #region buttons van plus min etc.
        public void name_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
            Textbox2.Text = "";
            buttonPunt.IsEnabled = true;
        }


        public void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text.Replace("+", "");
            TextBox.Text = "";
            Knopplus = true;
            buttonPunt.IsEnabled = true;
        }

        public void buttonMin_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text.Replace("-", "");

            TextBox.Text = "";
            Knopmin = true;
            buttonPunt.IsEnabled = true;
        }

        public void buttonKeer_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text.Replace("*", "");
            TextBox.Text = "";
            Knopkeer = true;
            buttonPunt.IsEnabled = true;
        }

        public void buttonDelen_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text.Replace("/", "");
            TextBox.Text = "";
            Knopdelen = true;
            buttonPunt.IsEnabled = true;
        }
        public void modulo_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text.Replace("mod", "");
            TextBox.Text = "";
            Knopmod = true;
            buttonPunt.IsEnabled = true;
        }
        #endregion

        #region Knop = gaat kijken welke knop is active van de plus, min, keer etc
        /// <summary>
        /// als je de = knop clickt dan kijkt die eerst of je op de keer plus etc knop hebt geclickt
        /// als het niet zo is dan laat hij zien wat er op dit moment staat
        /// </summary>

        public void buttonIs(object sender, RoutedEventArgs e)
        {
            #region zorgt ervoor dat de dollar en euro teken weg gaan.
            TextBox.Text = TextBox.Text.Replace("€", "");
            TextBox.Text = TextBox.Text.Replace("$", "");
            Textbox2.Text = Textbox2.Text.Replace("€", "");
            Textbox2.Text = Textbox2.Text.Replace("$", "");
            #endregion

            #region laat zien in textbox3 de database van de laatse 10.
            Textbox3.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connection;
            SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM [dbo].[Berekeningen] ORDER BY [IDname] DESC;", con);
            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Textbox3.Text += reader[0].ToString();
                    Textbox3.Text += reader[1].ToString();
                    Textbox3.Text += reader[2].ToString();
                    Textbox3.Text += reader[3].ToString();
                    Textbox3.Text += reader[4].ToString();
                    Textbox3.Text += "\r\n";
                }
            }
            con.Close();
            #endregion

            #region Gaat kijken of die plus min keer etc knop wel aan staan zo niet dan disabled hij ze.
            if (Knopplus == false && Knopmin == false && Knopkeer == false && Knopdelen == false && Knopmod == false)
            {
                TextBox.Text = Convert.ToString(TextBox.Text);
                return;
            }
            if (TextBox.Text == "")
            {
                TextBox.Text = Textbox2.Text;
                Textbox2.Text = "";
                Knopplus = false;
                Knopmin = false;
                Knopkeer = false;
                Knopdelen = false;
                return;
            }
            #endregion
            decimal getal1 = decimal.Parse(Textbox2.Text);
            decimal getal2 = decimal.Parse(TextBox.Text);


            if (Knopplus == true)
            {
                decimal antwoord = (getal1 + getal2);
                TextBox.Text = Convert.ToString(antwoord);
                InitializeComponent();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                var command =
                    new SqlCommand("INSERT INTO [dbo].[Berekeningen](Antwoord , Getal1, Getal2, Operator, isTeken) VALUES (@Antwoord, @Getal1, @Getal2, @Operator, @isTeken);", conn);
                command.Parameters.AddWithValue("@Antwoord  ", antwoord);
                command.Parameters.AddWithValue("@Getal1", getal1);
                command.Parameters.AddWithValue("@Getal2", getal2);
                command.Parameters.AddWithValue("@Operator", "+");
                command.Parameters.AddWithValue("@isTeken", "=");
                command.ExecuteReader();
                conn.Close();
                getal1 = 0;
                getal2 = 0;
                Knopplus = false;
            }
            else if (Knopmin == true)
            {
                decimal antwoord = (getal1 - getal2);
                TextBox.Text = Convert.ToString(antwoord);
                InitializeComponent();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                var command =
                    new SqlCommand("INSERT INTO [dbo].[Berekeningen](Antwoord , Getal1, Getal2, Operator, isTeken) VALUES (@Antwoord, @Getal1, @Getal2, @Operator, @isTeken);", conn);
                command.Parameters.AddWithValue("@Antwoord  ", antwoord);
                command.Parameters.AddWithValue("@Getal1", getal1);
                command.Parameters.AddWithValue("@Getal2", getal2);
                command.Parameters.AddWithValue("@Operator", "-");
                command.Parameters.AddWithValue("@isTeken", "=");
                command.ExecuteReader();
                conn.Close();

                getal1 = 0;
                getal2 = 0;
                Knopmin = false;
            }
            else if (Knopkeer == true)
            {
                decimal antwoord = (getal1 * getal2);
                TextBox.Text = Convert.ToString(antwoord);
                InitializeComponent();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                var command =
                    new SqlCommand("INSERT INTO [dbo].[Berekeningen](Antwoord , Getal1, Getal2, Operator, isTeken) VALUES (@Antwoord, @Getal1, @Getal2, @Operator, @isTeken);", conn);
                command.Parameters.AddWithValue("@Antwoord  ", antwoord);
                command.Parameters.AddWithValue("@Getal1", getal1);
                command.Parameters.AddWithValue("@Getal2", getal2);
                command.Parameters.AddWithValue("@Operator", "*");
                command.Parameters.AddWithValue("@isTeken", "=");
                command.ExecuteReader();
                conn.Close();
                getal1 = 0;
                getal2 = 0;
                Knopkeer = false;
            }
            else if (Knopdelen == true)
            {
                if (getal2 == 0)
                {
                    TextBox.Text = "kan niet door nul delen";
                    Knopdelen = false;
                    getal1 = 0;
                    getal2 = 0;
                    return;
                }
                decimal antwoord = (getal1 / getal2);
                TextBox.Text = Convert.ToString(antwoord);
                InitializeComponent();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                var command =
                    new SqlCommand("INSERT INTO [dbo].[Berekeningen](Antwoord , Getal1, Getal2, Operator, isTeken) VALUES (@Antwoord, @Getal1, @Getal2, @Operator, @isTeken);", conn);
                command.Parameters.AddWithValue("@Antwoord  ", antwoord);
                command.Parameters.AddWithValue("@Getal1", getal1);
                command.Parameters.AddWithValue("@Getal2", getal2);
                command.Parameters.AddWithValue("@Operator", "/");
                command.Parameters.AddWithValue("@isTeken", "=");
                command.ExecuteReader();
                conn.Close();
                getal1 = 0;
                getal2 = 0;
                Knopdelen = false;
            }
            else
            {
                decimal antwoord = (getal1 % getal2);
                TextBox.Text = Convert.ToString(antwoord);
                InitializeComponent();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                var command =
                    new SqlCommand("INSERT INTO [dbo].[Berekeningen](Antwoord , Getal1, Getal2, Operator, isTeken) VALUES (@Antwoord, @Getal1, @Getal2, @isTeken);", conn);
                command.Parameters.AddWithValue("@Antwoord  ", antwoord);
                command.Parameters.AddWithValue("@Getal1", getal1);
                command.Parameters.AddWithValue("@Getal2", getal2);
                command.Parameters.AddWithValue("@Operator", "%");
                command.Parameters.AddWithValue("@isTeken", "=");
                command.ExecuteReader();
                conn.Close();
                getal1 = 0;
                getal2 = 0;
                Knopmod = false;
            }
        }
        #endregion

        #region kan de getal negative maken
        private void buttenNegative_Click(object sender, RoutedEventArgs e)
        {
            double N;
            if (TextBox.Text == "")
            {
                buttenNegative.IsEnabled = false;
                buttenNegative.IsEnabled = true;
            }
            else
            {
                N = double.Parse(TextBox.Text);
                N = N - (N * 2);
                TextBox.Text = N.ToString("0");
            }

        }
        #endregion

        #region Delete button methode. hd
        //* simpel "textbox remove length -1 command", hij wist steeds de karakter aan de einde van de string. Natuurlijk kijkt hij eerst of de text ''null'' is of text bevat, en voert de 'if' command uit.
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text != "")
            {
                TextBox.Text = (TextBox.Text.Remove(TextBox.Text.Length - 1));
            }
        }
        #endregion

        #region Loop voor de Delete button. hd
        //* Hij kijkt of de text in TextBox.Text null is, en zet de Delete button naar False als hij niks bevat. True als er karakters er in zijn. Dit is zo gemaakt omdat hij anders crasht als je probeert de 'length -1' command uit te voeren op een 'null string'.
        private void DeleteButtonLoop()
        {
            if (TextBox.Text == "")
            {
                buttonDelete.IsEnabled = false;
            }
            else
            {
                buttonDelete.IsEnabled = true;
            }
        }
        #endregion

        #region EURO/USD wisselkoers api
        private void wisselKoers_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = TextBox.Text.Replace("€", "");
            TextBox.Text = TextBox.Text.Replace("$", "");
            decimal getal2 = 0;
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {

                try
                {
                    getal2 = decimal.Parse(TextBox.Text);
                    client.BaseAddress = new Uri("https://api.exchangeratesapi.io/latest");
                    HttpResponseMessage response = client.GetAsync("?symbols=USD").Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    string USD = result.Substring(16, 6);
                    string USD1 = USD.Replace(".", ".");
                    string USD2 = USD1.Replace("}", "");
                    string USD3 = USD2.Replace(",", "");
                    string USD4 = USD3.Replace("\"", "");
                    decimal USD5 = Convert.ToDecimal(USD4);
                    decimal antwoord = getal2 * USD5;
                    decimal antwoord2 = Math.Round(antwoord, 2);
                    TextBox.Text = Convert.ToString("$" + antwoord2);
                    getal2 = 0;
                }
                catch (Exception ex)
                {

                    decimal USD2 = Convert.ToDecimal(1.102);
                    decimal antwoord = getal2 * USD2;
                    decimal antwoord2 = Math.Round(antwoord, 2);
                    TextBox.Text = Convert.ToString("Schatting: $" + antwoord2);
                    getal2 = 0;
                    Console.WriteLine(ex.Message);
                }

            }
        }
        private void wisselKoersDollar_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = TextBox.Text.Replace("€", "");
            TextBox.Text = TextBox.Text.Replace("$", "");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                decimal getal2 = 0;
                try
                {
                    getal2 = decimal.Parse(TextBox.Text);
                    client.BaseAddress = new Uri("https://api.exchangeratesapi.io/latest");
                    HttpResponseMessage response = client.GetAsync("?symbols=USD").Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    string USD = result.Substring(16, 6);
                    string USD1 = USD.Replace(".", ".");
                    string USD2 = USD1.Replace("}", "");
                    string USD3 = USD2.Replace(",", "");
                    string USD4 = USD3.Replace("\"", "");
                    decimal USD5 = Convert.ToDecimal(USD4);
                    decimal antwoord = getal2 / USD5;
                    decimal antwoord2 = Math.Round(antwoord, 2);
                    TextBox.Text = Convert.ToString("€" + antwoord2);
                    getal2 = 0;
                }
                catch (Exception ex)
                {
                    decimal USD2 = Convert.ToDecimal(1.102);
                    decimal antwoord = getal2 / USD2;
                    decimal antwoord2 = Math.Round(antwoord, 2);
                    TextBox.Text = Convert.ToString("Schatting:€" + antwoord2);
                    getal2 = 0;
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Binair nummers en hexdec
        private void buttonBin_Click(object sender, RoutedEventArgs e)
        {
            int num;
            int quot;
            string rem = "";

            num = Convert.ToInt32(TextBox.Text);
            while (num >= 1)
            {
                quot = num / 2;
                rem += (num % 2).ToString();
                num = quot;
            }
            string bin = "";
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                bin = bin + rem[i];
            }
            TextBox.Text = bin;
        }
        private void buttonHex_Click(object sender, RoutedEventArgs e)
        {
            int antwoord = Convert.ToInt32(TextBox.Text);
            string eind = DecimalToHexadecimal(antwoord);
            TextBox.Text = eind;
        }

        #endregion

        #region Textboxes aka de output.
        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public void Textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        #region statics voor dec hex en Database
        // https://www.programmingalgorithms.com/algorithm/decimal-to-hexadecimal/
        public static string DecimalToHexadecimal(int dec)
        {
            if (dec < 1) return "0";
            int hex = dec;
            string hexStr = string.Empty;
            while (dec > 0)
            {
                hex = dec % 16;
                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());
                dec /= 16;
            }

            return hexStr;
        }

        #endregion

        #region sql delete database en cleart textbox3 
        private void buttonClearData_Click(object sender, RoutedEventArgs e)
        {
            Textbox3.Text = "";

            InitializeComponent();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection;
            conn.Open();
            var command =
                new SqlCommand("DELETE FROM [dbo].[Berekeningen] WHERE IDname <= 10; DBCC CHECKIDENT('[dbo].[Berekeningen]', RESEED, 0) ", conn);
            command.ExecuteReader();
            conn.Close();
            #endregion
        }
    }
} 
