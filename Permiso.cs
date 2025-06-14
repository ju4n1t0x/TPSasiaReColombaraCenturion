using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{
    internal class Permiso
    {
        //declaro las variables
        private int _codigo;
        private string _nombre;
        private string _descripcion;


        //constructor sin parametros
        //inicializo la collections
        public Permiso() { }

        //constructor con parametros
        public Permiso(int codigo, string nombre, string descripcion)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._descripcion = descripcion;

        }

        //metodos getters y setters para porder acceder a las variables
        public int Codigo { get { return _codigo; } set { _codigo = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }



        //ToString
        public override string ToString()
        {
            return $"El codigo del permiso es: {Codigo}, el nombre: {Nombre}, la descripcion: {Descripcion}";
        }


        //listar todos los permisos
        public static void listarPermiso(List<Permiso> listaPermisos)
        {
            foreach (var p in listaPermisos)
            {
                Console.WriteLine(p.ToString());
            }
        }

        //crear un alta de permiso
        public static void altaPermiso(List<Permiso> listaPermisos)
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
                    Permiso nuevoPermiso = new Permiso();
                    nuevoPermiso.Codigo = listaPermisos.Count + 1;

                    Console.Write("Ingrese el nombre del permiso: ");
                    nuevoPermiso.Nombre = Console.ReadLine();

                    Console.Write("Ingrese la descripción del permiso: ");
                    nuevoPermiso.Descripcion = Console.ReadLine();

                    listaPermisos.Add(nuevoPermiso);
                }

            } while (opcion == 1);
        }

        //modificar un permiso
        public static void modificarPermiso(List<Permiso> listaPermisos)
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

        //eliminar un permiso
        public static void eliminarPermiso(List<Permiso> listaPermisos)
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

        //menu para generar accesibilidad al usuario a cada metodo de la calse
        public static void mostrarMenuPermiso(List<Permiso> listaPermisos)
        {
            int entrada;
            do
            {

                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║        BIENVENIDOS AL TP FINAL    ║");
                Console.WriteLine("╠═══════════════════════════════════╣");
                Console.WriteLine("║ Ingrese una opción:               ║");
                Console.WriteLine("║ 1 - Listar                        ║");
                Console.WriteLine("║ 2 - Alta                          ║");
                Console.WriteLine("║ 3 - Modificar                     ║");
                Console.WriteLine("║ 4 - Eliminar                      ║");
                Console.WriteLine("║ 5 - Salir                         ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out entrada))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    continue;
                }
                switch (entrada)
                {
                    case 1:
                        listarPermiso( listaPermisos);
                        break;
                    case 2:
                        altaPermiso( listaPermisos);
                        break;
                    case 3:
                        modificarPermiso( listaPermisos);
                        break;
                    case 4:
                        eliminarPermiso( listaPermisos);
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
