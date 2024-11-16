using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AppointmentDetails.xaml
    /// </summary>
    public partial class AppointmentDetails : Page
    {
        public int Pid;
        public int Did;

        HospitalEntities1 Db = new HospitalEntities1();

        public AppointmentDetails(int Pid , int Did)
        {
            InitializeComponent();
            this.Pid = Pid;
            this.Did = Did;
            initializeLabels();
        }

        public void initializeLabels()
        {
            try
            {
            var Doctor = Db.Doctors.FirstOrDefault(D => D.Did == Did);
            var pacient = Db.Patients.FirstOrDefault(P => P.Pid == Pid);
            patientxt.Content = pacient.Pname ;
            doctortxt.Content = Doctor.Dname;
            Spetializationtxt.Content = Doctor.Dspecialize;
            Datetxt.Content = DateTime.Now.ToString();
            }catch(Exception e)
            {
                MessageBox.Show($"{e}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //madoelmalaj
        }
    }
}
