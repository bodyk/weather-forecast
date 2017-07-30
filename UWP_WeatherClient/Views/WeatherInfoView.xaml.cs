using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_WeatherClient.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_WeatherClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherInfoView : Page
    {

        int startindex;
        string s;
        public WeatherInfoView()
        {
            this.InitializeComponent();
            startindex = 0;
            s = numbertextBox.Text;
        }

        private void textBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //Suppose you have already restricted the value as 0.00
            int currentlength = numbertextBox.Text.Length;

            if ((e.Key >= VirtualKey.Number1 && e.Key <= VirtualKey.Number7 ||
                e.Key >= VirtualKey.NumberPad1 && e.Key <= VirtualKey.NumberPad7))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

            }
        }

        public string ReplaceAt(string input, int index, string number)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index - 1] = number[0];
            return new string(chars);
        }

        private void NumberUp_OnKeyDown(object sender, RoutedEventArgs routedEventArgs)
        {
            numbertextBox.Text = (int.Parse(numbertextBox.Text) + 1).ToString();
        }

        private void NumberDown_OnKeyDown(object sender, RoutedEventArgs routedEventArgs)
        {
            numbertextBox.Text = (int.Parse(numbertextBox.Text) - 1).ToString();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;
        }

        private void AutoSeggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                AutoSeggestBox.Text = args.ChosenSuggestion.ToString();
            }

        }
    }
}
