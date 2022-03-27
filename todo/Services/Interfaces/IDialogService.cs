using System;
using System.Threading.Tasks;

namespace todo.Services.Interfaces
{
    public interface IDialogServices
    {
        void DisplayAlert(string title = "Title", string message = "Message", string cancel = "Cancel");

        //Task<bool> DisplayActionSheet(string title = "Title", string message = "Message", string[] buttons = null);
    }
}
