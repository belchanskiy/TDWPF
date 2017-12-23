using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWorker
{
    public class Logger
    {
        private string errorMessage;

        public Logger(string _message)
        {
            this.errorMessage = _message;
        }

        public bool writeToLog()
        {
            return new DBWorker.LogWriter().writeToLog(this.errorMessage);
        }
    }
}
