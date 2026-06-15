//Examen 1
//Brandy Piedra Mena 

string[] productos = { "Cafe", "Sandwich", "Refresco", "Galleta", "Empanada" };
int[] precios = { 800, 1500, 1000, 700, 1200 };

int[,] pedidos = new int[10, 3];
// Columna 0 = producto
// Columna 1 = cantidad
// Columna 2 = estado

int cantidadPedidos = 0;
int opcion = 0;

do
{
    Console.WriteLine();
    Console.WriteLine("===== Soda / Cafeteria Solidaria =====");
    Console.WriteLine("1. Ver catalogo");
    Console.WriteLine("2. Registrar pedido");
    Console.WriteLine("3. Ver pedidos");
    Console.WriteLine("4. Salir");
    Console.Write("Digite una opcion: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    if (opcion == 1)
    {
        MostrarCatalogo();
    }
    else if (opcion == 2)
    {
        RegistrarPedido();
    }
    else if (opcion == 3)
    {
        MostrarPedidos();
    }
    else if (opcion == 4)
    {
        Console.WriteLine("Saliendo del sistema...");
    }
    else
    {
        Console.WriteLine("Opcion incorrecta");
    }

} while (opcion != 4);


// Metodo para mostrar el catalogo
void MostrarCatalogo()
{
    Console.WriteLine();
    Console.WriteLine("Catalogo de productos");

    for (int i = 0; i < productos.Length; i++)
    {
        Console.WriteLine((i + 1) + ". " + productos[i] + " - ₡" + precios[i]);
    }
}


// Metodo para registrar un pedido
void RegistrarPedido()
{
    if (cantidadPedidos >= 10)
    {
        Console.WriteLine("Ya no se pueden registrar mas pedidos.");
    }
    else
    {
        MostrarCatalogo();

        Console.WriteLine();
        Console.Write("Digite el numero del producto: ");
        int producto = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite la cantidad: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        producto = producto - 1;

        if (producto >= 0 && producto < productos.Length && cantidad > 0)
        {
            pedidos[cantidadPedidos, 0] = producto;
            pedidos[cantidadPedidos, 1] = cantidad;
            pedidos[cantidadPedidos, 2] = 1; // 1 = activo

            Console.WriteLine("Pedido registrado correctamente.");
            Console.WriteLine("Total: ₡" + (precios[producto] * cantidad));

            cantidadPedidos++;
        }
        else
        {
            Console.WriteLine("Datos incorrectos.");
        }
    }
}


// Metodo para mostrar los pedidos registrados
void MostrarPedidos()
{
    Console.WriteLine();
    Console.WriteLine("Reporte de pedidos");

    if (cantidadPedidos == 0)
    {
        Console.WriteLine("No hay pedidos registrados.");
    }
    else
    {
        for (int i = 0; i < cantidadPedidos; i++)
        {
            int producto = pedidos[i, 0];
            int cantidad = pedidos[i, 1];
            int estado = pedidos[i, 2];
            int total = precios[producto] * cantidad;

            string nombreEstado = "";

            if (estado == 1)
            {
                nombreEstado = "Activo";
            }
            else
            {
                nombreEstado = "Finalizado";
            }

            Console.WriteLine();
            Console.WriteLine("Pedido #" + (i + 1));
            Console.WriteLine("Producto: " + productos[producto]);
            Console.WriteLine("Cantidad: " + cantidad);
            Console.WriteLine("Estado: " + nombreEstado);
            Console.WriteLine("Total: ₡" + total);
        }
    }
}