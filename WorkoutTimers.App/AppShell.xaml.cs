using System.Windows.Input;

namespace WorkoutTimers.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Settings", typeof(Views.Settings));

            NavigateToSettingsCommand = new Command(async () =>
            {
                //await DisplayAlert("Menue Item", "Settings selected", "Ok");
                await GoToAsync("Settings",
                        new Dictionary<string, object>
                        {
                            {"Message","I'm Batman" }
                        }
                    );
                this.FlyoutIsPresented = this.FlyoutBehavior != FlyoutBehavior.Flyout;
            });
            BindingContext = this;
        }

        public ICommand NavigateToSettingsCommand { get; private set; }
    }
}