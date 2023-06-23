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
using System.Windows;
using System.Windows.Forms;

namespace LoanManagementSystem
{
    public partial class ClientGuarantorLenderUserControl : UserControl
    {
        private readonly DBConnection dbConnection;

        private List<Client> clientList;
        private ClientRepository clientRepository;
        private Client client;

        private List<Guarantor> guarantorList;
        private GuarantorRepository guarantorRepository;
        private Guarantor guarantor;

        private List<LoanOfficer> loanOfficerList;
        private LoanOfficerRepository loanOfficerRepository;
        private LoanOfficer loanOfficer;

        public ClientGuarantorLenderUserControl()
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            dbConnection = new DBConnection(connectionString);

            clientRepository = new ClientRepository(dbConnection);
            client = new Client();
            DisplayClientInformation();

            guarantorRepository = new GuarantorRepository(dbConnection);
            guarantor = new Guarantor();
            DisplayGuarantorInformation(); // Invoke method DisplayGuarantorInformation() to populate guarantorDataGridView

            loanOfficerRepository = new LoanOfficerRepository(dbConnection);
            loanOfficer = new LoanOfficer();
            DisplayLoanOfficerInformation(); // Invoke method DisplayLoanOfficerInformation() to populate loanOfficerDataGridView
        }

        public void DisplayClientInformation()
        {
            // Fetches the clients data by invoking GetClients() method from ClientRepository
            clientList = clientRepository.GetClients();

            // Set the DataSource property of the clientDataGridView
            clientDataGridView.DataSource = clientList;
            clientDataGridView.Columns[8].Visible = false;
            clientDataGridView.Columns[15].Visible = false;

            // To deselect row in the clientDataGridView when the program runs or the method is invoked
            clientDataGridView.ClearSelection();
        }

        public void DisplayGuarantorInformation()
        {
            // Fetches the guarantors data by invoking GetGuarantors() method from GuarantorRepository
            guarantorList = guarantorRepository.GetGuarantors();

            // Set the DataSource property of the guarantorDataGridView
            guarantorDataGridView.DataSource = guarantorList;

            // To deselect row in the guarantorDataGridView when the program runs or the method is invoked
            guarantorDataGridView.ClearSelection();
        }

        public void DisplayLoanOfficerInformation()
        {
            // Fetches the officers data by invoking GetOfficers() method from LoanOfficeRepository
            loanOfficerList = loanOfficerRepository.GetOfficers();

            // Set the DataSource property of the loanOfficerDataGridView
            loanOfficerDataGridView.DataSource = loanOfficerList;

            // To deselect row in the officerDataGridView when the program runs or the method is invoked
            loanOfficerDataGridView.ClearSelection();
        }

        private void btn_AddClient_Click(object sender, EventArgs e)
        {
            frmClientApplication _frmClient = new frmClientApplication(this);
            _frmClient.ShowDialog();
        }

        private void btn_AddNewLoanOfficer_Click(object sender, EventArgs e)
        {
            frmLoanOfficerApplication _frmLoanApplication = new frmLoanOfficerApplication(this);
            _frmLoanApplication.ShowDialog();
        }

        private void btn_AddNewGuarantor_Click(object sender, EventArgs e)
        {
            frmGuarantorApplication _frmGuarantorApplication = new frmGuarantorApplication(this);
            _frmGuarantorApplication.ShowDialog();
        }

        private void btn_RefreshClientDataGridView_Click(object sender, EventArgs e)
        {
            DisplayClientInformation();
        }

        private void btn_RefreshGuarantorDataGridView_Click(object sender, EventArgs e)
        {
            DisplayGuarantorInformation();
        }

        private void btn_RefreshLoanOfficerDataGridView_Click(object sender, EventArgs e)
        {
            DisplayLoanOfficerInformation();
        }

        private void loanOfficerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = loanOfficerDataGridView.Columns[e.ColumnIndex].Name; // Get the column name when clicked and store to var colName

                // If the selected colName is equal to colUpdate, open the frmLoanOfficerApplication and pass the data row in which the colUpdate was clicked
                if (colName.Equals("colUpdate"))
                {
                    frmLoanOfficerApplication _frmLoanOfficerApplication = new frmLoanOfficerApplication(this);
                    _frmLoanOfficerApplication.btn_Add.Enabled = false; // Disable btn_Add when updating an existing data
                    object value = loanOfficerDataGridView.Rows[e.RowIndex].Cells[0].Value;
                    _frmLoanOfficerApplication.id = Convert.ToInt32(value);
                    _frmLoanOfficerApplication.txtb_OfficerLastName.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _frmLoanOfficerApplication.txtb_OfficerFirstName.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    _frmLoanOfficerApplication.txtb_OfficerMiddleName.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _frmLoanOfficerApplication.officerDateOfBirthPicker.Value = DateTime.Parse(loanOfficerDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                    _frmLoanOfficerApplication.txtb_OfficerAddress.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                    _frmLoanOfficerApplication.txtb_OfficerPhone.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                    _frmLoanOfficerApplication.txtb_OfficerEmail.Text = loanOfficerDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                    _frmLoanOfficerApplication.btn_Update.Enabled = true;
                    _frmLoanOfficerApplication.ShowDialog();
                }

                if (colName.Equals("colRemove"))
                {
                    // Prompt a confirmation message before performing an action to avoid accidental deletion of data
                    if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // retrieves the value from the first cell (index 0) in the clicked row, assuming its the primary key for the loan officer
                        object value = loanOfficerDataGridView.Rows[e.RowIndex].Cells[0].Value;

                        // Converts the retrieved data stored in var value to an int
                        loanOfficer.ID = Convert.ToInt32(value);

                        // Invokes the Delete() method from the loanOfficerRepository to delete the loan officer record based on the provided identifier
                        loanOfficerRepository.Delete(loanOfficer);

                        // Invoke DisplayInformation() after the deletion to update or refresh the data from dataGridView
                        DisplayLoanOfficerInformation();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void guarantorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = guarantorDataGridView.Columns[e.ColumnIndex].Name; // Get the column name when clicked and store to var colName

                // If the selected colName is equal to colUpdate, open the frmLoanOfficerApplication and pass the data row in which the colUpdate was clicked
                if (colName.Equals("columnUpdate"))
                {
                    frmGuarantorApplication _frmGuarantorApplication = new frmGuarantorApplication(this);
                    _frmGuarantorApplication.btn_Add.Enabled = false; // Disable btn_Add when updating an existing data
                    object value = guarantorDataGridView.Rows[e.RowIndex].Cells[0].Value;
                    _frmGuarantorApplication.id = Convert.ToInt32(value);
                    _frmGuarantorApplication.cmb_GuarantorType.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _frmGuarantorApplication.txtb_GuarantorLastName.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    _frmGuarantorApplication.txtb_GuarantorFirstName.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _frmGuarantorApplication.txtb_GuarantorMiddleName.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                    _frmGuarantorApplication.guarantorDateOfBirthPicker.Value = DateTime.Parse(guarantorDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString());
                    _frmGuarantorApplication.txtb_GuarantorAddress.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                    _frmGuarantorApplication.txtb_GuarantorPhone.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                    _frmGuarantorApplication.txtb_GuarantorEmail.Text = guarantorDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                    _frmGuarantorApplication.btn_Update.Enabled = true;
                    _frmGuarantorApplication.ShowDialog();
                }

                if (colName.Equals("columnDelete"))
                {
                    // Prompt a confirmation message before performing an action to avoid accidental deletion of data
                    if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // retrieves the value from the first cell (index 0) in the clicked row, assuming its the primary key for the loan officer
                        object value = guarantorDataGridView.Rows[e.RowIndex].Cells[0].Value;

                        // Converts the retrieved data stored in var value to an int
                        guarantor.ID = Convert.ToInt32(value);

                        // Invokes the Delete() method from the loanOfficerRepository to delete the loan officer record based on the provided identifier
                        guarantorRepository.Delete(guarantor);

                        // Invoke DisplayInformation() after the deletion to update or refresh the data from dataGridView
                        DisplayGuarantorInformation();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void clientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = clientDataGridView.Columns[e.ColumnIndex].Name; // Get the column name when clicked and store to var colName

                // If the selected colName is equal to colUpdate, open the frmLoanOfficerApplication and pass the data row in which the colUpdate was clicked
                if (colName.Equals("colEdit"))
                {
                    frmClientApplication _frmClientApplication = new frmClientApplication(this);
                    _frmClientApplication.btn_Add.Enabled = false; // Disable btn_Add when updating an existing data
                    object value = clientDataGridView.Rows[e.RowIndex].Cells[0].Value;
                    _frmClientApplication.client_id = Convert.ToInt32(value);
                    _frmClientApplication.txtb_ClientLastName.Text = clientDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _frmClientApplication.txtb_ClientFirstName.Text = clientDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    _frmClientApplication.txtb_ClientMiddleName.Text = clientDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _frmClientApplication.clientDateOfBirthPicker.Value = DateTime.Parse(clientDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                    _frmClientApplication.txtb_ClientAddress.Text = clientDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                    _frmClientApplication.txtb_ClientPhone.Text = clientDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                    _frmClientApplication.txtb_ClientEmail.Text = clientDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                    
                    object value2 = clientDataGridView.Rows[e.RowIndex].Cells[8].Value;
                    _frmClientApplication.client_employment_id = Convert.ToInt32(value2);
                    _frmClientApplication.txtb_EmployerFullName.Text = clientDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                    _frmClientApplication.txtb_JobTitle.Text = clientDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                    _frmClientApplication.employeeStartDateTimePicker.Value = DateTime.Parse(clientDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString());
                    _frmClientApplication.cmb_EmploymentStatus.Text = clientDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                    _frmClientApplication.txtb_IncomeAmount.Text = clientDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                    _frmClientApplication.cmb_IncomeFrequency.Text = clientDataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();

                    object value3 = clientDataGridView.Rows[e.RowIndex].Cells[15].Value;
                    _frmClientApplication.client_financial_id = Convert.ToInt32(value3);
                    _frmClientApplication.txtb_AnnualIncome.Text = clientDataGridView.Rows[e.RowIndex].Cells[16].Value.ToString();
                    _frmClientApplication.cmb_IncomeSource.Text = clientDataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();
                    _frmClientApplication.txtb_ExpensesAmount.Text = clientDataGridView.Rows[e.RowIndex].Cells[18].Value.ToString();
                    _frmClientApplication.txtb_TotalAssets.Text = clientDataGridView.Rows[e.RowIndex].Cells[19].Value.ToString();
                    _frmClientApplication.txtb_TotalLiabilities.Text = clientDataGridView.Rows[e.RowIndex].Cells[20].Value.ToString();
                    _frmClientApplication.txtb_CreditScore.Text = clientDataGridView.Rows[e.RowIndex].Cells[21].Value.ToString();
                    _frmClientApplication.btn_Update.Enabled = true;
                    _frmClientApplication.ShowDialog();
                }

                if (colName.Equals("colDelete"))
                {
                    // Prompt a confirmation message before performing an action to avoid accidental deletion of data
                    if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // retrieves the value from the first cell (index 0) in the clicked row, assuming its the primary key for the loan officer
                        object value = clientDataGridView.Rows[e.RowIndex].Cells[0].Value;

                        // Converts the retrieved data stored in var value to an int
                        client.ID = Convert.ToInt32(value);

                        // Invokes the Delete() method from the loanOfficerRepository to delete the loan officer record based on the provided identifier
                        clientRepository.Delete(client);

                        // Invoke DisplayInformation() after the deletion to update or refresh the data from dataGridView
                        DisplayClientInformation();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Fetches the clients data by invoking GetFilteredClients() method from ClientRepository based on the argument we passed
        private void txtb_ClientSearchBar_TextChanged(object sender, EventArgs e)
        {
            // Checks if txtb_SearchBar length is greater than 0,
            // then if it is, either convert the value to int if it is a numerical value
            // and invoke the GetFilteredClients() method that accepts either an int or a string if it is an alphabetical value
            if (txtb_ClientSearchBar.Text.Length > 0)
            {
                int parsedValue;
                if (int.TryParse(txtb_ClientSearchBar.Text, out parsedValue))
                {
                    clientList = clientRepository.GetFilteredClients(parsedValue); // Get filtered clients based on the parsed integer value
                }
                else
                {
                    clientList = clientRepository.GetFilteredClients(txtb_ClientSearchBar.Text); // Get filtered clients based on the string value
                }

                // Set the DataSource property of the clientDataGridView to display the filtered client list
                clientDataGridView.DataSource = clientList;

                // To deselect row in the clientDataGridView when the program runs or the method is invoked
                clientDataGridView.ClearSelection();
            }
            else
            {
                DisplayClientInformation(); // If the search bar is empty, display all client information
            }
        }

        private void txtb_GuarantorSearchBar_TextChanged(object sender, EventArgs e)
        {
            // Checks if txtb_SearchBar length is greater than 0,
            // then if it is, either convert the value to int if it is a numerical value
            // and invoke the GetFilteredGuarantors() method that accepts either an int or a string if it is an alphabetical value
            if (txtb_GuarantorSearchBar.Text.Length > 0)
            {
                int parsedValue;
                if (int.TryParse(txtb_GuarantorSearchBar.Text, out parsedValue))
                {
                    guarantorList = guarantorRepository.GetFilteredGuarantors(parsedValue); // Get filtered guarantors based on the parsed integer value
                }
                else
                {
                    guarantorList = guarantorRepository.GetFilteredGuarantors(txtb_GuarantorSearchBar.Text); // Get filtered guarantors based on the string value
                }

                // Set the DataSource property of the guarantorDataGridView to display the filtered guarantor list
                guarantorDataGridView.DataSource = guarantorList;

                // To deselect row in the guarantorDataGridView when the program runs or the method is invoked
                guarantorDataGridView.ClearSelection();
            }
            else
            {
                DisplayGuarantorInformation(); // If the search bar is empty, display all guarantor information
            }
        }

        private void txtb_OfficerSearchBar_TextChanged(object sender, EventArgs e)
        {
            // Checks if txtb_SearchBar length is greater than 0,
            // then if it is, either convert the value to int if it is a numerical value
            // and invoke the GetFilteredGuarantors() method that accepts either an int or a string if it is an alphabetical value
            if (txtb_OfficerSearchBar.Text.Length > 0)
            {
                int parsedValue;
                if (int.TryParse(txtb_OfficerSearchBar.Text, out parsedValue))
                {
                    loanOfficerList = loanOfficerRepository.GetFilteredOfficers(parsedValue); // Get filtered guarantors based on the parsed integer value
                }
                else
                {
                    loanOfficerList = loanOfficerRepository.GetFilteredOfficers(txtb_OfficerSearchBar.Text); // Get filtered guarantors based on the string value
                }

                // Set the DataSource property of the guarantorDataGridView to display the filtered guarantor list
                loanOfficerDataGridView.DataSource = loanOfficerList;

                // To deselect row in the guarantorDataGridView when the program runs or the method is invoked
                loanOfficerDataGridView.ClearSelection();
            }
            else
            {
                DisplayLoanOfficerInformation(); // If the search bar is empty, display all guarantor information
            }
        }

        private void EntitiesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EntitiesTabControl.SelectedIndex == 0)
            {
                clientDataGridView.ClearSelection();
            }

            if (EntitiesTabControl.SelectedIndex == 1)
            {
                guarantorDataGridView.ClearSelection();
            }

            if (EntitiesTabControl.SelectedIndex == 2)
            {
                loanOfficerDataGridView.ClearSelection();
            }
        }

        private void usrCntrlClientGuarantorLender_Load(object sender, EventArgs e)
        {
            clientDataGridView.ClearSelection();
        }
    }
}
