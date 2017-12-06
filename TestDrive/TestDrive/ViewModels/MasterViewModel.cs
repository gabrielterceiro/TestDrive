using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel
    {
        #region Propriedades Públicas
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }
        #endregion

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }

        #region Construtor
        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(
                () =>
                {
                    MessagingCenter.Send<Usuario>(this.usuario, "EditarPerfil");
                });
        }
        #endregion
    }
}
