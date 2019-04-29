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

namespace Split_Goods
{
    public partial class NewCustomer : Form
    {
        //storage from identity values returned from database
        private int parsedCustomerID;
        private int orderID;

        //verifies that the customer name text box is not empty
        private bool IsCusotmerNameValid()
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter a name");
                return false;
            }
            else
            {
                return true;
            }
        }
        //
        private bool IsOrderDataValid()
        {
            //verify that CustomerID is present
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Please create customer account before placing order");
                return false;

            }
            else if (numOrderAmount.Value < 1 )
            {
                MessageBox.Show("Please specify an order amount.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearForm()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            dtpOrderDate.Value = DateTime.Now;
            numOrderAmount.Value = 0;
            this.parsedCustomerID = 0;
        }


        public NewCustomer()
        {
            InitializeComponent();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (IsCusotmerNameValid())
            {
                // create the connection
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString1))
                {
                    //create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspNewCustomer", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        // add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                        // add the output parameter
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();
                            //run the stored procedure.
                            sqlCommand.ExecuteNonQuery();
                            //customer ID is an Identity value from the database.
                            this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;
                            // put the customer id value into to read-only text box
                            this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);

                        }
                        catch
                        {
                            MessageBox.Show("Customer ID was not returned, Account could not be created.");
                        }
                        finally
                        {
                            connection.Close();
                        }

                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void numOrderAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // ensure the required input is present
            if (IsOrderDataValid())
            {
                // create the connection
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString1))
                {
                    // create sqlcommand and identity it as a stored procedure
                    using (SqlCommand sqlcommand = new SqlCommand("Sales.uspPlaceNewOrder", connection))
                    {
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        // add the @CustomerID input parameter, which was obtained from uspNewCustomer.
                        sqlcommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlcommand.Parameters["@CustomerID"].Value = this.parsedCustomerID;
                        // add the @orderdate input parameter.
                        sqlcommand.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                        sqlcommand.Parameters["@OrderDate"].Value = dtpOrderDate.Value;
                        // add the @amount order amount input parameter.
                        sqlcommand.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int));
                        sqlcommand.Parameters["@Amount"].Value = numOrderAmount.Value;
                        // add the @status order status input parameter
                        // for a new order, the status is always 0 (open)
                        sqlcommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1));
                        sqlcommand.Parameters["@Status"].Value = "0";
                        // add the return value for the stored procedure, which is order ID.
                        sqlcommand.Parameters.Add(new SqlParameter("@RC", SqlDbType.Int));
                        sqlcommand.Parameters["@RC"].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            // open connection.
                            connection.Open();
                            // run the stored procedure.
                            sqlcommand.ExecuteNonQuery();
                            // display the order number.
                            this.orderID = (int)sqlcommand.Parameters["@RC"].Value;
                            MessageBox.Show("Order number " + this.orderID + " has been submitted.");
                            
                        }
                        catch
                        {
                            MessageBox.Show("Order could not be placed");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
