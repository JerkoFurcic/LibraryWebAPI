using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Knjižnica.ViewModels;

namespace Knjižnica
{
    public partial class FormPosudbe : Form
    {
        private string urlClass = "Posudba/";
        DataTable dt;
        int knjiznicaId = Util.KnjiznicaID;

        public FormPosudbe()
        {
            InitializeComponent();
        }        

        public void GetAllKnjigas()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Knjiga/?knjiznicaID=" + knjiznicaId + "");
            List<KnjigaViewModel> Knjigas = JsonConvert.DeserializeObject<List<KnjigaViewModel>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Knjigas;
            cbKnjigaID.DataSource = bindingSource1.DataSource;
            cbKnjigaID.DisplayMember = "comboBoxName";
            cbKnjigaID.ValueMember = "ID";
            cbKnjigaID.SelectedIndex = -1;
            cbKnjigaID.SelectedText = "--Select--";
            cbKnjigaID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKnjigaID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }    

        public void GetAllClans()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Clan/?knjiznicaID=" + knjiznicaId + "");
            List<ClanViewModel> clans = JsonConvert.DeserializeObject<List<ClanViewModel>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = clans;
            cbClanID.DataSource = bindingSource1.DataSource;
            cbClanID.DisplayMember = "ComboBoxName";
            cbClanID.ValueMember = "ID";
            cbClanID.SelectedIndex = -1;
            cbClanID.SelectedText = "--Select--";
            cbClanID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClanID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAllZaposleniks()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Zaposlenik/?knjiznicaID=" + knjiznicaId + "");
            List<ZaposlenikViewModel> zaposleniks = JsonConvert.DeserializeObject<List<ZaposlenikViewModel>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = zaposleniks;
            cbZaposlenikID.DataSource = bindingSource1.DataSource;
            cbZaposlenikID.DisplayMember = "ComboBoxName";
            cbZaposlenikID.ValueMember = "ID";
            cbZaposlenikID.SelectedIndex = -1;
            cbZaposlenikID.SelectedText = "--Select--";
            cbZaposlenikID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbZaposlenikID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAll()
        {
            try
            {
                string filter = txtSearch.Text;
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/Posudba/?filter=" + filter + "&knjiznicaId=" + knjiznicaId);
                var posudbas = JsonConvert.DeserializeObject<List<PosudbaAllViewModel>>(json);
                dataGridView1.DataSource = posudbas;
            }
            catch (WebException)
            {
                dataGridView1.DataSource = null;
            }
        }

        private void AddData()
        {
            PosudbaViewModel novaPosudba = new PosudbaViewModel()
            {

                KnjigaID = int.Parse(cbKnjigaID.SelectedValue.ToString()),
                ClanID = int.Parse(cbClanID.SelectedValue.ToString()),
                KnjiznicaID = knjiznicaId,
                ZaposlenikID = int.Parse(cbZaposlenikID.SelectedValue.ToString()),
                DatumPreuzimanja = datumPreuzimanja.Value,
            };

            var data = JsonConvert.SerializeObject(novaPosudba);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            PosudbaViewModel novaPosudba = new PosudbaViewModel()
            {
                KnjigaID = int.Parse(cbKnjigaID.SelectedValue.ToString()),
                ClanID = int.Parse(cbClanID.SelectedValue.ToString()),
                KnjiznicaID = knjiznicaId,
                ZaposlenikID = int.Parse(cbZaposlenikID.SelectedValue.ToString()),
                DatumPreuzimanja = datumPreuzimanja.Value,
                DatumPovratka = datumPovratka.Value,
                ID = int.Parse(txtID.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(novaPosudba);
            Util.PUT(urlClass, data);
        }

        public void ClearTextData()
        {
            txtID.Text = "";
            cbKnjigaID.SelectedIndex = -1;
            cbKnjigaID.Text = "--Select--";
            cbClanID.SelectedIndex = -1;
            cbClanID.Text = "--Select--";
            cbZaposlenikID.SelectedIndex = -1;
            cbZaposlenikID.Text = "--Select--";
            datumPovratka.Value = DateTime.Today;
            datumPreuzimanja.Value = DateTime.Today;
        }

        
        private void FormPosudbe_Load(object sender, EventArgs e)
        {
            GetAll();
            GetAllKnjigas();
            GetAllClans();
            GetAllZaposleniks();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtID.Text = Convert.ToString(dataGridView1[0, row].Value);

            cbKnjigaID.SelectedValue = dataGridView1[2, row].Value;
            cbClanID.SelectedValue = dataGridView1[3, row].Value;
            cbZaposlenikID.SelectedValue = dataGridView1[4, row].Value;
            datumPreuzimanja.Text = Convert.ToString(dataGridView1[5, row].Value);
            datumPovratka.Text = Convert.ToString(dataGridView1[6, row].Value);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFields() == true)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearTextData();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetAll();
        }

        private bool CheckFields()
        {
            String empty = "--Select--";

            if (cbClanID.Text == empty || cbKnjigaID.Text == empty || cbZaposlenikID.Text == empty)
            {
                MessageBox.Show("Popunite sva polja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (datumPreuzimanja.Value.Date != DateTime.Today)
            {
                MessageBox.Show("Datum preuzimanja mora biti postavljen na današnji datum", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
