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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Page
    {
        HospitalEntities1 Db = new HospitalEntities1();
        int PID;
        public Appointment(int id)
        {
            InitializeComponent();
            InitializeCombo();
            Refresh();
            PID = id;
        }
        public void InitializeCombo()
        {
            var list = Db.Doctors.Select(d => d.Dspecialize).Distinct().ToList();
            list.Add("");
            combo.ItemsSource = list;
        }
        public void Refresh()
        {
            datagrid.ItemsSource = Db.Doctors.ToList();
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(combo.SelectedItem.ToString() == "")
            {
                Refresh();
                return;
            }
            var selected = Db.Doctors.Where(doc => doc.Dspecialize == combo.SelectedItem.ToString());
            datagrid.ItemsSource = selected.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(idtxt.Text == "")
            {
                MessageBox.Show("Id filed is reqiured");
                return;
            }
            var selected = Db.Doctors.Where(doc => doc.Did.ToString() == idtxt.Text).ToList();
            if(selected.Count == 0)
            {
                MessageBox.Show("No Doctor found");
                return;
            }
            datagrid.ItemsSource = selected;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (idtxt.Text == "")
            {
                MessageBox.Show("Id filed is reqiured");
                return;
            }
            var selected = Db.Doctors.FirstOrDefault(doc => doc.Did.ToString() == idtxt.Text);
            if (selected == null)
            {
                MessageBox.Show("No Doctor found");
                return;
            }
            AppointmentDetails D = new AppointmentDetails(PID, selected.Did);
            this.NavigationService.Navigate(D);
        }
    }
}
