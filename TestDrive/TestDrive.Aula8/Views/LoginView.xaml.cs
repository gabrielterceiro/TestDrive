using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginViewModel ViewModel { get; set; }

        public LoginView()
        {
            InitializeComponent();
            this.ViewModel = new LoginViewModel();
            this.BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", 
                async (exc) =>
                {
                    await DisplayAlert("Login", exc.Message, "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}