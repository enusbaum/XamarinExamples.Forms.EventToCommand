using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinExamples.Forms.EventToCommand.Converters
{
    /// <summary>
    ///     Converts an EventsArgs Object into the desired target type
    /// 
    ///     Code by Anthony Simmon
    ///     https://anthonysimmon.com/eventtocommand-in-xamarin-forms-apps/
    /// </summary>
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemTappedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected TappedEventArgs as value", "value");

            return eventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}