using Project_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Main_Form : Form
    {
        private OrderService orderService;
        private BindingSource orderBindingSource;
        private BindingSource orderDetailsBindingSource;

        public Main_Form()
        {
            InitializeComponent();
            orderService = new OrderService();
            orderBindingSource = new BindingSource();
            orderDetailsBindingSource = new BindingSource();

            // Setup data bindings
            LoadData();
            orderDetailsBindingSource.DataSource = orderBindingSource;
            orderDetailsBindingSource.DataMember = "OrderDetailsList";

            // Bind data to DataGridViews
            dgvOrders.DataSource = orderBindingSource;
            dgvOrderDetails.DataSource = orderDetailsBindingSource;
        }
        private void LoadData()
        {
            orderBindingSource.DataSource = orderService.QueryOrders(o => true);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderForm = new Order_Form();
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(orderForm.Order);
                RefreshOrderList();
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                var orderForm = new Order_Form(selectedOrder);
                if (orderForm.ShowDialog() == DialogResult.OK)
                {
                    orderService.UpdateOrder(orderForm.Order);
                    RefreshOrderList();
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                orderService.RemoveOrder(selectedOrder.OrderId);
                RefreshOrderList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            orderBindingSource.DataSource = orderService.QueryOrders(o =>
                o.OrderId.ToString().Contains(searchText) ||
                o.Customer.ToLower().Contains(searchText) ||
                o.OrderDetailsList.Any(d => d.ProductName.ToLower().Contains(searchText))
            );
            orderBindingSource.ResetBindings(false);
        }

        private void RefreshOrderList()
        {
            orderBindingSource.DataSource = orderService.QueryOrders(o => true);
            orderBindingSource.ResetBindings(false);
        }
    }
}
