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
    }
}
