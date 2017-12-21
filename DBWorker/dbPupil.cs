using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWorker
{
    public class dbPupil
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

        public dbPupil()
        {
            id = -1;
        }
    }

    public class dbPupils
    {
        List<dbPupil> Items;

        public List<dbPupil> GetPupilsFromDB()
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Items = mydbe.Pupils.Select(pup => new dbPupil()
                    {
                        id = pup.Id,
                        name = pup.name,
                        grade = pup.grade,
                        target = pup.target,
                        address = pup.address,
                        parentName = pup.parentName,
                        parentPhone = pup.parentPhone,
                        comment = pup.comment,
                        active = pup.active,
                    }).ToList();
                }
                catch
                {
                    //REVIEW: Ну и в чём смысл поймать и опять кинуть исключение?
                    throw new AccessViolationException("Ошибка чтения значений из базы данных");
                }
            }

            return Items;
        }

        public dbPupil GetPupilByIdFromDB(int _id)
        {
            dbPupil result = new dbPupil();

            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Pupils pup = mydbe.Pupils.Where(b => b.Id == _id).First();

                    result.id = pup.Id;
                    result.name = pup.name;
                    result.grade = pup.grade;
                    result.target = pup.target;
                    result.address = pup.address;
                    result.parentName = pup.parentName;
                    result.parentPhone = pup.parentPhone;
                    result.comment = pup.comment;
                    result.active = pup.active;
                }
                catch
                {
                    //REVIEW: И чего? Глотаем исключение?
                    //throw new AccessViolationException();
                }
            }

            return result;
        }

        public void RemovePupilByIdFromDB(int _id)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Pupils pup = mydbe.Pupils.Where(b => b.Id == _id).First();

                    mydbe.Pupils.Remove(pup);
                    mydbe.SaveChanges();
                }
                catch
                {
                    //REVIEW:Поймали и кинули? А залоггировать?
                    throw new AccessViolationException("Не удалось удалить элемент из БД");
                }
            }
        }

        public void UpdatePupilInDB(dbPupil _pupil)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Pupils pup = mydbe.Pupils.Where(a => a.Id == _pupil.id).First();

                    pup.name        = _pupil.name;
                    pup.grade       = _pupil.grade;
                    pup.target      = _pupil.target;
                    pup.address     = _pupil.address;
                    pup.parentName  = _pupil.parentName;
                    pup.parentPhone = _pupil.parentPhone;
                    pup.comment     = _pupil.comment;
                    pup.active      = _pupil.active;

                    mydbe.SaveChanges();
                }
                catch
                {
                    //REVIEW: Поймали и кинули?
                    throw new AccessViolationException();
                }
            }
        }

        public void CreatePupilInDB(dbPupil _pupil)
        {
            using (mydbaseEntities mydbe = new mydbaseEntities())
            {
                try
                {
                    Pupils pup = new Pupils();
                    
                    pup.name = _pupil.name;
                    pup.grade = _pupil.grade;
                    pup.target = _pupil.target;
                    pup.address = _pupil.address;
                    pup.parentName = _pupil.parentName;
                    pup.parentPhone = _pupil.parentPhone;
                    pup.comment = _pupil.comment;
                    pup.active = _pupil.active;

                    mydbe.Pupils.Add(pup);
                    mydbe.SaveChanges();
                }
                catch (Exception e)
                {
                    //REVIEW: Поймали и кинули?
                    throw new AccessViolationException("Не удалось записать в БД", e);
                }
            }
        }
    }
}
