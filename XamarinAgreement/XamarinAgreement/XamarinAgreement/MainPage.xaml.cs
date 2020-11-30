using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAgreement
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://localhost:6020/api/Agreement";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Agreement> _post;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing() {
            string content = await client.GetStringAsync(url);
            List<Agreement> agreements = JsonConvert.DeserializeObject<List<Agreement>>(content);
            _post = new ObservableCollection<Agreement>(agreements);
            collectionView.ItemsSource = _post;
            base.OnAppearing();
        }
    }
}
