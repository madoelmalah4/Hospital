using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 
    public partial class Login : Page
    {
        public HospitalEntities1 Db = new HospitalEntities1();
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Signup S = new Signup();
            this.NavigationService.Navigate(S);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(passwordbox.Password == "" || Emailtxt.Text == "")
            {
                MessageBox.Show("Flieds are reqiured");
                return;
            }



            var p = Db.Patients.FirstOrDefault(pacient => pacient.Pemail == Emailtxt.Text && pacient.Ppassword == passwordbox.Password);

            if(p == null)
            {
                MessageBox.Show("Invalid Email or Password");
                return;
            }

            MessageBox.Show("Logged in Successfully");
            Appointment appoint = new Appointment(p.Pid);
            this.NavigationService.Navigate(appoint);
        }
    }
}
