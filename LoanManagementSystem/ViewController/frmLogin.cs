using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Odbc;
using LoanManagementSystem.Repositories;
using Guna.UI2.WinForms;

namespace LoanManagementSystem
{
    public partial class frmLogin : Form
    {
        private readonly DBConnection dbConnection;
        private UserRepository userRepository;
        List<User> users;

        public frmLogin()
        {
            InitializeComponent();

            // The connection string for a database usually contains four parts: server_name, database_name, user_id, and password
            // However, since I'm using a Windows Authentication to log in to the db, I modified the connection string by adding 'Integrated Security=SSPI' parameter
            // This simply tells the db to use the credentials currently logged-in for user auth
            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            // Create a new DBConnection object and pass the modified connection string as a parameter to the obj's constructor
            dbConnection = new DBConnection(connectionString);
            userRepository = new UserRepository(dbConnection);

            this.AcceptButton = btn_Login;
        }

        private void ClearFields(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                if (c.HasChildren)
                {
                    ClearFields(c);
                }
            }
        }

        private void CheckFieldsIfEmpty(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Guna2TextBox textBox)
                {
                    if (textBox.Name == "txtb_MiddleName")
                    {
                        continue;
                    }
                    if (textBox.Text == "")
                    {
                        MessageBox.Show("Fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (c.HasChildren)
                {
                    CheckFieldsIfEmpty(c);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // Checks if the username or password are empty, then prompts an error message if true.
            // The 'return' keyword will prevent the program from executing the rest of the code.
            if (txtb_User.Text == "" || txtb_Pass.Text == "")
            {
                MessageBox.Show("Username or Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get all the user data
            users = userRepository.GetUsers();

            // Check if the login credentials match any user in the database
            bool accountExists = false;
            foreach (User user in users)
            {
                if (user.Username == txtb_User.Text && user.Password == txtb_Pass.Text)
                {
                    accountExists = true;
                    this.Hide();
                    new frmDashboard(user).ShowDialog(); // Pass the user as an argument to frmDashboard
                    this.Close();
                    break; // If a match is found, terminate loop
                }
            }

            if (!accountExists)
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // A function that reveal the 'Password' when cb_Password (checkBox) is checked
        private void cb_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ShowPassword.Checked)
            {
                txtb_Pass.PasswordChar = '\0'; // Reveal the password
            }
            else
            {
                txtb_Pass.PasswordChar = '*'; // Hide the password
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            CheckFieldsIfEmpty(pnlRegisterContainer);

            User newUser = new User(txtb_LastName.Text, txtb_FirstName.Text, txtb_MiddleName.Text, userDateTimePicker.Value, txtb_Address.Text, txtb_Phone.Text, txtb_Email.Text, txtb_Username.Text, txtb_Password.Text);

            if (userRepository.CheckIfExist(newUser))
            {
                MessageBox.Show("User already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                userRepository.Insert(newUser);
                ClearFields(pnlRegisterContainer);
            }
        }
    }
}