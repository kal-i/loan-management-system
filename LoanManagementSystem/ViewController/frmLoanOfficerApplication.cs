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
    public partial class frmLoanOfficerApplication : Form
    {
        private readonly DBConnection dbConnection;
        private LoanOfficerRepository loanOfficerRepository;
        ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender;

        public int id;

        public frmLoanOfficerApplication(ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender)
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            dbConnection = new DBConnection(connectionString);

            loanOfficerRepository = new LoanOfficerRepository(dbConnection);

            btn_Update.Enabled = false;

            this._usrCntrlClientGuarantorLender = _usrCntrlClientGuarantorLender;
        }

        private void Clear(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                // If control is dateTimePicker, set its value to the current date today
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                if (c.HasChildren)
                {
                    Clear(c);
                }
            }
        }

        // To prevent the program from accidentally closing, prompt a confirmation message
        // If the user click 'yes', close the program. Otherwise, do nothing
        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(pnlContainer);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next code
            if (txtb_OfficerLastName.Text == "" || txtb_OfficerFirstName.Text == "" || txtb_OfficerEmail.Text == "" || txtb_OfficerPhone.Text == "" || txtb_OfficerAddress.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before adding a new data to the database
            if (MessageBox.Show("Do you want to add this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoanOfficer officer = new LoanOfficer(txtb_OfficerLastName.Text, txtb_OfficerFirstName.Text, txtb_OfficerMiddleName.Text, officerDateOfBirthPicker.Value, txtb_OfficerAddress.Text, txtb_OfficerPhone.Text, txtb_OfficerEmail.Text);

                if (loanOfficerRepository.CheckIfExist(officer))
                {
                    MessageBox.Show("Record already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    loanOfficerRepository.Insert(officer);
                }
                // loanOfficerRepository.Insert(new LoanOfficer(txtb_OfficerLastName.Text, txtb_OfficerFirstName.Text, txtb_OfficerMiddleName.Text, officerDateOfBirthPicker.Value, txtb_OfficerAddress.Text, txtb_OfficerPhone.Text, txtb_OfficerEmail.Text));
            }
            _usrCntrlClientGuarantorLender.DisplayLoanOfficerInformation(); // This will update the dataGridView in the usrCntrlClientGuarantorLender
            Clear(pnlContainer); // Clear all the fields after a data is added  
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next condition
            if (txtb_OfficerLastName.Text == "" || txtb_OfficerFirstName.Text == "" || txtb_OfficerEmail.Text == "" || txtb_OfficerPhone.Text == "" || txtb_OfficerAddress.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before update an existing record to the database
            if (MessageBox.Show("Do you really want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loanOfficerRepository.Update(new LoanOfficer(id, txtb_OfficerLastName.Text, txtb_OfficerFirstName.Text, txtb_OfficerMiddleName.Text, officerDateOfBirthPicker.Value, txtb_OfficerAddress.Text, txtb_OfficerPhone.Text, txtb_OfficerEmail.Text));
                _usrCntrlClientGuarantorLender.DisplayLoanOfficerInformation(); // update the dataGridView
            }

            btn_Update.Enabled = false; // Disable btn_Update after performing an update operation
            Clear(pnlContainer); // Clear all the fields after a data is added
        }
    }
}
