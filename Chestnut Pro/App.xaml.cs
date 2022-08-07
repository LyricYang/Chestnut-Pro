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
        /// <summary>
        /// AAD Client
        /// </summary>
        public static IPublicClientApplication PublicClientApp { get; private set; }

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
            containerRegistry.RegisterForNavigation<JsonYamlConverterView>();
        }
    }
}
