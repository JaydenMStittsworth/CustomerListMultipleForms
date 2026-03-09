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

        public Customer GetCustomer()
        {
            return _customer;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            txtFirstName.DataBindings.Add("Text", _customer, "FirstName");
            txtLastName.DataBindings.Add("Text", _customer, "LastName");
            txtEmail.DataBindings.Add("Text", _customer, "Email");
            txtPhone.DataBindings.Add("Text", _customer, "Phone");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation logic here

            // does the form have a first name
            if (Validators.ContainsValue(txtFirstName.Text) == false)
            {
                MessageBox.Show("Please enter a first name");
                return;
            }

            // does the form have a last name
            if (Validators.ContainsValue(txtLastName.Text) == false)
            {
                MessageBox.Show("Please enter a last name");
                return;
            }

            // does the form have at least an email or a phone number?
            if (Validators.ContainsValue(txtEmail.Text) == false
                && Validators.ContainsValue(txtPhone.Text) == false)
            {
                MessageBox.Show("Please enter an email or phone number");
                return;
            }

            // check the pattern of email using regex
            if (Validators.ContainsValue(txtEmail.Text) &&
                Validators.IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // check the pattern of email using regex
            if (Validators.ContainsValue(txtPhone.Text) &&
                Validators.IsValidPhoneNumber(txtPhone.Text) == false)
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
