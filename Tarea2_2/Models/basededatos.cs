using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Tarea2_2.Models;
using System.Threading.Tasks;

namespace Tarea2_2.Models
{
    public class basededatos
    {
        readonly SQLiteAsyncConnection db;
        public basededatos()
        {
        }
        // contructor
        public basededatos(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // Crear tablas en la BD
            db.CreateTableAsync<constructor>();

        }

       //EnLista la tabla empleados
        public Task<List<constructor>> listaempleados()
        {

            return db.Table<constructor>().ToListAsync();
        }

        // buscar empleados
        public Task<constructor> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<constructor>().Where(i => i.codigo == pcodigo).FirstOrDefaultAsync();
        }

        // Para guardar o actualizar los datos de un empleado

        public Task<Int32> EmpleadoGuardar(constructor emple)
        {
            if (emple.codigo != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        //Eliminar

        public Task<Int32> EmpleadoBorrar(constructor emple)
        {
            return db.DeleteAsync(emple);
        }
    }
}
