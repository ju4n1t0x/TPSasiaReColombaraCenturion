
using System;

namespace TPSasiaReColombaraCenturion
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            int entrada;
            do
            {

                Console.WriteLine("Bienvenidos al tp final");
                Console.WriteLine("Ingrese una opcion");
                Console.WriteLine("1- Permisos");
                Console.WriteLine("2- Grupo");
                Console.WriteLine("3- Usuario");
                Console.WriteLine("4- Salir");
                if (!int.TryParse(Console.ReadLine(), out entrada))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    continue;
                }

                switch (entrada)
                {

                    case 1:
                        Permiso.mostrarMenuPermiso();
                        break;
                    case 2:
                        Grupo.mostrarMenuGrupo();
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

