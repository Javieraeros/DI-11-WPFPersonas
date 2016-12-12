using DI_11_WPFPersonas_BL.Listados;
using DI_11_WPFPersonas_BL.Manejadoras;
using DI_11_WPFPersonas_ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DI_11_WPFPersonas_UI.ViewModel
{
    public class MainPageVM : VMBase
    {
        #region "Atributos"
        private static Persona personaSeleccionada;
        private static ObservableCollection<Persona> listado;
        
        private Visibility visibilidad;

        private DelegateCommand _eliminarCommand;

        private DelegateCommand _guardarCommand;

        private DelegateCommand _nuevoCommand;

        private DelegateCommand _deshacerCommand;

        #endregion

        #region "Constructores"
        public MainPageVM()
        {
            listado = new ListadosBL().listadoPersonasBL();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Execute, EliminarCommand_CanExecute);
            _nuevoCommand = new DelegateCommand(NuevoCommand_Execute, NuevoCommand_CanExecute);
            _guardarCommand = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
            _deshacerCommand = new DelegateCommand(DeshacerCommand_Execute, DeshacerCommand_CanExecute);
        }

        #endregion

        #region "Propiedades"
        public Persona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        public ObservableCollection<Persona> Listado
        {
            get
            {
                return listado;
            }
            set
            {
                listado = value;
                NotifyPropertyChanged("Listado");
            }
        }
        public Visibility Visibilidad
        {
            get
            {
                return visibilidad;
            }
            set
            {
                visibilidad = value;
                NotifyPropertyChanged("Visibilidad");
            }
        }

        #endregion

        #region "Métodos"


        public DelegateCommand eliminarCommand
        {
            get
            {
                return _eliminarCommand;
            }
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                return _guardarCommand;
            }
        }
        public DelegateCommand nuevoCommand
        {
            get
            {
                return _nuevoCommand;
            }
        }

        public DelegateCommand deshacerCommand
        {
            get
            {
                return _deshacerCommand;
            }
        }

        private bool EliminarCommand_CanExecute()
        {
            bool sePuedeBorrar = true;
            if (personaSeleccionada == null)
            {
                sePuedeBorrar = false;
            }
            return sePuedeBorrar;
        }

        private void EliminarCommand_Execute()
        {
            manejadoraPersonaBL miManejadora = new manejadoraPersonaBL();
            ListadosBL misListados = new ListadosBL();
            try
            {
                miManejadora.deletePersonaBL(personaSeleccionada.id);
                listado = misListados.listadoPersonasBL();
                NotifyPropertyChanged("Listado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error con la BBDD");
            }

        }

        private bool GuardarCommand_CanExecute()
        {
            return true;
        }

        private void GuardarCommand_Execute()
        {
            //Cambiamos la visibilidad de la lista
            Visibilidad = Visibility.Visible;
            manejadoraPersonaBL miManejadora = new manejadoraPersonaBL();
            ListadosBL misListados = new ListadosBL();
            try
            {
                if (personaSeleccionada.id != 0)
                {
                    miManejadora.updatePersonaBL(personaSeleccionada);
                }else
                {
                    miManejadora.insertPersonaBL(personaSeleccionada);
                }
                listado = misListados.listadoPersonasBL();
                NotifyPropertyChanged("Listado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error con la BBDD");
            }
        }

        private bool NuevoCommand_CanExecute()
        {
            return true;
        }

        private void NuevoCommand_Execute()
        {
            //Cambiamos la visibilidad de la lista
            Visibilidad = Visibility.Collapsed;
            personaSeleccionada = new Persona();
            NotifyPropertyChanged("PersonaSeleccionada");
        }

        private bool DeshacerCommand_CanExecute()
        {
            return true;
        }

        private void DeshacerCommand_Execute()
        {
            //Cambiamos la visibilidad de la lista
            Visibilidad = Visibility.Visible;
            PersonaSeleccionada =null;
        }
        #endregion

    }
}
