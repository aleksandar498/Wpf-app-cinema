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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using Bioskop.Forme;


namespace Bioskop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool azuriraj;
        public static object selektovan;
        static SqlConnection konekcija = Konekcija.KreirajKonekciju();
        private static void PocetniDataGrid(DataGrid grid)
        {
            try
            {
                konekcija.Open();
                string upit = @"Select FilmID as ID,NazivFilma as 'Naziv Filma',GodinaObjavljivanja,Zanr as 'Zanr',ImeZaposlenog+''+PreimeZaposlenog as 'Zaposleni',ImeKorisnika+''+PrezimeKorisnika as 'Rezervisao'
                            from tblFilm inner join tblZanrFilma on tblFilm.ZanrID = tblZanrFilma.ZanrID
                                            inner join tblZaposleni on tblFilm.ZaposleniID = tblZaposleni.ZaposleniID
 inner join tblKorisnik on tblFilm.KorisnikID = tblKorisnik.KorisnikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Film");
                dataAdapter.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(CentralGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)//klik na dugme film
        {
            btnDodajFilm.Visibility = Visibility.Visible;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;            
            btnDodajZanr.Visibility = Visibility.Collapsed;
            btnDodajZaposleni.Visibility = Visibility.Collapsed;

            btnIzmjeniFilm.Visibility = Visibility.Visible;
            btnIzmjeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmjeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmjeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmjeniZanr.Visibility = Visibility.Collapsed;
            btnIzmjeniZaposleni.Visibility = Visibility.Collapsed;

            btnObrisiFilm.Visibility = Visibility.Visible;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiZanr.Visibility = Visibility.Collapsed;
            btnObrisiZaposleni.Visibility = Visibility.Collapsed;

            PocetniDataGrid(CentralGrid);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//klik na dugme dobavljac
        {

            btnDodajFilm.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Visible;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajZanr.Visibility = Visibility.Collapsed;
            btnDodajZaposleni.Visibility = Visibility.Collapsed;

            btnIzmjeniFilm.Visibility = Visibility.Collapsed;
            btnIzmjeniDobavljaca.Visibility = Visibility.Visible;
            btnIzmjeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmjeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmjeniZanr.Visibility = Visibility.Collapsed;
            btnIzmjeniZaposleni.Visibility = Visibility.Collapsed;

            btnObrisiFilm.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Visible;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiZanr.Visibility = Visibility.Collapsed;
            btnObrisiZaposleni.Visibility = Visibility.Collapsed;

            try
            {
                
                konekcija.Open();
                string upit = @"Select DobavljacID as ID,NazivDobavljaca as 'Naziv Dobavljaca',AdresaDobavljaca as'Adresa Dobavljaca',KontaktDobavljaca as 'Kontakt Dobavljaca' from tblDobavljac" ;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Dobavljac");
                dataAdapter.Fill(dt);
                CentralGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            btnDodajFilm.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Visible;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajZanr.Visibility = Visibility.Collapsed;
            btnDodajZaposleni.Visibility = Visibility.Collapsed;

            btnIzmjeniFilm.Visibility = Visibility.Collapsed;
            btnIzmjeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmjeniKorisnika.Visibility = Visibility.Visible;
            btnIzmjeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmjeniZanr.Visibility = Visibility.Collapsed;
            btnIzmjeniZaposleni.Visibility = Visibility.Collapsed;

            btnObrisiFilm.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Visible;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
           btnObrisiZanr.Visibility = Visibility.Collapsed;
            btnObrisiZaposleni.Visibility = Visibility.Collapsed;

            try
            {
                
                konekcija.Open();
                string upit = @"Select KorisnikID as ID,ImeKorisnika as 'Ime Korisnika',PrezimeKorisnika as 'Prezime Korisnika',
BrojRacuna as 'Broj Racuna',AdresaClana as 'Adresa Clana',KontaktClana as 'Kontakt Clana' from tblKorisnik";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Korisnik");
                dataAdapter.Fill(dt);
                CentralGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        } //klik na dugme korisnik

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            btnDodajFilm.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Visible;
            btnDodajZanr.Visibility = Visibility.Collapsed;
            btnDodajZaposleni.Visibility = Visibility.Collapsed;

            btnIzmjeniFilm.Visibility = Visibility.Collapsed;
            btnIzmjeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmjeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmjeniNabavku.Visibility = Visibility.Visible;
            btnIzmjeniZanr.Visibility = Visibility.Collapsed;
            btnIzmjeniZaposleni.Visibility = Visibility.Collapsed;

            btnObrisiFilm.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Visible;
           btnObrisiZanr.Visibility = Visibility.Collapsed;
            btnObrisiZaposleni.Visibility = Visibility.Collapsed;

            try
            {
                
                konekcija.Open();
                string upit = @"Select NabavkaID as ID,KolicinaRobe as 'Kolicina Robe',DatumNabavke as 'Datum Nabavke',CijenaRobe as 'Cijena Robe',NazivDobavljaca as 'Dobavljac',NazivFilma as 'Film' 
                            from tblNabavka inner join tblDobavljac on tblNabavka.DobavljacID = tblDobavljac.DobavljacID
                                            inner join tblFilm on tblNabavka.FilmID = tblFilm.FilmID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Nabavka");
                dataAdapter.Fill(dt);
                CentralGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }//Klik na dugme nabavka

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            btnDodajFilm.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajZanr.Visibility = Visibility.Visible;
            btnDodajZaposleni.Visibility = Visibility.Collapsed;

            btnIzmjeniFilm.Visibility = Visibility.Collapsed;
            btnIzmjeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmjeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmjeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmjeniZanr.Visibility = Visibility.Visible;
            btnIzmjeniZaposleni.Visibility = Visibility.Collapsed;

            btnObrisiFilm.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
           btnObrisiZanr.Visibility = Visibility.Visible;
            btnObrisiZaposleni.Visibility = Visibility.Collapsed;

            try
            {
                
                konekcija.Open();
                string upit = @"Select ZanrID as ID,Zanr as Zanr from tblZanrFilma";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("ZanrFilma");
                dataAdapter.Fill(dt);
                CentralGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }//klik na dugme zanr

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            btnDodajFilm.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajZanr.Visibility = Visibility.Collapsed;
            btnDodajZaposleni.Visibility = Visibility.Visible;

            btnIzmjeniFilm.Visibility = Visibility.Collapsed;
            btnIzmjeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmjeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmjeniNabavku.Visibility = Visibility.Collapsed;
           btnIzmjeniZanr.Visibility = Visibility.Collapsed;
            btnIzmjeniZaposleni.Visibility = Visibility.Visible;

            btnObrisiFilm.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
           btnObrisiZanr.Visibility = Visibility.Collapsed;
            btnObrisiZaposleni.Visibility = Visibility.Visible;

            try
            {
                
                konekcija.Open();
                string upit = @"Select ZaposleniID as ID,ImeZaposlenog as 'Ime Zaposlenog',
PreimeZaposlenog as 'Prezime Zaposlenog',Username as 'Username',Password as 'Password' from tblZaposleni";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Zaposleni");
                dataAdapter.Fill(dt);
                CentralGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }//klik na dugme zaposleni

        private void btnDodajFilm_Click(object sender, RoutedEventArgs e)
        {
            Film prozor = new Film();
            prozor.ShowDialog();
            PocetniDataGrid(CentralGrid);
        }

        private void btnIzmjeniFilm_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                azuriraj = true;
                Film prozor = new Film();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select * from tblFilm where FilmID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtNazivFilma.Text = citac["NazivFilma"].ToString();
                    prozor.txtGodinaObj.Text = citac["GodinaObjavljivanja"].ToString();
                    prozor.cmbZanr.SelectedValue = citac["ZanrID"].ToString();

                    prozor.cmbKarta.SelectedValue = citac["KorisnikID"].ToString();
                    prozor.cmbZaposleni.SelectedValue = citac["ZaposleniID"].ToString();

                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblFilm where FilmID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                PocetniDataGrid(CentralGrid);
            }
        }

        private void btnIzmjeniDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                Dobavljac prozor = new Dobavljac();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select NazivDobavljaca,AdresaDobavljaca,KontaktDobavljaca from tblDobavljac where DobavljacID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit,konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtNazivDobavljaca.Text = citac["NazivDobavljaca"].ToString();
                    prozor.txtAdresa.Text = citac["AdresaDobavljaca"].ToString();
                    prozor.txtKontakt.Text = citac["KontaktDobavljaca"].ToString();
                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_1(sender, e);
                azuriraj = false;
            }
        }

        private void btnDodajDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            Dobavljac prozor = new Dobavljac();
            prozor.ShowDialog();
            Button_Click_1(sender, e);

        }

        private void btnObrisiDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblDobavljac where DobavljacID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit,konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_1(sender, e);
            }

        }

        

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblKorisnik where KorisnikID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_3(sender, e);
            }
        }

        private void btnIzmjeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                Korisnik prozor = new Korisnik();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select ImeKorisnika,PrezimeKorisnika,BrojRacuna,AdresaClana,KontaktClana from tblKorisnik where KorisnikID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtImeKor.Text = citac["ImeKorisnika"].ToString();
                    prozor.txtPrezKor.Text = citac["PrezimeKorisnika"].ToString();
                    prozor.txtBrojRac.Text = citac["BrojRacuna"].ToString();

                    prozor.txtADresa.Text = citac["AdresaClana"].ToString();
                    prozor.txtKontakt.Text = citac["KontaktClana"].ToString();
                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_3(sender, e);
                azuriraj = false;
            }
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            Korisnik prozor = new Korisnik();
            prozor.ShowDialog();
            Button_Click_3(sender, e);
        }

        private void btnDodajNabavku_Click(object sender, RoutedEventArgs e)
        {
            Nabavka prozor = new Nabavka();
            prozor.ShowDialog();
            Button_Click_4(sender, e);

        }

        private void btnIzmjeniNabavku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                Nabavka prozor = new Nabavka();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select KolicinaRobe,DatumNabavke,CijenaRobe,FilmID,DobavljacID from tblNabavka where NabavkaID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtKolRobe.Text = citac["KolicinaRobe"].ToString();
                    prozor.date.Text = citac["DatumNabavke"].ToString();
                    prozor.txtCijena.Text = citac["CijenaRobe"].ToString();

                    prozor.cmbFilm.SelectedValue = citac["FilmID"].ToString();
                    prozor.cmbDobavljac.SelectedValue = citac["DobavljacID"].ToString();
                    
                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_4(sender, e);
                azuriraj = false;
            }

        }

        private void btnObrisiNabavku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblNabavka where NabavkaID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_4(sender, e);
            }

        }

        private void btnDodajZanr_Click(object sender, RoutedEventArgs e)
        {
            Zanr prozor = new Zanr();
            prozor.ShowDialog();
            Button_Click_5(sender, e);

        }

        private void btnIzmjeniZanr_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                azuriraj = true;
                Zanr prozor = new Zanr();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select Zanr from tblZanrFilma where ZanrID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtZanr.Text = citac["Zanr"].ToString();
                    

                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_5(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiZanr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblZanrFilma where ZanrID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_5(sender, e);
            }

        }

        private void btnDodajZaposleni_Click(object sender, RoutedEventArgs e)
        {
            Zaposleni prozor = new Zaposleni();
            prozor.ShowDialog();
            Button_Click_6(sender, e);

        }

        private void btnIzmjeniZaposleni_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                azuriraj = true;
                Zaposleni prozor = new Zaposleni();
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                selektovan = red;
                string upit = "Select ImeZaposlenog,PreimeZaposlenog,Username,Password from tblZaposleni where ZaposleniID=" + red["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();


                while (citac.Read())
                {
                    prozor.txtImeZap.Text = citac["ImeZaposlenog"].ToString();
                    prozor.txtPrezZap.Text = citac["PreimeZaposlenog"].ToString();
                    prozor.txtUsername.Text = citac["Username"].ToString();

                    prozor.txtPass.Text = citac["Password"].ToString();

                }
                prozor.ShowDialog();


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_6(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiZaposleni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)CentralGrid.SelectedItems[0];
                string upit = "Delete from tblZaposleni where ZaposleniID=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Potrebno je selektovati odgovarajuci red", "Greska");
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                Button_Click_6(sender, e);
            }

        }
    }
}
