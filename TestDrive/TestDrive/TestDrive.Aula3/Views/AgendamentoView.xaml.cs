using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Salvar Agendamento",
                string.Format(
                    @"
                    Veículo: {0}
                    Nome: {1}
                    Telefone: {2}
                    E-mail: {3}
                    Data: {4}
                    Hora: {5}",
                    ViewModel.Agendamento.Veiculo.Nome,
                    ViewModel.Agendamento.Nome,
                    ViewModel.Agendamento.Fone,
                    ViewModel.Agendamento.Email,
                    ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                    ViewModel.Agendamento.HoraAgendamento),
                "Ok");
        }
    }
}
