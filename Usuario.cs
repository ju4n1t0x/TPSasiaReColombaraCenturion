using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSasiaReColombaraCenturion
{
    internal class Usuario
    {
        private int _codigo;
        private string _nombre;
        private string _password;
        private string _email;
        private long _telefono;
        private Grupo _grupo;
        private List<Permiso> _listaPermisosUsuario;

        public Usuario() { }

        public Usuario(int codigo, string nombre, string password, string email, long telefono, Grupo grupo, List<Permiso> listaPermisosUsuario)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._password = password;
            this._email = email;
            this._telefono = telefono;
            this._grupo = grupo;
            this._listaPermisosUsuario = listaPermisosUsuario;


        }
        public int Codigo { get { return _codigo; } set { this._codigo = value; } }
        public string Nombre { get { return _nombre; } set { this._nombre = value; } }
        public string Password { get { return _password; } set { this._password = value; } }
        public string Email { get { return _email; } set { this._email = value; } }
        public long Telefono { get { return _telefono; } set { this._telefono = value; } }
        public Grupo Grupo { get { return _grupo; } set { this._grupo = value; } }
        public List<Permiso> ListaPermisosUsuario { get { return _listaPermisosUsuario; } set { _listaPermisosUsuario = value; } }



        public override string ToString()
        {
            return $"El usuario es: codigo {Codigo}, nombre {Nombre}, " +
                 $"password: {Password}, email: {Email}, telefono: {Telefono}, " +
                 $"grupo: {Grupo.ToString()}";
        }


          public static void listarUsuarios(List<Usuario> listaUsuarios) {
            Console.WriteLine("Estos son los Usuarios");
            foreach (var u in listaUsuarios)

            {
                Console.WriteLine(u.ToString());
                foreach (var p in u.ListaPermisosUsuario)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

          public static void cargarUsuarios(List<Usuario> listaUsuarios, List<Permiso> listaPermisos, List<Grupo> listaGrupos) {
            int opcion;

            do
            {
                Console.WriteLine("¿Desea agregar un nuevo Usuario?");
                Console.WriteLine("1 - Sí");
                Console.WriteLine("2 - No");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    continue;
                }

                if (opcion == 1)
                {
                    Usuario usu = new Usuario();
                    usu.ListaPermisosUsuario = new List<Permiso>();
                    
                    usu.Codigo = listaUsuarios.Count + 1;

                    Console.Write("Ingrese el nombre del Usuario: ");
                    usu.Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el password del usuario: ");
                    usu.Password = Console.ReadLine();
                    Console.WriteLine("Ingrese el email del usuario: ");
                    usu.Email = Console.ReadLine();
                    Console.WriteLine("Ingrese el telefono del usuario: ");
                    usu.Telefono = Convert.ToInt64(Console.ReadLine());
                    foreach (var g in listaGrupos)
                    {
                        Console.WriteLine("Ingrese el grupo al que pertenece el usuario: ");
                        int entrada = Convert.ToInt32(Console.ReadLine());
                        if (g.Codigo == entrada)
                        {
                            if (usu.Grupo == null)
                            {
                                usu.Grupo = new Grupo();
                            }
                            usu.Grupo.Codigo = entrada;
                        }
                        else { Console.WriteLine("El grupo elegido es inexistente");}
                    }
                    int opcionDos;
                    do
                    {
                        Console.WriteLine("Desea agregar un permiso para este usuario?");
                        Console.WriteLine("1 - Si");
                        Console.WriteLine("2 - No");

                        if (!int.TryParse(Console.ReadLine(), out opcionDos))
                        {
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            continue;
                        }
                        //permisos disponibles
                        foreach (var p in listaPermisos)
                        {
                            Console.WriteLine($"El codigo del permiso {p.Nombre} es: {p.Codigo}");
                        }
                        if (opcionDos == 1)
                        {
                            //asignar el permiso al grupo
                            Console.WriteLine("Ingrese el codigo del permiso a asignar: ");
                            int entrada = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < listaPermisos.Count; i++)
                            {
                                if (listaPermisos[i].Codigo == entrada)
                                {
                                    usu.ListaPermisosUsuario.Add(listaPermisos[i]);

                                }
                                else { Console.WriteLine("El permiso es inexistente"); }

                            }
                        }
                    } while (opcionDos == 1);
                    listaUsuarios.Add(usu);

                }
            } while (opcion == 1);
        }

          public static void modificarUsuarios() { }
          public static void eliminarUsuarios() { }

          public static void mostrarMenuUsuario(List<Usuario> listaUsuarios, List<Permiso> listaPermisos, List<Grupo> listaGrupos)
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
                        listarUsuarios(listaUsuarios);
                        break;
                    case 2:
                        cargarUsuarios(listaUsuarios, listaPermisos, listaGrupos);
                        break;
                    case 3:
                        //modificarUsuarios
                        break;
                    case 4:
                        //eliminarUsuarios
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

