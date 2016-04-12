using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Infrastructure.Utilities
{
    /// <summary>
    /// Pdf utility
    /// </summary>
    public class PdfUtility
    {
        /// <summary>
        /// Generate pdf
        /// </summary>
        /// <param name="htmlBody"></param>
        /// <returns></returns>
        public static byte[] GeneratePdf(string htmlBody)
        {
            byte[] bytes = null;
            if (!string.IsNullOrWhiteSpace(htmlBody))
            {
                var exeFilePath = PathUtility.MapPath("~/app_data/wkhtmltopdf/wkhtmltopdf.exe");
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = exeFilePath;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.Arguments = "-q -n " + " - -";

                using (Process p = Process.Start(startInfo))
                {
                    using (StreamWriter sw = p.StandardInput)
                    {
                        sw.AutoFlush = true;
                        sw.Write(String.Format(@"<!DOCTYPE html><html><head><meta charset = ""UTF-8"" /></head><body>{0}</body></html>", htmlBody));
                    }

                    using (var memstream = new MemoryStream())
                    {
                        p.StandardOutput.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }

                    p.WaitForExit();
                }
            }

            return bytes;
        }
    }
}
