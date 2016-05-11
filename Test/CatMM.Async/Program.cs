using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Infrastructure.PdfGenerator;
using CatMM.Infrastructure.PdfGenerator.WkHtmlToX;
using System.IO;

namespace CatMM.Async
{
    class Program
    {
        static void Main(string[] args)
        {

            IPdfGenerator pdfGenerator = new PdfGenerator();

            var result = pdfGenerator.GenerateByUrl("www.baidu.com");
            WriteFile(result, "test.pdf");
            Console.ReadKey();
        }

        static void WriteFile(byte[] bytes, string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdf", fileName);
            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.Write(bytes, 0, bytes.Length);
            }

        }

        public static async Task DoSomethingAsync()
        {
            int val = 13;
            Console.WriteLine("before first await");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("first await");
            val *= 2;
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("DoSomethingAsync");
        }
    }
}
