using System;
using Xamarin.Forms;

namespace todo.Views.Controls
{
    public class BorderLessEntry : Entry
    {
        public BorderLessEntry()
        {
            HeightRequest = 40;

            if (Device.RuntimePlatform == Device.iOS)
            {
                Xamarin.Forms.PlatformConfiguration.iOSSpecific.Entry.SetCursorColor(this, Color.FromHex("#00B4D8"));
            }
        }
    }
}
