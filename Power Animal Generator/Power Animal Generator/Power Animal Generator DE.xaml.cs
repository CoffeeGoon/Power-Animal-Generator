using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Web;
using Newtonsoft.Json;
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
    /// Interaction logic for Power_Animal_Generator_Data_Analysis.xaml
    /// </summary>
    public partial class Power_Animal_Generator_Data_Analysis : Window
    {
        String url = "https://data.ny.gov/api/views/tk82-7km5/rows.json?accessType=DOWNLOAD";

        HttpWebRequest getDataSet = null;
        HttpWebResponse proccessData = null;
        String[] countyNames;
        String user = "";
        String enemy = "";
        int entrophic = 0;
        List<ArrayList> sortedSet;
        ArrayList userData;
        ArrayList NemesisData;
        public Power_Animal_Generator_Data_Analysis(String[] counties)
        {
            countyNames = counties;
            InitializeComponent();
        }

        /*
         sort logic 
         first character of common name matches
         common names with most matching characters higher up in the queue
         generate random number between  1-100/ falls into one of these ranges
         then generate another number with an offsset and range based on 1/5
         the probability range goes  35% - 25% - 15% -15% - 10% each range being 1/5 of the total list length
         the entrophic number changes entry to ajacent element
         */
        public ArrayList generateData(List<ArrayList> subset, String name)
        {
            String username = name;
            List<ArrayList> tempset = subset.FindAll((ArrayList cond) => { return cond[13].ToString().StartsWith(username[0].ToString()); });
            List<ArrayList> insertList = new List<ArrayList>();
            insertList = tempset.FindAll( (ArrayList condB) => { return condB[13].ToString().StartsWith(username.Substring(0, 4)); } );
            sortedSet = new List<ArrayList>();
            if (insertList.Count != 0) {
                sortedSet.InsertRange(0, insertList);
                    tempset.RemoveAll((ArrayList tem) => { return tem[13].ToString().StartsWith(username.Substring(0, 4)); });
            }
           insertList = tempset.FindAll((ArrayList condC) => { return condC[13].ToString().StartsWith(username.Substring(0, 3)); });
               if (insertList.Count != 0)
               {
                   sortedSet.InsertRange(0, insertList);
                   tempset.RemoveAll((ArrayList tem) => { return tem[13].ToString().StartsWith(username.Substring(0, 3)); });
               }
           insertList = tempset.FindAll((ArrayList condD) => { return condD[13].ToString().StartsWith(username.Substring(0, 2)); });
               if (insertList.Count != 0)
               {
                   sortedSet.InsertRange(0, insertList);
                   tempset.RemoveAll((ArrayList tem) => { return tem[13].ToString().StartsWith(username.Substring(0, 2)); });
               }
              sortedSet.InsertRange(0, tempset);
            Random rand = new Random();
            int fraction = (int) ( sortedSet.Count / 5);
            int percent = rand.Next(1, 90) + rand.Next(0, entrophic);
            int elem = 0;
           if( percent < 36)
            {
                 elem = rand.Next(0, fraction);
               
            }

                   
           else if (percent < 61)
            {
                 elem = rand.Next(fraction + 1, (fraction * 2));
            }

                   
           else if( percent < 76)
            {
                 elem = rand.Next((fraction * 2) + 1, (fraction * 3));
            }

                   
           else if(percent < 91)
            {
                 elem = rand.Next((fraction * 3) + 1, (fraction * 4));
            }
            else
            {
                 elem = rand.Next((fraction * 4) + 1, sortedSet.Count - 1 );
            }

            return sortedSet[elem];

            
        }         



        public class record
        {

            //var set = { int a, string b, int c, int d, string e };
            //int, string, null, string, string, string, string, string, string, string, string, string, string }

        /*
            int sid;
            String id;
            int posistion;
            int created_at;
            string created_meta;
            int updated_at;
            string foofield;

            string county, co
            */

        }

        public class DataObj
        {
        public List<ArrayList> data;

        }

        private void Calc(object sender, RoutedEventArgs e)
        {

            Boolean ready = false;
           
            string fieldA = NameInput.Text.ToString();
            string fieldB = ONameInput.Text.ToString();
            string fieldC = NumberInput.Text.ToString();
            int tempval;
           ready = int.TryParse(fieldC, out tempval);
            if (ready)
            {
                entrophic = tempval % 10 + 1;
                if(fieldA.Length > 1)
                {
                    user = fieldA;
                    
                }
                else { ready = false;  }
                if(fieldB.Length > 1)
                {
                    enemy = fieldB;
                }
                else { ready = false; }

            }

            if (ready)
            {

                getDataSet = (HttpWebRequest)WebRequest.Create(url);
                getDataSet.Method = "GET";
                getDataSet.ContentType = "text/json";
                proccessData = (HttpWebResponse)getDataSet.GetResponse();
                StreamReader getLis = new StreamReader(proccessData.GetResponseStream());
                String response = "";
                Boolean store = false;
                int n = 0;

                Boolean end = false;
                StringBuilder buffer = new StringBuilder();
                
                while (!getLis.EndOfStream)
                {

                    String sentinel = getLis.ReadLine();
                    if (!store && sentinel.Contains("\"data\""))
                    {
                        store = true;
                    }
                    if (store)
                    {

                        buffer.Append(sentinel);

                    }
                }
             
                // MessageBox.Show("formattedStream!");
                proccessData.Close();
                response = "{ " +  buffer.ToString();
                var SpeciesList = JsonConvert.DeserializeObject<DataObj>(response);
                var completeList = SpeciesList.data;
                //MessageBox.Show((completeList.Count).ToString());
                List<ArrayList> subset = completeList.FindAll((ArrayList foo) => { return countyNames.Contains(foo[8]); });
                //MessageBox.Show( (subset.Count).ToString());
                 userData = generateData(subset, user);
               NemesisData = generateData(subset, enemy);
                // MessageBox.Show(userData[13].ToString());
                // MessageBox.Show(NemesisData[13].ToString());
                Window2 finale = new Window2(userData, NemesisData, user, enemy);
                App.Current.MainWindow = finale;
                this.Close();
                finale.Show();

            }
            else
            {
                MessageBox.Show("Input Error Try Again!");

            }
             
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
