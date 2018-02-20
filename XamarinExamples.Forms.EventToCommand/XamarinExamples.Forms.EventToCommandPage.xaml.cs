using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
namespace XamarinExamples.Forms.EventToCommand
{
    public partial class XamarinExamples_Forms_EventToCommandPage : ContentPage
    {
        public XamarinExamples_Forms_EventToCommandPage()
        {
            InitializeComponent();

            //Set safe areas for IOS
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            //Set Binding Context to the ViewModel
            this.BindingContext = new ViewModels.EventToCommandPageViewModel();
        }
    }
}
