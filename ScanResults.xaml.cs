using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
        CompromisedAccount api_results = null;
       
    }
    public class CompromisedAccount
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public List<string> DataClasses { get; set; }
    }
}
