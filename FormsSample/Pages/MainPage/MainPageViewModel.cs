using System;
using FormsSample.Commons;

namespace FormsSample.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {

        private bool isLoading = false;
        public bool IsLoading 
        {
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }
 

        public MainPageViewModel()
        {
        }
    }
}
