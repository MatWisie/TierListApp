using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TierListApp.Data;
using TierListApp.Interfaces;
using TierListApp.Navigation;
using TierListApp.Repository;
using TierListApp.Service;
using TierListApp.ViewModels;

namespace TierListApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<INavigationStore, NavigationStore>();
            services.AddTransient<ITierListRepository, TierListRepository>();
            services.AddTransient<ITierRepository, TierRepository>();
            services.AddTransient<ITierListService, TierListService>();
            services.AddTransient<ITierItemService, TierItemService>();
            services.AddTransient<ITierItemRepository, TierItemRepository>();
            services.AddTransient<IImageService, ImageService>();
            services.AddDbContext<TierDbContext>();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<AddTierListViewModel>();
            services.AddTransient<TierListViewModel>();


            return services.BuildServiceProvider();
        }
    }
}
