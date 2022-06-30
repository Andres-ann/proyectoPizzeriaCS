using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TonyPizzeria_ProyectoFinal

{
    public partial class TonyPizzeria : Form
    {
        //instancia las clases Pizzeria - Producto y promociones | inicializa el contador de numPedido
        Pizzeria TonysPizzeria = new Pizzeria("0001", "Tonys Pizzeria | Alto Avellaneda", "Guemes 4565", "(+54) 11 2345 7654");

        Producto combo1 = new Producto(1101, "1 Muzarella individual + Bebida", 1119.90M);
        Producto combo2 = new Producto(1201, "1 Especial individual + Bebida", 1449.90M);
        Producto combo3 = new Producto(1301, "1  Muzarella vegana + Bebida", 1529.90M);        

        Promociones promo1 = new Promociones();

        int numPedido = 1;

        public TonyPizzeria()
        {
            InitializeComponent();
            //Inicializa los label de los combos con el precio de la clase
            lblPrecioCombo1.Text = Convert.ToString(combo1.PrecioUnitario);
            lblPrecioCombo2.Text = Convert.ToString(combo2.PrecioUnitario);
            lblPrecioCombo3.Text = Convert.ToString(combo3.PrecioUnitario);

            //Coloca la fecha actual en el form
            lblFecha.Text = DateTime.Now.ToLongDateString();

            //inicializa los totales en 0
            lblDescuento.Text = "0.00";
            lblTotalPedido.Text = "0.00";
            lblTotalConDescuento.Text = "0.00";

            //Label con leyenda de promocion/es
            lblPromo.Text = "Nos volvimos locos!!! \nCon tu compra mayor a $ 3000 tenés un 5% de descuento!!!";
           
        }

        //Boton agregar (combo1)
        private void btnAgregarCombo1_Click(object sender, EventArgs e)
        {
            if (numCantidadCombo1.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0");
            }
            else
            {
                Console.Beep();
                var precioItem = combo1.PrecioUnitario * numCantidadCombo1.Value;
                dgvListaPedido.Rows.Add(combo1.IdProducto, combo1.Nombre, combo1.PrecioUnitario, numCantidadCombo1.Value, precioItem);
                numCantidadCombo1.Value = 0;

                decimal totalPedido = 0.00M;
                foreach (DataGridViewRow row in dgvListaPedido.Rows)
                {
                    totalPedido += Convert.ToDecimal(row.Cells["Column5"].Value);
                    lblTotalPedido.Text = Convert.ToString(totalPedido);
                }
            }
        }

        //botón agregar (combo2)
        private void btnAgregarCombo2_Click(object sender, EventArgs e)
        {
            if (numCantidadCombo2.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0");
            }
            else
            {
                Console.Beep();
                var precioItem = combo2.PrecioUnitario * numCantidadCombo2.Value;
                dgvListaPedido.Rows.Add(combo2.IdProducto, combo2.Nombre, combo2.PrecioUnitario, numCantidadCombo2.Value, precioItem);
                numCantidadCombo2.Value = 0;

                decimal totalPedido = 0.00M;
                foreach (DataGridViewRow row in dgvListaPedido.Rows)
                {
                    totalPedido += Convert.ToDecimal(row.Cells["Column5"].Value);
                    lblTotalPedido.Text = Convert.ToString(totalPedido);  
                }
            }
        }

        //botón agregar (combo3)
        private void btnAgregarCombo3_Click(object sender, EventArgs e)
        {
            if (numCantidadCombo3.Value == 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0");
            }
            else
            {
                Console.Beep();
                var precioItem = combo3.PrecioUnitario * numCantidadCombo3.Value;
                dgvListaPedido.Rows.Add(combo3.IdProducto, combo3.Nombre, combo3.PrecioUnitario, numCantidadCombo3.Value, precioItem);
                numCantidadCombo3.Value = 0;

                decimal totalPedido = 0.00M;
                foreach (DataGridViewRow row in dgvListaPedido.Rows)
                {
                    totalPedido += Convert.ToDecimal(row.Cells["Column5"].Value);
                    lblTotalPedido.Text = Convert.ToString(totalPedido);                    
                }
            }            
        }
        //botón eliminar un item del pedido
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvListaPedido.SelectedRows)
            {
                try
                {
                    Console.Beep();
                    dgvListaPedido.Rows.RemoveAt(item.Index);
                    decimal totalPedido = 0.00M;

                    foreach (DataGridViewRow row in dgvListaPedido.Rows)
                    {
                        totalPedido += Convert.ToDecimal(row.Cells["Column5"].Value);
                        lblTotalPedido.Text = Convert.ToString(totalPedido);
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("No existen items para eliminar");
                }
            }    
        }
        //botón cancelar todo el pedido
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Console.Beep();
            dgvListaPedido.Rows.Clear();
            lblTotalPedido.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblTotalConDescuento.Text = "0.00";
        }
       
        //botón de confirmación del pedido
        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            Console.Beep();
            lblDescuento.Text = Convert.ToString(promo1.promoPorMonto(lblTotalPedido.Text));
            var totalPedido = Convert.ToDecimal(lblTotalPedido.Text) - Convert.ToDecimal(lblDescuento.Text);
            lblTotalConDescuento.Text = Convert.ToString(totalPedido);

            if (dgvListaPedido.Rows.Count > 1 && dgvListaPedido.Rows != null)
            {
                var date = DateTime.Now;
                
                MessageBox.Show($"{TonysPizzeria.ToString()}Fecha:{date}\n\n ¡Su pedido fue confirmado exitosamente! \n\n Número de Pedido #000{ numPedido} \n\nSubtotal: {lblTotalPedido.Text} \nDescuento: {lblDescuento.Text} \nTotal: {lblTotalConDescuento.Text}");
                dgvListaPedido.Rows.Clear();
                lblTotalPedido.Text = "0.00";
                numPedido++;
            }
            else
            {
                MessageBox.Show("Debes ingresar por lo menos un item al pedido");
            }   

            lblDescuento.Text = "0.00";
            lblTotalConDescuento.Text = "0.00";
        }
       
        //Formulario n°2: Ayuda
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAyuda formAyuda = new FormAyuda();
            formAyuda.Show();

        }
        //Boton de salir 
        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton del menú: Contacto
        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TonysPizzeria.ToString());
        }

        private void TonyPizzeria_Load(object sender, EventArgs e)
        {

        }
    }
}
