using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamarinExamples.Forms.EventToCommand.ViewModels
{
    /// <summary>
    ///     ViewModel for our Exampel Page
    /// 
    ///     Demonstrating how we can handle Events through a Command to the ViewModel
    /// </summary>
    public class EventToCommandPageViewModel : INotifyPropertyChanged
    {
        public EventToCommandPageViewModel()
        {
            //Assign method to be invoked by Command
            ItemTappedCommand = new Command((o) => ItemTapped(o));
        }

        /// <summary>
        ///     Command that will be mapped to the ItemTapped event
        /// </summary>
        /// <value>The item tapped command.</value>
        public Command ItemTappedCommand { get; }

        //Really great helper method by James Montemagno for MVVM PropertyChanged Events
        //https://blog.xamarin.com/the-xamarin-show-getting-started-with-mvvm/
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        ///    Default values for our ListView
        /// </summary>
        /// <value>The list values.</value>
        public IEnumerable<string> ListValues => new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven" };

        //Value that is selected in the list
        string _selectedValue;
        public string SelectedValue {
            get => _selectedValue;
            set
            {
                _selectedValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Handle ItemTapped Event (via Command)
        /// </summary>
        /// <param name="value">Value.</param>
        void ItemTapped(object value)
        {
            SelectedValue = value as string ?? string.Empty;;
        }
    }
}