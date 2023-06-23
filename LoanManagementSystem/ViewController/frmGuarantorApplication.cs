using LoanManagementSystem.Repositories;
using LoanManagementSystem.ViewController;
using System;
using System.Collections;
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
    public partial class frmGuarantorApplication : Form
    {
        private readonly DBConnection dBConnection;
        private GuarantorRepository guarantorRepository;
        ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender;
        private ArrayList guarantorList;

        public int id;

        public frmGuarantorApplication(ClientGuarantorLenderUserControl _usrCntrlClientGuarantorLender)
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            dBConnection = new DBConnection(connectionString);

            guarantorRepository = new GuarantorRepository(dBConnection);

            btn_Update.Enabled = false;

            this._usrCntrlClientGuarantorLender = _usrCntrlClientGuarantorLender;

            guarantorList = new ArrayList
            {
                "Personal Guarantor", 
                "Corporate Guarantor",
                "Government Guarantor"
            };

            // Iterate through each element
            foreach (String guarantor in guarantorList)
            {
                cmb_GuarantorType.Items.Add(guarantor); // To add each element of the guarantor list in combo box
            }

            // To set the default value of combo box
            cmb_GuarantorType.Items.Insert(0, "-Guarantor Type-");
            cmb_GuarantorType.SelectedIndex = 0;
        }

        // A method to Clear all fields
        // Clear() method takes a Control object as a parameter, which represents the parent control containing other controls
        private void Clear(Control control)
        {
            // Iterate through each control
            foreach (Control c in control.Controls)
            {
                // If control is textbox, set its value to empty or null
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                // Else if control is comboBox, set its value to default
                else if (c is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }

                // Else if control is dateTimePicker, set its value to the current date today
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                // If control c has children (child controls or the controls inside it)
                if (c.HasChildren)
                {
                    Clear(c); // Invoke method Clear() and pass control object as an argument
                }
            }
        }

        // Prompt a confirmation message to prevent the program from accidentally closing
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
            // Checks if cmb_GuarantorType selected index is equal to 0. If true, prompt a message and return. Otherwise, proceed to the rest of the code
            if (cmb_GuarantorType.SelectedIndex == 0)
            {
                MessageBox.Show("Select an appropriate Guarantor Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next code
            if (txtb_GuarantorLastName.Text == "" || txtb_GuarantorFirstName.Text == "" || txtb_GuarantorAddress.Text == "" || txtb_GuarantorPhone.Text == "" || txtb_GuarantorEmail.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before adding a new data to the database
            if (MessageBox.Show("Do you want to add this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guarantor guarantor = new Guarantor(cmb_GuarantorType.SelectedItem.ToString(), txtb_GuarantorLastName.Text, txtb_GuarantorFirstName.Text, txtb_GuarantorMiddleName.Text, guarantorDateOfBirthPicker.Value, txtb_GuarantorAddress.Text, txtb_GuarantorPhone.Text, txtb_GuarantorEmail.Text);

                if (guarantorRepository.CheckIfExist(guarantor))
                {
                    MessageBox.Show("Record already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    guarantorRepository.Insert(guarantor);
                }

                // guarantorRepository.Insert(new Guarantor(cmb_GuarantorType.SelectedItem.ToString(), txtb_GuarantorLastName.Text, txtb_GuarantorFirstName.Text, txtb_GuarantorMiddleName.Text, guarantorDateOfBirthPicker.Value, txtb_GuarantorAddress.Text, txtb_GuarantorPhone.Text, txtb_GuarantorEmail.Text));
            }
            _usrCntrlClientGuarantorLender.DisplayGuarantorInformation(); // Update the dataGridView in the usrCntrlClientGuarantorLender
            Clear(pnlContainer); // To clear all fields after a data is added
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Checks if cmb_GuarantorType selected index is equal to 0. If true, prompt a message and return. Otherwise, proceed on the next condition
            if (cmb_GuarantorType.SelectedIndex == 0)
            {
                MessageBox.Show("Select an appropriate Guarantor Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Checks if any of the text boxes is empty. If true, prompt a message then return. Otherwise, proceed to the next condition
            if (txtb_GuarantorLastName.Text == "" || txtb_GuarantorFirstName.Text == "" || txtb_GuarantorAddress.Text == "" || txtb_GuarantorPhone.Text == "" || txtb_GuarantorEmail.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prompt a confirmation message before update an existing record to the database
            if (MessageBox.Show("Do you really want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                guarantorRepository.Update(new Guarantor(id, cmb_GuarantorType.SelectedItem.ToString(), txtb_GuarantorLastName.Text, txtb_GuarantorFirstName.Text, txtb_GuarantorMiddleName.Text, guarantorDateOfBirthPicker.Value, txtb_GuarantorAddress.Text, txtb_GuarantorPhone.Text, txtb_GuarantorEmail.Text));
                _usrCntrlClientGuarantorLender.DisplayGuarantorInformation(); // Update the dataGridView in the usrCntrlClientGuarantorLender
            }
            btn_Update.Enabled = false; // Disable btn_Update after performing an update operation
            Clear(pnlContainer); // Clear all the fields after a data is added
        }
    }
}