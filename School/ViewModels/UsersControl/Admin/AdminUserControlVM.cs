using School.Helpers;
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
    class AdminUserControlVM
    {
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
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "2":
                    Switcher.pageSwitcher.Close();
                    break;
                case "3":
                    Switcher.Switch(new EditStudentUserControl());
                    break;
                case "4":
                    Switcher.Switch(new EditTeacherUserControl());
                    break;
                case "5":
                    Switcher.Switch(new EditClassUserControl());
                    break;
                case "6":
                    break;
            }
        }
    }
}
