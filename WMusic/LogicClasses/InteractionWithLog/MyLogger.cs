using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMusic.LogicClasses.InteractionWithLog
{
    internal class MyLogger
    {
        public static void Log(string log, ILogger logger) => logger.Log(log);
    }
}
