using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Bioskop.Forme
{
    /// <summary>
    /// Interaction logic for Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Film()
        {
            InitializeComponent();
            txtNazivFilma.Focus();
            try
            {
                konekcija.Open();
                string vratiZanr = @"select ZanrID, Zanr from tblZanrFilma";
                DataTable dtZanr = new DataTable();
                SqlDataAdapter daZanr = new SqlDataAdapter(vratiZanr, konekcija);
                daZanr.Fill(dtZanr);
                cmbZanr.ItemsSource = dtZanr.DefaultView;

                string vratiKartu = @"select KorisnikID, ImeKorisnika from tblKorisnik";
                DataTable dtKarta = new DataTable();
                SqlDataAdapter daKarta = new SqlDataAdapter(vratiKartu, konekcija);
                daKarta.Fill(dtKarta);
                cmbKarta.ItemsSource = dtKarta.DefaultView;

                string vratiZaposlenog = @"select ZaposleniID,ImeZaposlenog from tblZaposleni";
                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlenog, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cmbZaposleni.ItemsSource = dtZaposleni.DefaultView;



            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnSacuvaj_Click(object sender,RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = (DataRowView)MainWindow.selektovan;
                    string update = @"Update tblFilm Set NazivFilma ='" + txtNazivFilma.Text + "' , GodinaObjavljivanja = '" + txtGodinaObj.Text + "'," +
                                    " ZanrID = '" + cmbZanr.SelectedValue + "', " + " KorisnikID= " + cmbKarta.SelectedValue +
                                    ", ZaposleniID = " + cmbZaposleni.SelectedValue + " Where FilmID =" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.selektovan = null;
                    this.Close();

                }
                else
                {
                    string insert = @"insert into tblFilm(NazivFilma,GodinaObjavljivanja,zanrID,KorisnikID,ZaposleniID)values('" + txtNazivFilma.Text + "','" + txtGodinaObj.Text + "','" + cmbZanr.SelectedValue + "','" + cmbKarta.SelectedValue + "','" + cmbZaposleni.SelectedValue + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                
            }
            catch(SqlException)
            {
                MessageBox.Show("unos odredjenih vrijednosti nije validan!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija!=null)
                {
                    konekcija.Close();
                }
                
            }
        }
        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
