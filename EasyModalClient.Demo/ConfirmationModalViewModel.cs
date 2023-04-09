using System;
using CommunityToolkit.Mvvm.Input;
using EasyModal;

namespace EasyModalClient.Demo;

public partial class ConfirmationModalViewModel : IModalViewModelBase
{
    [RelayCommand]
    public void Yes() => CloseAction?.Invoke();

    [RelayCommand]
    public void No() => CloseAction?.Invoke();

    public event Action? CloseAction;
}