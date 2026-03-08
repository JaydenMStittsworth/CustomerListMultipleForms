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
            newCustomerForm.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // fire code to edit the selected customer form
        }
    }
}
