namespace EasyModal;

public interface IViewModelFactory
{
    /// <summary>
    /// Creates a ViewModel of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of the ViewModel. T needs to implement <see cref="IModalViewModelBase"/></typeparam>
    /// <returns>An <see cref="IModalViewModelBase"/></returns>
    IModalViewModelBase Create<T>() where T : IModalViewModelBase;
}