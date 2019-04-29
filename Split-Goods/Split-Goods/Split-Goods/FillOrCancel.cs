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
using System.Text.RegularExpressions;

namespace Split_Goods
{
    public partial class FillOrCancel : Form
    {
        // store the order ID value. 
        private int parsedOrderID;
        // verifies that an order ID is present and contains valid characters.
        private bool IsOrderIDValid()
        {
            // check for input in the order ID text box.
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please specify the order ID.");
                return false;
            }
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                //show message and clear input
                MessageBox.Show("Customer ID must contain only numbers.");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                // convert the text in the text box to an integer to send to the database
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }


        public FillOrCancel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString1))
                {
                    // define a t-sql query string that has a parameter for orderid
                    const string sql = "SELECT * FROM Sales.Orders where orderID = @orderID";
                    // create a SqlCommand object.
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        // define the @orderID parameter and set its value
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();
                            //run the query by calling executereader().
                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                // create a data table to hold the retrieved data.
                                DataTable dataTable = new DataTable();
                                // load the data from sqldatareader into the data table
                                dataTable.Load(dataReader);
                                // display the data from the data table in the data grid view
                                this.dgvCustomerOrders.DataSource = dataTable;
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("The requested order could not be loaded into the form");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void dtpFillDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvCustomerOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FillOrCancel_Load(object sender, EventArgs e)
        {

        }

        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                // create the connection
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString1))
                {
                    // create the sqlcommand object and identity it as a stored procedure
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspCancelOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        // add the order ID input parameter for the stored procedure.
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("The cancel operation was not completed.");

                        }
                        finally
                        {
                            connection.Close();
                        }

                    }
                }
            }
        }

        private void btnFillOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                // create the connection
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString1))
                {
                    //create command and identify it as a stored procedure
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspFillOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        sqlCommand.Parameters.Add(new SqlParameter("@FilledDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@FilledDate"].Value = dtpFillDate.Value;

                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("The fill operation was not completed.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
