using System.ComponentModel;

namespace CustomerListMultipleForms
{
    public partial class Form1 : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<Customer> Customers { get; set; }

        public Form1()
        {
            InitializeComponent();
            Customers = new BindingList<Customer>
            {
                AllowNew = true,
                AllowRemove = true,
                AllowEdit = false
            };

            //Customers.AddRange(new List<Customer>
            //{
            //    new Customer
            //    {
            //        FirstName = "John",
            //        LastName = "Smith",
            //        Email = "idk",
            //        Phone = "idk3"
            //    },
            //    new Customer
            //    {
            //        FirstName = "Johna",
            //        LastName = "Smitha",
            //        Email = "idkk",
            //        Phone = "idkk3"
            //    },
            //    new Customer
            //    {
            //        FirstName = "Johne",
            //        LastName = "Smithe",
            //        Email = "iadk",
            //        Phone = "iadk3"
            //    }
            //});
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            // fire code to create a new customer form
            var newCustomerForm = new CustomerForm();

            if (newCustomerForm.ShowDialog() == DialogResult.OK)
            {
                // add the customer to the list of customers
                Customers.Add(newCustomerForm.GetCustomer());
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // fire code to edit the selected customer form
            var customerForm = new CustomerForm();

            // get the selected customer from the datagridview
            var selectedCustomer = dgvCustomers.CurrentRow?.DataBoundItem as Customer;

            // be defensive and make sure a customer is selected before trying to load the form
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }

            // add customer data (based on what customer is currently selected)
            customerForm.LoadCustomer(selectedCustomer);

            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                // update the customer in the list of customers
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // binding the list of customers to the datagridview
            dgvCustomers.DataSource = Customers;
        }
    }
}
