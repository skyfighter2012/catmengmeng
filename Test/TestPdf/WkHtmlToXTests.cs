using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatMM.Infrastructure.PdfGenerator;
using CatMM.Infrastructure.PdfGenerator.WkHtmlToX;
using TuesPechkin;
using System.IO;

namespace TestPdf
{
    [TestClass]
    public class WkHtmlToXTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPdfGenerator generator = new PdfGenerator();
            var result = generator.GenerateByUrl("www.baidu.com");
            Console.WriteLine(result);
            int i = 0;
        }
    }
}
