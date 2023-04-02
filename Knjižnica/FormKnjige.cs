using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace Knjižnica
{
    public partial class FormKnjige : Form
    {
        private string urlClass = "Knjiga/";
        string cs = "data source=LAPTOP-K71Q5NCK;initial catalog=DBKNJIZNICA;integrated security=True;";
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;

        public FormKnjige()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/" + urlClass);
                List<Knjiga> knjigas = JsonConvert.DeserializeObject<List<Knjiga>>(json);
                dataGridView1.DataSource = knjigas;
                dataGridView1.Columns.Remove("ComboBoxName");
            }
            catch (WebException)
            {

            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                AddData();
            }
            catch (FormatException)
            {
                MessageBox.Show("Test");
            }
            ClearTextData();
            GetAll();
        }

        private void AddData()
        {
            Knjiga novaKnjiga = new Knjiga()
            {
                NazivKnjige = txtNazivKnjige.Text.Trim(),
                Pisac = txtPisac.Text.Trim(),
                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
            };
            
            var data = JsonConvert.SerializeObject(novaKnjiga);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            Knjiga novaKnjiga = new Knjiga()
            {
                NazivKnjige = txtNazivKnjige.Text.Trim(),
                Pisac = txtPisac.Text.Trim(),
                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
                ID = int.Parse(txtID.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(novaKnjiga);
            Util.PUT(urlClass, data);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtKnjiznicaID.Text = Convert.ToString(dataGridView1[0, row].Value);
            txtID.Text = Convert.ToString(dataGridView1[1, row].Value);
            txtNazivKnjige.Text = Convert.ToString(dataGridView1[2, row].Value);
            txtPisac.Text = Convert.ToString(dataGridView1[3, row].Value);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                Util.Delete(urlClass, id);
                ClearTextData();
                SqlConnection();
                GetAll();
            }
            catch (FormatException)
            {
                GetAll();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateData();
                ClearTextData();
                GetAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error");
            }
        }

        public void ClearTextData()
        {
            txtID.Text = "";
            txtKnjiznicaID.Text = "";
            txtNazivKnjige.Text = "";
            txtPisac.Text = "";
        }

        public void SqlConnection()
        {
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("select * from Knjiga", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        
    }


}

