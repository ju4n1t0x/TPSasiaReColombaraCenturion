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
        private List<Permiso> listaPermisos = new List<Permiso>();
        private static List <Grupo> listaGrupos = new List<Grupo>();
        public List <Permiso> listaPermisoGrupo = new List<Permiso>();

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

        public static List<Grupo> obtenerGrupos() { 
            return new List<Grupo>(listaGrupos);
        }
         
        public override string ToString()
        {

            return $"El codigo del grupo es: {codigo}, el nombre: {nombre}";

        }

        public static void listarGrupos() {
            Console.WriteLine("Estos son los grupos");
            foreach (var g in listaGrupos)
                
            {
                Console.WriteLine(g.ToString());
                foreach (var p in g.listaPermisoGrupo)
                {
                    Console.WriteLine(p.ToString()); 
                }
            }
        }

        public static void cargarGrupos() {
            
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
                    Grupo grupo = new Grupo();
                    grupo.Codigo = listaGrupos.Count + 1;

                    Console.Write("Ingrese el nombre del Grupo: ");
                    grupo.Nombre = Console.ReadLine();

                    //permisos disponibles
                    foreach (var p in Permiso.obtenerPermisos())
                    {
                        Console.WriteLine($"El codigo del permiso {p.Nombre} es: {p.Codigo}");
                    }

                    //asignar el permiso al grupo
                    Console.WriteLine("Ingrese el codigo del permiso a asignar: ");
                    int entrada = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < Permiso.obtenerPermisos().Count; i++)
                    {
                        if (Permiso.obtenerPermisos()[i].Codigo == entrada)   
                        {
                            grupo.listaPermisoGrupo.Add(Permiso.obtenerPermisos()[i]);
                        }

                    }
                    listaGrupos.Add(grupo);

                }
            } while (opcion == 1);
            }

            

        

        public static void modificarGrupos() { }

        public static void eliminarGrupos() { }

        public static void mostrarMenuGrupo()
        {
            int entrada;
            do
            {

                Console.WriteLine("Ingrese una opcion: ");
                Console.WriteLine("1- Listar");
                Console.WriteLine("2- Alta");
                Console.WriteLine("3- Modificar");
                Console.WriteLine("4- Eliminar");
                Console.WriteLine("5- Salir");

             entrada = Convert.ToInt32(Console.ReadLine());
            switch (entrada)
            {
                case 1:
                    listarGrupos();
                    break;
                case 2:
                    cargarGrupos();
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
            } while (entrada != 5);
        }
    }
}

    
