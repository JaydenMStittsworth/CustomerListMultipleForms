using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerListMultipleForms
{
    public partial class CustomerForm : Form
    {
        private Customer _customer;

        public CustomerForm()
        {
            // bunch of logic here
            InitializeComponent();
            _customer = new Customer();
        }

        public void LoadCustomer(Customer customer)
        {
            _customer = customer;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            txtFirstName.DataBindings.Add("Text", _customer, "FirstName");
            txtLastName.DataBindings.Add("Text", _customer, "LastName");
            txtEmail.DataBindings.Add("Text", _customer, "Email");
            txtPhone.DataBindings.Add("Text", _customer, "Phone");
        }
    }
}
