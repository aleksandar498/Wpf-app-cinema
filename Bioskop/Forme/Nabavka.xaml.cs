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
    /// Interaction logic for Nabavka.xaml
    /// </summary>
    public partial class Nabavka : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Nabavka()
        {
           
            InitializeComponent();
            txtKolRobe.Focus();
            try
            {
                konekcija.Open();
                string vratiDobavljaca = @"select DobavljacID, NazivDobavljaca from tblDobavljac";
                DataTable dtDobavljac = new DataTable();
                SqlDataAdapter daDobavljac = new SqlDataAdapter(vratiDobavljaca, konekcija);
                daDobavljac.Fill(dtDobavljac);
                cmbDobavljac.ItemsSource = dtDobavljac.DefaultView;

                string vratiFilm = @"select FilmID, NazivFilma from tblFilm";
                DataTable dtFilm = new DataTable();
                SqlDataAdapter daFilm = new SqlDataAdapter(vratiFilm, konekcija);
                daFilm.Fill(dtFilm);
                cmbFilm.ItemsSource = dtFilm.DefaultView;

                


            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            
                try
                {
                    konekcija.Open();

                    if (MainWindow.azuriraj)
                    {
                        DataRowView red = (DataRowView)MainWindow.selektovan;
                    string update = @"Update tblNabavka Set KolicinaRobe ='" + txtKolRobe.Text + "' , CijenaRobe = '" + txtCijena.Text + "'," +
                                " DatumNabavke = '" + date.SelectedDate + "', " + " FilmID= " + cmbFilm.SelectedValue +
                                ", DobavljacID = " + cmbDobavljac.SelectedValue + " Where NabavkaID =" + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                        MainWindow.selektovan = null;
                        this.Close();

                    }

                else
                {
                    string insert = @"insert into tblNabavka(KolicinaRobe,DatumNabavke,CijenaRobe,FilmID,DobavljacID)
                                values ('" + txtKolRobe.Text + "', '" + date.SelectedDate + "', '" + txtCijena.Text + "', " + cmbFilm.SelectedValue + "," +cmbDobavljac.SelectedValue + ");";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("unos odredjenih vrijednosti nije validan!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
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
