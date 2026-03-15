namespace FoodStreetGuide
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register routes for navigation
            Routing.RegisterRoute("marketpage", typeof(Pages.MapPage));
            Routing.RegisterRoute("marketdetail", typeof(Pages.MarketPage));
        }
    }
}
