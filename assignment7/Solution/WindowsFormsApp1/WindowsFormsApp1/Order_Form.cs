using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_class;

namespace WinFormsApp1
{
    public partial class Order_Form : Form
    {
        public Order Order { get; private set; }

        public Order_Form(Order order = null)
        {
            InitializeComponent();
            if (order == null)
            {
                Order = new Order(0, string.Empty);
            }
            else
            {
                Order = order;
                txtOrderId.Text = order.OrderId.ToString();
                txtCustomer.Text = order.Customer;
            }
            orderDetailsBindingSource.DataSource = Order.OrderDetailsList;
            dgvOrderDetails.DataSource = orderDetailsBindingSource;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Order.OrderId = int.Parse(txtOrderId.Text);
            Order.Customer = txtCustomer.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            var orderDetail = new OrderDetails(txtProductName.Text, int.Parse(txtQuantity.Text), double.Parse(txtUnitPrice.Text));
            Order.OrderDetailsList.Add(orderDetail);
            orderDetailsBindingSource.ResetBindings(false);
        }
    }
}
