using Microsoft.Extensions.DependencyInjection;

namespace EasyModal.Extensions;

/// <summary>
/// Extension methods for adding services to an <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the EasyModal services to the container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddEasyModal(this IServiceCollection services)
    {
        return services
            .AddSingleton<IViewModelFactory, ViewModelFactory>()
            .AddTransient<ModalViewModel>();
    }
}