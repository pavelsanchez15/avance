﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace avance
{

  
    public partial class Form1 : Form
    {
        
        DataTable dt = new DataTable();
        string query;      
        DataSet ds = new DataSet();    

        private void alta()
        {
            DateTime fecha = DateTime.Now;
            string conexion = "Data Source=PAVELAZO;Initial Catalog=preparadas;Integrated Security=True";

            SqlConnection con = new SqlConnection(conexion);

            con.Open();

            query = "INSERT INTO ventaa (total, idmesero, mesa, fecha, iddetalle_venta)"+
                    "VALUES('1500', '2', '4', '" + fecha+ "', '6'); "; //prueba de query para meter datos a la tabla venta

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();      
        }
        
        public void cambio()
        {
            
            string conexion = "Data Source=PAVELAZO;Initial Catalog=preparadas;Integrated Security=True";

            SqlConnection con = new SqlConnection(conexion);

            con.Open();
           
            query = "UPDATE ventaa SET total = '3000' WHERE (idventa = '1');"; //UPDATE `preparadas`.`venta` SET `total` = '1000' WHERE (`idventa` = '4');

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void upload()
        { 
           string conexion = "Data Source=PAVELAZO;Initial Catalog=preparadas;Integrated Security=True";

           SqlConnection con = new SqlConnection(conexion);

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * FROM ventaa";
            var rdr = cmd.ExecuteReader();

            dt.Load(rdr);
            rdr.Close();
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void informe()
        {
           
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
          // alta();
             upload();
          // cambio();
          // informe();


        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
