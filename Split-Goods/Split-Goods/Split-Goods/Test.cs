using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split_Goods
{
    public partial class Test : Form
    {
        //定义产品序列号
        private string sn;
        //定义批次号
        private string currentsn;
        //定义绿线圈批次号
        private string coilsn;
        //定义同批次的产品数量
        private int counter = 0 ;
        //定义已存在的序列号数量，如该值>1，则为重复扫号，系统告警
        private int result = 0;

        private bool IsCurrentSNValid()
        {
            if (txtCurrentSN.Text == "")
            {
                MessageBox.Show("Please enter a batch number!");
                return false;
            }
            else if (txtCurrentSN.Text.Length < 6)
            {
                MessageBox.Show("Batch number length is less than 6 characters!");
                return false;
            }
            else
            {
                currentsn = txtCurrentSN.Text;
                return true;
            }
        }

        private bool IsSNValid()
        {
            if (txtSN.Text == "")
            {
                MessageBox.Show("Please enter a SN!");
                return false;
            }
            else if (txtSN.Text.Length < 4)
            {
                MessageBox.Show("SN length is less than 4 characters!");
                return false;
            }
            else
            {
                sn = txtSN.Text;
                return true;
            }
        }

        private bool IsCoilSNValid()
        {
            if (txtCoilSN.Text == "")
            {
                MessageBox.Show("Please enter a coil SN");
                return false;
            }
            else if (txtCoilSN.Text.Length < 6)
            {
                MessageBox.Show("Coil SN length is less than 6 characters");
                return false;
            }
            else
            {
                coilsn = txtCoilSN.Text;
                return true;
            }
        }

        public Test()
        {
            InitializeComponent();
        }

        private void Serial_No_Click(object sender, EventArgs e)
        {

        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validate();
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void download()
        {
            if (IsCurrentSNValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    const string sql = "SELECT * FROM Sales.Test Where batch = @batch Order by TestID Desc";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@batch", currentsn);
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
                                this.dataGridView1.DataSource = dataTable;
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("The requested data could not be loaded into the form");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }

                //get the counts of SN after user entered the batch number
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    string sql = "Select Count (*) From Sales.Test Where batch = @batch";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@batch", currentsn);
                        try
                        {
                            connection.Open();
                            counter = ((int)sqlCommand.ExecuteScalar());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                    if (counter > 0)
                    {
                        this.txtCounter.Text = Convert.ToString(counter);
                    }


                }
            }
            
        }

        private void validate()
        {
            if (IsCurrentSNValid())
            {
                if (IsCoilSNValid())
                {                
                    if (IsSNValid())
                    {
                        if (sn.Substring(0, 4) != currentsn.Substring(2, 4))
                        {
                            MessageBox.Show("Serial Number does not match the batch number");
                        }
                        else
                        {

                            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                            {
                                string sql = "Select Count (*) From Sales.Test Where sn = @sn";
                                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                                {
                                    sqlCommand.CommandType = CommandType.Text;
                                    sqlCommand.Parameters.AddWithValue("@sn", sn);
                                    try
                                    {
                                        connection.Open();
                                        result = ((int)sqlCommand.ExecuteScalar());
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        connection.Close();
                                    }
                                }

                                if (result > 0)
                                {
                                    MessageBox.Show("Serial Number already existed in database");
                                }
                                else
                                {
                                    string sql2 = "INSERT INTO Sales.Test (SN,Batch,CoilSN) VALUES (@sn,@batch,@coilsn)";
                                    using (SqlCommand sqlCommand = new SqlCommand(sql2, connection))
                                    {
                                        sqlCommand.CommandType = CommandType.Text;
                                        sqlCommand.Parameters.AddWithValue("@sn", sn);
                                        sqlCommand.Parameters.AddWithValue("@batch", currentsn);
                                        sqlCommand.Parameters.AddWithValue("@coilsn", coilsn);
                                        try
                                        {
                                            connection.Open();
                                            sqlCommand.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        finally
                                        {
                                            connection.Close();
                                        }
                                    }

                                    // counter +1
                                    counter = counter + 1;
                                    this.txtCounter.Text = Convert.ToString(counter);

                                }


                            }
                            // display data in gridview
                            download();


                        }
                        txtSN.Clear();

                    }
            }
            }
        }

        private void txtCurrentSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCounter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCurrentSN.Enabled == true)
            {
                txtCurrentSN.Enabled = false;
                btnConfirm.Text = "Unlock";
                download();
            }
            else
            {
                txtCurrentSN.Enabled = true;
                btnConfirm.Text = "Lock";
            }

            //download();


            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ToCsv(DataGridView dGV, string filename)
        {
            string stOutput = "";
            //export title:
            string sHeader = "";
            sHeader = sHeader + "外箱批号" + "\t" + "外箱箱号" + "\t" + "内盒批号" + "\t" + "产品序列号" + "\t";
            //for (int j = 1; j < dGV.Columns.Count; j++)
            //    sHeader = sHeader.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            sHeader = sHeader + "绿线圈批次号" + "\t";
            stOutput += sHeader + "\r\n";
            //export data
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                stLine = stLine + "\t" + "\t";
                for (int j = 1; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stLine = stLine + "\t";
                stOutput += stLine + "\r\n";
                
            }
            //Encoding utf16 = Encoding.GetEncoding(1254);
            Encoding utf16 = Encoding.GetEncoding("GB2312");
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();

        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsv(dataGridView1, @"C:\export.xls");
                ToCsv(dataGridView1, sfd.FileName);
            }
        }

        private void btnCoil_Click(object sender, EventArgs e)
        {
            if (txtCoilSN.Enabled == true)
            {
                txtCoilSN.Enabled = false;
                btnCoil.Text = "Unlock";        
            }
            else
            {
                txtCoilSN.Enabled = true;
                btnCoil.Text = "Lock";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
