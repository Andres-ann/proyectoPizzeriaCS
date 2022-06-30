using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonyPizzeria_ProyectoFinal
{
    class Producto
    {
        int _idProducto;
        string _nombre;
        decimal _precioUnitario;        

        public Producto(int idProducto, string nombre, decimal precioUnitario)
        {
            _idProducto = idProducto;
            _nombre = nombre;
            _precioUnitario = precioUnitario;
        }        

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
    }
}
