using System;
using System.Collections.Generic;
using Entities_POJO;
using CoreAPI;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

static class Module1
{
    static HttpClient client = new HttpClient();
    public static ClienteManager clieMng = new ClienteManager();
    public static DireccionManager direcMng = new DireccionManager();
    public static CuentaManager cuentaMng = new CuentaManager();
    public static CreditoManager creditMng = new CreditoManager();
    public static Cliente tCliente = new Cliente();
    public static Cuenta tCuenta = new Cuenta();
    public static Credito tCredito = new Credito();
    public static Direccion tDirec = new Direccion();
    public static void Main()
    {
        Init();
        Menu();
    } // main
    public static void Init()
    {
        tCliente = null;
        tCuenta = null;
        tDirec = null;
        tCredito = null;
    }
    public static void Menu()
    {
        string leer = "";
        int opcion = 0;
        do
        {
            opcion = 0;
            Console.Clear();
            Console.WriteLine(" ----------- Menu --------------");
            Console.WriteLine(" 1.  Listar todos los clientes");
            Console.WriteLine(" 2.  Listar todas las cuentas");
            Console.WriteLine(" 3.  Listar todos los créditos");
            Console.WriteLine(" -------------------------------");
            Console.WriteLine(" 4.  Buscar cliente por ID");
            Console.WriteLine(" 5.  Crear nuevo cliente");
            if (tCliente != null)
            {
                Console.WriteLine();
                Console.WriteLine("     ------- Cliente " + tCliente.Id + " --------");
                Console.WriteLine("     8.  Ver perfil del cliente");
                Console.WriteLine("     9.  Modificar perfil del cliente");
                Console.WriteLine("     10. Eliminar cliente");
                Console.WriteLine(" ----------------------------------------");
                if (tCuenta == null)
                {
                    Console.WriteLine("     6.  Registrar cuenta");
                    Console.WriteLine("     ------------------------------------");
                }
                else
                {
                    Console.WriteLine("     11.  Ver cuenta");
                    Console.WriteLine("     12.  Modificar cuenta");
                    Console.WriteLine("     13.  Eliminar cuenta");
                    Console.WriteLine("     ------------------------------------");
                }

                if (tCredito == null)
                {
                    Console.WriteLine("     7.   Registrar crédito");
                    Console.WriteLine("     ------------------------------------");
                }
                else
                {
                    Console.WriteLine("     14.  Ver crédito");
                    Console.WriteLine("     15.  Modificar crédito");
                    Console.WriteLine("     16.  Eliminar crédito");
                    Console.WriteLine(" ----------------------------------------");
                }
            }

            Console.WriteLine(" -------------------------------");
            Console.WriteLine(" 100. SALIR");
            Console.WriteLine(" -------------------------------");
            Console.WriteLine();
            Console.Write(" Seleccione una opción: ");
            leer = Console.ReadLine();
            if (int.TryParse(leer, out opcion))
                opcion = int.Parse(leer);
            else
                opcion = -1;
            switch (opcion)
            {
                case 1:
                    {
                        ListarTodos();
                        break;
                    }

                case 2:
                    {
                        ListarCuentas();
                        break;
                    }

                case 3:
                    {
                        ListarCreditos();
                        break;
                    }

                case 4:
                    {
                        BuscarCliente();
                        break;
                    }

                case 5:
                    {
                        CrearCliente();
                        break;
                    }

                case 6:
                    {
                        if (tCliente != null)
                            CrearCuenta();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido, seleccione un cliente primero.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 7:
                    {
                        if (tCliente != null)
                            CrearCredito();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido, seleccione un cliente primero.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 8:
                    {
                        if (tCliente != null)
                            ListarCliente();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido, seleccione un cliente primero.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 9:
                    {
                        if (tCliente != null)
                            UpdateCliente();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido, seleccione un cliente primero.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 10:
                    {
                        if (tCliente != null)
                            EliminarCliente();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido, seleccione un cliente primero.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 11:
                    {
                        if (tCuenta != null)
                            ListarCuenta();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 12:
                    {
                        if (tCuenta != null)
                            ModificarCuenta();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 13:
                    {
                        if (tCuenta != null)
                            EliminarCuenta();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 14:
                    {
                        if (tCredito != null)
                            ListarCredito();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 15:
                    {
                        if (tCredito != null)
                            ModificarCredito();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 16:
                    {
                        if (tCredito != null)
                            EliminarCredito();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Comando no válido.");
                            Console.ReadKey();
                        }

                        break;
                    }

                case 100:
                    {
                        Console.WriteLine("  Gracias por usar el sistema.");
                        Console.ReadKey();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        Console.ReadKey();
                        break;
                    }
            }
        }
        while (opcion != 100);
    }

    public static String IngresarFecha() 
    {
        Console.WriteLine("Ingrese un año: ");


    }

    public static void ListarTodos()
    {
        try
        {
            Console.Clear();
            List<Cliente> lista = new List<Cliente>();
            Direccion direccion = new Direccion();
            lista = clieMng.RetrieveAll();

            if (lista.Count > 0)
            {
                foreach (Cliente clitemp in lista)
                {
                    direccion.IdCliente = clitemp.Id;
                    direccion = direcMng.RetrieveById(direccion);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente:              " + clitemp.Id);
                    Console.WriteLine("Nombre:               " + clitemp.Nombre);
                    Console.WriteLine("Apellido:             " + clitemp.Apellido);
                    Console.WriteLine("Fecha de nacimiento:  " + clitemp.DOB);
                    Console.WriteLine("Estado civil:         " + clitemp.ECivil);
                    Console.WriteLine("Edad:                 " + clitemp.Edad);
                    if (direccion.Provincia != null/* TODO Change to default(_) if this is not a reference type */ )
                        Console.WriteLine("Direccion: " + direccion.Provincia + ", " + direccion.Canton + " ," + direccion.Distrito);
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay clientes registrados");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    
    public static void ListarCuentas()
    {
        try
        {
            Console.Clear();
            List<Cuenta> lista = new List<Cuenta>();
            lista = cuentaMng.RetrieveAll();

            if (lista.Count > 0)
            {
                foreach (Cuenta clitemp in lista)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente: " + clitemp.IdCliente);
                    Console.WriteLine("Tipo: " + clitemp.Tipo);
                    Console.WriteLine("Moneda: " + clitemp.Moneda);
                    Console.WriteLine("Saldo: " + clitemp.Saldo);
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay cuentas registradas");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void ListarCreditos()
    {
        Console.Clear();
        try
        {
            List<Credito> lista = new List<Credito>();
            lista = creditMng.RetrieveAll();

            if (lista.Count > 0)
            {
                foreach (Credito clitemp in lista)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente: " + clitemp.IdCliente);
                    Console.WriteLine("Monto: " + clitemp.Monto);
                    Console.WriteLine("Tasa: " + clitemp.Tasa);
                    Console.WriteLine("Nombre: " + clitemp.Nombre);
                    Console.WriteLine("Cuota: " + clitemp.Cuota);
                    Console.WriteLine("Fecha de aprobación: " + clitemp.Fecha);
                    Console.WriteLine("Estado: " + clitemp.Estado);
                    Console.WriteLine("Saldo: " + clitemp.Saldo);
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay créditos registrados");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void CrearCliente()
    {
        Console.Clear();
        Console.WriteLine("   *****************************");
        Console.WriteLine("   *****  Crear usuario  *******");
        Console.WriteLine("   *****************************");
        Console.WriteLine();

        try
        {
            Console.Write("Identificacion: ");
            string id = Console.ReadLine();
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente = clieMng.RetrieveById(cliente);
            if (cliente == null)
            {
                Console.Write("Primer Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("Fecha de nacimiento: ");
                string dob = Console.ReadLine();
                int edad;
                do
                {
                    Console.Write("Edad: ");
                    if (int.TryParse(Console.ReadLine(), out edad))
                        break;
                    Console.WriteLine("No es un número entero, intente de nuevo.");
                }
                while (true);

                Console.Write("Estado civil: ");
                string estado = Console.ReadLine();
                Console.Write("Sexo: ");
                string sexo = Console.ReadLine();
                Console.WriteLine("Ingrese su dirección: ");
                Console.Write("Provincia: ");
                string provincia = Console.ReadLine();
                Console.Write("Cantón: ");
                string canton = Console.ReadLine();
                Console.Write("Distrito: ");
                string distrito = Console.ReadLine();
                Console.Write("Detalles: ");
                string detalles = Console.ReadLine();
                cliente = new Cliente();
                cliente.Id = id;
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.DOB = dob;
                cliente.Edad = edad;
                cliente.ECivil = estado;
                cliente.Edad = edad;
                cliente.Sexo = sexo;
                Direccion direccion = new Direccion();
                direccion.Provincia = provincia;
                direccion.Canton = canton;
                direccion.Distrito = distrito;
                direccion.Detalles = detalles;
                Init();
                clieMng.Create(cliente);
                direcMng.Create(direccion);
                tCliente = clieMng.RetrieveById(cliente);
                tDirec = direcMng.RetrieveById(direccion);
                Console.WriteLine("Nuevo cliente creado.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cliente ya existe.");
                Console.ReadKey();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void CrearCuenta()
    {
        Console.Clear();
        Console.WriteLine("   *****************************");
        Console.WriteLine("   *****   Crear cuenta  *******");
        Console.WriteLine("   *****************************");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Identificacion: " + tCliente.Id);
            string id = tCliente.Id;
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente = clieMng.RetrieveById(cliente);
            if (cliente != null)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.IdCliente = id;
                cuenta = cuentaMng.RetrieveById(cuenta);
                if (cuenta == null)
                {
                    Console.Write("Tipo de la cuenta, Ahorro (A) o Corriente(C): ");
                    string tipo = Console.ReadLine();
                    Console.Write("Tipo de moneda: ");
                    string moneda = Console.ReadLine();

                    double saldo;
                    do
                    {
                        Console.Write("Saldo: ");
                        if (double.TryParse(Console.ReadLine(), out saldo))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    cuenta = new Cuenta();
                    cuenta.IdCliente = id;
                    cuenta.Tipo = tipo;
                    cuenta.Moneda = moneda;
                    cuenta.Saldo = saldo;

                    cuentaMng.Create(cuenta);
                    tCuenta = cuenta;
                    Console.WriteLine("Nueva cuenta creada.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Este cliente ya tiene una cuenta creada.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Cliente con esa identificación no existe.");
                Console.ReadKey();
            }
        }


        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void CrearCredito()
    {
        Console.Clear();
        Console.WriteLine("   *****************************");
        Console.WriteLine("   *****   Crear crédito  ******");
        Console.WriteLine("   *****************************");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Identificacion: " + tCliente.Id);
            string id = tCliente.Id;
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente = clieMng.RetrieveById(cliente);
            if (cliente != null)
            {
                Credito temp = new Credito();
                temp.IdCliente = id;
                temp = creditMng.RetrieveById(temp);
                if (temp == null)
                {
                    double monto;
                    do
                    {
                        Console.Write("Monto del crédito: ");
                        if (double.TryParse(Console.ReadLine(), out monto))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    double tasa;
                    do
                    {
                        Console.Write("Tasa del crédito: ");
                        if (double.TryParse(Console.ReadLine(), out tasa))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    Console.Write("Nombre del crédito: ");
                    string nombre = Console.ReadLine();

                    double cuota;
                    do
                    {
                        Console.Write("Cuota mensual: ");
                        if (double.TryParse(Console.ReadLine(), out cuota))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    Console.Write("Estado del crédito: ");
                    string estado = Console.ReadLine();

                    double saldo;
                    do
                    {
                        Console.Write("Saldo: ");
                        if (double.TryParse(Console.ReadLine(), out saldo))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    Credito credito = new Credito();
                    credito.IdCliente = id;
                    credito.Monto = monto;
                    credito.Tasa = tasa;
                    credito.Nombre = nombre;
                    credito.Cuota = cuota;
                    credito.Fecha = DateTime.Now;
                    credito.Estado = estado;
                    credito.Saldo = saldo;
                    creditMng.Create(credito);
                    tCredito = credito;

                    Console.WriteLine("Nuevo crédito aprobado.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ese cliente ya tiene un crédito aprobado.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Cliente con esa identificación no existe.");
                Console.ReadKey();
            }
        }


        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void ListarCliente()
    {
        try
        {
            Console.Clear();
            Cliente cliente = tCliente;
            Direccion direccion = tDirec;

            if (cliente != null)
            {
                Console.WriteLine();
                Console.WriteLine("Cliente:             " + cliente.Id);
                Console.WriteLine("Nombre:              " + cliente.Nombre);
                Console.WriteLine("Apellido:            " + cliente.Apellido);
                Console.WriteLine("Fecha de nacimiento: " + cliente.DOB);
                Console.WriteLine("Estado civil:        " + cliente.ECivil);
                Console.WriteLine("Edad:                " + cliente.Edad);
                if (direccion != null)
                    Console.WriteLine("Direccion: " + direccion.Provincia + ", " + direccion.Canton + 
                        " ," + direccion.Distrito+" ," + direccion.Detalles);

                Console.WriteLine();
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay clientes registrados con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void BuscarCliente()
    {
        try
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            Direccion direccion = new Direccion();

            Console.WriteLine("Digite la identificación del cliente por buscar: ");
            string id = Console.ReadLine();
            cliente.Id = id;
            cliente = clieMng.RetrieveById(cliente);

            if (cliente != null)
            {
                direccion.IdCliente = cliente.Id;
                direccion = direcMng.RetrieveById(direccion);
                Console.WriteLine();
                Console.WriteLine("Cliente:             " + cliente.Id);
                Console.WriteLine("Nombre:              " + cliente.Nombre);
                Console.WriteLine("Apellido:            " + cliente.Apellido);
                Console.WriteLine("Fecha de nacimiento: " + cliente.DOB);
                Console.WriteLine("Estado civil:        " + cliente.ECivil);
                Console.WriteLine("Edad:                " + cliente.Edad);
                if (direccion != null)
                    Console.WriteLine("Direccion: " + direccion.Provincia + ", " + direccion.Canton + " ," + direccion.Distrito+ " ," + direccion.Detalles);
                Cuenta cuenta = new Cuenta();
                cuenta.IdCliente = id;
                Credito credito = new Credito();
                credito.IdCliente = id;

                Init();
                tCliente = cliente;
                tDirec = direccion;
                tCuenta = cuentaMng.RetrieveById(cuenta);
                tCredito = creditMng.RetrieveById(credito);

                Console.WriteLine();
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay clientes registrados con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void UpdateCliente()
    {
        Console.Clear();
        Console.WriteLine("   *******************************");
        Console.WriteLine("   *****  Modificar usuario  *****");
        Console.WriteLine("   *******************************");
        Console.WriteLine();

        try
        {
            Cliente cliente = tCliente;
            Direccion direccion = tDirec;
            Console.WriteLine("Identificacion: " + tCliente.Id);

            if (cliente != null)
            {
                Console.Write("[" + cliente.Nombre + "] Primer Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("[" + cliente.Apellido + "] Apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("[" + cliente.DOB + "] Fecha de nacimiento: ");
                string dob = Console.ReadLine();
                int edad;
                do
                {
                    Console.Write("[" + cliente.Edad + "] Edad: ");
                    if (int.TryParse(Console.ReadLine(), out edad))
                        break;
                    Console.WriteLine("No es un número entero, intente de nuevo.");
                }
                while (true);

                Console.Write("[" + cliente.ECivil + "] Estado civil: ");
                string estado = Console.ReadLine();
                Console.Write("[" + cliente.Sexo + "] Sexo: ");
                string sexo = Console.ReadLine();
                Console.WriteLine("Ingrese su dirección: ");
                Console.Write("[" + direccion.Provincia + "] Provincia: ");
                string provincia = Console.ReadLine();
                Console.Write("[" + direccion.Canton + "] Cantón: ");
                string canton = Console.ReadLine();
                Console.Write("[" + direccion.Distrito + "] Distrito: ");
                string distrito = Console.ReadLine();

                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.DOB = dob;
                cliente.Edad = edad;
                cliente.ECivil = estado;
                cliente.Edad = edad;
                cliente.Sexo = sexo;

                direccion.Provincia = provincia;
                direccion.Canton = canton;
                direccion.Distrito = distrito;

                clieMng.Update(cliente);
                direcMng.Update(direccion);
                tCliente = cliente;
                tDirec = direccion;
                Console.WriteLine("Cliente modificado con éxito.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cliente no existe.");
                Console.ReadKey();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void EliminarCliente()
    {
        try
        {
            Cliente cliente = tCliente;
            Direccion direccion = tDirec;
            Cuenta cuenta = tCuenta;
            Credito credito = tCredito;

            if (cliente != null)
            {
                string resp = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("----------------------- Cliente -------------------------------");
                    Console.WriteLine("Cliente:             " + cliente.Id);
                    Console.WriteLine("Nombre:              " + cliente.Nombre);
                    Console.WriteLine("Apellido:            " + cliente.Apellido);
                    Console.WriteLine("Fecha de nacimiento: " + cliente.DOB);
                    Console.WriteLine("Estado civil:        " + cliente.ECivil);
                    Console.WriteLine("Edad:                " + cliente.Edad);
                    if (direccion != null)
                        Console.WriteLine("Direccion:           " + direccion.Provincia + ", " + direccion.Canton + " ," + direccion.Distrito);
                    if (cuenta != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("----------------------- Cuenta -------------------------------");
                        Console.WriteLine("Cuenta: " + cuenta.IdCuenta);
                        Console.WriteLine("Tipo: " + cuenta.Tipo);
                        Console.WriteLine("Moneda: " + cuenta.Moneda);
                        Console.WriteLine("Saldo:  " + cuenta.Saldo);
                    }

                    if (credito != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("----------------------- Crédito -------------------------------");
                        Console.WriteLine("CréditoID:           " + credito.IdCredito);
                        Console.WriteLine("Monto:               " + credito.Monto);
                        Console.WriteLine("Tasa:                " + credito.Tasa);
                        Console.WriteLine("Nombre:              " + credito.Nombre);
                        Console.WriteLine("Cuota:               " + credito.Cuota);
                        Console.WriteLine("Fecha de aprobación: " + credito.Fecha);
                        Console.WriteLine("Estado:              " + credito.Estado);
                        Console.WriteLine("Saldo:               " + credito.Saldo);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Desea eliminar al cliente " + cliente.Id + " y todos sus datos asociados? (S/N) ");
                    resp = Console.ReadLine();
                }
                while (!(resp == "S") | (resp == "s") | (resp == "n") | (resp == "N"));

                if ((resp == "S") | (resp == "s"))
                {
                    clieMng.Delete(cliente);
                    direcMng.Delete(direccion);
                    if (cuenta != null)
                    {
                        cuentaMng.Delete(cuenta);
                        Console.WriteLine("Cuenta eliminada...");
                    }
                    if (credito != null)
                    {
                        creditMng.Delete(credito);
                        Console.WriteLine("Crédito eliminado...");
                    }

                    Console.WriteLine("Todos los datos fueron eliminados.");
                    Init();
                }
                else
                    Console.WriteLine("No se ha eliminado.");

                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay clientes registrados con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void ListarCuenta()
    {
        try
        {
            Console.Clear();
            Cuenta cuenta = tCuenta;

            if (cuenta != null)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------- Cuenta -------------------------------");
                Console.WriteLine("Id:     " + cuenta.IdCuenta);
                Console.WriteLine("Cliente:     " + cuenta.IdCliente);
                Console.WriteLine("Tipo: " + cuenta.Tipo);
                Console.WriteLine("Moneda: " + cuenta.Moneda);
                Console.WriteLine("Saldo:  " + cuenta.Saldo);

                Console.WriteLine();
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay cuentas registrados con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void ModificarCuenta()
    {
        Console.Clear();
        Console.WriteLine("   *******************************");
        Console.WriteLine("   *****   Modificar cuenta  *****");
        Console.WriteLine("   *******************************");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Identificacion: " + tCliente.Id);

            if (tCuenta != null)
            {
                Cuenta cuenta = new Cuenta();
                cuenta = tCuenta;

                if (cuenta != null)
                {
                    Console.Write("[" + cuenta.Tipo + "] Tipo de la cuenta: ");
                    string tipo = Console.ReadLine();

                    Console.Write("[" + cuenta.Moneda + "] Tipo de moneda: ");
                    string moneda = Console.ReadLine();

                    double saldo;
                    do
                    {
                        Console.Write("[" + cuenta.Saldo + "] Saldo: ");
                        if (double.TryParse(Console.ReadLine(), out saldo))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    cuenta.Tipo = tipo;
                    cuenta.Moneda = moneda;
                    cuenta.Saldo = saldo;

                    cuentaMng.Update(cuenta);
                    tCuenta = cuenta;
                    Console.WriteLine("Cuenta modificada.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Este cliente no tiene una cuenta creada.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Cliente con esa identificación no existe.");
                Console.ReadKey();
            }
        }


        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void EliminarCuenta()
    {
        try
        {
            Cuenta cuenta = tCuenta;

            if (cuenta != null)
            {
                string resp = "";
                do
                {
                    if (cuenta != null)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" ----------------------- Cuenta -------------------------------");
                        Console.WriteLine(" Cliente: " + cuenta.IdCliente);
                        Console.WriteLine(" Cuenta: " + cuenta.IdCuenta);
                        Console.WriteLine(" Tipo: " + cuenta.Tipo);
                        Console.WriteLine(" Moneda: " + cuenta.Moneda);
                        Console.WriteLine(" Saldo:  " + cuenta.Saldo);
                    }

                    Console.WriteLine();
                    Console.WriteLine(" Desea eliminar la cuenta " + cuenta.IdCuenta + " y todos sus datos asociados? (S/N) ");
                    resp = Console.ReadLine();
                }
                while (!(resp == "S") | (resp == "s") | (resp == "n") | (resp == "N"));

                if ((resp == "S") | (resp == "s"))
                {
                    cuentaMng.Delete(cuenta);
                    tCuenta = null;
                    Console.WriteLine(" Cuenta eliminada...");
                }
                else
                    Console.WriteLine(" No se ha eliminado.");

                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" No hay cuentas registradas con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void ListarCredito()
    {
        try
        {
            Console.Clear();
            Credito credito = tCredito;

            if (credito != null)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------- Crédito -------------------------------");
                Console.WriteLine("ID:                  " + credito.IdCredito);
                Console.WriteLine("Cliente:             " + credito.IdCliente);
                Console.WriteLine("Monto:               " + credito.Monto);
                Console.WriteLine("Tasa:                " + credito.Tasa);
                Console.WriteLine("Nombre:              " + credito.Nombre);
                Console.WriteLine("Cuota:               " + credito.Cuota);
                Console.WriteLine("Fecha de aprobación: " + credito.Fecha);
                Console.WriteLine("Estado:              " + credito.Estado);
                Console.WriteLine("Saldo:               " + credito.Saldo);

                Console.WriteLine();
                Console.Write("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay créditos registrados con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
    public static void ModificarCredito()
    {
        Console.Clear();
        Console.WriteLine("   *******************************");
        Console.WriteLine("   *****   Modificar crédito  ****");
        Console.WriteLine("   *******************************");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Identificacion: " + tCliente.Id);

            if (tCredito != null)
            {
                Credito credito = new Credito();
                credito = tCredito;

                if (credito != null)
                {
                    double monto;
                    do
                    {
                        Console.Write("[" + credito.Monto + "] Monto del crédito: ");
                        if (double.TryParse(Console.ReadLine(), out monto))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    double tasa;
                    do
                    {
                        Console.Write("[" + credito.Tasa + "] Tasa del crédito: ");
                        if (double.TryParse(Console.ReadLine(), out tasa))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    Console.Write("[" + credito.Nombre + "] Nombre del crédito: ");
                    string nombre = Console.ReadLine();

                    double cuota;
                    do
                    {
                        Console.Write("[" + credito.Cuota + "] Cuota mensual: ");
                        if (double.TryParse(Console.ReadLine(), out cuota))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    Console.Write("[" + credito.Fecha + "] Fecha de firma: ");
                    DateTime fecha = Console.ReadLine();
                    Console.Write("[" + credito.Estado + "] Estado del crédito: ");
                    string estado = Console.ReadLine();

                    double saldo;
                    do
                    {
                        Console.Write("[" + credito.Saldo + "] Saldo: ");
                        if (double.TryParse(Console.ReadLine(), out saldo))
                            break;
                        Console.WriteLine("No es un número, intente de nuevo.");
                    }
                    while (true);

                    credito.Monto = monto;
                    credito.Tasa = tasa;
                    credito.Nombre = nombre;
                    credito.Cuota = cuota;
                    credito.Fecha = fecha;
                    credito.Estado = estado;
                    credito.Saldo = saldo;
                    creditMng.Update(credito);
                    tCredito = credito;

                    Console.WriteLine("Crédito modificado.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Este cliente no tiene un crédito aprobado.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Un crédito con esa identificación no existe.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
            Console.ReadKey();
        }
    }
    public static void EliminarCredito()
    {
        try
        {
            Credito credito = tCredito;

            if (credito != null)
            {
                string resp = "";
                do
                {
                    if (credito != null)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("----------------------- Crédito -------------------------------");
                        Console.WriteLine("Monto:               " + credito.Monto);
                        Console.WriteLine("Tasa:                " + credito.Tasa);
                        Console.WriteLine("Nombre:              " + credito.Nombre);
                        Console.WriteLine("Cuota:               " + credito.Cuota);
                        Console.WriteLine("Fecha de aprobación: " + credito.Fecha);
                        Console.WriteLine("Estado:              " + credito.Estado);
                        Console.WriteLine("Saldo:               " + credito.Saldo);
                    }

                    Console.WriteLine();
                    Console.WriteLine(" Desea eliminar el crédito " + credito.Nombre + " y todos sus datos asociados? (S/N) ");
                    resp = Console.ReadLine();
                }
                while (!(resp == "S") | (resp == "s") | (resp == "n") | (resp == "N"));

                if ((resp == "S") | (resp == "s"))
                {
                    creditMng.Delete(credito);
                    tCredito = null;
                    Console.WriteLine(" Cuenta eliminada...");
                }
                else
                    Console.WriteLine(" No se ha eliminado.");

                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" No hay cuentas registradas con esa identificación");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("***************************");
        }
    }
}


