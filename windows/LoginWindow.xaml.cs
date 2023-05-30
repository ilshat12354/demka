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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            List<string> roleslist = new List<string>();

            using(demkaEntities db = new demkaEntities())
            {
                foreach(role role in db.role)
                {
                    roleslist.Add(role.role1);
                }
            }
            Role.ItemsSource = roleslist;
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            string role = (string)Role.SelectedItem;
            int id_role = 0;

            using(demkaEntities db = new demkaEntities())
            {
                Polzovatel pz = new Polzovatel();
                role role1 = new role();

                pz.login = Login_textbox.Text;
                pz.email = Email_textbox.Text;
                pz.password = Password_textbox.Text;
                
                foreach(role r in db.role)
                {
                    if(r.role1 == role)
                    {
                        id_role = r.id_role;
                    }
                }
                pz.id_role = id_role;

                db.Polzovatel.Add(pz);
                db.SaveChanges();
            }
            MessageBox.Show("success");

            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AutorizeWindow aw = new AutorizeWindow();
            aw.Show();
        }
    }
}
