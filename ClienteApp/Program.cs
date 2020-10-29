using System;
using System.Collections.Generic;
using Entities_POJO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using System.Collections;

static class Module1
{
    static HttpClient client = new HttpClient();
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
    public static void drawMenu() 
    {
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

    }
    public static async Task Menu()
    {
        string leer = "";
        int opcion = 0;
        do
        {
            opcion = 0;
            drawMenu();
            leer = Console.ReadLine();
            if (int.TryParse(leer, out opcion))
                opcion = int.Parse(leer);
            else
                opcion = -1;
            switch (opcion)
            {
                case 1:
                    {
                        ListarTodosClientes().Wait();
                        break;
                    }

                case 2:
                    {
                        ListarCuentas().Wait();
                        break;
                    }

                case 3:
                    {
                        ListarCreditos().Wait();
                        break;
                    }
               
                case 17: 
                    {
                        IngresarDireccion().Wait();
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
    public static DateTime IngresarFecha() 
    {
        string fecha = "";
        int valor;
        string anno;
        string mes;
        string dia;
        Boolean token = false;
        do
        {
            anno = "";
            Console.WriteLine("Ingrese un año: ");
            anno = Console.ReadLine();
            if (int.TryParse(anno, out valor))
            {
                valor = int.Parse(anno);
                if (valor > 0 && valor <= DateTime.Now.Year)
                {
                    fecha = anno;
                    token = true;
                }
            }
        } while (token == false);

        token = false;
        do
        {
            mes = "";
            Console.WriteLine("Ingrese un mes: ");
            mes = Console.ReadLine();
            if (int.TryParse(mes, out valor))
            {
                valor = int.Parse(mes);
                if (valor > 0 && valor <= DateTime.Now.Month && (int.Parse(anno) == DateTime.Now.Year))
                {
                    fecha = fecha + "-" + mes;
                    token = true;
                }
                else
                {
                    if (valor > 0 && valor <= 12 && (int.Parse(anno) < DateTime.Now.Year))
                    {
                        fecha = fecha + "-" + mes;
                        token = true;
                    }
                }

            }
        } while (token == false);
        token = false;
        do
        {
            dia = "";
            Console.WriteLine("Ingrese un día: ");
            dia = Console.ReadLine();
            if (int.TryParse(dia, out valor))
            {
                valor = int.Parse(dia);
                if (valor > 0 && valor <= DateTime.Now.Day && (int.Parse(mes) == DateTime.Now.Month))
                {
                    fecha = fecha + "-" + dia;
                    token = true;
                }
                else
                {
                    if (valor > 0 && valor <= 31 && (int.Parse(mes) < DateTime.Now.Month))
                    {
                        fecha = fecha + "-" + dia;
                        token = true;
                    }
                }

            }
        } while (token == false);
        Console.WriteLine(fecha);
        DateTime resultado = new DateTime(int.Parse(anno),int.Parse(mes),int.Parse(dia));
        return resultado;
    }
    public static async Task <Direccion> IngresarDireccion()
    {
        Direccion tempDirec = new Direccion();
        string provincia = "";
        string canton = "";
        string distrito = "";
        string detalles = "";
        int result = 0;
        bool token = false;

        try
        {
            var respProv = await client.GetAsync("https://localhost:44384/api/provincia");
            var contenido = await respProv.Content.ReadAsStringAsync();
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
            Provincia[] tempList = JsonConvert.DeserializeObject<Provincia[]>(apiResponse.Data.ToString());
            
            do
            {
                Console.Clear();
                Console.WriteLine("- Codigo: --- Provincia: ----------------------------------------");
                foreach (var c in tempList)
                {
                    Console.WriteLine();
                    Console.Write("-  " + c.Cod);
                    Console.WriteLine(" - " + c.Nombre);
                }
                Console.WriteLine();
                Console.Write("Ingrese el CODIGO de una provincia: ");
                provincia = Console.ReadLine();
                if (int.TryParse(provincia, out result))
                {
                    if (result > 0 && result < 8)
                    {
                        token = true;
                        tempDirec.Provincia = tempList[result-1].Nombre;

                    }
                    else
                    {
                        Console.WriteLine("Código inválido.");
                        provincia = "";
                        Console.ReadKey();
                    }

                }
                else 
                {
                    Console.WriteLine("Código inválido.");
                    provincia = "";
                    Console.ReadKey();
                }


            } while (token == false);

            token = false;
            var respCant = await client.GetAsync("https://localhost:44384/api/canton/?canton=0&provincia=" + provincia);
            contenido = await respCant.Content.ReadAsStringAsync();
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
            Canton[] tempListC = JsonConvert.DeserializeObject<Canton[]>(apiResponse.Data.ToString());

            do
            {
                Console.Clear();
                Console.WriteLine("- Codigo: --- Canton: ------------------------------");
                foreach (var c in tempListC)
                {
                    Console.WriteLine();
                    Console.Write("-  " + c.CantonId);
                    Console.WriteLine(" -   " + c.Nombre);
                }
                Console.WriteLine();
                Console.WriteLine("Ingrese el CODIGO de un canton: ");
                canton = Console.ReadLine();
                if (int.TryParse(canton, out result))
                {
                    
                    if (result > 0 && result <= tempListC.Length)
                    {
                        token = true;
                        tempDirec.Canton = tempListC[result-1].Nombre ;
                    }
                    else
                    {
                        Console.WriteLine("Código inválido.");
                        canton = "";
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("Código inválido.");
                    canton = "";
                    Console.ReadKey();
                }


            } while (token == false);

            token = false;
            var respDist = await client.GetAsync("https://localhost:44384/api/Distrito/?canton=0" +canton+ "&provincia=" + provincia);
            contenido = await respDist.Content.ReadAsStringAsync();
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
            Distrito[] tempListD = JsonConvert.DeserializeObject<Distrito[]>(apiResponse.Data.ToString());

            do
            {
                Console.Clear();
                Console.WriteLine("- Codigo: --- Distrito: ----------------------------");
                foreach (var c in tempListD)
                {
                    Console.WriteLine();
                    Console.Write("-  " + c.DistritoId);
                    Console.WriteLine(" -   " + c.Nombre);
                }
                Console.WriteLine();
                Console.WriteLine("Ingrese el CODIGO de un distrito: ");
                distrito = Console.ReadLine();
                if (int.TryParse(distrito, out result))
                {
                    
                    if (result > 0 && result <= tempListD.Length)
                    {
                        token = true;
                        tempDirec.Distrito = tempListD[result-1].Nombre;
                    }
                    else
                    {
                        Console.WriteLine("Código inválido.");
                        distrito = "";
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("Código inválido.");
                    distrito = "";
                    Console.ReadKey();
                }


            } while (token == false);

            token = false;
            do 
            {
                Console.Write("Ingrese señas particulares: ");
                detalles = Console.ReadLine();
                Console.WriteLine(" - " + detalles + " - es correcto?(s/n): ");
                var respuesta = Console.ReadLine();
                if (respuesta.Equals("s") || respuesta.Equals("S")) 
                {
                    token = true;
                    tempDirec.Detalles = detalles;
                } else 
                {
                    Console.Clear();
                }
            } while (token == false);
            

            

        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine(tempDirec.Provincia);
        Console.WriteLine(tempDirec.Canton);
        Console.WriteLine(tempDirec.Distrito);
        Console.WriteLine(tempDirec.Detalles);
        Console.ReadKey();
        return tempDirec;
    }
    public static async Task ListarTodosClientes()
    {

        try
        {
            var respuesta = await client.GetAsync("https://localhost:44384/api/cliente");
            if (respuesta.Content != null)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
                Cliente[] tempClienteList = JsonConvert.DeserializeObject<Cliente[]>(apiResponse.Data.ToString());
                Console.Clear();
                foreach (var c in tempClienteList)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente:              " + c.Id);
                    Console.WriteLine("Nombre:               " + c.Nombre);
                    Console.WriteLine("Apellido:             " + c.Apellido);
                    Console.WriteLine("Fecha de nacimiento:  " + c.DOB);
                    Console.WriteLine("Estado civil:         " + c.ECivil);
                    Console.WriteLine("Edad:                 " + c.Edad);
                }
                Console.ReadKey();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static async Task ListarCuentas()
    {
        try
        {
            var respuesta = await client.GetAsync("https://localhost:44384/api/cuenta");
            if (respuesta.Content != null)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();

                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
                Cuenta[] tempList = JsonConvert.DeserializeObject<Cuenta[]>(apiResponse.Data.ToString());
                Console.Clear();
                foreach (var c in tempList)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente: " + c.IdCliente);
                    Console.WriteLine("Cuenta: " + c.IdCuenta);
                    Console.WriteLine("Tipo: " + c.Tipo);
                    Console.WriteLine("Moneda: " + c.Moneda);
                    Console.WriteLine("Saldo: " + c.Saldo);
                }
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
    public static async Task ListarCreditos()
    {
        Console.Clear();
        try
        {
            var respuesta = await client.GetAsync("https://localhost:44384/api/credito");
            if (respuesta.Content != null)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();

                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contenido);
                Credito[] tempList = JsonConvert.DeserializeObject<Credito[]>(apiResponse.Data.ToString());
                Console.Clear();
                foreach (var c in tempList)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Cliente: " + c.IdCliente);
                    Console.WriteLine("IdCredito: " + c.IdCredito);
                    Console.WriteLine("Monto: " + c.Monto);
                    Console.WriteLine("Tasa: " + c.Tasa);
                    Console.WriteLine("Nombre: " + c.Nombre);
                    Console.WriteLine("Cuota: " + c.Cuota);
                    Console.WriteLine("Fecha de aprobación: " + c.Fecha);
                    Console.WriteLine("Estado: " + c.Estado);
                    Console.WriteLine("Saldo: " + c.Saldo);
                }
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
            //cliente = clieMng.RetrieveById(cliente);
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
                cliente.DOB = IngresarFecha();
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
              /*  clieMng.Create(cliente);
                direcMng.Create(direccion);
                tCliente = clieMng.RetrieveById(cliente);
                tDirec = direcMng.RetrieveById(direccion);*/
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


