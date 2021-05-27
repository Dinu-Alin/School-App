using School.Helpers;
using School.Models;
using School.ViewModels.UsersControl.Student;
using School.ViewModels.UsersControl.Teacher;
using School.Views.AdminView;
using School.Views.LogInView;
using School.Views.StudentView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.LogIn
{
    class LogInUserControlVM
    {
        SchoolDBEntities context = new SchoolDBEntities();

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
                    Switcher.pageSwitcher.Close();
                    break;
                case "2":
                    LogIn();
                    break;
            }


        }
        public void LogIn()
        {
            try
            {
                LogInUserControl logInUserControl = Switcher.pageSwitcher.Content as LogInUserControl;

                var userId = context.CheckCredentials(logInUserControl.textBoxEmail.Text, logInUserControl.passwordBox.Password).ToList<int?>();

                if (logInUserControl == null)
                    return;
                var role = context.FindRole(userId[0]).ToList<String>();
                if (role[0].Equals("admin"))
                    Switcher.Switch(new AdminUserControl());
                else
                if (role[0].Equals("teacher"))
                {
                    TeacherUserControlVM.CURRENT_TEACHER = (int)userId[0];
                    Switcher.Switch(new TeacherUserControl());
                }
                else
                {
                    StudentUserControlVM.CURRENT_STUDENT = (int)userId[0];
                    Switcher.Switch(new StudentUserControl());

                }
            }
            catch(Exception e)
            {
                //do nothing
            }
        }
    }
}