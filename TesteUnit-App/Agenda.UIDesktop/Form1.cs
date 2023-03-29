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

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            txtContatoSalvo.Text = nome;

            try
            {
                string strCon = @"Server=DSV-ANDRELUIS-5;Database=AgendaT; Trusted_Connection=yes;";
                //string strCon = @"Data Source=.\sqlexpress;Initial Catalog=AgendaT; Integrated Security=True;";
                SqlConnection con = new SqlConnection(strCon);
                con.Open();

                string sql = $@"insert into Contato (Id, Nome) values ({Guid.NewGuid().ToString()}, '{nome}'";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                con.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
