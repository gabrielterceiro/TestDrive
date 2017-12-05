using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive2.ViewModels;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        #region Constantes
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";
        #endregion

        #region Propriedades Públicas
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }

            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }

        }
        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }

            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }

        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }

            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }
        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }
        #endregion

        #region Construtor
        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            //Instancia Command e Verifica se campos necessários estão preenchidos
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento
                    , "Agendamento");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Nome)
                 && !string.IsNullOrEmpty(this.Fone)
                 && !string.IsNullOrEmpty(this.Email);
            });
        }
        #endregion

        #region Agendamento no Web Service
        public ICommand AgendarCommand { get; set; }
        public async void SalvarAgendamento()
        {
            //Instancia um novo objeto do tipo HttpClient
            HttpClient cliente = new HttpClient();

            //Junta as Propriedades DataAgendamento e HoraAgendamento em uma dataHoraAgendamento
            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            //Serializa o objeto utilizando o Newtonsoft
            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            //Faz um StringContent com o objeto serializado, utilizando UTF8 e o tipo application/json
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            //Faz a tentativa de agendamento utilizando o PostAsync
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);
            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
        } 
        #endregion
    }
}
