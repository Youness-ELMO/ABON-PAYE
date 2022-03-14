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

namespace EFM_REGIO_V4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cnx;
        BindingSource bnd = new BindingSource();
        private void Form2_Load(object sender, EventArgs e)
        {
            cnx = new SqlConnection(@"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=EFM_REGIO_V4;Integrated Security=True");

            


            dataGridView1.Columns.Add("CIN", "CIN");
            dataGridView1.Columns.Add("ADRESSE", "ADRESSE");
            dataGridView1.Columns.Add("tel", "tel");           
            dataGridView1.Columns.Add("NOM", "NOM");




            cnx.Open();
            string dgv = "select * from Client where ACTIVE = 'oui' ";
            SqlCommand cmd = new SqlCommand(dgv,cnx);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r[0], r[4],r[1],r[2],r[3]);
            }

            cnx.Close();

            cnx.Open();
            string af = "select * from Client";
            SqlCommand cmd2= new SqlCommand(af,cnx);
            SqlDataReader rd = cmd2.ExecuteReader();
            DataTable dt= new DataTable();
            dt.Load(rd);

           
            bnd.DataSource = dt;
            textBox1.DataBindings.Add("text",bnd, "CIN");
            textBox4.DataBindings.Add("text", bnd, "NOM");
            textBox3.DataBindings.Add("text", bnd, "tel");
            textBox2.DataBindings.Add("text", bnd, "ADRESSE");

            cnx.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            string aj = "insert into client values('"+textBox1.Text+ "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(aj, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnx.Open();
            string aj = "update client set NOM='" + textBox4.Text + "' , ADRESSE ='" + textBox3.Text + "', tel = '" + textBox3.Text + "' where CIN ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(aj, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnx.Open();
            string de = "update client set ACTIVE='non' where CIN ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(de, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            int d = dataGridView1.CurrentRow.Index;
            textBox1.Text= dataGridView1.Rows[d].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bnd.MoveNext();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bnd.MovePrevious();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bnd.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bnd.MoveLast();
        }
    }
}
