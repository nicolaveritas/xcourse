using Xamarin.Forms;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using FormsSample.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FormsSample.MainPage;
using FormsSample.Pages.DetailPage;

namespace FormsSample
{
    public partial class FormsSamplePage : ContentPage
    {

        public ObservableCollection<Post> _posts = new ObservableCollection<Post>();
        private MainPageViewModel _vm;

        public FormsSamplePage()
        {
            BindingContext = _vm = new MainPageViewModel();
            InitializeComponent();
            Title = "Main Page";
            _vm.IsLoading = true;
            list.ItemsSource = _posts;

            Init();
        }

        private async void Init() {

            var allPostsReq = await RestService.GetAllPosts();

            var json = await allPostsReq.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(json);
            foreach (var item in posts)
            {
                _posts.Add(item);
            }

            _vm.IsLoading = false;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            list.SelectedItem = null;
            var item = e.Item as Post;
            if (item != null) {
                Navigation.PushAsync(new DetailPage(item));
            }
        }
    }
}
