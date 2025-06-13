using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{
    internal class Usuario
    {
        private int codigo;
        private string nombre;
        private string password;
        private string email;
        private int telefono;
        private Grupo grupo;
        private List<Permiso> listaPermisos;

        public Usuario()
        {
        }

        public Usuario(int codigo, string nombre, string password, string email, int telefono, Grupo grupo, List<Permiso> listaPermisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.password = password;
            this.email = email;
            this.telefono = telefono;
            this.grupo = grupo;
            this.listaPermisos = listaPermisos;
        }
        public int Codigo {get { return codigo; } set { this.codigo = value; }}
        public string Nombre {get { return nombre; } set { this.nombre = value; }}
        public string Password { get { return password; } set { this.password = value; }}
        public string Email { get { return email; } set { this.email = value; } }
        public int Telefono { get { return telefono; } set { this.telefono = value; }}
        public Grupo Grupo { get { return grupo; } set { grupo = value; }}

        public List<Permiso> ListaPermisos {
            get { return listaPermisos; }
            set { this.listaPermisos = value; }
        }

        public override string ToString()
        {
            return $"El usuario es: codigo {codigo}, nombre {nombre}, " +
                 $"password: {password}, email: {email}, telefono: {telefono}, " +
                 $"grupo: {grupo.ToString()}, permisos: {listaPermisos.ToString()}";
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
