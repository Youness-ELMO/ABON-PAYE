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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection cnx;
        DataSet ds = new DataSet();
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'eFM_REGIO_V4DataSet.PAYEMENTS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pAYEMENTSTableAdapter.Fill(this.eFM_REGIO_V4DataSet.PAYEMENTS);

            cnx = new SqlConnection(@"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=EFM_REGIO_V4;Integrated Security=True");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int i = 0;
            cnx.Open();
            string ch = "select PAYEMENTS.ID_ABONN,PERIODE ,TOTAL from PAYEMENTS join ABONNEMENTS on PAYEMENTS.ID_ABONN=ABONNEMENTS.ID_ABONN where PAYE = 'non' and CIN = '" + textBox1.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(ch, cnx);
            da.Fill(ds, "PAYEMENTS");

            dataGridView1.DataSource = ds.Tables["PAYEMENTS"];
            //sqldatareader r = cmd.executereader();
            //while (r.read())
            //{

            //    datagridview1.rows[i].cells[1].value = r[0];
            //    datagridview1.rows[i].cells[2].value = r[1];
            //    datagridview1.rows[i].cells[3].value = r[2];
            //    i++;

            //}
            //r.close();
            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float som = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    som += float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                    int id = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    DateTime pr = (DateTime)dataGridView1.Rows[i].Cells[2].Value;
                    cnx.Open();
                    string md = "update PAYEMENTS set PAYE='oui' where ID_ABONN=" + id + " and  PERIODE ='" + pr + "'";
                    SqlCommand cmd = new SqlCommand(md, cnx);
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                }
            }
            label4.Text= som.ToString();
        }
    }
}

