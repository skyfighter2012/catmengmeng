using DotLiquid.FileSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using System.IO;

namespace CatMM.Infrastructure.TemplateEngine.FileSystems
{
    public class TemplateSystem : IFileSystem
    {
        /// <summary>
        /// Read template file
        /// </summary>
        /// <param name="context"></param>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public string ReadTemplateFile(Context context, string templateName)
        {
            return ReadLocalFile(templateName);
        }

        public string ReadLocalFile(string templateName)
        {
            //获取本地
            string text = String.Empty;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templateName);
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }

            return text;
        }
    }
}
