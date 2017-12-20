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
                this.dayStr = this.dayToString(this.pday);
            }
        }
        private string dStr;
        public string dayStr
        {
            get { return this.dStr; }
            set { this.dStr = value; }
        }
        private TimeSpan tBegin;
        public TimeSpan timeBegin
        {
            get { return this.tBegin; }
            set
            {
                this.tBegin = value;
                this.timeBeginStr = this.addNulls(this.tBegin.Hours.ToString(), 2) + ':' + this.addNulls(this.tBegin.Minutes.ToString(), 2);
            }
        }
        private TimeSpan tEnd;
        public TimeSpan timeEnd
        {
            get { return this.tEnd; }
            set
            {
                this.tEnd = value;
                this.timeEndStr = this.addNulls(this.tEnd.Hours.ToString(), 2) + ':' + this.addNulls(this.tEnd.Minutes.ToString(), 2);
            }
        }
        public bool active;
        public string comment;
        public DateTime dateBegin;
        private string tBeginStr;
        public string timeBeginStr
        {
            get { return this.tBeginStr; }
            set { this.tBeginStr = value; }
        }
        private string tEndStr;
        public string timeEndStr
        {
            get { return this.tEndStr; }
            set { this.tEndStr = value; }
        }
        public DateTime? dateEnd;
        public string addNulls(string _str, int _length)
        {
            while(_str.Length < _length)
            {
                _str = '0' + _str;
            }
            return _str;
        }
        private string dayToString(int _day)
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
        public string PupilName { get; set; }
        public string PupilAddress { get; set; }
        public string PupilPhone { get; set; }
    }
}
