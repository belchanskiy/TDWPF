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
        private int pday;
        public int day {
            get { return this.pday; }
            set { this.pday = value;
                this.dayStr = this.intToString(value);
            }
        }
        public string dayStr;
        public TimeSpan timeBegin;
        public TimeSpan timeEnd;
        public bool active;
        public string comment;
        public DateTime dateBegin;
        public DateTime? dateEnd;

        private string intToString(int _day)
        {
            if (_day == 0) return "Понедельник";
            if (_day == 1) return "Вторник";
            if (_day == 2) return "Среда";
            if (_day == 3) return "Четверг";
            if (_day == 4) return "Пятница";
            if (_day == 5) return "Суббота";
            if (_day == 6) return "Воскресенье";
            return "";
        }
    }
}
