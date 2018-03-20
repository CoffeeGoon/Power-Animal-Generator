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

namespace Power_Animal_Generator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        String[] zoneOne = { "Niagra", "Orleans", "Erie", "Wyoming", "Chautaqua", "Cattaraugus", "Allegany" };
        String[] zoneTwo = {"Monroe", "Wayne", "Ontario", "Livingston", "Yates", "Seneca", "Shayle", "Steuben", "Chemung" };
        String[] zoneThree = {"Cayuga", "Onondaga", "Madison", "Cortland", "Tompkins", "Chenango", "Tioga", "Broome" };
        String[] zoneFour = {"Jefferson", "Lewis", "Oswego", "Oneida" };
        String[] zoneFive = {"St. Lawrence", "Franklin", "Clinton" };
        String[] zoneSix = { "Essex", "Hamilton", "Warren", "Washington", "Herkimer", "Fulton", "Saratoga", "Montgomery", "Schenectady", "Otsego", "Schoharie", "Albany", "Rensselaer", "Richmond"};
        String[] zoneSeven = {"Delaware", "Green", "Columbia", "Sullivan","Genesee", "Ulster", "Dutchess", "Orange", "Putnam", "Westchester" };
        String[] zoneEight = {"Queens", "Nassau", "Suffolk", "Newyork", "Kings", "Rockland" };
        int change = 0;
        public Window1()
        {
       

            InitializeComponent();
          
        }

        private void PickZone(object sender, MouseButtonEventArgs e)
        {
            var mdata = e.GetPosition(NyMap);
            change = 0;
            if(mdata.X < 91 && mdata.Y > 92 && mdata.Y < 176)
            {
                change = 1;
            }
            else if (mdata.X < 163 && mdata.Y > 94 && mdata.Y < 177)
            {
                change = 2;
            }
            else if (mdata.X < 239 && mdata.Y > 103 && mdata.Y < 165)
            {
                change = 3;
            }
            else if (mdata.X < 249 && mdata.Y > 39 && mdata.Y < 106)
            {
                change = 4;
            }
            else if (mdata.X < 319 && mdata.Y > 4 && mdata.Y < 42)
            {
                change = 5;
            }
            else if (mdata.X < 337 && mdata.Y > 45 && mdata.Y < 145)
            {
                change = 6;
            }
            else if (mdata.X < 322 && mdata.Y > 144 && mdata.Y < 220)
            {
                change = 7;
            }
            else if (mdata.X < 383 && mdata.Y > 221 && mdata.Y < 258)
            {
                change = 8;
            }
            Prompt.Content = "Picked Zone: " + change.ToString();
           
        }

        private void nextWindow(object sender, RoutedEventArgs e)
        {
            Power_Animal_Generator_Data_Analysis foci  = new Power_Animal_Generator_Data_Analysis(zoneEight);
           
            if(change == 8)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneEight);
            }
            if (change == 1)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneOne);
            }
            if (change == 2)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneTwo);
            }
            if (change == 3)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneThree);
            }
            if (change == 4)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneFour);
            }
            if (change == 5)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneFive);
            }
            if (change == 6)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneSix);
            }
            if (change == 7)
            {
                foci = new Power_Animal_Generator_Data_Analysis(zoneSeven);
            }
            App.Current.MainWindow = foci;
            this.Close();
            foci.Show();
        }
    }
}
