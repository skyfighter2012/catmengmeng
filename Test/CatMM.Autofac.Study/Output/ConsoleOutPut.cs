using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Autofac.Study.Output
{
    public class ConsoleOutPut : IOutPut
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
