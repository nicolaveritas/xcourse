using System;
using FormsSample.Commons;
namespace FormsSample.Pages.DetailPage
{
    public class DetailPageViewModel : BaseViewModel
    {

        private string titleContent;
        public string TitleContent 
        {
            get => titleContent;
            set => SetProperty(ref titleContent, value);
        }

        private string textContent;
        public string TextContent 
        {
            get => textContent;
            set => SetProperty(ref textContent, value);
        }
    }
}
