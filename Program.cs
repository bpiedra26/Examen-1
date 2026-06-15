using System;

class Program
{
    static void Main()
    {
        // Vector principal del catalogo
        string[] catalogo = { "Cafe", "Sandwich", "Refresco", "Galleta", "Empanada" };

        // Vector paralelo de precios
        double[] precios = { 800, 1500, 1000, 700, 1200 };

        // Matriz de registros
        // Columna 0 = indice del producto
        // Columna 1 = cantidad
        // Columna 2 = estado
        int[,] registros = new int[50, 3];

        int contador = 0;
        int opcion = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Registrar pedido");
            Console.WriteLine("2. Mostrar registros");
            Console.WriteLine("3. Salir");
            Console.Write("Digite una opcion: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Correccion: se usa ref para que el contador se actualice
                    RegistrarEvento(registros, catalogo, precios, ref contador);
                    break;

                case 2:
                    MostrarRegistros(registros, catalogo, precios, contador);
                    break;

                case 3:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta");
                    break;
            }

        } while (opcion != 3);
    }

    static void RegistrarEvento(int[,] matriz, string[] catalogo, double[] precios, ref int contador)
    {
        // Correccion: validar que no se pase del tamaño de la matriz
        if (contador >= 50)
        {
            Console.WriteLine("Ya no se pueden registrar mas pedidos.");
        }
        else
        {
            string codigo;

            Console.WriteLine();
            Console.WriteLine("Catalogo de productos:");

            for (int i = 0; i < catalogo.Length; i++)
            {
                Console.WriteLine(catalogo[i] + " - Precio: " + precios[i]);
            }

            Console.WriteLine();
            Console.Write("Ingrese codigo del producto: ");
            codigo = Console.ReadLine();

            int pos = -1;

            // Correccion: se usa < catalogo.Length, no <= catalogo.Length
            for (int i = 0; i < catalogo.Length; i++)
            {
                if (catalogo[i] == codigo)
                {
                    pos = i;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("Codigo no encontrado.");
            }
            else
            {
                Console.Write("Cantidad: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                if (cantidad <= 0)
                {
                    Console.WriteLine("La cantidad debe ser mayor a cero.");
                }
                else
                {
                    // Se guarda el indice del producto
                    matriz[contador, 0] = pos;

                    // Se guarda la cantidad
                    matriz[contador, 1] = cantidad;

                    // Estado 1 = activo
                    matriz[contador, 2] = 1;

                    contador++;

                    Console.WriteLine("Pedido registrado correctamente.");
                }
            }
        }
    }

    static void MostrarRegistros(int[,] matriz, string[] catalogo, double[] precios, int contador)
    {
        Console.WriteLine();
        Console.WriteLine("Registros guardados:");

        if (contador == 0)
        {
            Console.WriteLine("No hay registros.");
        }
        else
        {
            for (int i = 0; i < contador; i++)
            {
                int posicionProducto = matriz[i, 0];
                int cantidad = matriz[i, 1];
                int estado = matriz[i, 2];

                double total = precios[posicionProducto] * cantidad;

                Console.WriteLine();
                Console.WriteLine("Pedido #" + (i + 1));
                Console.WriteLine("Producto: " + catalogo[posicionProducto]);
                Console.WriteLine("Cantidad: " + cantidad);
                Console.WriteLine("Estado: " + estado);
                Console.WriteLine("Total: " + total);
            }
        }
    }
}