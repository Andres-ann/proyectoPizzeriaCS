using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonyPizzeria_ProyectoFinal
{
    interface IDescuentoSubtotal
    {
       decimal promoPorMonto(string subtotal);
    }
}
