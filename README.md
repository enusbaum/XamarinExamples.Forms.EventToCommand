# XamarinExamples.Forms.EventToCommand

This repository holds an a working example of the Xamarin Reusable EventToCommand custom Behavior which lets you bind Commands to Events for Xamarin.Form elements that do not properly support the MVVM Command Pattern.

While this example uses a [ListView](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/) [ItemTapped](https://developer.xamarin.com/api/event/Xamarin.Forms.ListView.ItemTapped/) Event as the example, it can be applied to any Event using the appropriate Converter for the EventArgs.

Cheers!
# How it works
### Xamarin.Forms

In the Xamarin.Forms project we implement the resusable EventToCommand Behavior example as described over at the Xamarin documentation ([link](https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/behaviors/reusable/event-to-command-behavior/))

```xml
<ListView ItemsSource="{Binding ListValues}">
    ...
    <ListView.Behaviors>
        <b:EventToCommandBehavior EventName="ItemTapped" Command="{Binding ItemTappedCommand}" Converter="{StaticResource SelectedItemConverter}" />
    </ListView.Behaviors>
</ListView>
```

This tells Xamarin.Forms to use our EventToCommand behavior to bind the **ItemTapped** Event to the specified command **ItemTappedCommand** which is defined in the ViewModel

```csharp
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

... more code ...

/// <summary>
///     Handle ItemTapped Event (via Command)
/// </summary>
/// <param name="value">Value.</param>
void ItemTapped(object value)
{
    SelectedValue = value as string ?? string.Empty;;
}
```

Using this method keeps our Code Behind clean from any Event mapping and allows us to follow a pure MVVM model where Events are bound to Commands and there's loose couping between our XAML and our ViewModel.

#### FYI

* This Example makes use of James Montemagno's OnPropertyChanged() implementation of [INotifyPropertyChanged](https://developer.xamarin.com/api/type/System.ComponentModel.INotifyPropertyChanged/) which is really fantasic and should be in the base class for any MVVM ViewModel you're working with. Check out his MVVM Blog Post and video from The Xamarin Show [here](https://blog.xamarin.com/the-xamarin-show-getting-started-with-mvvm/)

```csharp
public event PropertyChangedEventHandler PropertyChanged;
void OnPropertyChanged([CallerMemberName] string name = "")
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
```

* We use a little tick to keep the ListView from rendering blank items past the end of our enumerated strings. By placing the following code as the "footer" for the ListView, it'll cause it to truncate the rendering of the items at the correct point.
```xml
<!-- This actually keeps the list from rendering blank cells past the last item-->
<ListView.Footer>
    <StackLayout Orientation="Horizontal" />
</ListView.Footer>
```

**Cheers!**

![Example of ItemTapped Event through MVVM](https://d2ffutrenqvap3.cloudfront.net/items/3M2E0L3e2d3d1i0E2T0q/Screen%20Recording%202018-02-20%20at%2004.15%20PM.gif "Example of ItemTapped Event")
