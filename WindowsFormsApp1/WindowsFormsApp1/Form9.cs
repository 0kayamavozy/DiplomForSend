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

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        public void Stations(string numbertrain)
        {
            string sqlConnection = $@"Data Source={Global.HostServer};Initial Catalog=TrainDataBase;Integrated Security=True";
            string query = "select * from TrainsStations where TrainName = @Train";

            SqlConnection connection = new SqlConnection(sqlConnection);

            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Train", numbertrain);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    label1.Text = reader.GetString(0);
                    label2.Text = reader.GetString(1);
                    label3.Text = reader.GetString(2);
                    label4.Text = reader.GetString(3);
                    label5.Text = reader.GetString(4);
                    label6.Text = reader.GetString(5);
                    label7.Text = reader.GetString(6);
                    label8.Text = reader.GetString(7);
                    label9.Text = reader.GetString(8);
                    label14.Text = reader.GetString(9);
                    label13.Text = reader.GetString(10);
                }
                reader.Close();
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Stations(Global.SetStations);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
