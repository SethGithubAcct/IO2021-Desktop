using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Newtonsoft.Json;


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
            async Task<List<CompromisedAccount>> APICall()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.haveibeenpwned.com/");
                //CompromisedAccount api_results = client.GetAsync("api/v3/");
                string email = "adkinsseth03579@gmail.com";
                client.DefaultRequestHeaders.Add("hibp-api-key", "17dc6675863c4f3da9850646f98b3b84");
                client.DefaultRequestHeaders.Add("user-agent", "Explosive Security API Call");

                string endpoint = $"/api/v3/breachedaccount/{email}?truncateResponse=false";
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                List<CompromisedAccount> compromised = JsonConvert.DeserializeObject<List<CompromisedAccount>>(content);

                return compromised;
            }

            var res = await APICall();

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
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public List<string> DataClasses { get; set; }
    }
}