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
using Knjižnica.ViewModels;

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
            int knjiznicaId = Util.KnjiznicaID;
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/Zaposlenik/?knjiznicaID=" + knjiznicaId + "");
                List<ZaposlenikViewModel> zaposleniks = JsonConvert.DeserializeObject<List<ZaposlenikViewModel>>(json);
                dataGridView1.DataSource = zaposleniks;
                dataGridView1.Columns.Remove("ComboBoxName");
            }
            catch (WebException)
            {

            }
        }

        private void AddData()
        {
            ZaposlenikViewModel noviZaposlenik = new ZaposlenikViewModel()
            {
                KnjiznicaID = Util.KnjiznicaID,
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                PocetakRada = txtPocetakRada.Value,
                Sifra = int.Parse(txtSifra.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(noviZaposlenik);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            ZaposlenikViewModel noviZaposlenik = new ZaposlenikViewModel()
            {
                KnjiznicaID = Util.KnjiznicaID,
                ID = int.Parse(txtID.Text.Trim()),
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                KontaktBroj = txtKontaktBroj.Text.Trim(),
                PocetakRada = txtPocetakRada.Value,
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
            try
            {
                if (txtIme.Text == "" || txtPrezime.Text == "" || txtSifra.Text == "" || txtKontaktBroj.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("popunite sva polja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AddData();
                    ClearTextData();
                    GetAll();
                }
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

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
            catch (Exception)
            {

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

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearTextData();
        }
    }
}
