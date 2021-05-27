using School.Helpers;
using School.Models;
using School.Views.LogInView;
using School.Views.MasterView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Teacher
{
    class TeacherUserControlVM
    {
        public static int CURRENT_TEACHER { get; set; }

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
            var isMaster = context.GetClassWhereMaster(CURRENT_TEACHER).ToList<int?>();

            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    if (isMaster[0] != null)
                        Switcher.Switch(new MasterUserControl());
                    else
                        MessageBox.Show("This teacher is not a classmaster!");
                    break;
                case "2":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
                case "4":
                    Switcher.Switch(new AbsenceUserControl());
                    break;
                case "5":
                    Switcher.Switch(new GradeUserControl());
                    break;
                case "6":
                    Switcher.Switch(new MaterialUserControl());
                    break;
                case "7":
                    break;

            }
        }
    }
}