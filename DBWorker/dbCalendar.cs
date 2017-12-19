using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWorker
{
    public class dbCalendar
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

        public Calendar toCalendar()
        {
            Calendar retVal = new Calendar();

            retVal.idTeacher    = this.idTeacher;
            retVal.idPupil      = this.idPupil;
            retVal.day          = this.day;
            retVal.timeBegin    = this.timeBegin;
            retVal.timeEnd      = this.timeEnd;
            retVal.active       = this.active;
            retVal.comment      = this.comment;
            retVal.dateBegin    = this.dateBegin;
            retVal.dateEnd      = this.dateEnd;

            return retVal;
        }

        public void fromCalendar(object _cal)
        {
            if (_cal == null)
            {
                this.idTeacher = 0;
                this.idPupil = 0;
                this.day = 0;
                this.timeBegin = new TimeSpan();
                this.timeEnd = new TimeSpan();
                this.active = false;
                this.comment = "";
                this.dateBegin = new DateTime();
                this.dateEnd = new DateTime();
            }
            else
            {
                Calendar cal = _cal as Calendar;

                this.idTeacher = cal.idTeacher;
                this.idPupil = cal.idPupil;
                this.day = cal.day;
                this.timeBegin = cal.timeBegin;
                this.timeEnd = cal.timeEnd;
                this.active = cal.active;
                this.comment = cal.comment;
                this.dateBegin = cal.dateBegin;
                this.dateEnd = cal.dateEnd;
            }
        }
    }

    public class dbCalendars
    {
        public List<dbCalendar> Items;

        public List<dbCalendar> getItems()
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Items = mydbe.Calendar.Select(cal => new dbCalendar()
                    {
                        idTeacher   = cal.idTeacher,
                        idPupil     = cal.idPupil,
                        day         = cal.day,
                        timeBegin   = cal.timeBegin,
                        timeEnd     = cal.timeEnd,
                        active      = cal.active,
                        comment     = cal.comment,
                        dateBegin   = cal.dateBegin,
                        dateEnd     = cal.dateEnd,
                    }).ToList();

                }
                catch
                {
                    throw new AccessViolationException();
                }
            }

            return Items;
        }

        public List<dbCalendar> GetCalendarEventsByDate(DateTime _date)
        {
            List<dbCalendar> ItemsByDate = new List<dbCalendar>();

            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    ItemsByDate = mydbe.Calendar.Where(b => b.day == (int)_date.DayOfWeek && b.active).Select(cal => new dbCalendar()
                    {
                        
                        idTeacher = cal.idTeacher,
                        idPupil = cal.idPupil,
                        day = cal.day,
                        timeBegin = cal.timeBegin,
                        timeEnd = cal.timeEnd,
                        active = cal.active,
                        comment = cal.comment,
                        dateBegin = cal.dateBegin,
                        dateEnd = cal.dateEnd,
                    }
                    ).ToList();
                }
                catch
                {
                    throw new AccessViolationException();
                }
            }

            return ItemsByDate;
        }

        public void createCalendarInDB(dbCalendar _cal)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Calendar cal = _cal.toCalendar();

                    mydbe.Calendar.Add(cal);
                    mydbe.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new AccessViolationException("Не удалось записать в БД", e);
                }
            }
        }

        public void updateCalendarInDB(dbCalendar _cal)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Calendar cal = mydbe.Calendar.Where(a => (a.idPupil == _cal.idPupil 
                                                                && a.idTeacher == _cal.idTeacher
                                                                && a.day == _cal.day)).First();

                    cal.idTeacher = _cal.idTeacher;
                    cal.idPupil = _cal.idPupil;
                    cal.day = _cal.day;
                    cal.timeBegin = _cal.timeBegin;
                    cal.timeEnd = _cal.timeEnd;
                    cal.active = _cal.active;
                    cal.comment = _cal.comment;
                    cal.dateBegin = _cal.dateBegin;
                    cal.dateEnd = _cal.dateEnd;

                    mydbe.SaveChanges();
                }
                catch
                {
                    throw new AccessViolationException();
                }
            }
        }

        public dbCalendar getItemByIDSFromDB(int _idTeacher, int _idPupil, int _day)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                dbCalendar retValue = new dbCalendar();
                try
                {
                    Calendar cal = mydbe.Calendar.Where(a => (a.idPupil == _idPupil
                                                                && a.idTeacher == _idTeacher
                                                                && a.day == _day)).FirstOrDefault();
                    retValue.fromCalendar(cal);
                    
                }
                catch(Exception e)
                {
                    throw new AccessViolationException("Не удалось прочитать из БД", e);
                }
                return retValue;
            }
        }

        public List<dbCalendar> getItemByIDPupilFromDB(int _idTeacher, int _idPupil)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                List<dbCalendar> retValue = new List<dbCalendar>();
                try
                {
                    var cal = mydbe.Calendar.Where(a => (a.idPupil == _idPupil
                                                                && a.idTeacher == _idTeacher));

                    foreach (Calendar Item in cal)
                    {
                        dbCalendar dbC = new dbCalendar();

                        dbC.fromCalendar(Item);

                        retValue.Add(dbC);
                    }

                }
                catch
                {
                    throw new AccessViolationException();
                }
                return retValue;
            }
        }
    }
}
