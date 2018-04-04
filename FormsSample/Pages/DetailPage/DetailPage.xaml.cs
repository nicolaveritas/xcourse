using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsSample.Models;

namespace FormsSample.Pages.DetailPage
{
    public partial class DetailPage : ContentPage
    {

        private DetailPageViewModel _vm;

        public DetailPage(Post selectedPost)
        {
            InitializeComponent();

            BindingContext = _vm = new DetailPageViewModel();

            _vm.TitleContent = selectedPost.title;
            _vm.TextContent = selectedPost.body;
        }
    }
}
