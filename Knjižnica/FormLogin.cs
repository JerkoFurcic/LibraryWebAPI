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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public void GetLogin(string email, int sifra)
        {
            try
            {
                WebClient client = new WebClient();
                String json = client.DownloadString("http://localhost:59403/api/Zaposlenik");
                List<Zaposlenik> zaposleniks = JsonConvert.DeserializeObject<List<Zaposlenik>>(json);
                
            }
            catch (WebException)
            {

            }
        }
    }
}
