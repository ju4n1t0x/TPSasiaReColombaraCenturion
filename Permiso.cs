using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{
    internal class Permiso
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private List<Permiso> listaPermisos;

        public Permiso()
        {
            listaPermisos = new List<Permiso>();
        }
        public Permiso(int codigo, string nombre, string descripcion, List<Permiso> listaPermisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;

        }

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public List<Permiso> ListaPermisos { get { return listaPermisos; } set { listaPermisos = value; } }

        public override string ToString()
        {
            return $"El codigo del permiso es: {codigo}, el nombre: {nombre}, la descripcion: {descripcion}";
        }


        public void listarPermiso()
        {
            foreach (var p in listaPermisos)
            {
                Console.Write(p.ToString());
            }
        }

        public void altaPermiso()
        {
            int opcion;

            do
            {
                Console.WriteLine("¿Desea agregar un nuevo permiso?");
                Console.WriteLine("1 - Sí");
                Console.WriteLine("2 - No");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    continue;
                }

                if (opcion == 1)
                {
                    Permiso permiso = new Permiso();
                    permiso.Codigo = listaPermisos.Count + 1;

                    Console.Write("Ingrese el nombre del permiso: ");
                    permiso.Nombre = Console.ReadLine();

                    Console.Write("Ingrese la descripción del permiso: ");
                    permiso.Descripcion = Console.ReadLine();

                    listaPermisos.Add(permiso);
                }

            } while (opcion == 1);
        }

        public void modificarPermiso()
        {
            Console.WriteLine("Ingrese el codigo del permiso a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int codigoModificador))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            int indice = listaPermisos.FindIndex(p => p.Codigo == codigoModificador);

            if (indice == -1)
            {
                Console.WriteLine("Permiso no encontrado");
            }
            else
            {
                Console.WriteLine("Usted esta modificando el permiso: " + listaPermisos[indice].Nombre);
                Console.WriteLine("Ingrese el nuevo nombre para el permiso: ");
                listaPermisos[indice].Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la nueva descripcion del permiso");
                listaPermisos[indice].Descripcion = Console.ReadLine();
                Console.WriteLine("Permiso modificado");
            }
        }

        public void eliminarPermiso()
        {
            Console.WriteLine("Ingreese el codigo del permiso a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int codigoEliminador))
            {
                Console.WriteLine("Código inválido.");
                return;
            }
            int indice = listaPermisos.FindIndex(p => p.Codigo == codigoEliminador);

            if (indice == -1)
            {
                Console.WriteLine("Permiso no encontrado");
            }
            else
            {
                listaPermisos.RemoveAt(indice);
                Console.WriteLine("El permiso se ha eliminado correctamente");
            }

        }
        public void mostrarMenuPermiso()
        {
            int entrada;
            do
            {

                Console.WriteLine("Ingrese una opcion: ");
                Console.WriteLine("1- Listar");
                Console.WriteLine("2- Alta");
                Console.WriteLine("3- Modificacion");
                Console.WriteLine("4- Eliminar");
                Console.WriteLine("5- Salir");
                if (!int.TryParse(Console.ReadLine(), out entrada))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    continue;
                }
                switch (entrada)
                {
                    case 1:
                        listarPermiso();
                        break;
                    case 2:
                        altaPermiso();
                        break;
                    case 3:
                        modificarPermiso();
                        break;
                    case 4:
                        eliminarPermiso();
                        break;
                    case 5:
                        Console.WriteLine("Si esta seguro que desea salir presione Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (entrada != 5);


        }

    }
}
