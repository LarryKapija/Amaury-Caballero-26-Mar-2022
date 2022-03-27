using System;
using System.Threading.Tasks;
using Prism.Navigation;
using PropertyChanged;

namespace todo.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public BaseViewModel()
        {
        }
    }
}
