using System;
using System.Threading.Tasks;
using todo.Services.Interfaces;
using Xamarin.Forms;

namespace todo.Services
{
    public class DialogServices : IDialogServices
    {
        public void DisplayAlert(string title = "Title", string message = "Message", string cancel = "Cancel")
        {
            Device.BeginInvokeOnMainThread(async () =>
                    await Application.Current.MainPage.DisplayAlert(title, message, cancel));
        }
    }
}
