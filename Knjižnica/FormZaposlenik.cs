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
    public partial class FormZaposlenik : Form
    {
        private string urlClass = "Zaposlenik/";
        public FormZaposlenik()
        {
            InitializeComponent();
        }

        public void GetAll()
        {
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/" + urlClass);
                List<Zaposlenik> zaposleniks = JsonConvert.DeserializeObject<List<Zaposlenik>>(json);
                dataGridView1.DataSource = zaposleniks;
                dataGridView1.Columns.Remove("ComboBoxName");
            }
            catch (WebException)
            {

            }
        }

        private void AddData()
        {
            Zaposlenik noviZaposlenik = new Zaposlenik()
            {
                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                PocetakRada = DateTime.Parse(txtPocetakRada.Text.Trim()),
                Sifra = int.Parse(txtSifra.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(noviZaposlenik);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            Zaposlenik noviZaposlenik = new Zaposlenik()
            {

                KnjiznicaID = int.Parse(txtKnjiznicaID.Text.Trim()),
                ID = int.Parse(txtID.Text.Trim()),
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                PocetakRada = DateTime.Parse(txtPocetakRada.Text.Trim()),
                Sifra = int.Parse(txtSifra.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(noviZaposlenik);
            Util.PUT(urlClass, data);
        }

        private void FormZaposlenik_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddData();
            ClearTextData();
            GetAll();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            Util.Delete(urlClass, id);
            ClearTextData();
            GetAll();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            UpdateData();
            ClearTextData();
            GetAll();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtKnjiznicaID.Text = Convert.ToString(dataGridView1[0, row].Value);
            txtID.Text = Convert.ToString(dataGridView1[1, row].Value);
            txtIme.Text = Convert.ToString(dataGridView1[2, row].Value);
            txtPrezime.Text = Convert.ToString(dataGridView1[3, row].Value);
            txtEmail.Text = Convert.ToString(dataGridView1[4, row].Value);
            txtSifra.Text = Convert.ToString(dataGridView1[5, row].Value);
            txtKontaktBroj.Text = Convert.ToString(dataGridView1[6, row].Value);
            txtPocetakRada.Text = Convert.ToString(dataGridView1[7, row].Value);
        }

        public void ClearTextData()
        {
            txtEmail.Text = "";
            txtID.Text = "";
            txtIme.Text = "";
            txtKnjiznicaID.Text = "";
            txtKontaktBroj.Text = "";
            txtPocetakRada.Text = "";
            txtPrezime.Text = "";
            txtSifra.Text = "";
        }
    }
}
