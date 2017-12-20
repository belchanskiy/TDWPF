using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWorker
{
    public class Authorizer
    {
        public dataTypes.User AuthorizeMe(dataTypes.User User)
        {
            DBWorker.dbUser dbUser = new DBWorker.dbUser().GetUserByLoginFromDB(User.login);

            if (User.password == dbUser.password)
            {
                User.id = dbUser.id;
                User.name = dbUser.name;
                User.password = "";
            }

            return User;
        }

    }

    public class PupilsWorker
    {
        private ObservableCollection<Pupil> PupilsItems;
        DBWorker.dbPupils DBWPup;

        public PupilsWorker()
        {
            PupilsItems = new ObservableCollection<Pupil>();
            DBWPup = new DBWorker.dbPupils();
        }

        public ObservableCollection<Pupil> getPupils()
        {
            PupilsItems.Clear();
            List<DBWorker.dbPupil> result = DBWPup.GetPupilsFromDB();

            foreach(DBWorker.dbPupil resItem in result)
            {
                PupilsItems.Add(new Pupil(resItem.id,
                                          resItem.name,
                                          resItem.grade,
                                          resItem.target,
                                          resItem.address,
                                          resItem.parentName,
                                          resItem.parentPhone,
                                          resItem.comment,
                                          resItem.active));
            }

            return PupilsItems;
        }

        public Pupil getPupilById(int _id)
        {
            DBWorker.dbPupil resItem = DBWPup.GetPupilByIdFromDB(_id);

            return new Pupil(resItem.id,
                            resItem.name,
                            resItem.grade,
                            resItem.target,
                            resItem.address,
                            resItem.parentName,
                            resItem.parentPhone,
                            resItem.comment,
                            resItem.active);
           
        }

        public void removePupilById(int _id)
        {
            DBWPup.RemovePupilByIdFromDB(_id);
        }

        public void updateOrCreatePupil(Pupil _pupil)
        {
            DBWorker.dbPupil Pupil = new DBWorker.dbPupil();

            Pupil.id = _pupil.id;
            Pupil.name = _pupil.name;
            Pupil.grade = _pupil.grade;
            Pupil.target = _pupil.target;
            Pupil.parentName = _pupil.parentName;
            Pupil.parentPhone = _pupil.parentPhone;
            Pupil.address = _pupil.address;
            Pupil.comment = _pupil.comment;
            Pupil.active = _pupil.active;

            if (this.getPupilById(_pupil.id).id == _pupil.id)
            {
                DBWPup.UpdatePupilInDB(Pupil);
            }
            else
            {
                DBWPup.CreatePupilInDB(Pupil);
            }
        }
    }

    public class CalendarWorker
    {
        DBWorker.dbCalendars DBWCal;
        ObservableCollection<Calendar> Items;

        public CalendarWorker()
        {
            DBWCal = new DBWorker.dbCalendars();
            Items = new ObservableCollection<Calendar>();
        }

        public ObservableCollection<Calendar> getItemsByDate(int _idTeacher, DateTime _date)
        {
            List<DBWorker.dbCalendar> dbItems = DBWCal.GetCalendarEventsByDate(_idTeacher, new DateTime(_date.Year, _date.Month, _date.Day));

            this.Items.Clear();

            foreach(DBWorker.dbCalendar dbItem in dbItems)
            {
                Calendar Item = new Calendar();

                Item.idTeacher = dbItem.idTeacher;
                Item.idPupil = dbItem.idPupil;
                Item.day = dbItem.day;
                Item.timeBegin = dbItem.timeBegin;
                Item.timeEnd = dbItem.timeEnd;
                Item.active = dbItem.active;
                Item.comment = dbItem.comment;
                Item.dateBegin = dbItem.dateBegin;
                Item.dateEnd = dbItem.dateEnd;
                Item.PupilAddress = dbItem.PupilAddress;
                Item.PupilPhone = dbItem.PupilPhone;
                Item.PupilName = dbItem.PupilName;

                this.Items.Add(Item);
            }

            return this.Items;
        }

        public Calendar getItemByIDS(int _idTeacher, int _idPupil, int _day)
        {
            DBWorker.dbCalendar dbItem = DBWCal.getItemByIDSFromDB(_idTeacher, _idPupil, ++_day);

            Calendar Item = new Calendar();

            Item.idTeacher = dbItem.idTeacher;
            Item.idPupil = dbItem.idPupil;
            Item.day = --dbItem.day;
            Item.timeBegin = dbItem.timeBegin;
            Item.timeEnd = dbItem.timeEnd;
            Item.active = dbItem.active;
            Item.comment = dbItem.comment;
            Item.dateBegin = dbItem.dateBegin;
            Item.dateEnd = dbItem.dateEnd;

            return Item;
        }

        public ObservableCollection<Calendar> GetItemsByIdPupil(int _idTeacher, int _idPupil)
        {
            ObservableCollection<Calendar> retVal = new ObservableCollection<Calendar>();

            List<DBWorker.dbCalendar> dbItems = DBWCal.getItemByIDPupilFromDB(_idTeacher, _idPupil);

            foreach (DBWorker.dbCalendar dbItem in dbItems)
            {
                Calendar Item = new Calendar();

                Item.active = dbItem.active;
                Item.comment = dbItem.comment;
                Item.dateBegin = dbItem.dateBegin;
                Item.dateEnd = dbItem.dateEnd;
                Item.day = --dbItem.day;
                Item.idPupil = dbItem.idPupil;
                Item.idTeacher = dbItem.idTeacher;
                Item.timeBegin = dbItem.timeBegin;
                Item.timeEnd = dbItem.timeEnd;

                retVal.Add(Item);
            }

            return retVal;
        }

        public void AddItemToDB(Calendar _Item)
        {
            DBWorker.dbCalendar Item = new DBWorker.dbCalendar();

            Item.active = _Item.active;
            Item.comment = _Item.comment;
            Item.dateBegin = _Item.dateBegin;
            Item.dateEnd = _Item.dateEnd;
            Item.day = ++_Item.day;
            Item.idPupil = _Item.idPupil;
            Item.idTeacher = _Item.idTeacher;
            Item.timeBegin = _Item.timeBegin;
            Item.timeEnd = _Item.timeEnd;

            if (DBWCal.getItemByIDSFromDB(_Item.idTeacher, _Item.idPupil, _Item.day).idPupil == 0)
            {
                DBWCal.createCalendarInDB(Item);
            }
            else
            {
                DBWCal.updateCalendarInDB(Item);
            }
        }

        public void RemoveItemFromDB(int _idTeacher, int _idPupil, int _day)
        {
            DBWCal.deleteCalendarInDBbyIDS(_idTeacher, _idPupil, ++_day);
        }
    }
}
