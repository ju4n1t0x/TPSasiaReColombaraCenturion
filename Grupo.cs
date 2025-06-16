using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{

    internal class Grupo
    {
        private int _codigo;
        private string _nombre;
        private List<Permiso> _listaPermisosGrupo;


        public Grupo()
        {
        }

        public Grupo(int codigo, string nombre, List<Permiso> listaPermisosGrupo)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._listaPermisosGrupo = listaPermisosGrupo;
        }
        public int Codigo { get { return _codigo; } set { this._codigo = value; } }
        public string Nombre { get { return _nombre; } set { this._nombre = value; } }
        public List<Permiso> listaPermisosGrupo { get { return _listaPermisosGrupo; } set { _listaPermisosGrupo = value; } }



        public override string ToString()
        {

            return $"El codigo del grupo es: {Codigo}, el nombre: {Nombre} y sus permisos son";

        }

        public static void listarGrupos(List<Grupo> listaGrupos) {
             Console.WriteLine("Estos son los grupos");
             foreach (var g in listaGrupos)

             {
                 Console.WriteLine(g.ToString());
                 foreach (var p in g.listaPermisosGrupo)
                 {
                     Console.WriteLine(p.ToString()); 
                 }
             }
         }

         public static void cargarGrupos(List<Grupo> listaGrupos, List<Permiso> listaPermisos) {

             int opcion;

             do
             {
                 Console.WriteLine("¿Desea agregar un nuevo Grupo?");
                 Console.WriteLine("1 - Sí");
                 Console.WriteLine("2 - No");

                 if (!int.TryParse(Console.ReadLine(), out opcion))
                 {
                     Console.WriteLine("Opción inválida. Intente de nuevo.");
                     continue;
                 }

                 if (opcion == 1)
                 {
                    Grupo gru = new Grupo();
                    gru.listaPermisosGrupo = new List<Permiso>();
                    gru.Codigo = listaGrupos.Count + 1;

                     Console.Write("Ingrese el nombre del Grupo: ");
                     gru.Nombre = Console.ReadLine();

                     //permisos disponibles
                     foreach (var p in listaPermisos)
                     {
                         Console.WriteLine($"El codigo del permiso {p.Nombre} es: {p.Codigo}");
                     }

                     //asignar el permiso al grupo
                     Console.WriteLine("Ingrese el codigo del permiso a asignar: ");
                     int entrada = Convert.ToInt32(Console.ReadLine());
                     for (int i = 0; i < listaPermisos.Count; i++)
                     {
                         if (listaPermisos[i].Codigo == entrada)   
                         {
                            gru.listaPermisosGrupo.Add(listaPermisos[i]);
                             
                         }

                     }
                     listaGrupos.Add(gru);

                 }
             } while (opcion == 1);
             }

        public static void modificarGrupos(List<Grupo> listaGrupos)
        {
            Console.WriteLine("Ingrese el codigo del grupo a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int codigoModificador))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            int indice = listaGrupos.FindIndex(p => p.Codigo == codigoModificador);

            if (indice == -1)
            {
                Console.WriteLine("Permiso no encontrado");
            }
            else
            {
                Console.WriteLine("Usted esta modificando el grupo: " + listaGrupos[indice].Nombre);
                Console.WriteLine("Ingrese el nuevo Codigo para el grupo: ");
                listaGrupos[indice].Codigo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo nombre del grupo");
                listaGrupos[indice].Nombre = Console.ReadLine();
                Console.WriteLine("Grupo modificado");
            }
        }

        public static void eliminarGrupos(List<Grupo> listaGrupos) {
            

            Console.WriteLine("Ingreese el codigo del Grupo a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int codigoEliminador))
            {
                Console.WriteLine("Código inválido.");
                return;
            }
            int indice = listaGrupos.FindIndex(p => p.Codigo == codigoEliminador);

            if (indice == -1)
            {
                Console.WriteLine("Grupo no encontrado");
            }
            else
            {
                if (listaGrupos[indice].listaPermisosGrupo.Count == 0)
                {
                    listaGrupos.RemoveAt(indice);
                    Console.WriteLine("El grupo se ha eliminado correctamente");
                }
                else { Console.WriteLine("El grupo no puede eliminarse porque contiene permisos asignados"); }
            }
        }

         public static void mostrarMenuGrupo(List<Grupo>listaGrupos, List<Permiso> listaPermisos)
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

                entrada = Convert.ToInt32(Console.ReadLine());
             switch (entrada)
             {
                 case 1:
                     listarGrupos(listaGrupos);
                     break;
                 case 2:
                     cargarGrupos(listaGrupos, listaPermisos);
                     break;
                 case 3:
                        modificarGrupos(listaGrupos);   
                     break;
                 case 4:
                     eliminarGrupos(listaGrupos);
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

    
