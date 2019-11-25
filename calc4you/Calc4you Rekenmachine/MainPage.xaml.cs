﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public MainPage()
        {
            this.InitializeComponent();
        }
        #region Nummer van rekenmachine.
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
            TextBox.Text = TextBox.Text + ",";
            buttonPunt.IsEnabled = false;
        }
        private void buttonProcent_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #endregion

        private void name_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
            Textbox2.Text = "";
            buttonPunt.IsEnabled = true;
        }

        #region buttons van plus win keer delen en = knop en andere.
        public void buttonPlus_Click(object sender, RoutedEventArgs e)
        {

            Textbox2.Text = TextBox.Text + "";
            TextBox.Text = "";
            Knopplus = true;
        }

        public void buttonMin_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text + "";
            TextBox.Text = "";
            Knopmin = true;
        }

        public void buttonKeer_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text + "";
            TextBox.Text = "";
            Knopkeer = true;
        }

        public void buttonDelen_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text + "";
            TextBox.Text = "";
            Knopdelen = true;
        }
        private void mod_Click(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = TextBox.Text + "";
            TextBox.Text = "";
        }
        public void buttonIs(object sender, RoutedEventArgs e)
        {
            int getal1 = Convert.ToInt32(Textbox2.Text);
            int getal2 = Convert.ToInt32(TextBox.Text);
            if (Knopplus == true)
            {
                int antwoord = (getal1 + getal2);
                TextBox.Text = Convert.ToString(antwoord);
                getal1 = 0;
                getal2 = 0;
                Knopplus = false;
            }
            else if (Knopmin == true)
            {
                int antwoord = (getal1 - getal2);
                TextBox.Text = Convert.ToString(antwoord);
                getal1 = 0;
                getal2 = 0;
                Knopmin = false;
            }
            else if (Knopkeer == true)
            {
                int antwoord = (getal1 * getal2);
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
                int antwoord = (getal1 / getal2);
                TextBox.Text = Convert.ToString(antwoord);
                getal1 = 0;
                getal2 = 0;
                Knopdelen = false;
            }
            else
            {
                int antwoord = (getal1 % getal2);
                TextBox.Text = Convert.ToString(antwoord);
                getal1 = 0;
                getal2 = 0;
            }
        }
        #endregion

        #region Textboxes aka de output.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        #region functions
        /// public int Berekenen(int getal1, int getal2)
        ///{
        ///    getal1 = Convert.ToInt32(TextBox.Text);        
        ///}
        #endregion

        private void buttenNegative_Click(object sender, RoutedEventArgs e)
        {
            double N;

            N = double.Parse(TextBox.Text);

            N = N - (N * 2);



            TextBox.Text = N.ToString("0");
        }

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
                buttonDelete.IsEnabled = false;
            else
                buttonDelete.IsEnabled = true;


        }
        #endregion

        private void buttonBinary_Click(object sender, RoutedEventArgs e)
        {
            int number = int.Parse(TextBox.Text);
            string Base = Convert.ToString(number, 2);
            TextBox.Text = Base;
        }

        private void buttonHex_Click(object sender, RoutedEventArgs e)
        {
            int number = int.Parse(TextBox.Text);
            string Base = Convert.ToString(number, 16);
            TextBox.Text = Base;

        }
    }
}
