using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMusic.LogicClasses.InteractionWithLog
{
    internal class PausedLog : ILogger
    {
        public void Log(string log)
        {
            FileStream fileStream = new FileStream("Log.txt", FileMode.OpenOrCreate);

            StreamWriter sw = new StreamWriter(fileStream);

            sw.WriteLine("[PAUSED] " + DateTime.Now.ToString() + log);
        }
    }
}
