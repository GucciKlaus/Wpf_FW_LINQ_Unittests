using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfFW_LING_Unittests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string name = "DonauDampfSchiffFahrtsKapitän";
        public static int[] numbers = new int[] { 1, 3, 6, 7, 9, 12, 13, 17 };
        public static List<string> stringList = new List<string> { "Andi", "Berta", "Caesar",
        "Dieter", "Emil", "Franz", "Gerlinde" };
        public static List<string> PatientenStringList = new List<string> { "Gustav Gips", "Hans Halsweh",
          "Gunther Grippe", "Giesela Grippe","Birgit Bauchweh"};

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int numOfChars = AnzahlUnterschiedlicheBuchstaben_Lambda(name);
            string output = ($"Anzahl char Word: {numOfChars}");
            string emptyrow = ("/////////////////////////////////////////////");
            lboOutputs.Items.Add(output);
            lboOutputs.Items.Add(emptyrow);
            lboOutputs.Items.Add("Alle Namen mit weniger als 6 Buchstaben groß geschrieben und absteigend sortiert (Lambda&Query)");
            List<string> nameBig = NamenK6GRoss_Lambda(stringList);
            ListWriter(nameBig);
            nameBig = NamenK6GRoss_Query(stringList);
            ListWriter(nameBig);
            lboOutputs.Items.Add(emptyrow);
            lboOutputs.Items.Add("Anzahl der Ungeraden Zahlen in numbers (Lambda & Query)");
            lboOutputs.Items.Add(AnzahlUngeradeZahlen_Lambda(numbers));
            lboOutputs.Items.Add(AnzahlUngeradeZahlen_Query(numbers));
            lboOutputs.Items.Add(emptyrow);
            lboOutputs.Items.Add("Eine Liste von alle zweistelligen Zahlen in numbers, die ver-2,5-facht wurden (Lambda &Query)");
            List<double> doubleBig = ZweistelligeZahlen_Lambda(numbers);
            ListWriter(doubleBig);
            doubleBig = ZweistelligeZahlen_Query(numbers);
            ListWriter(doubleBig);
            lboOutputs.Items.Add(emptyrow);
            lboOutputs.Items.Add("Ein String-Array mit folgenden Einträgen \"Gips bei Gustav\"... sortiert nach dem 2.\r\nBuchstaben der Krankheit (Lambda & Query)");
            nameBig = NamenStringArray_Lambda(PatientenStringList);
            ListWriter(nameBig);
            nameBig = NamenStringArray_Query(PatientenStringList);
            ListWriter(nameBig);
            lboOutputs.Items.Add(emptyrow);
            lboOutputs.Items.Add("Dictionary von char (1. Buchstabe der Krankheit) und einem Integer der zählt wieviele\r\nPatienten ein Krankheit haben, mit diesem Buchstaben beginnt.");
            lboOutputs.Items.Add(emptyrow);
            ListWriterDic(KrankheitCountDictionary_Lambda(PatientenStringList)); 
        }

        public static int AnzahlUnterschiedlicheBuchstaben_Lambda(string name)
        {
            // List<char> chars = name.ToLower().ToList();
            //  int value = chars.Distinct().Count();
            int value = name.ToLower()
                            .Distinct()
                            .Count();
            return value;
        }

        public static List<string> NamenK6GRoss_Lambda(List<string> namen)
        {
            var valuebacklist = namen
                .Where(x => x.Length < 6)
                .OrderByDescending(x => x.ToUpper())
                .Select(x => x.ToUpper())
                .ToList();
            return valuebacklist;
        }
        public static List<string> NamenK6GRoss_Query(List<string> namen)
        {
            List<string> backlist = new List<string>();
            var valuebacklist = from x in namen
                                where x.Length < 6
                                orderby x.ToLower() descending
                                select x.ToUpper();

            foreach (var x in valuebacklist)
            {
                backlist.Add(x);
            }

            return backlist;
        }

        public static int AnzahlUngeradeZahlen_Lambda(int[] num)
        {
            int anzahl = num.Where(x => x % 2 != 0).Count();
            return anzahl;
        }
        public static int AnzahlUngeradeZahlen_Query(int[] num)
        {
            int anzahl = (from x in num
                          where x % 2 != 0
                          select x).Count();
            return anzahl;
        }

        public static List<double> ZweistelligeZahlen_Lambda(int[] num)
        {
            var returnvalue = num.Where(x => x < 100 && x > 10).Select(x => x * 2.5).ToList();
            return returnvalue;
        }
        public static List<double> ZweistelligeZahlen_Query(int[] num)
        {
            List<double> backlist = new List<double>();

            var vaulebacklist = from x in num
                                where x > 10 && x < 100
                                select x * 2.5;

            foreach (var x in vaulebacklist)
            {
                backlist.Add(x);
            }

            return backlist;
        }

        public static List<string> NamenStringArray_Lambda(List<string> namen)
        {
            var sortedlist = namen.OrderBy(x => x.Split(' ')[1][1]).Select(x => x.Split(' ')[1] + " bei " + x.Split(' ')[0]).ToList();
            // var sortedlistV2 = sortedlist.Add(x => x.Split(' ')[0] + "bei");                   
            return sortedlist;
        }
        public static List<string> NamenStringArray_Query(List<string> namen)
        {
            var sortedlistV2 = new List<string>();
            var sortedlist = from x in namen
                             orderby x.Split(' ')[1][1]
                             select x.Split(' ')[1] + " bei " + x.Split(' ')[0];

            foreach (var x in sortedlist)
            {
                sortedlistV2.Add(x);
            }

            return sortedlistV2;
        }

        public static Dictionary<char, int> KrankheitCountDictionary_Lambda(List<string> namen)
        {
            var returnlist = namen.GroupBy(x => x.Split(' ')[1][0]).ToDictionary(x => x.Key,x => x.Count());
            return returnlist;
        }


        public void ListWriter<T>(List<T> list)
        {

            string storedValue = "";
            foreach (var item in list)
            {
                storedValue += item.ToString() + ", ";
            }
            lboOutputs.Items.Add(storedValue);
        }

        public void ListWriterDic<T>(Dictionary<char, T> dictionary)
        {
            string storedValues = "";

            foreach (var value in dictionary)
            {
                storedValues += value.ToString() + ", ";
            }

            lboOutputs.Items.Add(storedValues.TrimEnd(',', ' '));
        }
    }
}
