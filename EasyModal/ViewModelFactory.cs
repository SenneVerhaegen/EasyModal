using System;
using Microsoft.Extensions.DependencyInjection;

namespace EasyModal;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public IModalViewModelBase Create<T>() where T : IModalViewModelBase => (IModalViewModelBase)_serviceProvider.GetRequiredService(typeof(T));
}