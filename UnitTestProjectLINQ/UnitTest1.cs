using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace UnitTestProjectLINQ
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_AnzUntersch_Buchstaben()
        {
            int count = WpfFW_LING_Unittests.MainWindow.AnzahlUnterschiedlicheBuchstaben_Lambda(WpfFW_LING_Unittests.MainWindow.name);
            Assert.AreEqual(16, count);
        }
        [TestMethod]
        public void TestMethod_AnzNamenmitBuchstabenLambda()
        {
            List<string> stringList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            List<string> listnew = WpfFW_LING_Unittests.MainWindow.NamenK6GRoss_Lambda(WpfFW_LING_Unittests.MainWindow.stringList);
            CollectionAssert.AreEqual(stringList, listnew);
        }
        [TestMethod]
        public void TestMethod_AnzNamenmitBuchstabenQuery()
        {
            List<string> stringList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            List<string> listnew = WpfFW_LING_Unittests.MainWindow.NamenK6GRoss_Query(WpfFW_LING_Unittests.MainWindow.stringList);
            CollectionAssert.AreEqual(stringList, listnew);
        }
        [TestMethod]
        public void TestMethod_AnzahlUngeradeZahlen_Lambda()
        {
            int sol = 6;
            int que = WpfFW_LING_Unittests.MainWindow.AnzahlUngeradeZahlen_Lambda(WpfFW_LING_Unittests.MainWindow.numbers);
            Assert.AreEqual(sol, que);
        }
        [TestMethod]
        public void TestMethod_AnzahlUngeradeZahlen_Query()
        {
            int sol = 6;
            int que = WpfFW_LING_Unittests.MainWindow.AnzahlUngeradeZahlen_Query(WpfFW_LING_Unittests.MainWindow.numbers);
            Assert.AreEqual(sol, que);
        }
        [TestMethod]
        public void TestMethod_ZweistelligeZahlen_Lambda()
        {
            List<double> expList = new List<double> { 12 * 2.5, 13 * 2.5, 17 * 2.5 };
            List<double> actList = WpfFW_LING_Unittests.MainWindow.ZweistelligeZahlen_Lambda(WpfFW_LING_Unittests.MainWindow.numbers);
            CollectionAssert.AreEqual(expList, actList);
        }
        [TestMethod]
        public void TestMethod_ZweistelligeZahlen_Query()
        {
            List<double> expList = new List<double> { 12 * 2.5, 13 * 2.5, 17 * 2.5 };
            List<double> actList = WpfFW_LING_Unittests.MainWindow.ZweistelligeZahlen_Query(WpfFW_LING_Unittests.MainWindow.numbers);
            CollectionAssert.AreEqual(expList, actList);
        }
        [TestMethod]
        public void TestMethod_NamenStringArray_Lambda()
        {
            List<string> stringArrayExp = new List<string> { "Halsweh bei Hans", "Bauchweh bei Birgit",
            "Gips bei Gustav", "Grippe bei Gunther", "Grippe bei Giesela" };
            List<string> stringnewList = WpfFW_LING_Unittests.MainWindow.NamenStringArray_Lambda(WpfFW_LING_Unittests.MainWindow.PatientenStringList);
            CollectionAssert.AreEqual(stringArrayExp, stringnewList);
        }
        [TestMethod]
        public void TestMethod_NamenStringArray_Query()
        {
            List<string> stringArrayExp = new List<string> { "Halsweh bei Hans", "Bauchweh bei Birgit",
            "Gips bei Gustav", "Grippe bei Gunther", "Grippe bei Giesela" };
            List<string> stringnewList = WpfFW_LING_Unittests.MainWindow.NamenStringArray_Query(WpfFW_LING_Unittests.MainWindow.PatientenStringList);
            CollectionAssert.AreEqual(stringArrayExp, stringnewList);
        }

        [TestMethod]
        public void TestMethod_KrankheitCountDictionary_Lambda()
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('G', 3); dic.Add('H', 1); dic.Add('B', 1);

            Dictionary<char, int> dic2 = WpfFW_LING_Unittests.MainWindow.KrankheitCountDictionary_Lambda(WpfFW_LING_Unittests.MainWindow.PatientenStringList);
            CollectionAssert.AreEqual(dic, dic2);
        }
    }
}
