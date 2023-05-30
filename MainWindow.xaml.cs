using demka.windows;
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

namespace demka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            List<tkani> tkaniinfos = new List<tkani>();

            using (demkaEntities db = new demkaEntities())
            {
                foreach (tkani tkani in db.tkani)
                {
                    tkaniinfos.Add(tkani);
                } 
            }
            Tkani.ItemsSource = tkaniinfos; 
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow lg = new LoginWindow();
            lg.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            tkani tk = (sender as Button).DataContext as tkani;

            using(demkaEntities db = new demkaEntities())
            {
                foreach(tkani tkani in db.tkani)
                {
                    if(tk.artikul_tkani == tkani.artikul_tkani)
                    {
                        db.tkani.Remove(tkani);
                        MessageBox.Show("Успешно");
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
