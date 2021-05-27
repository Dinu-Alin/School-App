using School.Helpers;
using School.Models.Actions.Admin;
using School.Models.Actions.Teacher;
using School.Views.AdminView;
using School.Views.LogInView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Admin
{
    class AddTeacherUserControlVM
    {
        private ICommand _AddTeacher;
        public ICommand AddTeacher
        {
            get
            {
                if (_AddTeacher == null)
                {
                    _AddTeacher = new RelayCommand((new EditTeacherAction()).AddTeacher);
                }

                return _AddTeacher;
            }
        }

        private ICommand openUserControlCommand;
        public ICommand OpenUserControlCommand
        {
            get
            {
                if (openUserControlCommand == null)
                {
                    openUserControlCommand = new RelayCommand(OpenUserControl);
                }
                return openUserControlCommand;
            }
        }



        public void OpenUserControl(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    Switcher.Switch(new EditTeacherUserControl());
                    break;
                case "2":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
            }
        }
    }
}
