
using System;
using System.Security.Cryptography.X509Certificates;

namespace TPSasiaReColombaraCenturion
{
    class Program
    {


        static List<Permiso> todosLosPermisos = new List<Permiso>();
        static List<Grupo> listaGrupos  = new List<Grupo>();
        

        static void Main(string[] args)
        {   
            
            int entrada;
            do
            {

                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║        BIENVENIDOS AL TP FINAL    ║");
                Console.WriteLine("╠═══════════════════════════════════╣");
                Console.WriteLine("║ Ingrese una opción:               ║");
                Console.WriteLine("║ 1 - Permisos                      ║");
                Console.WriteLine("║ 2 - Grupo (Próximamente)          ║");
                Console.WriteLine("║ 3 - Usuario (Próximamente)        ║");
                Console.WriteLine("║ 4 - Salir                         ║");
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
                        Permiso.mostrarMenuPermiso(todosLosPermisos);
                        break;
                    case 2:
                        
                        Grupo.mostrarMenuGrupo(listaGrupos, todosLosPermisos);
                        break;
                    case 3:
                        Console.WriteLine("Usuario");
                        break;
                    case 4:
                        Console.WriteLine("Si esta seguro que desea salir presione Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;

                }
            } while (entrada != 4);
          
        
        }
    }
    }


