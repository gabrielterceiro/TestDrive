using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrive.Models
{
    public  class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 85000 },
                new Veiculo { Nome = "Onix 1.6", Preco = 35000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 52000 },
                new Veiculo { Nome = "C3 1.0", Preco = 22000 },
                new Veiculo { Nome = "Uno Fire", Preco = 11000 },
                new Veiculo { Nome = "Sentra 2.0", Preco = 53000 },
                new Veiculo { Nome = "Astra Sedan", Preco = 39000 },
                new Veiculo { Nome = "Vectra 2.0 Turbo", Preco = 37000 },
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000 },
                new Veiculo { Nome = "Montana Cabine dupla", Preco = 57000 },
                new Veiculo { Nome = "Outlander 2.4", Preco = 99000 },
                new Veiculo { Nome = "Brasilia Amarela", Preco = 9500 },
                new Veiculo { Nome = "Omega Hatch", Preco = 8000 }
            };
        }
    }
}
