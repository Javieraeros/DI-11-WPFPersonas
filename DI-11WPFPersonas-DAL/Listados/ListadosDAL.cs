﻿using DI_11_WPFPersonas_ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_11WPFPersonas_DAL.Listados
{
    public class ListadosDAL
    {
        /// <summary>
        /// Devuelve un listado de personas de la base de datos, o lanza una excepción en caso de que 
        /// la conexión falle, o algo bloquee la tabla personas
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Persona> listadoPersonas()
        {
            Persona miPer;
            ObservableCollection<Persona> devolver = new ObservableCollection<Persona>();
            MyConnection conn = new MyConnection();
            SqlCommand consulta = new SqlCommand();
            SqlDataReader lector;
            try
            {
                //Abrimos la conexión
                conn.openConnection();
                //Cambiar todo por enum o constantes!!!
                consulta.CommandText = "Select IDPersona,nombre,apellidos,fechaNac," +
                    "direccion,telefono From personas";
                consulta.Connection = conn.connection;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        miPer = new Persona();
                        miPer.id = (int)lector["IDPersona"];
                        miPer.Nombre = (String)lector["nombre"];
                        miPer.Apellidos = (String)lector["apellidos"];
                        miPer.FechaNac = (DateTime)lector["fechaNac"];
                        miPer.direccion = (String)lector["direccion"];
                        miPer.telefono = (String)lector["telefono"];
                        devolver.Add(miPer);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.closeConnection();
                
            }
            return devolver;
        }
    }
}
