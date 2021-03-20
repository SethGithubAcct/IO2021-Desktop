﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace IO2021_Desktop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        async void Scan_Click(object sender, RoutedEventArgs e)
        {
            CompromisedAccount APICall()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.haveibeenpwned.com/");
                CompromisedAccount api_results = client.GetAsync("api/v3/");
                client.DefaultRequestHeaders.Add("hibp-api-key", "17dc6675863c4f3da9850646f98b3b84");
                client.DefaultRequestHeaders.Add("user-agent", "Explosive Security API Call");
                Console.WriteLine(api_results);
                return api_results;
            }
            ContentDialog scanResult = new ContentDialog
            {
                Title = "Scan Results",
                Content = "May God have mercy on your email account",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await scanResult.ShowAsync();
        }
    }
    public class CompromisedAccount
    {
        public string email;
        public string breach;
        public string[] compromised_data;
        public int date;
    }
}