using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBWorker
{
    public class LogWriter
    {
        public bool writeToLog(string _message)
        {
            // Здесь используем конструкцию try-catch, 
            // чтобы избежать зацикливания в глобальном обработчике
            try
            {
                string PathToFile = Directory.GetCurrentDirectory() + "\\";

                StreamWriter fileWriter = new StreamWriter(PathToFile + "log.txt", true);

                fileWriter.WriteLine(DateTime.Now.ToString() + " - " + _message);

                fileWriter.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
