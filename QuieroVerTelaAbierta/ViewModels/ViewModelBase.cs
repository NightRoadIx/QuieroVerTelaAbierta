using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuieroVerTelaAbierta.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método protegido para notificar cambios en las propiedades
        protected void OnPropertyChanged([CallerMemberName] string? nombre = null)
        {
            // Se invoca el evento PropertyChanged si hay suscriptores
            // esto es, si alguien está escuchando los cambios de las propiedades
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
