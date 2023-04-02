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

namespace Knjižnica
{
    public partial class FormPosudbe : Form
    {
        private string urlClass = "Posudba/";
        string cs = "data source=LAPTOP-K71Q5NCK;initial catalog=DBKNJIZNICA;integrated security=True;";
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;

        public FormPosudbe()
        {
            InitializeComponent();
        }

        public void GetAllKnjiznicas()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Knjiznica");
            List<Knjiznica> knjiznicas = JsonConvert.DeserializeObject<List<Knjiznica>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = knjiznicas;
            comboBoxKnjiznicaID.DataSource = bindingSource1.DataSource;
            comboBoxKnjiznicaID.DisplayMember = "KnjiznicaID";
            comboBoxKnjiznicaID.ValueMember = "ID";
            comboBoxKnjiznicaID.SelectedIndex = -1;
            comboBoxKnjiznicaID.SelectedText = "--Select--";
            comboBoxKnjiznicaID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxKnjiznicaID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAllKnjigas()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Knjiga");
            List<Knjiga> knjigas = JsonConvert.DeserializeObject<List<Knjiga>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = knjigas;
            comboBoxKnjigaID.DataSource = bindingSource1.DataSource;
            comboBoxKnjigaID.DisplayMember = "KnjigaID";
            comboBoxKnjigaID.ValueMember = "ID";
            comboBoxKnjigaID.SelectedIndex = -1;
            comboBoxKnjigaID.SelectedText = "--Select--";
            comboBoxKnjigaID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxKnjigaID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAllClans()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Clan");
            List<Clan> clans = JsonConvert.DeserializeObject<List<Clan>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = clans;
            comboBoxClanID.DataSource = bindingSource1.DataSource;
            comboBoxClanID.DisplayMember = "ClanID";
            comboBoxClanID.ValueMember = "ID";
            comboBoxClanID.SelectedIndex = -1;
            comboBoxClanID.SelectedText = "--Select--";
            comboBoxClanID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClanID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAllZaposleniks()
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://localhost:59403/api/Zaposlenik");
            List<Zaposlenik> zaposleniks = JsonConvert.DeserializeObject<List<Zaposlenik>>(json);

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = zaposleniks;
            comboBoxZaposlenikID.DataSource = bindingSource1.DataSource;
            comboBoxZaposlenikID.DisplayMember = "ZaposlenikID";
            comboBoxZaposlenikID.ValueMember = "ID";
            comboBoxZaposlenikID.SelectedIndex = -1;
            comboBoxZaposlenikID.SelectedText = "--Select--";
            comboBoxZaposlenikID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxZaposlenikID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetAll()
        {
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/" + urlClass);
                List<Posudba> posudbas = JsonConvert.DeserializeObject<List<Posudba>>(json);
                dataGridView1.DataSource = posudbas;
            }
            catch (WebException)
            {


            }
        }

        private void AddData()
        {
            Posudba novaPosudba = new Posudba()
            {
                KnjigaID = int.Parse(comboBoxKnjigaID.SelectedValue.ToString()),
                ClanID = int.Parse(comboBoxClanID.SelectedValue.ToString()),
                KnjiznicaID = int.Parse(comboBoxKnjiznicaID.SelectedValue.ToString()),
                ZaposlenikID = int.Parse(comboBoxZaposlenikID.SelectedValue.ToString()),
                DatumPreuzimanja = DateTime.Parse(txtDatumPreuzimanja.Text.Trim()),
                DatumPovratka = EmptyDate()
            };

            var data = JsonConvert.SerializeObject(novaPosudba);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            Posudba novaPosudba = new Posudba()
            {
                KnjigaID = int.Parse(comboBoxKnjigaID.SelectedValue.ToString()),
                ClanID = int.Parse(comboBoxClanID.SelectedValue.ToString()),
                KnjiznicaID = int.Parse(comboBoxKnjiznicaID.SelectedValue.ToString()),
                ZaposlenikID = int.Parse(comboBoxZaposlenikID.SelectedValue.ToString()),
                DatumPreuzimanja = DateTime.Parse(txtDatumPreuzimanja.Text.Trim()),
                DatumPovratka = DateTime.Parse(txtDatumPovratka.Text.Trim()),
                ID = int.Parse(txtID.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(novaPosudba);
            Util.PUT(urlClass, data);
        }

        public void ClearTextData()
        {
            txtID.Text = "";
            comboBoxKnjiznicaID.SelectedIndex = -1;
            comboBoxKnjiznicaID.SelectedText = "";
            comboBoxKnjigaID.SelectedIndex = -1;
            comboBoxKnjigaID.SelectedText = "";
            comboBoxClanID.SelectedIndex = -1;
            comboBoxClanID.SelectedText = "";
            comboBoxZaposlenikID.SelectedIndex = -1;
            comboBoxZaposlenikID.SelectedText = "";
            txtDatumPreuzimanja.Text = "";
            txtDatumPovratka.Text = "";
        }

        public DateTime ? EmptyDate()
        {
            if (txtDatumPovratka.Text == "")
            {
                DateTime? emptyDate = new DateTime();
                return emptyDate;
            }
            else
            {
                DateTime date = DateTime.Parse(txtDatumPovratka.Text);
                return date;
            }
        }

        public void SqlConnection()
        {
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("select * from Posudba as p join Clan as c on p.ClanID = c.ID join Knjiga as k on p.KnjigaID = k.ID ", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void FormPosudbe_Load(object sender, EventArgs e)
        {
            SqlConnection();
            GetAll();
            GetAllKnjiznicas();
            GetAllKnjigas();
            GetAllClans();
            GetAllZaposleniks();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtID.Text = Convert.ToString(dataGridView1[0, row].Value);
            comboBoxKnjiznicaID.SelectedValue = dataGridView1[1, row].Value;
            comboBoxKnjigaID.SelectedValue = dataGridView1[2, row].Value;
            comboBoxClanID.SelectedValue = dataGridView1[3, row].Value;
            comboBoxZaposlenikID.SelectedValue = dataGridView1[4, row].Value;
            txtDatumPreuzimanja.Text = Convert.ToString(dataGridView1[5, row].Value);
            txtDatumPovratka.Text = Convert.ToString(dataGridView1[6, row].Value);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddData();
            ClearTextData();
            GetAll();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearTextData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            UpdateData();
            ClearTextData();
            GetAll();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            Util.Delete(urlClass, id);
            ClearTextData();
            SqlConnection();
            GetAll();
        }

        public void SearchByName()
        {
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("Select p.ID, p.KnjiznicaID, p.KnjigaID, p.ClanID, p.ZaposlenikID, p.DatumPreuzimanja, p.DatumPovratka, c.Ime, c.Prezime, c.Email, k.NazivKnjige, k.Pisac from Posudba as p join Clan as c on p.ClanID = c.ID join Knjiga as k on p.KnjigaID = k.ID where Ime like '" + txtSearch.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByName();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            GetAll();
        }
    }
}
