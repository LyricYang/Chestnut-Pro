namespace Chestnut_Pro
{
    using Chestnut_Pro.Views;
    using Microsoft.Identity.Client;
    using Prism.DryIoc;
    using Prism.Ioc;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private static string ClientId = "73699afd-8b57-45ec-b5e5-9f655606eb93";
        private static string Tenant = "3e14b798-1d17-4d79-a0d6-bae8c66cda60";
        private static string Instance = "https://login.microsoftonline.com/";

        public static string[] scopes = new string[] { "api://73699afd-8b57-45ec-b5e5-9f655606eb93/app_scope" };

        public static IPublicClientApplication PublicClientApp { get; private set; }

        static App()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithAuthority($"{Instance}{Tenant}")
                .WithRedirectUri("http://localhost")
                .Build();
        }

        protected override Window CreateShell()
        {
            // start main window
            return Container.Resolve<MainWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AllToolsView>();
            containerRegistry.RegisterForNavigation<SettingsView>();
            containerRegistry.RegisterForNavigation<NumberBaseView>();
            containerRegistry.RegisterForNavigation<EpochView>();
            containerRegistry.RegisterForNavigation<TSVCSVView>();
            containerRegistry.RegisterForNavigation<GUIDGeneratorView>();
            containerRegistry.RegisterForNavigation<HashGeneratorView>();
            containerRegistry.RegisterForNavigation<ASCIIArtGeneratorView>();
            containerRegistry.RegisterForNavigation<ColorPaletteView>();
            containerRegistry.RegisterForNavigation<JsonFormatterView>();
            containerRegistry.RegisterForNavigation<XmlFormatterView>();
            containerRegistry.RegisterForNavigation<Base64View>();
            containerRegistry.RegisterForNavigation<JWTDecoderView>();
            containerRegistry.RegisterForNavigation<ChartGeneratorView>();
            containerRegistry.RegisterForNavigation<DashboardView>();
        }
    }
}
