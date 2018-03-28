using System;
using FormsSample.Commons;

namespace FormsSample.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {

        private string loading = "Not loading";
        public string Loading 
        {
            get => loading;
            set => SetProperty(ref loading, value);
        }
 

        public MainPageViewModel()
        {
        }
    }
}
