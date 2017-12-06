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
    public partial class MasterView : ContentPage
    {
        public MasterViewModel ViewModel { get; set; }

        public MasterView(Usuario usuario)
        {
            InitializeComponent();

            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = ViewModel;
        }
    }
}