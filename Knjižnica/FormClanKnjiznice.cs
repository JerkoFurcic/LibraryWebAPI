using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjižnica
{
    public partial class FormClanKnjiznice : Form
    {
        private string urlClass = "Clan/";
        public FormClanKnjiznice()
        {
            InitializeComponent();
        }

        private void FormClanKnjiznice_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/" + urlClass);
                List<Clan> clans = JsonConvert.DeserializeObject<List<Clan>>(json);
                dataGridView1.DataSource = clans;
                dataGridView1.Columns.Remove("ComboBoxName");
            }
            catch (WebException)
            {


            }
        }

        private void AddData()
        {
            Clan noviClanKnjiznice = new Clan()
            {
                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                ClanarinaVrijediDo = DateTime.Parse(txtClanarinaVrijediDo.Text.Trim())

            };
            var data = JsonConvert.SerializeObject(noviClanKnjiznice);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            Clan noviClanKnjiznice = new Clan()
            {
                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
                ID = int.Parse(txtID.Text.Trim()),
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                ClanarinaVrijediDo = DateTime.Parse(txtClanarinaVrijediDo.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(noviClanKnjiznice);
            Util.PUT(urlClass, data);
        }

        public void ClearTextData()
        {
            txtKnjiznicaID.Text = "";
            txtID.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtEmail.Text = "";
            txtKontaktBroj.Text = "";
            txtClanarinaVrijediDo.Text = "";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                AddData();
                ClearTextData();
                GetAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                Util.Delete(urlClass, id);
                ClearTextData();
                GetAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error");
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtKnjiznicaID.Text = Convert.ToString(dataGridView1[0, row].Value);
            txtID.Text = Convert.ToString(dataGridView1[1, row].Value);
            txtIme.Text = Convert.ToString(dataGridView1[2, row].Value);
            txtPrezime.Text = Convert.ToString(dataGridView1[3, row].Value);
            txtEmail.Text = Convert.ToString(dataGridView1[4, row].Value);
            txtKontaktBroj.Text = Convert.ToString(dataGridView1[5, row].Value);
            txtClanarinaVrijediDo.Text = Convert.ToString(dataGridView1[6, row].Value);
        }

    }
}
