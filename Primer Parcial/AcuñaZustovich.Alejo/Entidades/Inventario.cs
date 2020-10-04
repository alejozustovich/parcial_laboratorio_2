using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Inventario
    {
        #region ATRIBUTOS
        private static List<Producto> listadoProductos = new List<Producto>();
        private static List<Cliente> listadoClientes = new List<Cliente>();
        private static List<Empleado> listadoEmpleados = new List<Empleado>();
        private static List<Compra> listadoCompras = new List<Compra>();
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Permisos de sólo lectura para productos.
        /// </summary>
        public static List<Producto> ListadoProductos
        {
            get { return listadoProductos; }
        }

        /// <summary>
        /// Permisos de sólo lectura para clientes.
        /// </summary>
        public static List<Cliente> ListadoClientes
        {
            get { return listadoClientes; }
        }

        /// <summary>
        /// Permisos de sólo lectura para empleados.
        /// </summary>
        public static List<Empleado> ListadoEmpleados
        {
            get { return listadoEmpleados; }
        }

        /// <summary>
        /// Permisos de sólo lectura para compras.
        /// </summary>
        public static List<Compra> ListadoCompras
        {
            get { return listadoCompras; }
        }
        #endregion

        #region HARDCODEOS
        /// <summary>
        /// Carga la información inicial del negocio.
        /// </summary>
        public static void CargaInformacion()
        {
            HardcodeoProductos();
            HardcodeoClientes();
            HardcodeoEmpleados();
            HardcodeoCompras();
        }

        /// <summary>
        /// Carga productos.
        /// </summary>
        public static void HardcodeoProductos()
        {
            ListadoProductos.Add(new Producto(100, "Rosquilla con chispitas", 25, 67, 3));
            ListadoProductos.Add(new Producto(101, "Cerveza Duff", 80, 150, 5));
            ListadoProductos.Add(new Producto(102, "Gazpacho", 75, 5, 1));
            ListadoProductos.Add(new Producto(103, "ToMacco 1 kg", 40, 200, 2));
            ListadoProductos.Add(new Producto(104, "Pastel de Plátano", 110, 4, 1));
            ListadoProductos.Add(new Producto(105, "Llamarada Moe Pack x6", 350, 80, 4));
            ListadoProductos.Add(new Producto(106, "Hamburguesas Krusty x4", 150, 12, 3));
            ListadoProductos.Add(new Producto(107, "1 Lt. de Helado Chocolate", 300, 5, 1));
            ListadoProductos.Add(new Producto(108, "Huevos x12", 250, 10, 2));
            ListadoProductos.Add(new Producto(109, "Buzz Cola", 90, 15, 1));
        }

        /// <summary>
        /// Carga clientes.
        /// </summary>
        public static void HardcodeoClientes()
        {
            ListadoClientes.Add(new Cliente(2000, "Homero", "Simpson", 1));
            ListadoClientes.Add(new Cliente(2001, "Marge", "Simpson", 2));
            ListadoClientes.Add(new Cliente(2002, "Lenny", "Lenard", 3));
            ListadoClientes.Add(new Cliente(2003, "Juan", "Topo", 4));
        }

        /// <summary>
        /// Carga empleados.
        /// </summary>
        public static void HardcodeoEmpleados()
        {
            ListadoEmpleados.Add(new Empleado(1000, "Poonam", "Nahasapeemapetilon", 11));
            ListadoEmpleados.Add(new Empleado(1001, "Sashi", "Nahasapeemapetilon", 12));
            ListadoEmpleados.Add(new Empleado(1002, "Pria", "Nahasapeemapetilon", 13));
            ListadoEmpleados.Add(new Empleado(1003, "Uma", "Nahasapeemapetilon", 14));
            ListadoEmpleados.Add(new Empleado(1004, "Anoop", "Nahasapeemapetilon", 15));
            ListadoEmpleados.Add(new Empleado(1005, "Sandeep", "Nahasapeemapetilon", 16));
            ListadoEmpleados.Add(new Empleado(1006, "Nabendu", "Nahasapeemapetilon", 17));
            ListadoEmpleados.Add(new Empleado(1007, "Gheet", "Nahasapeemapetilon", 18));
        }

        /// <summary>
        /// Carga compras.
        /// </summary>
        public static void HardcodeoCompras()
        {
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 0, 1), 105, ListadoClientes[0], ListadoEmpleados[0]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 4, 5), 310, ListadoClientes[1], ListadoEmpleados[1]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 2, 3), 115, ListadoClientes[2], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 9, 6), 390, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 7, 1), 380, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 0, 1), 630, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 7, 8), 550, ListadoClientes[3], ListadoEmpleados[7]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 3, 4), 150, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 3, 4), 150, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 0, 1), 105, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 2, 3), 115, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 4, 5), 460, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 6, 7), 450, ListadoClientes[0], ListadoEmpleados[2]));
            ListadoCompras.Add(new Compra(CrearSublista(ListadoProductos, 8, 9), 340, ListadoClientes[0], ListadoEmpleados[2]));
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Retorno el último ticket+1 para asignarle a la nueva compra
        /// </summary>
        /// <returns>El nro de ticket.</returns>
        public static int AsignarNroTicket()
        {
            int ultimoTicket = 500;

            for (int i = 0; i < ListadoCompras.Count; i++)
            {
                if(ListadoCompras[i].NroTicket > ultimoTicket)
                    ultimoTicket = ListadoCompras[i].NroTicket;
            }

            return ultimoTicket+1;
        }

        /// <summary>
        /// Agrega un nuevo producto al listado.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>True si se pudo agregar, caso contrario False.</returns>
        public static bool AgregarProducto(Producto producto)
        {
            return ListadoProductos + producto;
        }

        /// <summary>
        /// Elimina un producto del listado.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>True si lo pudo eliminar, caso contrario False.</returns>
        public static bool QuitarProducto(Producto producto)
        {
            return ListadoProductos - producto;
        }

        /// <summary>
        /// Agrega un nuevo cliente al listado.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>True si lo pudo agregar, caso contrario False.</returns>
        public static bool AgregarCliente(Cliente cliente)
        {
            return ListadoClientes + cliente;
        }

        /// <summary>
        /// Crea una sublista con los productos que tienen menos de 10 unidades.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <returns>La sublista de productos.</returns>
        public static List<Producto> ProductosConMenos10Unidades(List<Producto> listadoAux)
        {
            List<Producto> listadoMenos10Unidades = new List<Producto>();

            for (int i = 0; i < (listadoAux.Count); i++)
            {
                if (listadoAux[i].Stock < 10)
                    listadoMenos10Unidades.Add(listadoAux[i]);
            }

            return listadoMenos10Unidades;
        }

        /// <summary>
        /// Busca el indice de un producto en el listado por su ID.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <param name="id"></param>
        /// <returns>El ID del producto, caso contrario -1.</returns>
        public static int BuscarIndicePorID(List<Producto> listadoAux, int id)
        {
            for (int i = 0; i < (listadoAux.Count); i++)
            {
                if(listadoAux[i].Id == id)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Crea una sublista de los empleados con mas de 10 ventas.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <returns>La sublista de empleados.</returns>
        public static List<Empleado> EmpleadosMas10Ventas(List<Empleado> listadoAux)
        {
            List<Empleado> listadoMas10Ventas = new List<Empleado>();

            for (int i = 0; i < (listadoAux.Count); i++)
            {
                if (listadoAux[i].Ventas > 10)
                    listadoMas10Ventas.Add(listadoAux[i]);
            }

            return listadoMas10Ventas;
        }

        /// <summary>
        /// Crea una sublista de los clientes con mas de 10 compras.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <returns>La sublista de clientes.</returns>
        public static List<Cliente> ClientesMas10Compras(List<Cliente> listadoAux)
        {
            List<Cliente> listadoMas10Compras = new List<Cliente>();

            for (int i = 0; i < (listadoAux.Count); i++)
            {
                if (listadoAux[i].Compras > 10)
                    listadoMas10Compras.Add(listadoAux[i]);
            }

            return listadoMas10Compras;
        }

        /// <summary>
        /// Actualiza las unidades en stock y vendidas en cada compra realizada.
        /// </summary>
        /// <param name="productoAux"></param>
        /// <param name="unidades"></param>
        public static void ProductoComprado(Producto productoAux, int unidades)
        {
            productoAux.Stock -= unidades;
            productoAux.Vendidos += unidades;
        }

        /// <summary>
        /// Busca un producto en el listado por su descripción.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <param name="descripcion"></param>
        /// <returns>El producto encontrado.</returns>
        public static Producto BuscarProductoPorDescripcion(List<Producto> listadoAux, string descripcion)
        {
            int i;
           
            for (i = 0; i < listadoAux.Count; i++)
            {
                if (listadoAux[i].Descripcion == descripcion)
                    return listadoAux[i];
            }

            return listadoAux[i];
        }

        /// <summary>
        /// Busca un cliente en el listado por su nombre.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <param name="nombre"></param>
        /// <returns>El cliente encontrado.</returns>
        public static Cliente BuscarClientePorNombre(List<Cliente> listadoAux, string nombre)
        {
            int i;

            for (i = 0; i < listadoAux.Count; i++)
            {
                if (listadoAux[i].Comprador == nombre)
                    return listadoAux[i];
            }

            return listadoAux[i];
        }

        /// <summary>
        /// Busca un empleado en el listado por su nombre.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <param name="nombre"></param>
        /// <returns>El empleado encontrado.</returns>
        public static Empleado BuscarEmpleadoPorNombre(List<Empleado> listadoAux, string nombre)
        {
            int i;

            for (i = 0; i < listadoAux.Count; i++)
            {
                if (listadoAux[i].Vendedor == nombre)
                    return listadoAux[i];
            }

            return listadoAux[i];
        }

        /// <summary>
        /// Crea una sublista de productos para asignar a compras hardcodeadas.
        /// </summary>
        /// <param name="listadoAux"></param>
        /// <param name="indice1"></param>
        /// <param name="indice2"></param>
        /// <returns></returns>
        public static List<Producto> CrearSublista(List<Producto> listadoAux, int indice1, int indice2)
        {
            List<Producto> sublista = new List<Producto>();

            sublista.Add(listadoAux[indice1]);
            sublista.Add(listadoAux[indice2]);

            return sublista;
        }
        #endregion
    }
}
