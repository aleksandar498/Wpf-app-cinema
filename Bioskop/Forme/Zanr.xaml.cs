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
    /// Interaction logic for Zanr.xaml
    /// </summary>
    public partial class Zanr : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public Zanr()
        {
            
            InitializeComponent();
            txtZanr.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    DataRowView red = (DataRowView)MainWindow.selektovan;
                    string upit = @"Update tblZanrFilma Set Zanr ='" + txtZanr.Text + "' Where ZanrID=" + red["ID"];
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.selektovan = null;
                    this.Close();

                }
                else
                {
                    
                    string insert = @"insert into tblZanrFilma(Zanr)values('" + txtZanr.Text + "');";
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
