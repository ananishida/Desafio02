using DESAFIO.dal;
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

namespace desafio2
{
    public partial class DESAFIO : Form
    {
        public DESAFIO()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[remedio] ([nome],[horario]) VALUES (@nome, @horario);SELECT SCOPE_IDENTITY();";
            sqlCommand.Parameters.AddWithValue("@nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@horario", dateTimePicker1.Value);
            db.Executar(sqlCommand);

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from remedio ";
            dataGridView1.DataSource = db.Consulta(sqlCommand);

            MessageBox.Show("Cadastrado com sucesso");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                DateTime horario = Convert.ToDateTime(item.Cells[2].Value);
                if (horario.Hour == DateTime.Now.Hour && horario.Minute == DateTime.Now.Minute)
                {
                    label3.Text = "Hora de tomar o seu rémedio: " + item.Cells[1].Value;
                    MessageBox.Show(label3.Text);

                }
            }
        }

        private void DESAFIO_Load(object sender, EventArgs e)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from remedio ";
            dataGridView1.DataSource = db.Consulta(sqlCommand);
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             var db = new BandoDados();
            var sqlCommand = new SqlCommand();

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Delete remedio Select 1";
            db.Executar(sqlCommand);

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from remedio ";
            dataGridView1.DataSource = db.Consulta(sqlCommand);

            MessageBox.Show("Cadastro deletado!");

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var itemToDelete = dataGridView1.SelectedRows[0].Cells;
            int id =(int) itemToDelete[0].Value;
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Delete remedio where id = @id Select 1";
            sqlCommand.Parameters.AddWithValue("@id", id);
            db.Executar(sqlCommand);

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select * from remedio ";
            dataGridView1.DataSource = db.Consulta(sqlCommand);

            MessageBox.Show("Registro deletado!");
        }
    }
}
