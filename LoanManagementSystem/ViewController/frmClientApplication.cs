using LoanManagementSystem.Repositories;
using LoanManagementSystem.ViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem
{
    public partial class frmClientApplication : Form
    {
        private readonly DBConnection dbConnection;
        private ClientRepository clientRepository;
        ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender;

        public int client_id;
        public int client_employment_id;
        public int client_financial_id;

        public frmClientApplication(ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender)
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            dbConnection = new DBConnection(connectionString);

            clientRepository = new ClientRepository(dbConnection);

            btn_Update.Enabled = false;

            this._usrCntrlClientGuarantorLender = _usrCntrlClientGuarantorLender;

            PopulateEmploymentStatus();
            PopulateIncomeFrequency();
            PopulateIncomeSource();
        }

        // A function that takes a 'Control' as a parameter and clear its fields
        private void Clear(Control control)
        {
            // Iterate through each control
            foreach (Control c in control.Controls)
            {
                // If control is Textbox, set its value to empty
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                // If control is ComboBox, reset its 'SelectedIndex' to -1
                else if (c is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }

                // If control is dateTimePicker, set its value to the current date today
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                // If control has child controls, recursively clear their fields
                if (control.HasChildren)
                {
                   Clear(c);
                }
            }
        }

        private void PopulateEmploymentStatus()
        {
            List<string> statusList = new List<string>()
            {
                "Full-time",
                "Part-time",
                "Self-employment",
                "Freelance or contract work",
                "Seasonal employment",
                "Unemployment"
            };

            foreach (string status in statusList)
            {
                cmb_EmploymentStatus.Items.Add(status);
            }

            cmb_EmploymentStatus.Items.Insert(0, "-Select Employment Status-");
            cmb_EmploymentStatus.SelectedIndex = 0;
        }

        private void PopulateIncomeFrequency()
        {
            List<string> incomeFrequencies = new List<string>()
            {
                "Monthly",
                "Bi-Monthly",
                "Bi-weekly",
                "Weekly",
                "Quarterly",
                "Annual"
            };

            foreach (string income in incomeFrequencies)
            {
                cmb_IncomeFrequency.Items.Add(income);
            }

            cmb_IncomeFrequency.Items.Insert(0, "-Select Income Frequency-");
            cmb_IncomeFrequency.SelectedIndex = 0;
        }

        private void PopulateIncomeSource()
        {
            List<string> incomeSources = new List<string>()
            {
                "Employment income",
                "Self-employment income",
                "Rental income",
                "Investment income",
                "Retirement income",
                "Spousal or partner income"
            };

            foreach (string source in incomeSources)
            {
                cmb_IncomeSource.Items.Add(source);
            }

            cmb_IncomeSource.Items.Insert(0, "-Select Income Source-");
            cmb_IncomeSource.SelectedIndex = 0;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                this.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(pnlContainer); // Invoke method clear and pass 'pnlContainer' as an argument
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next condition
            if (txtb_ClientLastName.Text == "" || txtb_ClientFirstName.Text == "" || txtb_ClientAddress.Text == "" || txtb_ClientPhone.Text == "" || txtb_ClientEmail.Text == "" || txtb_EmployerFullName.Text == "" || txtb_IncomeAmount.Text == "" || txtb_AnnualIncome.Text == "" || txtb_ExpensesAmount.Text == "" || txtb_TotalAssets.Text == "" || txtb_TotalLiabilities.Text == "" || txtb_CreditScore.Text == "") 
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_EmploymentStatus.SelectedIndex == 0 || cmb_IncomeFrequency.SelectedIndex == 0 || cmb_IncomeSource.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an option from the dropdown menu to proceed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before adding a new record to the database
            if (MessageBox.Show("Do you want to add this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Client client = new Client(txtb_ClientLastName.Text, txtb_ClientFirstName.Text, txtb_ClientMiddleName.Text, clientDateOfBirthPicker.Value, txtb_ClientAddress.Text, txtb_ClientPhone.Text, txtb_ClientEmail.Text, txtb_EmployerFullName.Text, txtb_JobTitle.Text, employeeStartDateTimePicker.Value, cmb_EmploymentStatus.SelectedItem.ToString(), Double.Parse(txtb_IncomeAmount.Text), cmb_IncomeFrequency.SelectedItem.ToString(), Double.Parse(txtb_AnnualIncome.Text), cmb_IncomeSource.SelectedItem.ToString(), Double.Parse(txtb_ExpensesAmount.Text), Double.Parse(txtb_TotalAssets.Text), Double.Parse(txtb_TotalLiabilities.Text), int.Parse(txtb_CreditScore.Text));

                if (clientRepository.CheckIfExist(client))
                {
                    MessageBox.Show("Record already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    clientRepository.Insert(client);
                }
                // clientRepository.Insert(new Client(txtb_ClientLastName.Text, txtb_ClientFirstName.Text, txtb_ClientMiddleName.Text, clientDateOfBirthPicker.Value, txtb_ClientAddress.Text, txtb_ClientPhone.Text, txtb_ClientEmail.Text, txtb_EmployerFullName.Text, txtb_JobTitle.Text, employeeStartDateTimePicker.Value, cmb_EmploymentStatus.SelectedItem.ToString(), Double.Parse(txtb_IncomeAmount.Text), cmb_IncomeFrequency.SelectedItem.ToString(), Double.Parse(txtb_AnnualIncome.Text), cmb_IncomeSource.SelectedItem.ToString(), Double.Parse(txtb_ExpensesAmount.Text), Double.Parse(txtb_TotalAssets.Text), Double.Parse(txtb_TotalLiabilities.Text), int.Parse(txtb_CreditScore.Text)));
                _usrCntrlClientGuarantorLender.DisplayClientInformation(); // Update the dataGridView in the usrCntrlClientGuarantorLender
            }
            btn_Update.Enabled = false; // Disable btn_Update after performing an update operation
            Clear(pnlContainer); // Clear all the fields after a data is added
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next condition
            if (txtb_ClientLastName.Text == "" || txtb_ClientFirstName.Text == "" || txtb_ClientAddress.Text == "" || txtb_ClientPhone.Text == "" || txtb_ClientEmail.Text == "" || txtb_EmployerFullName.Text == "" || txtb_IncomeAmount.Text == "" || txtb_AnnualIncome.Text == "" || txtb_ExpensesAmount.Text == "" || txtb_TotalAssets.Text == "" || txtb_TotalLiabilities.Text == "" || txtb_CreditScore.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_EmploymentStatus.SelectedIndex == 0 || cmb_IncomeFrequency.SelectedIndex == 0 || cmb_IncomeSource.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an option from the dropdown menu to proceed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before adding a new record to the database
            if (MessageBox.Show("Do you really want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clientRepository.Update(new Client(client_id, txtb_ClientLastName.Text, txtb_ClientFirstName.Text, txtb_ClientMiddleName.Text, clientDateOfBirthPicker.Value, txtb_ClientAddress.Text, txtb_ClientPhone.Text, txtb_ClientEmail.Text, client_employment_id, txtb_EmployerFullName.Text, txtb_JobTitle.Text, employeeStartDateTimePicker.Value, cmb_EmploymentStatus.SelectedItem.ToString(), Double.Parse(txtb_IncomeAmount.Text), cmb_IncomeFrequency.SelectedItem.ToString(), client_financial_id, Double.Parse(txtb_AnnualIncome.Text), cmb_IncomeSource.SelectedItem.ToString(), Double.Parse(txtb_ExpensesAmount.Text), Double.Parse(txtb_TotalAssets.Text), Double.Parse(txtb_TotalLiabilities.Text), int.Parse(txtb_CreditScore.Text)));
                _usrCntrlClientGuarantorLender.DisplayClientInformation(); // Update the dataGridView in the usrCntrlClientGuarantorLender
            }
            btn_Update.Enabled = false; // Disable btn_Update after performing an update operation
            Clear(pnlContainer); // Clear all the fields after a data is added
        }

        private void btn_AttachEmploymentDocument_Click(object sender, EventArgs e)
        {

        }

        private void btn_AttachFinancialDocument_Click(object sender, EventArgs e)
        {

        }
    }
}
