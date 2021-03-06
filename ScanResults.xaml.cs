using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IO2021_Desktop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanResults: Page
    {
        public ScanResults()
        {
            this.InitializeComponent();
        }
        async void Search_Click(object sender, RoutedEventArgs e)
        {
           async Task<List<CompromisedAccount>> APICall()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.haveibeenpwned.com/");
                string email = "adkinsseth03579@gmail.com";
                client.DefaultRequestHeaders.Add("hibp-api-key", "17dc6675863c4f3da9850646f98b3b84");
                client.DefaultRequestHeaders.Add("user-agent", "Safety.NET API Call");

                string endpoint = $"/api/v3/breachedaccount/{email}?truncateResponse=false";
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                List<CompromisedAccount> compromised = JsonConvert.DeserializeObject<List<CompromisedAccount>>(content);

                return compromised;
            }
            var res = await APICall();
        }
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

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
