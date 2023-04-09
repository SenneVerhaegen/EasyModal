# EasyModal
A WPF library that simplifies the use of modals / popups.
This library allows you to create your own design for your modals and simply inject them as content into the modal.

# Getting started
Some code has been omitted for brevity. Check out the `EasyModalClient.Demo` project for a full working implementation.

Note that this library and the demo application use [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm).

Firstly, add the services to your container. The demo project shows one strategy to setup DI in your WPF project.
```c#
IServiceCollection services = new ServiceCollection();
services.AddEasyModal();
IServiceProvider = services.BuildServiceProvider();
```

Next, add the modal to your application resources. We also add a `BooleanToVisibilityConverter` which we will need later.
```xaml
<Application x:Class="EasyModalClient.Demo.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:EasyModalClient"
             xmlns:easyModal="clr-namespace:EasyModal;assembly=EasyModal"
             xmlns:demo="clr-namespace:EasyModalClient.Demo">
    <Application.Resources>
        <DataTemplate DataType="{x:Type easyModal:ModalViewModel}">
            <easyModal:ModalView />
        </DataTemplate>

        <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
    </Application.Resources>
</Application>
```

Inside the main window (or any window you want), define a grid with only a single row so that the modal can be on top of your main content.
```xaml
<Window x:Class="EasyModalClient.Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:EasyModalClient.Demo"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        d:DataContext="{d:DesignInstance Type=local:MainViewModel}">
    <Grid>
        <!-- This is your main content -->
        <Grid Grid.Row="0">
            <!-- ... -->
        </Grid>
        
        <!-- This is your modal -->
        <ContentControl
            Grid.Row="0"
            HorizontalAlignment="Center"
            VerticalAlignment="Center"
            Background="#80000000"
            Content="{Binding Modal}"
            Visibility="{Binding Modal.Visible, Converter={StaticResource BooleanToVisibilityConverter}}" />
    </Grid>
</Window>
```
And add the `ModalViewModal` as a public property to the corresponding ViewModel of your window.
```c#
public partial class MainViewModel
{
    public ModalViewModel Modal { get; }

    public MainViewModel(ModalViewModel modal) => Modal = modal;
    
    [RelayCommand]
    public void ShowConfirmation() => Modal.Show<ConfirmationModalViewModel>();
}
```
# Creating a modal
Now you can create your own UserControl and inject it as content into the modal.

Create a new view (e.g. a UserControl)
```c#
<UserControl x:Class="EasyModalClient.Demo.ConfirmationModal"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             mc:Ignorable="d"
             d:DesignHeight="300" d:DesignWidth="300"
             d:DataContext="{d:DesignInstance d:Type=local:ConfirmationModalViewModel}">
</UserControl>
```
Create a ViewModel for it that implements `IModalViewModelBase` and register it with the container.
```c#
public class ConfirmationModalViewModel : IModalViewModelBase
{
    public event Action? CloseAction;
}

...
services.AddTransient<ConfirmationModalViewModel>();
```

Add the view and view model to the application resources.
```XAML
...
<DataTemplate DataType="{x:Type demo:ConfirmationModalViewModel}">
    <demo:ConfirmationModal />
</DataTemplate>
...
```
