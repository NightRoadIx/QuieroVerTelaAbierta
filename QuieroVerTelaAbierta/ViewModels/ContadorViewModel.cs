using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace QuieroVerTelaAbierta.ViewModels
{
    public class ContadorViewModel : ViewModelBase
    {
        // ATRIBUTOS
        private int cuenta;
        private int maximo = 30;

        // PROPIEDADES
        public int Cuenta
        {
            get { return cuenta; }
            private set
            {
                // Aquí se asegura que no se pueda poner un valor negativo
                // ni mayor que el máximo
                if (cuenta == value) return;
                cuenta = value;
                // Se notifica a la vista que ha cambiado el valor de la propiedad
                OnPropertyChanged();
                // Se notifica a la vista que ha cambiado el valor de las propiedades dependientes
                OnPropertyChanged(nameof(TextoBoton));
                OnPropertyChanged(nameof(MensajeEstado));
                // Se actualizan los comandos para que se habiliten o deshabiliten según corresponda
                ActualizarComandos();
            }
        }

        public int Maximo
        {
            get { return maximo; }
            set
            {
                // Aquí se asegura que no se pueda poner un valor menor que 1 ni mayor que el máximo
                if (maximo == value || value < 1) return;
                maximo = value;
                // Se notifica a la vista que ha cambiado el valor de la propiedad
                OnPropertyChanged();
                // Se notifica a la vista que ha cambiado el valor de las propiedades dependientes
                OnPropertyChanged(nameof(MensajeEstado));
                // Se actualizan los comandos para que se habiliten o deshabiliten según corresponda
                ActualizarComandos();
            }
        }

        // PROPIEDADES DERIVADAS
        // Esta propiedad devuelve un texto diferente según el valor de la cuenta
        // Se usa un switch expression para simplificar el código
        public string TextoBoton => Cuenta switch
        {
            0 => "Contar",
            1 => "1 clic",
            _ => $"{cuenta} clics"
        };

        public string MensajeEstado
        {
            get
            {
                if (Cuenta == 0) return "listo";
                if (Cuenta >= Maximo) return "maximo alcanzado";
                return "contando";
            }
        }

        // COMANDOS
        // Se usan comandos para que la vista pueda invocar métodos del ViewModel
        public Command IncrementarCommand { get; }
        public Command DecrementarCommand { get; }
        public Command ReiniciarCommand { get; }

        // CONSTRUCTOR
        public ContadorViewModel()
        {
            // Se inicializan los comandos con los métodos que ejecutan y las condiciones para habilitarlos o deshabilitarlos
            // Se usa la sobrecarga de Command que recibe un método y un predicado que indica si se puede ejecutar o no
            IncrementarCommand = new Command(Incrementar, () => Cuenta < Maximo);
            DecrementarCommand = new Command(Decrementar, () => Cuenta > 0);
            ReiniciarCommand = new Command(Reiniciar, () => Cuenta > 0);
        }

        private void Incrementar() => Cuenta++;
        private void Decrementar() => Cuenta--;
        private void Reiniciar()   => Cuenta = 0;

        private void ActualizarComandos()
        {
            IncrementarCommand.ChangeCanExecute();
            DecrementarCommand.ChangeCanExecute();
            ReiniciarCommand.ChangeCanExecute();
        }
    }
}
