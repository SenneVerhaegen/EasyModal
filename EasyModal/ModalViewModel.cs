using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EasyModal;

public sealed partial class ModalViewModel : ObservableObject, IDisposable
{
    private readonly IViewModelFactory _viewModelFactory;

    [ObservableProperty] private IModalViewModelBase? _content;
    [ObservableProperty] private bool _visible;

    public ModalViewModel(IViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

    /// <summary>
    /// Opens a modal of type <see cref="TViewModel"/>.
    /// </summary>
    /// <typeparam name="TViewModel">Type of the ViewModel that corresponds to the view you want to show.</typeparam>
    public void Show<TViewModel>() where TViewModel : IModalViewModelBase
    {
        var content = _viewModelFactory.Create<TViewModel>();
        Content = content;
        Content.CloseAction += Close;
        Visible = true;
    }

    /// <summary>
    /// Closes the modal.
    /// </summary>
    public void Close()
    {
        if (Content == null) return;

        Content.CloseAction -= Close;
        Visible = false;
        Content = default;
    }

    public void Dispose()
    {
        if (Content == null) return;

        Content.CloseAction -= Close;
    }
}