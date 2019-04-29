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
    public partial class Iterate_DB : Form
    {
        public Iterate_DB()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIterate_Click(object sender, EventArgs e)
        {
            //string connString = @"server = .\sqlexpress;integrated security = true;database = northwind";
            string filename = "";
            string sourcepath = "";
            string targetpath = "";
            int ID = 0;
            string sql = @"select * from dbo.MoveFile";
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    filename = row["filename"].ToString();
                    sourcepath = row["sourcepath"].ToString();
                    targetpath = row["targetpath"].ToString();
                    ID = Convert.ToInt32(row["ID"].ToString());

                    string sourcefile = System.IO.Path.Combine(sourcepath, filename);
                    string destfile = System.IO.Path.Combine(targetpath, filename);
                    string result = "";
                    
                    if (!Directory.Exists(targetpath))
                    {
                        Directory.CreateDirectory(targetpath);
                    }

                    if (!File.Exists(sourcefile))
                    {

                        result = "File Not Exists";
                    }
                    else
                    {
                        try
                        {
                            File.Move(sourcefile, destfile);
                            result = "File Move Success";
                        }
                        catch (Exception ex)
                        {
                            result = ex.Message;
                        }
                        
                    }

                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString);
                    string sql2 = "Update dbo.MoveFile Set result=@result where ID=@id";
                    using (SqlCommand sqlCommand = new SqlCommand(sql2, connection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@result", result);
                        sqlCommand.Parameters.AddWithValue("@id", ID);
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


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                conn.Close();
            }

            MessageBox.Show("Process completed, please see log for details");

        }
    }
}
