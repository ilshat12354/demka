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

namespace demka.windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizeWindow.xaml
    /// </summary>
    public partial class AutorizeWindow : Window
    {
        public AutorizeWindow()
        {
            InitializeComponent();
        }

        private void autorize_Click(object sender, RoutedEventArgs e)
        {
            using(demkaEntities db = new demkaEntities())
            {
                foreach(Polzovatel pz in db.Polzovatel)
                {
                    if(pz.login == Login.Text && pz.password == Password.Text)
                    {
                        MessageBox.Show("Успешно");
                        this.Hide();
                        MainWindow mw = new MainWindow();
                        mw.Show();
                    }
                }
            }
        }

        private void registy_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow lw = new LoginWindow();
            lw.Show();
        }
    }
}
