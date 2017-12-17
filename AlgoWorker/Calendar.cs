using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWorker
{
    public class Calendar
    {
        public int idTeacher;
        public int idPupil;
        public int day;
        public TimeSpan timeBegin;
        public TimeSpan timeEnd;
        public bool active;
        public string comment;
        public DateTime dateBegin;
        public DateTime? dateEnd;
    }
}
