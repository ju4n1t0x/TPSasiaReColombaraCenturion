using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{

    internal class Grupo
    {
        private int codigo;
        private string nombre;
        private List<Permiso> listaPermisos;

        public Grupo()
        {
        }

        public Grupo(int codigo, string nombre, List<Permiso> listaPermisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.listaPermisos = listaPermisos;
        }
        public int Codigo {get { return codigo; }set { this.codigo = value; }}
        public string Nombre {get { return nombre; }set { this.nombre = value; }}
        public List<Permiso> ListaPermisos {get { return listaPermisos; } set { listaPermisos = value; }}

        public override string ToString()
        {

            return $"El codigo del grupo es: {codigo}, el nombre: {nombre}, los permisos: {listaPermisos.ToString()}";

        }

        public void listarObjetos() { } 
        
        public void cargarObjeto() { }
        public void modificarObjeto() { }
        public void eliminarObjeto() { }

        public void mostrarMenuGrupo()
        {

            Console.WriteLine("Ingrese una opcion: ");
            int entrada = Convert.ToInt32(Console.ReadLine());
            switch (entrada)
            {
                case 1:
                    Console.WriteLine("1- Listar");
                    break;
                case 2:
                    Console.WriteLine("2- Alta");
                    break;
                case 3:
                    Console.WriteLine("3- Modificacion");
                    break;
                case 4:
                    Console.WriteLine("4- Eliminar");
                    break;
                case 5:
                    Console.WriteLine("5- Salir");
                    break;

            }
        }
    }
}

    
