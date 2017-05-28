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
            
            NavigationService.NavigateAsync("MyNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MyNavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<BeaconsPage>();
            Container.RegisterTypeForNavigation<RouteInfoPage>();
            Container.RegisterTypeForNavigation<BeaconContentPage>();
            Container.RegisterTypeForNavigation<AboutPage>();

            Container.RegisterType<IRestService, RestService>();
        }
    }
}
