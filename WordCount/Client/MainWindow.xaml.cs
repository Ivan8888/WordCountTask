﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetText(object sender, RoutedEventArgs e)
        {
            IText text = TextFactory.Instance(((Button)sender).Content.ToString());
            txt_TextToProcess.Text = text.GetText();
        }

        private void BtnCountWords_Click(object sender, RoutedEventArgs e)
        {
            txt_WordsNumber.Text = GetWordCount(txt_TextToProcess.Text).ToString();
        }

        private int GetWordCount(string text)
        {
            int result = 0;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6600");
            HttpResponseMessage response = client.PostAsJsonAsync("api/text/wordcount", new { Text = text}).Result;
            if(response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<int>().Result;
            }

            return result;
        }

    }
}
