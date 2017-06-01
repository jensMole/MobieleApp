using Prism.Unity;
using EstimoteBeacons.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using EstimoteBeacons.Interfaces;
using EstimoteBeacons.Data;

namespace EstimoteBeacons
{
    public partial class App : PrismApplication
    {
        public static int currentSequenceNumber = -1;
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            
            // Naar de MainPage navigeren als de app op start
            NavigationService.NavigateAsync("MyNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            // Eigen NavigationPage registreren i.p.v default
            Container.RegisterTypeForNavigation<MyNavigationPage>();
            // Alle pagina's registreren zodat er genavigeerd kan worden
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<BeaconsPage>();
            Container.RegisterTypeForNavigation<RouteInfoPage>();
            Container.RegisterTypeForNavigation<BeaconContentPage>();
            Container.RegisterTypeForNavigation<AboutPage>();

            // Rest service die we willen gebruiken registreren 
            Container.RegisterType<IRestService, RestService>();
        }
    }
}
