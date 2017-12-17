using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWorker
{
    public class Pupil
    {
        public int id { get; set; }
        public string name { get; set; }
        public string grade { get; set; }
        public string target { get; set; }
        public string address { get; set; }
        public string parentName { get; set; }
        public string parentPhone { get; set; }
        public string comment { get; set; }
        public bool active { get; set; }

        public Pupil(int _id,
                     string _name,
                     string _grade,
                     string _target,
                     string _address,
                     string _parentName,
                     string _parentPhone,
                     string _comment,
                     bool _active)
        {
            id = _id;
            name = _name;
            grade = _grade;
            target = _target;
            address = _address;
            parentName = _parentName;
            parentPhone = _parentPhone;
            comment = _comment;
            active = _active;
        }
    }
}
