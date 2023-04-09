using System;

namespace EasyModal;

/// <summary>
/// Base type for modal view models.
/// Views that serve as content in a modal should let their ViewModels implement this interface.
/// </summary>
public interface IModalViewModelBase
{
    /// <summary>
    /// Closes the <see cref="ModalView"/>.
    /// </summary>
    public event Action? CloseAction;
}