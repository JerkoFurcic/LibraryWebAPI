using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using Knjižnica.ViewModels;

namespace Knjižnica
{
    public partial class FormKnjige : Form
    {
        private string urlClass = "Knjiga/";

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
            int knjiznicaId = Util.KnjiznicaID;
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/Knjiga/?knjiznicaID=" + knjiznicaId + "");
                List<KnjigaViewModel> knjigas = JsonConvert.DeserializeObject<List<KnjigaViewModel>>(json);
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
                if (txtNazivKnjige.Text == "" || txtPisac.Text == "")
                {
                    MessageBox.Show("Popunite sva polja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddData()
        {
            KnjigaViewModel novaKnjiga = new KnjigaViewModel()
            {
                NazivKnjige = txtNazivKnjige.Text.Trim(),
                Pisac = txtPisac.Text.Trim(),
                KnjiznicaID = Util.KnjiznicaID
            };

            var data = JsonConvert.SerializeObject(novaKnjiga);
            Util.POST(urlClass, data);
        }

        private void UpdateData()
        {
            KnjigaViewModel novaKnjiga = new KnjigaViewModel()
            {
                NazivKnjige = txtNazivKnjige.Text.Trim(),
                Pisac = txtPisac.Text.Trim(),
                KnjiznicaID = Util.KnjiznicaID,
                ID = int.Parse(txtID.Text.Trim())
            };

            var data = JsonConvert.SerializeObject(novaKnjiga);
            Util.PUT(urlClass, data);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
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
            catch (FormatException)
            {
                MessageBox.Show("Error");
            }
        }

        public void ClearTextData()
        {
            txtID.Text = "";
            txtNazivKnjige.Text = "";
            txtPisac.Text = "";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearTextData();
        }

        
        
    }


}

