using System.ComponentModel;
using System.Net.Http.Headers;

namespace PROYECTO2_AEVM1103526
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /** PROYECTO 2: GESTIÓN DE GRANJA
                
                Inicio de variables:
            **/





            //MENSAJE DE BIENVENIDA
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("""
                ==============GESTIÓN DE GRANJA==============
                                ANDRÉS VAQUIAX
                                  PROYECTO 2
                                   1103526
                =============================================
                """);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione Enter para continuar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();

            //CONFIGURACIÓN INICIAL

            //INGRESAR EL DINERO INICIAL
            int ValDineroEnCaja = 0;
            int ValnumEmpleados = 0;
            int ValsueldoMensual = 0;
            int ValmesesSimular = 0;
            int ValnumFilas = 0;
            int ValnumColumnas = 0;
            int dineroEnCaja = 0;
            int numEmpleados = 0;
            int sueldoMensual = 0;
            int mesesSimulados = 0;
            int numFilas = 0;
            int numColumnas = 0;



            while (ValDineroEnCaja == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese el dinero inicial:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(27, 1);
                string entradaDineroEnCaja = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionSueldo(ref entradaDineroEnCaja, ref dineroEnCaja, ref ValDineroEnCaja);
            }

            Console.Clear();

            //INGRESAR EL NÚMERO DE EMPLEADOS

            while (ValnumEmpleados == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese el número de empleados:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(32, 1);
                string entradaNumEmpleados = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionGeneral(ref entradaNumEmpleados, ref numEmpleados, ref ValnumEmpleados);

            }


            Console.Clear();


            while (ValsueldoMensual == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese el sueldo mensual por empleado:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(40, 1);
                string entradaSueldo = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionGeneral(ref entradaSueldo, ref sueldoMensual, ref ValsueldoMensual);
            }

            Console.Clear();

            while (ValmesesSimular == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese el número de meses a simular:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(38, 1);
                string entradaMeses = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionGeneral(ref entradaMeses, ref mesesSimulados, ref ValmesesSimular);
            }

            Console.Clear();

            while (ValnumFilas == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese la cantidad de filas de su parcela:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(44, 1);
                string entradaFilas = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionGeneral(ref entradaFilas, ref numFilas, ref ValnumFilas);
            }

            Console.Clear();

            while (ValnumColumnas == 0)
            {
                Console.WriteLine("============== GESTIÓN DE GRANJA ==============");
                Console.WriteLine("Ingrese la cantidad de columnas de su parcela:  ");
                Console.WriteLine("===============================================");

                Console.SetCursorPosition(47, 1);
                string entradaColumnas = Console.ReadLine();
                Console.SetCursorPosition(0, 3);

                ValidacionGeneral(ref entradaColumnas, ref numColumnas, ref ValnumColumnas);
            }

            Console.Clear();


            //MENÚ PRINCIPAL
            int costoMensualProyectado = numEmpleados * sueldoMensual;
            int utilidadProyectada = dineroEnCaja - costoMensualProyectado;
            int capitalInicial = dineroEnCaja;
            int mesesRestantes = mesesSimulados;
            int totalIngresos = 0;
            int totalManoDeObra = 0;
            int totalMateriaPrima = 0;
            int[] cantidadSemillas = new int[5];
            int[,] parcelas = new int[numFilas, numColumnas];
            int[,] mesesCrecimiento = new int[numFilas, numColumnas];
            int[] mesesPorSemilla = { 1, 2, 3, 4, 6 };
            int[] gananciaPorSemilla = { 130, 280, 450, 360, 1000 };


            int contadorSimulacion = 0;


            for (int i = 0; i < numFilas; i++)
            {
                for (int j = 0; j < numColumnas; j++)
                {
                    parcelas[i, j] = 0;
                }
            }


            while (mesesRestantes > 0 && dineroEnCaja > 0)
            {

                int valMenuPrincipal = 0;
                int opcionMenuInt = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                while (valMenuPrincipal == 0)
                {
                Console.WriteLine($"""
                    Dinero en caja: Q.{dineroEnCaja}
                    """);
                Console.WriteLine($"""Mes ({mesesSimulados - mesesRestantes + 1}/{mesesSimulados}) """);

                Console.ForegroundColor= ConsoleColor.White;
                    
                    Console.Write("""
                ==============GESTIÓN DE GRANJA==============
                1. Comprar semillas
                2. Sembrar
                3. Consultar Parcelas
                4. Avanzar mes
                5. Salir
                =============================================
                Ingrese el número de la opción deseada: 
                """);

                    string opcionMenu = Console.ReadLine();

                    ValidacionGeneral(ref opcionMenu, ref opcionMenuInt, ref valMenuPrincipal);

                }



                switch (opcionMenuInt)
                {
                    case 1:

                        ComprarSemillas(ref dineroEnCaja, numEmpleados, sueldoMensual, ref cantidadSemillas, ref totalMateriaPrima);

                        break;
                    case 2:
                        sembrar(ref parcelas, ref cantidadSemillas, ref mesesCrecimiento, mesesPorSemilla);

                        break;
                    case 3:
                        consultarParcelas(ref parcelas, ref cantidadSemillas, ref mesesCrecimiento, ref mesesPorSemilla, ref gananciaPorSemilla);

                        break;
                    case 4:
                        avanzarMes(sueldoMensual, numEmpleados, ref dineroEnCaja, ref mesesRestantes, ref totalIngresos, ref totalManoDeObra, ref totalMateriaPrima, ref parcelas, ref mesesCrecimiento, ref cantidadSemillas, mesesPorSemilla, gananciaPorSemilla);

                        break;
                    case 5:
                        salirPrograma(totalIngresos, totalManoDeObra, totalMateriaPrima, capitalInicial, dineroEnCaja, parcelas, gananciaPorSemilla);
                        contadorSimulacion++;


                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor ingresado debe ser entre 1 a 5.");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.Clear();

                        break;


                }

            }

            if (contadorSimulacion == 0)
            {
                salirPrograma(totalIngresos, totalManoDeObra, totalMateriaPrima, capitalInicial, dineroEnCaja, parcelas, gananciaPorSemilla);
            }


        }



        static void ValidacionSueldo(ref string entrada, ref int salida, ref int aumento)
        {
            if (!int.TryParse(entrada, out salida))
            {
                ValidacionNumerica();
            }
            else if (salida < 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El valor ingresado debe ser mínimo 100.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Presione Enter para continuar...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                aumento = 1;
            }
        }



        static void ValidacionGeneral(ref string entrada, ref int salida, ref int aumento)
        {
            if (!int.TryParse(entrada, out salida))
            {
                ValidacionNumerica();
            }
            else if (salida <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El valor ingresado debe ser mayor a cero.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Presione Enter para continuar...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                aumento = 1;
            }
        }


        static void ValidacionNumerica()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Solo se permiten valores numéricos.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione Enter para continuar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
        }

        static void ComprarSemillas(ref int dineroEnCaja, int numEmpleados, int sueldoMensual, ref int[] cantidadSemillas, ref int totalMateriaPrima)
        {
            int costoMensualProyectado = numEmpleados * sueldoMensual;
            int utilidadProyectada = dineroEnCaja - costoMensualProyectado;
            int contadorSemillas = 0;


            while (contadorSemillas == 0)
            {
                int opcionSemillasInt = 0;
                int valOpcionSemillas = 0;
                int ContadorSeguridad = 0;
                if (utilidadProyectada > 0)
                {
                    while (valOpcionSemillas == 0)
                    {


                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"""
                        Dinero en caja: Q.{dineroEnCaja}
                        Costo mensual proyectado: Q.{costoMensualProyectado}
                        Utilidad mensual proyectada: Q.{utilidadProyectada}
                        """);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($"""
                        ============= GESTIÓN DE GRANJA ==============
                        1. Trigo (Q.100)            | Poseídas: {cantidadSemillas[0]}
                        2. Repollo (Q.180)          | Poseídas: {cantidadSemillas[1]}
                        3. Tomate (Q.250)           | Poseídas: {cantidadSemillas[2]}
                        4. Calabaza (Q.220)         | Poseídas: {cantidadSemillas[3]}
                        5. Esparrago (Q.500)        | Poseídas: {cantidadSemillas[4]}
                        6. Volver al menú principal
                        ==============================================
                        """);
                        Console.WriteLine("Ingrese el número de la semilla que desea comprar: ");

                        string opcionSemillas = Console.ReadLine();
                        ValidacionGeneral(ref opcionSemillas, ref opcionSemillasInt, ref valOpcionSemillas);
                    }

                    switch (opcionSemillasInt)
                    {
                        case 1:
                            int valTrigo = 0;
                            int cantidadTrigoInt = 0;
                            while (valTrigo == 0)
                            {
                                Console.Clear();
                                Console.Write("""
                                ============= GESTIÓN DE GRANJA ==============
                                - Trigo (Q.100)
                                - 1 mes de crecimiento
                                - Q.130 de ganancia
                                ==============================================
                                Ingrese la cantidad de semillas de trigo a comprar: 
                                """);
                                string cantidadTrigo = Console.ReadLine();
                                ValidacionGeneral(ref cantidadTrigo, ref cantidadTrigoInt, ref valTrigo);
                            }

                            if ((dineroEnCaja - 100 * cantidadTrigoInt) < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No es posible comprar esa cantidad de semillas. Fondos Insuficientes");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if ((dineroEnCaja - 100 * cantidadTrigoInt) < costoMensualProyectado)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No alcanzará para pagarle a los empleados este mes.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                string confirmacionTrigo = "";

                                while (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                {
                                    Console.Write($"""
                                        ============= GESTIÓN DE GRANJA ==============
                                        Está seguro que desea comprar {cantidadTrigoInt} semillas de trigo por Q.{100 * cantidadTrigoInt}? 
                                        - 1. Sí
                                        - 2. No
                                        ==============================================
                                        Ingrese la opción deseada: 
                                        """);

                                    confirmacionTrigo = Console.ReadLine();

                                    if (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ingrese 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }

                                switch (confirmacionTrigo)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Compra realizada con éxito.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        dineroEnCaja = dineroEnCaja - 100 * cantidadTrigoInt;
                                        cantidadSemillas[0] += cantidadTrigoInt;
                                        Console.WriteLine("Dinero restante: Q." + dineroEnCaja);
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        totalMateriaPrima += 100 * cantidadTrigoInt;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Compra cancelada.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado debe ser 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }

                            }
                            break;

                        case 2:
                            int valRepollo = 0;
                            int cantidadRepolloInt = 0;
                            while (valRepollo == 0)
                            {
                                Console.Clear();
                                Console.Write("""
                                ============= GESTIÓN DE GRANJA ==============
                                - Repollo (Q.180)
                                - 2 meses de crecimiento
                                - Q.280 de ganancia
                                ==============================================
                                Ingrese la cantidad de semillas de repollo a comprar: 
                                """);
                                string cantidadRepollo = Console.ReadLine();
                                ValidacionGeneral(ref cantidadRepollo, ref cantidadRepolloInt, ref valRepollo);
                            }

                            if ((dineroEnCaja - 180 * cantidadRepolloInt) < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No es posible comprar esa cantidad de semillas. Fondos Insuficientes");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if ((dineroEnCaja - 180 * cantidadRepolloInt) < costoMensualProyectado)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No alcanzará para pagarle a los empleados este mes.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                string confirmacionTrigo = "";

                                while (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                {
                                    Console.Write($"""
                                        ============= GESTIÓN DE GRANJA ==============
                                        Está seguro que desea comprar {cantidadRepolloInt} semillas de repollo por Q.{180 * cantidadRepolloInt}? 
                                        - 1. Sí
                                        - 2. No
                                        ==============================================
                                        Ingrese la opción deseada: 
                                        """);

                                    confirmacionTrigo = Console.ReadLine();

                                    if (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ingrese 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }

                                switch (confirmacionTrigo)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Compra realizada con éxito.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        dineroEnCaja = dineroEnCaja - 180 * cantidadRepolloInt;
                                        cantidadSemillas[1] += cantidadRepolloInt;
                                        Console.WriteLine("Dinero restante: Q." + dineroEnCaja);
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        totalMateriaPrima += 180 * cantidadRepolloInt;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Compra cancelada.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado debe ser 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }

                            }
                            break;
                        case 3:
                            int valTomate = 0;
                            int cantidadTomateInt = 0;
                            while (valTomate == 0)
                            {
                                Console.Clear();
                                Console.Write("""
                                ============= GESTIÓN DE GRANJA ==============
                                - Tomate (Q.250)
                                - 3 meses de crecimiento
                                - Q.450 de ganancia
                                ==============================================
                                Ingrese la cantidad de semillas de tomate a comprar: 
                                """);
                                string cantidadTomate = Console.ReadLine();
                                ValidacionGeneral(ref cantidadTomate, ref cantidadTomateInt, ref valTomate);
                            }

                            if ((dineroEnCaja - 250 * cantidadTomateInt) < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No es posible comprar esa cantidad de semillas. Fondos Insuficientes");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if ((dineroEnCaja - 250 * cantidadTomateInt) < costoMensualProyectado)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No alcanzará para pagarle a los empleados este mes.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                string confirmacionTrigo = "";

                                while (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                {
                                    Console.Write($"""
                                        ============= GESTIÓN DE GRANJA ==============
                                        Está seguro que desea comprar {cantidadTomateInt} semillas de tomate por Q.{250 * cantidadTomateInt}? 
                                        - 1. Sí
                                        - 2. No
                                        ==============================================
                                        Ingrese la opción deseada: 
                                        """);

                                    confirmacionTrigo = Console.ReadLine();

                                    if (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ingrese 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }

                                switch (confirmacionTrigo)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Compra realizada con éxito.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        dineroEnCaja = dineroEnCaja - 250 * cantidadTomateInt;
                                        cantidadSemillas[2] += cantidadTomateInt;
                                        Console.WriteLine("Dinero restante: Q." + dineroEnCaja);
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        totalMateriaPrima += 250 * cantidadTomateInt;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Compra cancelada.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado debe ser 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                                break;
                            }

                        case 4:
                            int valCalabaza = 0;
                            int cantidadCalabazaInt = 0;
                            while (valCalabaza == 0)
                            {
                                Console.Clear();
                                Console.Write("""
                                    ============= GESTIÓN DE GRANJA ==============
                                    - Calabaza (Q.220)
                                    - 4 meses de crecimiento
                                    - Q.360 de ganancia
                                    ==============================================
                                    Ingrese la cantidad de semillas de calabaza a comprar: 
                                    """);
                                string cantidadCalabaza = Console.ReadLine();
                                ValidacionGeneral(ref cantidadCalabaza, ref cantidadCalabazaInt, ref valCalabaza);
                            }

                            if ((dineroEnCaja - 220 * cantidadCalabazaInt) < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No es posible comprar esa cantidad de semillas. Fondos Insuficientes");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if ((dineroEnCaja - 220 * cantidadCalabazaInt) < costoMensualProyectado)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No alcanzará para pagarle a los empleados este mes.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                string confirmacionTrigo = "";

                                while (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                {
                                    Console.Write($"""
                                        ============= GESTIÓN DE GRANJA ==============
                                        Está seguro que desea comprar {cantidadCalabazaInt} semillas de calabaza por Q.{220 * cantidadCalabazaInt}? 
                                        - 1. Sí
                                        - 2. No
                                        ==============================================
                                        Ingrese la opción deseada: 
                                        """);

                                    confirmacionTrigo = Console.ReadLine();

                                    if (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ingrese 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }

                                switch (confirmacionTrigo)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Compra realizada con éxito.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        dineroEnCaja = dineroEnCaja - 220 * cantidadCalabazaInt;
                                        cantidadSemillas[3] += cantidadCalabazaInt;
                                        Console.WriteLine("Dinero restante: Q." + dineroEnCaja);
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        totalMateriaPrima += 220 * cantidadCalabazaInt;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Compra cancelada.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado debe ser 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                                break;
                            }
                        case 5:
                            int valEsparrago = 0;
                            int cantidadEsparragoInt = 0;
                            while (valEsparrago == 0)
                            {
                                Console.Clear();
                                Console.Write("""
                                ============= GESTIÓN DE GRANJA ==============
                                - Espárrago (Q.500)
                                - 6 meses de crecimiento
                                - Q.1000 de ganancia
                                ==============================================
                                Ingrese la cantidad de semillas de espárrago a comprar: 
                                """);
                                string cantidadEsparrago = Console.ReadLine();
                                ValidacionGeneral(ref cantidadEsparrago, ref cantidadEsparragoInt, ref valEsparrago);
                            }

                            if ((dineroEnCaja - 500 * cantidadEsparragoInt) < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No es posible comprar esa cantidad de semillas. Fondos Insuficientes");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if ((dineroEnCaja - 500 * cantidadEsparragoInt) < costoMensualProyectado)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No alcanzará para pagarle a los empleados este mes.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                string confirmacionTrigo = "";

                                while (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                {
                                    Console.Write($"""
                                        ============= GESTIÓN DE GRANJA ==============
                                        Está seguro que desea comprar {cantidadEsparragoInt} semillas de espárrago por Q.{500 * cantidadEsparragoInt}? 
                                        - 1. Sí
                                        - 2. No
                                        ==============================================
                                        Ingrese la opción deseada: 
                                        """);

                                    confirmacionTrigo = Console.ReadLine();

                                    if (confirmacionTrigo != "1" && confirmacionTrigo != "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ingrese 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }

                                switch (confirmacionTrigo)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Compra realizada con éxito.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        dineroEnCaja = dineroEnCaja - 500 * cantidadEsparragoInt;
                                        cantidadSemillas[4] += cantidadEsparragoInt;
                                        Console.WriteLine("Dinero restante: Q." + dineroEnCaja);
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        totalMateriaPrima += 500 * cantidadEsparragoInt;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Compra cancelada.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado debe ser 1 o 2.");
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Presione Enter para continuar...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                                break;
                            }
                        case 6:
                            contadorSemillas = 1;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El valor ingresado debe ser entre 1 a 6.");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Presione Enter para continuar...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("============= GESTIÓN DE GRANJA ==============");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"""
                                        No es posible comprar semillas, ya que el 
                                        costo mensual proyectado ({utilidadProyectada}) 
                                        es mayor al dinero en caja.
                                        """);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===============================================");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    contadorSemillas = 1;
                }
            }


            Console.Clear();

        }



        static void sembrar(ref int[,] parcelas, ref int[] cantidadSemillas, ref int[,] mesesCrecimiento, int[] mesesPorSemilla)
        {
            int filaInt = 0;
            int valFila = 0;
            int columnaInt = 0;
            int valColumna = 0;
            int tipoSemillaInt = 0;
            int valTipoSemilla = 0;
            int contadorSiembra = 0;

            bool volverMenuPrincipal = false;
            if (cantidadSemillas[0] == 0 && cantidadSemillas[1] == 0 && cantidadSemillas[2] == 0 && cantidadSemillas[3] == 0 && cantidadSemillas[4] == 0)
            {
                Console.Clear();
                Console.WriteLine("============= GESTIÓN DE GRANJA ==============");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No tiene semillas para sembrar. Compre semillas en la opción de comprar semillas.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===============================================");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Presione Enter para continuar...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                contadorSiembra = 1;
            }
            

            while (contadorSiembra == 0)
            {

                while (valColumna < 2 && !volverMenuPrincipal)
                {
                    while (valFila < 2 && !volverMenuPrincipal)
                    {
                        while (valTipoSemilla < 2 && !volverMenuPrincipal)
                        {


                            Console.Clear();
                            Console.WriteLine($"""
                        ============= GESTIÓN DE GRANJA ==============
                        1. Trigo             | Poseídas: {cantidadSemillas[0]}
                        2. Repollo           | Poseídas: {cantidadSemillas[1]}
                        3. Tomate            | Poseídas: {cantidadSemillas[2]}
                        4. Calabaza          | Poseídas: {cantidadSemillas[3]}
                        5. Esparrago         | Poseídas: {cantidadSemillas[4]}
                        6. Volver al menú principal
                        ==============================================
                        """);
                            for (int i = 0; i < parcelas.GetLength(0); i++)
                            {
                                for (int j = 0; j < parcelas.GetLength(1); j++)
                                {
                                    if (parcelas[i, j] == 0)
                                    {
                                        Console.Write($"[ -- ] ");
                                    }
                                    else if (parcelas[i, j] == 1)
                                    {
                                        Console.Write($"[ TR ] ");
                                    }
                                    else if (parcelas[i, j] == 2)
                                    {
                                        Console.Write($"[ RP ] ");
                                    }
                                    else if (parcelas[i, j] == 3)
                                    {
                                        Console.Write($"[ TM ] ");
                                    }
                                    else if (parcelas[i, j] == 4)
                                    {
                                        Console.Write($"[ CL ] ");
                                    }
                                    else if (parcelas[i, j] == 5)
                                    {
                                        Console.Write($"[ ES ] ");
                                    }

                                }
                                Console.WriteLine();
                            }

                        
                    

                    Console.WriteLine("==============================================");
                    Console.Write("Ingrese el tipo de semilla a sembrar: ");
                    string tipoSemilla = Console.ReadLine();
                    ValidacionGeneral(ref tipoSemilla, ref tipoSemillaInt, ref valTipoSemilla);



                    if (valTipoSemilla == 1)
                    {
                        if (tipoSemillaInt == 6)
                        {
                            volverMenuPrincipal = true;
                            break;

                        }
                        else
                        {
                            if (1 > tipoSemillaInt || tipoSemillaInt > 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El valor ingresado debe ser entre 1 a 6.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                            }
                            else
                            {
                                if (cantidadSemillas[tipoSemillaInt - 1] == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("No tiene semillas de ese tipo para sembrar. Compre semillas en la opción de comprar semillas.");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Presione Enter para continuar...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                    valTipoSemilla++;
                            }
                        }
                    }
                }





                        if (volverMenuPrincipal)
                        {
                            Console.Clear();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Ingrese la fila a sembrar: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string fila = Console.ReadLine();
                        ValidacionGeneral(ref fila, ref filaInt, ref valFila);
                        if (valFila == 1)
                        {
                            if (filaInt > parcelas.GetLength(0))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La fila ingresada no existe.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            else
                            {
                                valFila++;
                            }
                        }
                    }

                    if (volverMenuPrincipal)
                    {
                        Console.Clear();
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Ingrese la columna a sembrar: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string columna = Console.ReadLine();
                    ValidacionGeneral(ref columna, ref columnaInt, ref valColumna);
                    if (valColumna == 1)
                    {
                        if (columnaInt > parcelas.GetLength(1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La columna ingresada no existe.");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Presione Enter para continuar...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            valColumna++;
                        }
                    }
                }

                if (volverMenuPrincipal)
                {
                    Console.Clear();
                    break;
                }

                if (parcelas[filaInt - 1, columnaInt - 1] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La parcela ya tiene una semilla sembrada.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    valFila = 0;
                    valColumna = 0;
                    valTipoSemilla = 0;
                    filaInt = 0;
                    columnaInt = 0;
                    tipoSemillaInt = 0;
                }
                else
                {
                    parcelas[filaInt - 1, columnaInt - 1] = tipoSemillaInt;
                    mesesCrecimiento[filaInt - 1, columnaInt - 1] = mesesPorSemilla[tipoSemillaInt - 1];
                    cantidadSemillas[tipoSemillaInt - 1]--;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Siembra realizada con éxito.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                    contadorSiembra++;
                }

            }
        }




        static void consultarParcelas(ref int[,] parcelas, ref int[] cantidadSemillas, ref int[,] mesesCrecimiento, ref int[] mesesPorSemilla, ref int[] gananciaPorSemilla)
        {
            Console.Clear();
            int filaInt = 0;
            int valFila = 0;
            int columnaInt = 0;
            int valColumna = 0;
            int tipoSemillaInt = 0;
            int valSeguridad = 0;
            int contadorSiembra = 0;

            bool volverMenuPrincipal = false;



            while (contadorSiembra == 0)
            {

                while (valColumna < 2 && !volverMenuPrincipal)
                {
                    while (valFila < 2 && !volverMenuPrincipal)
                    {
                        while (valSeguridad < 2 && !volverMenuPrincipal)
                        {
                            Console.WriteLine("============= GESTIÓN DE GRANJA ==============");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("""
                                                ¿Desea consultar una parcela? 
                                                1. Sí
                                                2. No, volver al menú principal.
                                                """);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("==============================================");
                            string seguridad = Console.ReadLine();
                            ValidacionGeneral(ref seguridad, ref tipoSemillaInt, ref valSeguridad);
                            switch (seguridad)
                            {
                                case "1":
                                    valSeguridad++;
                                    break;
                                case "2":
                                    volverMenuPrincipal = true;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ingrese 1 o 2.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                            Console.Clear();

                            if (volverMenuPrincipal)
                            {
                                Console.Clear();
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine($"""
                        ============= GESTIÓN DE GRANJA ==============
                        """);
                            for (int i = 0; i < parcelas.GetLength(0); i++)
                            {
                                for (int j = 0; j < parcelas.GetLength(1); j++)
                                {
                                    if (parcelas[i, j] == 0)
                                    {
                                        Console.Write($"[ -- ] ");
                                    }
                                    else if (parcelas[i, j] == 1)
                                    {
                                        Console.Write($"[ TR ] ");
                                    }
                                    else if (parcelas[i, j] == 2)
                                    {
                                        Console.Write($"[ RP ] ");
                                    }
                                    else if (parcelas[i, j] == 3)
                                    {
                                        Console.Write($"[ TM ] ");
                                    }
                                    else if (parcelas[i, j] == 4)
                                    {
                                        Console.Write($"[ CL ] ");
                                    }
                                    else if (parcelas[i, j] == 5)
                                    {
                                        Console.Write($"[ ES ] ");
                                    }

                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine("==============================================");

                        }

                        if (volverMenuPrincipal)
                        {
                            Console.Clear();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Ingrese la fila a consultar: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string fila = Console.ReadLine();
                        ValidacionGeneral(ref fila, ref filaInt, ref valFila);
                        if (valFila == 1)
                        {
                            if (filaInt > parcelas.GetLength(0))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La fila ingresada no existe.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Presione Enter para continuar...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();

                            }
                            else
                            {
                                valFila++;
                            }
                        }
                    }

                    if (volverMenuPrincipal)
                    {
                        Console.Clear();
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Ingrese la columna a consultar: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string columna = Console.ReadLine();
                    ValidacionGeneral(ref columna, ref columnaInt, ref valColumna);
                    if (valColumna == 1)
                    {
                        if (columnaInt > parcelas.GetLength(1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La columna ingresada no existe.");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Presione Enter para continuar...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            valColumna++;
                        }
                    }
                }

                if (volverMenuPrincipal)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("==============================================");
                if (parcelas[filaInt - 1, columnaInt - 1] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("La parcela ya tiene una semilla.");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (parcelas[filaInt - 1, columnaInt - 1] == 1)
                    {
                        Console.WriteLine("Tipo de semilla: Trigo.");
                    }
                    else if (parcelas[filaInt - 1, columnaInt - 1] == 2)
                    {
                        Console.WriteLine("Tipo de semilla: Repollo.");
                    }
                    else if (parcelas[filaInt - 1, columnaInt - 1] == 3)
                    {
                        Console.WriteLine("Tipo de semilla: Tomate.");
                    }
                    else if (parcelas[filaInt - 1, columnaInt - 1] == 4)
                    {
                        Console.WriteLine("Tipo de semilla: Calabaza.");
                    }
                    else if (parcelas[filaInt - 1, columnaInt - 1] == 5)
                    {
                        Console.WriteLine("Tipo de semilla: Espárrago.");
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Meses de crecimiento:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(mesesCrecimiento[filaInt - 1, columnaInt - 1] + " meses restantes de " + mesesPorSemilla[parcelas[filaInt - 1, columnaInt - 1] - 1] + " meses totales.");
                    Console.WriteLine("Ingresos esperados: Q." + gananciaPorSemilla[parcelas[filaInt - 1, columnaInt - 1] - 1]);
                    Console.WriteLine("==============================================");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    valFila = 0;
                    valColumna = 0;
                    valSeguridad = 0;
                    filaInt = 0;
                    columnaInt = 0;
                    tipoSemillaInt = 0;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La parcela está libre.");
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.WriteLine("Ingresos esperados: Q.0");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    valFila = 0;
                    valColumna = 0;
                    valSeguridad = 0;
                    filaInt = 0;
                    columnaInt = 0;
                    tipoSemillaInt = 0;
                }



            }
        }

            static void avanzarMes(int sueldoMensual, int numEmpleados, ref int dineroEnCaja, ref int mesesRestantes, ref int totalIngresos, ref int totalManoDeObra, ref int totalMateriaPrima, ref int[,] parcelas, ref int[,] mesesCrecimiento, ref int [] cantidadSemillas, int[] mesesPorSemilla, int[] gananciaPorSemilla)
        {
            Console.Clear();
            int salariosMes = numEmpleados * sueldoMensual;
            dineroEnCaja = dineroEnCaja - salariosMes;
            totalManoDeObra += salariosMes;
            mesesRestantes -= 1;
            Console.WriteLine("============= GESTIÓN DE GRANJA ==============");
            for (int i = 0; i < parcelas.GetLength(0); i++)
            {
                Console.WriteLine($"Fila: {i + 1}");
                for (int j = 0; j < parcelas.GetLength(1); j++)
                {
                    
                    if (parcelas[i, j] != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"""
                            Parcela: fila {i + 1} y columna {j + 1}.
                            Meses restantes para cosechar: {mesesCrecimiento[i, j]-1}.
                            """);
                        Console.ForegroundColor = ConsoleColor.White;
                        mesesCrecimiento[i, j] -= 1;
                        if (mesesCrecimiento[i, j] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"""
                                La parcela en la fila {i + 1} y columna {j + 1} ha sido cosechada. 
                                Se obtuvo una ganancia de Q.{gananciaPorSemilla[parcelas[i, j] - 1]}.
                                """);
                            Console.ForegroundColor= ConsoleColor.White;
                            dineroEnCaja += gananciaPorSemilla[parcelas[i, j] - 1];
                            totalIngresos += gananciaPorSemilla[parcelas[i, j] - 1];
                            parcelas[i, j] = 0;
                        }
                    } 
                }
            }

            Console.WriteLine("==============================================");
            Console.WriteLine($"""
                                Salarios pagados: Q.{salariosMes}
                                Ingresos acumulados: Q.{totalIngresos}
                                Dinero restante en caja: Q.{dineroEnCaja}
                                """);
            Console.WriteLine("==============================================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione Enter para continuar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
        }

            static void salirPrograma(int totalIngresos, int totalManoDeObra, int totalMateriaPrima, int capitalInicial, int dineroEnCaja, int[,] parcelas, int[] gananciaPorSemilla)
            {

                int totalFalta = 0;
                for (int i = 0; i < parcelas.GetLength(0); i++)
                {
                    for (int j = 0; j < parcelas.GetLength(1); j++)
                    {
                        if (parcelas[i, j] != 0)
                        {
                            totalFalta += gananciaPorSemilla[parcelas[i, j] - 1];
                        }
                    }
            }

                int utilidades = capitalInicial + totalIngresos - totalManoDeObra - totalMateriaPrima;

            Console.WriteLine("============= GESTIÓN DE GRANJA ==============");
            Console.WriteLine($"""
                                Resumen final:
                                Ingresos totales: Q.{totalIngresos}
                                Gastos en mano de obra: Q.{totalManoDeObra}
                                Gastos en materia prima: Q.{totalMateriaPrima}
                                Capital inicial: Q.{capitalInicial}
                                Dinero restante en caja: Q.{dineroEnCaja}
                                Inventario en proceso: Q.{totalFalta}
                                Utilidades totales: Q.{utilidades}
                                """);
            Console.WriteLine("==============================================");

            Console.WriteLine("Gracias por usar el programa de gestión de granja. ¡Hasta luego!");
                Environment.Exit(0);
            }
        }
    }



