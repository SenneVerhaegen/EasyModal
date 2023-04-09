using CommunityToolkit.Mvvm.Input;
using EasyModal;

namespace EasyModalClient.Demo;

public partial class MainViewModel
{
    public ModalViewModel Modal { get; }

    public MainViewModel(ModalViewModel modal) => Modal = modal;

    [RelayCommand]
    public void ShowConfirmation() => Modal.Show<ConfirmationModalViewModel>();
}