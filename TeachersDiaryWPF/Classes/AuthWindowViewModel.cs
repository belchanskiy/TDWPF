using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace TeachersDiaryWPF
{
    public class AuthWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string login;
        private string password;

        
        private void OnPropertyChanged(string prop = "")
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string text_Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("text_Login");
            }
        }

        private ICommand btnLoginCMD;
        private ICommand btnCancelCMD;

        public ICommand Button_Login_CMD
        {
            get
            {
                return btnLoginCMD;
            }
            set {}
        }

        public ICommand Button_Cancel_CMD
        {
            get
            {
                return btnCancelCMD;
            }
            set { }
        }

        public string password_Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("password_Password");
            }
        }

        public AuthWindowViewModel()
        {
            login = "";
            password = "";

            btnLoginCMD = new Button_Login_Command(this);
            btnCancelCMD = new Button_Cancel_Command(this);
        }

    }

    public class Button_Login_Command : ICommand
    {
        private AuthWindowViewModel model;

        public bool CanExecute(object sender)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public Button_Login_Command(AuthWindowViewModel model)
        {
            this.model = model;
        }

        public void Execute(object sender)
        {
            if (model.text_Login == "")
            {
                MessageBox.Show("Не введено имя пользователя");
                return;
            }

            dataTypes.User User = new dataTypes.User(model.text_Login, model.password_Password);

            new AlgoWorker.Authorizer().AuthorizeMe(User);
            //REVIEW: Встроенные методы
            if (User.name != "")
            {
                AuthWindow ParentWindow = (AuthWindow)sender;
                new MainWindow(User).Show();
                ParentWindow.Close();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
    }

    public class Button_Cancel_Command : ICommand
    {
        private AuthWindowViewModel model;

        public bool CanExecute(object sender)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public Button_Cancel_Command(AuthWindowViewModel model)
        {
            this.model = model;
        }

        public void Execute(object sender)
        {
            AuthWindow ParentWindow = (AuthWindow)sender;
            if (MessageBox.Show("Выйти из программы?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                ParentWindow.Close(); ;         
        }
    }
}
