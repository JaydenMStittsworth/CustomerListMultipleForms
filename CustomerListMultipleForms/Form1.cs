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
                var updatedCustomer = customerForm.GetCustomer();
                selectedCustomer.FirstName = updatedCustomer.FirstName;
                selectedCustomer.LastName = updatedCustomer.LastName;
                selectedCustomer.Email = updatedCustomer.Email;
                selectedCustomer.Phone = updatedCustomer.Phone;
                dgvCustomers.Refresh();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // binding the list of customers to the datagridview
            dgvCustomers.DataSource = Customers;
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // check if the selected item is valid
                // if valid, enable the edit button
                // if not, disable the edit button
            var isValidSelection = dgvCustomers.CurrentRow?.DataBoundItem is Customer;

            if (isValidSelection)
            {
                btnEditCustomer.Enabled = true;
            }
            else
            {
                btnEditCustomer.Enabled = false;
            }
                
        }
    }
}
