using System;
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
        async void HelloWorld_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog helloWorld = new ContentDialog
            {
                Title = "It works!",
                Content = "Hello world!",
                CloseButtonText = "Exit"
            };
            ContentDialogResult result = await helloWorld.ShowAsync();
        }
        async void Scan_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog scanResult = new ContentDialog
            {
                Title = "Scan Results",
                Content = "May God have mercy on your email account",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await scanResult.ShowAsync();
        }
    }
}