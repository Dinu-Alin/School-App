using School.Helpers;
using School.Models;
using School.Models.Actions;
using School.Models.Actions.Admin;
using School.Views.AdminView;
using School.Views.LogInView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Admin
{
    class EditStudentUserControlVM : BaseVM
    {
        private EditStudentAction adminActions = new EditStudentAction();

        SchoolDBEntities context = new SchoolDBEntities();

        public ObservableCollection<StudentVM> Students { get; set; }

        public EditStudentUserControlVM()
        {
            Students = new ObservableCollection<StudentVM>();

            var temp = context.AdminGetAllStudents();

            foreach (var student in temp)
            {
                Students.Add(new StudentVM()
                {
                    Id = student.id_person,
                    Person = new PersonVM()
                    {
                        FirstName = student.first_name,
                        LastName = student.last_name,
                        Password = student.password,
                        Username = student.username
                    },
                    IdClass = (int)student.fk_class
                }); ;

            }
        }

        private ICommand _EditStudent;
        public ICommand EditStudent
        {
            get
            {
                if (_EditStudent == null)
                {
                    _EditStudent = new RelayCommand(adminActions.EditStudent);
                }

                return _EditStudent;
            }
        }

        private ICommand _DeleteStudent;
        public ICommand DeleteStudent
        {
            get
            {
                if (_DeleteStudent == null)
                {
                    _DeleteStudent = new RelayCommand(adminActions.DeleteStudent);
                }
                return _DeleteStudent;
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
                    Switcher.Switch(new AdminUserControl());
                    break;
                case "2":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
                case "4":
                    Switcher.Switch(new AddStudentUserControl());
                    break;

            }
        }


    }
}
