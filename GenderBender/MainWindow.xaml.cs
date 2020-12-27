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
using System.IO;

namespace GenderBender
{
   
    public struct people
    {
        public string name;
        public string DR;
        public string gender;
        public string dopInfo;

    }
    public partial class MainWindow : Window
    { 
        people[] pip = new people[1];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            string dop = "";
            if (cbCDA.IsChecked == true)
            {
                dop += cbCDA.Content + "; ";
            }
            if (cbEvil.IsChecked == true)
            {
                dop += cbEvil.Content + "; ";
            }
            if (cbGood.IsChecked == true)
            {
                dop += cbGood.Content + "; ";
            }
            if (cbModest.IsChecked == true)
            {
                dop += cbModest.Content + "; ";
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open("MyDataBase.txt", FileMode.Append)))
            {
                bw.Write(txtName.Text);
                bw.Write(dtpDR.SelectedDate.ToString());
                if (lstGender.SelectedItem != null)
                {
                    ListBoxItem lbi_item = (ListBoxItem)lstGender.SelectedItem;
                    bw.Write(lbi_item.Content.ToString());
                }
                bw.Write(dop);
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
           
          
            using (BinaryReader br = new BinaryReader(File.Open("MyDataBase.txt", FileMode.Open)))
            { int i = 0;
                while (br.PeekChar() > -1)
                {
                    pip[i].name = br.ReadString();
                    pip[i].DR = br.ReadString();
                    pip[i].gender = br.ReadString();
                    pip[i].dopInfo = br.ReadString();
                    i++;
                    Array.Resize(ref pip, pip.Length + 1);
                }
            }
        }
        int n = 0;
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            lblname.Content = pip[n].name;
            lblDR.Content = pip[n].DR;
            lblgender.Content = pip[n].gender;
            lblFeatures.Content = pip[n].dopInfo;
            n++;

        }
    }
}
