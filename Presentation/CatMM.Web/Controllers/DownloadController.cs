using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CatMM.Web.Controllers
{
    public class DownloadController : Controller
    {
        public ActionResult FromFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return File(path, MimeMapping.GetMimeMapping(path));
            }

            return null;
        }

        public void File(string path)
        {
            if (System.IO.File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Response.BufferOutput = false;
                    Response.AddHeader("Content-Length", stream.Length.ToString());
                    Response.AddHeader("Content-Disposition", "attachment;   filename=testc.pdf");
                    int bufferSize = 4 * 1024;
                    byte[] buffer = new byte[bufferSize];
                    int offset = 0;
                    int readCount = 0;
                    while ((readCount = stream.Read(buffer, 0, bufferSize)) > 0 && Response.IsClientConnected)
                    {
                        offset += readCount;
                        Response.OutputStream.Write(buffer, 0, readCount);
                        Response.Flush();
                    }

                    Response.End();
                }
            }
        }
    }
}