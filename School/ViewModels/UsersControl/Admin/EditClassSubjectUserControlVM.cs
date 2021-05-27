using School.Helpers;
using School.Models;
using School.Models.Actions.Admin;
using School.Views.AdminView;
using School.Views.LogInView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Admin
{
    class EditClassSubjectUserControlVM
    {

        ObservableCollection<ClassVM> Classes;

        private EditClassSubjectAction adminActions = new EditClassSubjectAction();

        SchoolDBEntities context = new SchoolDBEntities();

        public EditClassSubjectUserControlVM()
        {
            //Classes = new ObservableCollection<ClassVM>();

            //var temp = context.GetAllClasses();

            //foreach (var @class in temp)
            //{
            //    Classes.Add(new ClassVM()
            //    {
            //        IdClass = student.,
            //        Person = new ClassVM()
            //        {
            //            FirstName = student.first_name,
            //            LastName = student.last_name,
            //            Password = student.password,
            //            Username = student.username
            //        },
            //        IdClass = (int)student.fk_class
            //    }); ;

            //}
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
                    Switcher.Switch(new AdminUserControl());
                    break;
                case "2":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
                case "4":
                    EditClass();
                    break;
                case "5":
                    DeleteClass();
                    break;
                case "6":
                    AddClass();
                    break;
                case "7":
                    SaveClass();
                    break;
                case "8":
                    EditSubject();
                    break;
                case "9":
                    DeleteSubject();
                    break;
                case "10":
                    AddSubject();
                    break;
                case "11":
                    SaveSubject();
                    break;
            }
        }

        private void SaveSubject()
        {
            throw new NotImplementedException();
        }

        private void AddSubject()
        {
            throw new NotImplementedException();
        }

        private void DeleteSubject()
        {
            throw new NotImplementedException();
        }

        private void EditSubject()
        {
            throw new NotImplementedException();
        }

        private void SaveClass()
        {
            throw new NotImplementedException();
        }

        private void AddClass()
        {
            throw new NotImplementedException();
        }

        private void DeleteClass()
        {
            throw new NotImplementedException();
        }

        private void EditClass()
        {
            throw new NotImplementedException();
        }
    }
}
