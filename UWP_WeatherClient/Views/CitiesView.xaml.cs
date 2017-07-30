using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_WeatherClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CitiesView : Page
    {
        private Button editButton;

        public CitiesView()
        {
            this.InitializeComponent();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var curButton = (Button) sender;
            if (curButton.Content != null)
            {
                curButton.Visibility = (curButton.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;

                var parent = VisualTreeHelper.GetParent(curButton.Parent);

                var btnSave = (Button)this.FindName("btnSaveCity");

                if (btnSave != null)
                {
                    btnSave.Visibility = (btnSave.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
                }

                var cityNameEdit = parent.FindDescendant<TextBox>();
                if (cityNameEdit != null)
                    cityNameEdit.IsReadOnly = !cityNameEdit.IsReadOnly;
            }
        }
    }
}
