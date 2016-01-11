using CatMM.Autofac.Study.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Autofac.Study.DateWriter
{
    public class TodayWriter : IDateWriter
    {
        private IOutPut _output;

        public TodayWriter(IOutPut output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Now.ToShortDateString());
        }
    }
}
