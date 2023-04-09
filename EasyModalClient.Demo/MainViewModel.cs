using System;
using CommunityToolkit.Mvvm.Input;
using EasyModal;

namespace EasyModalClient.Demo;

public partial class MainViewModel : IModalViewModelBase
{
    public ModalViewModel Modal { get; }

    public MainViewModel(ModalViewModel modal) => Modal = modal;

    [RelayCommand]
    public void ShowConfirmation() => Modal.Show<ConfirmationModalViewModel>();

    public event Action? CloseAction;
}