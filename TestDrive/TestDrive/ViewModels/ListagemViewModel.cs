using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive2.ViewModels;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        #region Constantes
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";
        #endregion

        #region Propriedades públicas
        //Cria uma Coleção Observável
        public ObservableCollection<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }
        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Construtor
        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }
        #endregion

        #region Listagem
        //Método que pega os Veículos com o http Get
        public async Task GetVeiculos()
        {
            Aguarde = true;
            try
            {
                //Instancia objeto HttpClient
                HttpClient cliente = new HttpClient();

                //Recebe resultado com Objetos em json
                var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

                //Deserializa os objetos Json
                var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

                //inclui os objetos na lista
                foreach (var veiculoJson in veiculosJson)
                {
                    this.Veiculos.Add(new Veiculo
                    {
                        Nome = veiculoJson.nome,
                        Preco = veiculoJson.preco
                    });
                }
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }

            Aguarde = false;
        } 
        #endregion
    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
