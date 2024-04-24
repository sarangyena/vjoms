using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;


namespace VJOMS
{
    public partial class frmaddJO : Form
    {
        private List<RadTextBox> radTextBoxes;
        private List<RadLabel> radLabels;
        private List<RadButton> radButtons;

        public Int64 JONo { get; set; }
        public string plate { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string company { get; set; }
        public string brand { get; set; }
        public string user { get; set; }

        private string row;




        public frmaddJO()
        {
            InitializeComponent();
            radTextBoxes = new List<RadTextBox>();
            radLabels = new List<RadLabel>();
            radButtons = new List<RadButton>();
        }

        private void cbRegistration_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if(cbRegistration.Checked == true)
            {
                grdRegistration.Enabled = true;
                foreach (RadTextBox radTextBox in radTextBoxes)
                {
                    if(radTextBox.Name == "txtPrev" || radTextBox.Name == "txtPrevAmount" || radTextBox.Name == "txtPrevTotal")
                    {
                        radTextBox.ReadOnly = false;
                    }
                    radTextBox.Enabled = true;
                }
                foreach (RadLabel radLabel in radLabels)
                {
                    radLabel.Enabled = true;
                }
                foreach (RadButton radButton in radButtons)
                {
                    radButton.Enabled = true;
                }
            }
            else
            {
                grdRegistration.Enabled = false;
                foreach (RadTextBox radTextBox in radTextBoxes)
                {
                    if (radTextBox.Name == "txtPrev" || radTextBox.Name == "txtPrevAmount" || radTextBox.Name == "txtPrevTotal")
                    {
                        radTextBox.Enabled = false;
                    }
                    else
                    {
                        radTextBox.Enabled = true;

                    }
                }
                foreach (RadLabel radLabel in radLabels)
                {
                    radLabel.Enabled = false;
                }
                foreach (RadButton radButton in radButtons)
                {
                    radButton.Enabled = false;
                }
            }
            

        }

        private void frmaddJO_Load(object sender, EventArgs e)
        {
            grdJO.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdRegistration.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            txtJO.Text = JONo.ToString();
            DateTime today = DateTime.Today;
            lblDate.Text = today.ToShortDateString();
            radTextBoxes.AddRange(radPanel4.Controls.OfType<RadTextBox>());
            radLabels.AddRange(radPanel4.Controls.OfType<RadLabel>());
            radLabels.AddRange(splitPanel4.Controls.OfType<RadLabel>());
            radTextBoxes.AddRange(splitPanel4.Controls.OfType<RadTextBox>());
            radButtons.AddRange(splitPanel4.Controls.OfType<RadButton>());
            radTextBoxes.AddRange(dwProfile.Controls.OfType<RadTextBox>());

            txtPlate.Text = plate;
            txtBrand.Text = brand;
            txtCompany.Text = company;
            txtUser.Text = user;
            txtModel.Text = model;
            txtYear.Text = year;
            foreach (RadTextBox radTextBox in radTextBoxes)
            {
                if(radTextBox.Name != "txtUser")
                {
                    radTextBox.ReadOnly = true;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDetails.Clear();
            txtAmount.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("details", typeof(string));
            dataTable.Columns.Add("amount", typeof(string));

            // Add sample rows to the DataTable
            dataTable.Rows.Add(1, "John");
            dataTable.Rows.Add(2, "Alice");
            dataTable.Rows.Add(3, "Bob");

            // Bind the DataTable to the RadGridView
            grdJO.DataSource = dataTable;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grdJO.ReadOnly = false;
            foreach (GridViewColumn column in grdJO.Columns)
            {
                column.ReadOnly = false;
            }

        }
    }
}
