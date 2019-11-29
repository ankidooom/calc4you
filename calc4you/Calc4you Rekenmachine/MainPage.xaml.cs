using System;
using System.Collections.Generic;
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
            TextBox.Text = TextBox.Text.Replace("€", "");
            TextBox.Text = TextBox.Text.Replace("$", "");
            Textbox2.Text = Textbox2.Text.Replace("€", "");
            Textbox2.Text = Textbox2.Text.Replace("$", "");

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
                getal1 = 0;
                getal2 = 0;
                Knopplus = false;
            }
            else if (Knopmin == true)
            {
                decimal antwoord = (getal1 - getal2);
                TextBox.Text = Convert.ToString(antwoord);
                getal1 = 0;
                getal2 = 0;
                Knopmin = false;
            }
            else if (Knopkeer == true)
            {
                decimal antwoord = (getal1 * getal2);
                TextBox.Text = Convert.ToString(antwoord);
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
                getal1 = 0;
                getal2 = 0;
                Knopdelen = false;
            }
            else
            {
                decimal antwoord = (getal1 % getal2);
                TextBox.Text = Convert.ToString(antwoord);
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
            int getal1 = Convert.ToInt32(TextBox.Text);
            TextBox.Text = "";
            if (getal1 >= 128)
            {
                getal1 = getal1 - 128;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 64)
            {
                getal1 = getal1 - 64;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 32)
            {
                getal1 = getal1 - 32;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 16)
            {
                getal1 = getal1 - 16;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 8)
            {
                getal1 = getal1 - 8;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 4)
            {
                getal1 = getal1 - 4;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 2)
            {
                getal1 = getal1 - 2;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }
            if (getal1 >= 1)
            {
                getal1 = getal1 - 1;
                TextBox.Text += "1";
            }
            else
            {
                TextBox.Text += "0";
            }

        }
        private void buttonHex_Click(object sender, RoutedEventArgs e)
        {
            int getal1 = Convert.ToInt32(TextBox.Text);
            TextBox.Text = "";
            int gedeeld;
            int keer;
            int rest;

            gedeeld = getal1 / 16;
            keer = 16 * gedeeld;
            rest = getal1 - keer;
            while (rest != 0 && gedeeld != 0)
            {
                if (rest == 0)
                {
                    this.TextBox.Text += 0;
                    rest = 0;
                }
                if (gedeeld == 0)
                {
                    this.TextBox.Text += 0;
                    gedeeld = 0;
                }
                if (rest == 1)
                {

                    this.TextBox.Text += 1;
                    rest = 0;
                }
                if (gedeeld == 1)
                {
                    this.TextBox.Text += 1;
                    gedeeld = 0;
                }
                if (rest == 2)
                {
                    this.TextBox.Text += 2;
                    rest = 0;
                }
                if (gedeeld == 2)
                {
                    this.TextBox.Text += 2;
                    gedeeld = 0;
                }
                if (rest == 3)
                {

                    this.TextBox.Text += 3;
                    rest = 0;

                }
                if (gedeeld == 3)
                {
                    this.TextBox.Text += 3;
                    gedeeld = 0;
                }
                if (rest == 4)
                {

                    this.TextBox.Text += 4;
                    rest = 0;

                }
                if (gedeeld == 4)
                {
                    this.TextBox.Text += 4;
                    gedeeld = 0;
                }
                if (rest == 5)
                {

                    this.TextBox.Text += 5;
                    rest = 0;

                }
                if (gedeeld == 5)
                {
                    this.TextBox.Text += 5;
                    gedeeld = 0;
                }
                if (rest == 6)
                {

                    this.TextBox.Text += 6;
                    rest = 0;
                }
                if (gedeeld == 6)
                {
                    this.TextBox.Text += 6;
                    gedeeld = 0;
                }
                if (rest == 7)
                {

                    this.TextBox.Text += 7;
                    rest = 0;

                }
                if (gedeeld == 7)
                {
                    this.TextBox.Text += 7;
                    gedeeld = 0;
                }
                if (rest == 8)
                {

                    this.TextBox.Text += 8;
                    rest = 0;

                }
                if (gedeeld == 8)
                {
                    this.TextBox.Text += 8;
                    gedeeld = 0;
                }
                if (rest == 9)
                {

                    this.TextBox.Text += 9;
                    rest = 0;

                }
                if (gedeeld == 9)
                {
                    this.TextBox.Text += 9;
                    gedeeld = 0;
                }
                if (rest == 10)
                {

                    this.TextBox.Text += "A";
                    rest = 0;
                    
                }
                if (gedeeld == 10)
                {
                    this.TextBox.Text += "A";
                    gedeeld = 0;
                }
                if (rest == 11)
                {

                    this.TextBox.Text += "B";
                    rest = 0;
                    
                }
                if (gedeeld == 11)
                {
                    this.TextBox.Text += "B";
                    gedeeld = 0;
                }
                if (rest == 12)
                {

                    this.TextBox.Text += "C";
                    rest = 0;
                    
                }
                 if (gedeeld == 12)
                {
                    this.TextBox.Text += "C";
                    gedeeld = 0;
                }
                if (rest == 13)
                {

                    this.TextBox.Text += "D";
                    rest = 0;
                    
                }
                if (gedeeld == 13)
                {
                    this.TextBox.Text += "D";
                    gedeeld = 0;
                }
                if (rest == 14)
                {

                    this.TextBox.Text += "E";
                    rest = 0;
                    
                }
                if (gedeeld == 14)
                {
                    this.TextBox.Text += "E";
                    gedeeld = 0;
                }
                if (rest == 15)
                {
                    this.TextBox.Text += "F";
                    rest = 0;
                    
                }
                if (gedeeld == 15)
                {
                    this.TextBox.Text += "F";
                    gedeeld = 0;
                }
                if (getal1 >=256)
                {
                    TextBox.Text = "dat is iets te hoog";
                }
            }
        }
            
            #endregion

            #region Textboxes aka de output.
            public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {

            }


            public void Textbox2_TextChanged(object sender, TextChangedEventArgs e)
            {

            }
            #endregion

        
     }
} 
