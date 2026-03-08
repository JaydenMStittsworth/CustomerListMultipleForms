using System.ComponentModel;

namespace CustomerListMultipleForms
{
    public partial class Form1 : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers { get; set; }

        public Form1()
        {
            InitializeComponent();
            Customers = new List<Customer>();
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
            //refresh the datagridview
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = Customers;
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // fire code to edit the selected customer form
            var customerForm = new CustomerForm();

            // add customer data (this is temporary)
            customerForm.LoadCustomer(new Customer
            {
                FirstName = "Jayden",
                LastName = "Stittsworth",
                Email = "idk",
                Phone = "idk2"
            });

            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Dialog returned an ok.");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // binding the list of customers to the datagridview
            dgvCustomers.DataSource = Customers;
        }
    }
}
