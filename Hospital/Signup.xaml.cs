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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        HospitalEntities1 Db =  new HospitalEntities1();
        public Signup()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(passwordbox.Password == "" || Emailtxt.Text == "" || Nametxt.Text == "")
            {
                MessageBox.Show("Fileds reqiured");
                return;
            }

            Patient p = new Patient()
            {
                Pemail = Emailtxt.Text,
                Ppassword = passwordbox.Password,   
                Pname = Nametxt.Text
            };
            Db.Patients.Add(p);
            Db.SaveChanges();
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }
    }
}
