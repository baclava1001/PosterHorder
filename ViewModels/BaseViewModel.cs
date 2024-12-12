using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        public bool IsNotBusy => !IsBusy;
    }
}
