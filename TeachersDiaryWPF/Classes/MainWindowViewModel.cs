using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TeachersDiaryWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public dataTypes.User User;

        public event PropertyChangedEventHandler PropertyChanged;

        public AlgoWorker.PupilsWorker AWpWorker;
        public AlgoWorker.CalendarWorker AWcWorker;

        private ObservableCollection<AlgoWorker.Calendar> cPupilsList;

        public ObservableCollection<AlgoWorker.Calendar> CalPupilsList
        {
            get { return this.cPupilsList; }
            set
            {
                this.cPupilsList = value;
                OnPropertyChanged("CalPupilsList");
            }
        }

        private List<AlgoWorker.Calendar> calEvents;

        public List<AlgoWorker.Calendar> CalendarEvents
        {
            get { return this.calEvents; }
            set
            {
                this.calEvents = value;
                OnPropertyChanged("CalendarEvents");
            }
        }

        private DateTime cSelDate;

        public DateTime CalSelDate
        {
            get { return this.cSelDate; }
            set
            {
                this.cSelDate = value;
                OnPropertyChanged("CalSelDate");
            }
        }

        private int pId;
        public int PupilId
        {
            get { return this.pId; }
            set
            {
                this.pId = value;
                OnPropertyChanged("PupilId");
            }
        }
        private string pName;
        public string PupilName
        {
            get { return this.pName; }
            set
            {
                this.pName = value;
                OnPropertyChanged("PupilName");
            }
        }
        private string pGrade;
        public string PupilGrade
        {
            get { return this.pGrade; }
            set
            {
                this.pGrade = value;
                OnPropertyChanged("PupilGrade");
            }
        }
        private string pTarget;
        public string PupilTarget
        {
            get { return this.pTarget; }
            set
            {
                this.pTarget = value;
                OnPropertyChanged("PupilTarget");
            }
        }
        private string pAddress;
        public string PupilAddress
        {
            get { return this.pAddress; }
            set
            {
                this.pAddress = value;
                OnPropertyChanged("PupilAddress");
            }
        }
        public string pParentName;
        public string PupilParentName
        {
            get { return this.pParentName; }
            set
            {
                this.pParentName = value;
                OnPropertyChanged("PupilParentName");
            }
        }
        private string pParentPhone;
        public string PupilParentPhone
        {
            get { return this.pParentPhone; }
            set
            {
                this.pParentPhone = value;
                OnPropertyChanged("PupilParentPhone");
            }
        }
        private string pComment;
        public string PupilComment
        {
            get { return this.pComment; }
            set
            {
                this.pComment = value;
                OnPropertyChanged("PupilComment");
            }
        }
        private bool pActive;
        public bool   PupilActive
        {
            get { return this.pActive; }
            set
            {
                this.pActive = value;
                OnPropertyChanged("PupilActive");
            }
        }

        private int jDayOfWeek;
        public int JournDayOfWeek
        {
            get { return this.jDayOfWeek; }
            set
            {
                this.jDayOfWeek = value;
                OnPropertyChanged("JournDayOfWeek");
            }
        }

        private DateTime jDateStart;
        public DateTime JournDateStart
        {
            get { return this.jDateStart; }
            set
            {
                this.jDateStart = value;
                OnPropertyChanged("JournDateStart");
            }
        }

        private DateTime jDateEnd;
        public DateTime JournDateEnd
        {
            get { return this.jDateEnd; }
            set
            {
                this.jDateEnd = value;
                OnPropertyChanged("JournDateEnd");
            }
        }

        private int jTimeStartH;
        public int JournTimeStartH
        {
            get { return this.jTimeStartH; }
            set
            {
                this.jTimeStartH = value;
                OnPropertyChanged("JournTimeStartH");
            }
        }

        private int jTimeStartM;
        public int JournTimeStartM
        {
            get { return this.jTimeStartM; }
            set
            {
                this.jTimeStartM = value;
                OnPropertyChanged("JournTimeStartM");
            }
        }

        private int jTimeEndH;
        public int JournTimeEndH
        {
            get { return this.jTimeEndH; }
            set
            {
                this.jTimeEndH = value;
                OnPropertyChanged("JournTimeEndH");
            }
        }

        private int jTimeEndM;
        public int JournTimeEndM
        {
            get { return this.jTimeEndM; }
            set
            {
                this.jTimeEndM = value;
                OnPropertyChanged("JournTimeEndM");
            }
        }

        private string jComment;
        public string JournComment
        {
            get { return this.jComment; }
            set
            {
                this.jComment = value;
                OnPropertyChanged("JournComment");
            }
        }

        private bool jActive;
        public bool JournActive
        {
            get { return this.jActive; }
            set
            {
                this.jActive = value;
                OnPropertyChanged("JournActive");
            }
        }

        private ObservableCollection<AlgoWorker.Pupil> pList;
        public ObservableCollection<AlgoWorker.Pupil> PupilsList
        {
            get { return this.pList; }
            set
            {
                this.pList = value;
                OnPropertyChanged("PupilsList");
            }
        }

        public ICommand BtnPupilOK { get; set; }
        public ICommand BtnPupilAdd { get; set; }
        public ICommand BtnPupilModify { get; set; }
        public ICommand BtnPupilRemove { get; set; }
        public ICommand CalSelDateChanged { get; set; }
        public ICommand BtnPupCalOK { get; set; }
        public ICommand BtnPupCalAdd { get; set; }
        public ICommand BtnPupCalMod { get; set; }
        public ICommand BtnPupCalRem { get; set; }

        public ObservableCollection<AlgoWorker.Pupil> Pupils;

        private void OnPropertyChanged(string prop = "")
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void clearPupilFields()
        {
            this.PupilActive = false;
            this.PupilAddress = "";
            this.PupilComment = "";
            this.PupilGrade = "";
            this.PupilId = 0;
            this.PupilName = "";
            this.PupilParentName = "";
            this.PupilParentPhone = "";
            this.PupilTarget = "";
        }

        public void RemovePupilById(int _id)
        {
            AWpWorker.removePupilById(_id);
            this.UpdatePupilsList();
        }

        public void ClearJournFields()
        {
            this.JournActive = false;
            this.JournComment = "";
            this.JournDateEnd = new DateTime();
            this.JournDateStart = new DateTime();
            this.JournDayOfWeek = -1;
            this.JournTimeEndH = 0;
            this.JournTimeEndM = 0;
            this.JournTimeStartH = 0;
            this.JournTimeStartM = 0;
        }

        public void UpdateJournalList()
        {
            this.CalPupilsList = AWcWorker.GetItemsByIdPupil(this.User.id, this.PupilId);
        }

        public void UpdatePupilsList()
        {
            PupilsList = AWpWorker.getPupils();
        }

        public void fillPupilsField(AlgoWorker.Pupil _pupil)
        {
            this.PupilActive = _pupil.active;
            this.PupilAddress = _pupil.address;
            this.PupilComment = _pupil.comment;
            this.PupilGrade = _pupil.grade;
            this.PupilId = _pupil.id;
            this.PupilName = _pupil.name;
            this.PupilParentName = _pupil.parentName;
            this.PupilParentPhone = _pupil.parentPhone;
            this.PupilTarget = _pupil.target;
        }

        public MainWindowViewModel(dataTypes.User _User)
        {
            this.User = _User;
            AWpWorker = new AlgoWorker.PupilsWorker();
            AWcWorker = new AlgoWorker.CalendarWorker();

            Pupils = AWpWorker.getPupils();

            BtnPupilOK = new Button_PupilOK(this);
            BtnPupilAdd = new Button_PupilAdd(this);
            BtnPupilModify = new Button_PupilModify(this);
            BtnPupilRemove = new Button_PupilRemove(this);
            BtnPupCalAdd = new Button_PupCalAdd(this);
            BtnPupCalMod = new Button_PupCalMod(this);
            BtnPupCalOK = new Button_PupCalOK(this);
            BtnPupCalRem = new Button_PupCalDel(this);

            CalSelDateChanged = new Calendar_DateCahnged(this);

            JournDayOfWeek = -1;

            this.CalendarEvents = AWcWorker.getItemsByDate(DateTime.Now);

            this.UpdatePupilsList();
            this.UpdateJournalList();

        }
    }

    public class Button_PupilOK : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;


        public Button_PupilOK(object _model)
        {
            model = (MainWindowViewModel)_model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            model.AWpWorker.updateOrCreatePupil(new AlgoWorker.Pupil(model.PupilId,
                                                                     model.PupilName,
                                                                     model.PupilGrade,
                                                                     model.PupilTarget,
                                                                     model.PupilAddress,
                                                                     model.PupilParentName,
                                                                     model.PupilParentPhone,
                                                                     model.PupilComment,
                                                                     model.PupilActive));
            model.UpdatePupilsList();
            model.clearPupilFields();
        }
    }

    public class Button_PupilAdd : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;


        public Button_PupilAdd(MainWindowViewModel _model)
        {
            model = _model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            model.clearPupilFields();
        }
    }

    public class Button_PupilModify : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;


        public Button_PupilModify(MainWindowViewModel _model)
        {
            model = _model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow _parameter = (MainWindow)parameter;

            if (_parameter.ListPupils.SelectedValue != null) model.fillPupilsField((AlgoWorker.Pupil)_parameter.ListPupils.SelectedValue);
        }
    }

    public class Button_PupilRemove : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;


        public Button_PupilRemove(MainWindowViewModel _model)
        {
            model = _model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow _parameter = (MainWindow)parameter;

            if (_parameter.ListPupils.SelectedValue != null) model.RemovePupilById(((AlgoWorker.Pupil)_parameter.ListPupils.SelectedValue).id);
        }
    }

    public class Calendar_DateCahnged : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;


        public Calendar_DateCahnged(MainWindowViewModel _model)
        {
            model = _model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow _parameter = (MainWindow)parameter;

            this.model.CalendarEvents = this.model.AWcWorker.getItemsByDate((DateTime)_parameter.MainCalendar.SelectedDate);
        }
    }

    public class Button_PupCalOK : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;

        public Button_PupCalOK(object _model)
        {
            model = (MainWindowViewModel)_model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AlgoWorker.Calendar Item = new AlgoWorker.Calendar();

            Item.active = model.JournActive;
            Item.comment = model.JournComment;
            Item.dateBegin = model.JournDateStart;
            Item.dateEnd = model.JournDateEnd;
            Item.day = model.JournDayOfWeek;
            Item.idPupil = model.PupilId;
            Item.idTeacher = model.User.id;
            Item.timeBegin = new TimeSpan(model.JournTimeStartH, model.JournTimeStartM, 0);
            Item.timeEnd = new TimeSpan(model.JournTimeEndH, model.JournTimeEndM, 0);

            this.model.AWcWorker.AddItemToDB(Item);
            this.model.UpdateJournalList();
        }
    }

    public class Button_PupCalAdd : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;

        public Button_PupCalAdd(object _model)
        {
            model = (MainWindowViewModel)_model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            model.ClearJournFields();
        }
    }

    public class Button_PupCalDel : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;

        public Button_PupCalDel(object _model)
        {
            model = (MainWindowViewModel)_model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //this.model.AWcWorker.
            int f = 1;
        }
    }

    public class Button_PupCalMod : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private MainWindowViewModel model;

        public Button_PupCalMod(object _model)
        {
            model = (MainWindowViewModel)_model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AlgoWorker.Calendar Item = model.AWcWorker.getItemByIDS(this.model.User.id, this.model.PupilId, this.model.JournDayOfWeek);

            this.model.JournDayOfWeek = Item.day;
            this.model.JournDateStart = Item.dateBegin;
            this.model.JournDateEnd = (DateTime)Item.dateEnd;
            this.model.JournTimeEndH = Item.timeEnd.Hours;
            this.model.JournTimeEndM = Item.timeEnd.Minutes;
            this.model.JournTimeStartH = Item.timeBegin.Hours;
            this.model.JournTimeStartM = Item.timeBegin.Minutes;
            this.model.JournActive = Item.active;
            this.model.JournComment = Item.comment;

        }
    }
}
