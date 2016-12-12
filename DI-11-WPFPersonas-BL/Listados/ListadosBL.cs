using DI_11_WPFPersonas_ENT;
using DI_11WPFPersonas_DAL.Listados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_11_WPFPersonas_BL.Listados
{
    public class ListadosBL
    {
        public ObservableCollection<Persona> listadoPersonasBL()
        {
            ObservableCollection<Persona> devolver;
            ListadosDAL listDAL = new ListadosDAL();
            devolver = listDAL.listadoPersonas();
            return devolver;
        }
    }
}
