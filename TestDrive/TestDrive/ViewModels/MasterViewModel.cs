﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Media;
using TestDrive2.ViewModels;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        #region Propriedades Públicas
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged();
            }
        }

        private ImageSource fotoPerfil = "perfil.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { fotoPerfil = value; }
        }

        #endregion

        private readonly Usuario usuario;

        #region Commands
        public ICommand EditarPerfilCommand { get; private set; }

        public ICommand SalvarCommand { get; private set; }

        public ICommand EditarCommand { get; private set; }

        public ICommand TirarFotoCommand { get; private set; }
        #endregion

        #region Construtor
        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos();
        }

        private void DefinirComandos()
        {
            EditarPerfilCommand = new Command(
                () =>
                {
                    MessagingCenter.Send<Usuario>(this.usuario, "EditarPerfil");
                });
            SalvarCommand = new Command(
                () =>
                {
                    MessagingCenter.Send<Usuario>(this.usuario, "SucessoSalvarUsuario");
                    this.Editando = false;
                });
            EditarCommand = new Command(
                () => 
                {
                    this.Editando = true;
                });
            TirarFotoCommand = new Command(
                () =>
                {
                    DependencyService.Get<ICamera>().TirarFoto();
                });
        }
        #endregion
    }
}
