using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonyPizzeria_ProyectoFinal
{
    public class Promociones : IDescuentoSubtotal
    {
                
        public decimal promoPorMonto(string subtotal)
        {
            decimal porcentajeDescuento = 0.05M;
            decimal subt = Convert.ToDecimal(subtotal);
            decimal descuento = 0.00M;

            if (subt >= 3000)
            {
               descuento = subt * porcentajeDescuento;
            }

            descuento = decimal.Round(descuento, 2);
            return descuento;
        } 
    }
}
