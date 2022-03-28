using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace avance
{

  
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        DataTable dt = new DataTable();
        string query;
        MySqlDataAdapter dta = new MySqlDataAdapter();
        MySqlDataReader reader;
        DataSet ds = new DataSet();


        


        string server = "localhost";
        string username = "root";
        string password = "#Pavel15";
        string database = "preparadas";


        private void alta()
        {
            DateTime fecha = DateTime.Now;

            conn.ConnectionString = "server=" + server + ";" + "user id = " + username + ";" +
           "password =" + password + ";" + "database = " + database;

            try
            {
                conn.Open();
                MessageBox.Show("hoy es " + fecha);
                query = "INSERT INTO `preparadas`.`venta` (`total`, `idmesero`, `mesa`, `fecha`, `iddetalle_venta`) " +
                    "VALUES ('1500', '2', '4', '"+fecha+"', '6');"; //prueba de query para meter datos a la tabla venta
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void cambio()
        {
            conn.ConnectionString = "server=" + server + ";" + "user id = " + username + ";" +
           "password =" + password + ";" + "database = " + database;
           
            try
            {

                conn.Open();
                query = "UPDATE `preparadas`.`venta` SET `total` = '1000' WHERE (`idventa` = '4');"; //UPDATE `preparadas`.`venta` SET `total` = '1000' WHERE (`idventa` = '4');
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void upload()
        {
            conn.ConnectionString = "server=" + server + ";" + "user id = " + username + ";" +
            "password =" + password + ";" + "database = " + database;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * FROM preparadas.venta";
            reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            conn.Close();

            dataGridView1.DataSource = dt;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alta();
            upload();
            cambio();
        }
    }
}
