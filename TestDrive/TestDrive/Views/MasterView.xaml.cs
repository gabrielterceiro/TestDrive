using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                (usuario) =>
                {
                    this.CurrentPage = this.Children[1];
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}