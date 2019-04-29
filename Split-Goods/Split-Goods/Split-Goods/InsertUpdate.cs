using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split_Goods
{
    public partial class InsertUpdate : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.connString);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in updating and deleting record
        int ID = 0 ;

        public InsertUpdate()
        {
            InitializeComponent();
            DisplayData();
        }

        private void InsertUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "" && txt_Status.Text != "")
            {
                cmd = new SqlCommand("insert into table_1(Name, Status) values(@name,@status)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@status", txt_Status.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record inserted sucessfully");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please input data");
            }
        }
        //Display data in DataGridView
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from table_1", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        //Clear Data
        private void ClearData()
        {
            txt_Name.Text = "";
            txt_Status.Text = "";
            ID = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Status.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "" && txt_Status.Text != "")
            {
                cmd = new SqlCommand("update table_1 set name=@name, status=@status where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@status", txt_Status.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please select a record to update");
            }
        }
        //delete record
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete table_1 where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record delete successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please select a record to delete");
            }

        }
        


    }
}
