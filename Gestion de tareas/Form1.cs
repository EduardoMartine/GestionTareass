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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_de_tareas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection("server= ALDO\\SQLEXPRESS; database=ListaDeTareas; integrated security= true;");
            cone.Open();
            MessageBox.Show("Conectado");
            string tarea = comboBox1.Text;
            string descri = richTextBox1.Text;


            string cadena = "Insert into Tareas(Tarea,Descripcion,Estado) values('" + tarea + "','" + descri + "','Pendiente')";
            SqlCommand comand = new SqlCommand(cadena, cone);
            comand.ExecuteNonQuery();
            cone.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection("server= ALDO\\SQLEXPRESS; database=ListaDeTareas; integrated security= true;");
            cone.Open();

            string query = "SELECT Tarea,Descripcion,Estado FROM Tareas";
            SqlCommand comand = new SqlCommand(query, cone);
            SqlDataReader reader = comand.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {

                string tareaInfo = $"{reader["Tarea"].ToString()}{reader["Descripcion"].ToString()}{reader["Estado"].ToString()}";


                listBox1.Items.Add(tareaInfo);
            }

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string nombre = comboBox1.Text;
            SqlConnection cone = new SqlConnection("server= ALDO\\SQLEXPRESS; database=ListaDeTareas; integrated security= true;");
            cone.Open();
            string query2 = "UPDATE Tareas SET Estado = 'Completado' WHERE Tarea = '" + nombre + "'";
            SqlCommand comando = new SqlCommand(query2, cone);
            comando.ExecuteNonQuery();
            cone.Close();



        }

        private void comboBox1_SelectedIndexChanged_Load(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            SqlCommand comand = new SqlCommand();
            DataTable tabla = new DataTable();

            SqlConnection cone = new SqlConnection("server=ALDO\\SQLEXPRESS; database=ListaDeTareas; integrated security=true;");
            cone.Open();
            comand.Connection = cone;
            comand.CommandType = CommandType.Text;
            comand.CommandText = "SELECT Tarea FROM Tareas";
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            adapter.Fill(tabla);

            comboBox1.DataSource = tabla;
            comboBox1.DisplayMember = "Tarea";
            comboBox1.ValueMember = "Tarea";
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string nombre = comboBox1.Text;
            SqlConnection cone = new SqlConnection("server= ALDO\\SQLEXPRESS; database=ListaDeTareas; integrated security= true;");
            cone.Open();
            string query3 = "DELETE FROM Tareas WHERE Tarea = '" + nombre + "'"; ;
            SqlCommand comando = new SqlCommand(query3, cone);
            comando.ExecuteNonQuery();
            MessageBox.Show("Eliminado");
            cone.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                
                Color colorSeleccionado = colorDialog.Color;

                
                this.BackColor = colorSeleccionado;
            }
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                
                Font fuenteSeleccionada = fontDialog.Font;

                
                listBox1.Font = fuenteSeleccionada;
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
