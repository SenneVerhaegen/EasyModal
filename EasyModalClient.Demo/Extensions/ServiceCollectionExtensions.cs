using EasyModal.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EasyModalClient.Demo.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddSingleton<MainWindow>(sp => new MainWindow
            {
                DataContext = sp.GetRequiredService<MainViewModel>()
            })
            .AddSingleton<MainViewModel>()
            .AddTransient<ConfirmationModalViewModel>()
            .AddEasyModal();
    }
}