using System;
using System.Collections;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(ArrayList ind, ArrayList enem, String yname, String ename)
        {
            String para = "Your power Animal or Plant is The " + ind[13].ToString() + " It resides in " + ind[8].ToString() + " county in New York State.. " +
                " Its Scientific Name is The " + ind[12].ToString() + " Its status is considered " + ind[15].ToString() +
                " Your Arch Nemesis " + ename + " Is best represented by The " + enem[13].ToString() + " Your rivals familiar is considered " + enem[15].ToString() +
                " So in the burg of " + enem[8].ToString() + " You " + yname + " " + ind[13].ToString() + " confront your mortal Enemy " + ename + " " + enem[13].ToString() +
                " The two of you savagely battle for supremacy and rend each other asunder at the conclusion of the quarrel only one of you is left standing.. the other runs away like a terrified coward..";
        
            InitializeComponent();
            recordOutput.Text = para;
        }
    }
}
