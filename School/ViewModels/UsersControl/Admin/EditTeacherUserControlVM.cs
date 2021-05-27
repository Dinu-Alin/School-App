using School.Helpers;
using School.Models;
using School.Models.Actions.Admin;
using School.Models.Actions.Teacher;
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
    class EditTeacherUserControlVM
    {

        public ObservableCollection<TeacherVM> Teachers { get; set; }

        public static int CURRENT_TEACHER { get; set; }

        EditTeacherAction action = new EditTeacherAction();

        SchoolDBEntities context = new SchoolDBEntities();

        public EditTeacherUserControlVM()
        {
            Teachers = new ObservableCollection<TeacherVM>();

            var temp = context.AdminGetAllTeachers();
            foreach (var teacher in temp)
            {
                Teachers.Add(new TeacherVM()
                {
                    IdTeacher = teacher.id_person,
                    Person = new PersonVM()
                    {
                        FirstName = teacher.first_name,
                        LastName = teacher.last_name,
                        Password = teacher.password,
                        Username = teacher.username
                    }
                });
            }

        }



        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;

            set
            {
                if (_selectedIndex == value)
                {
                    return;
                }


                _selectedIndex = value;

                CURRENT_TEACHER = ((Switcher.pageSwitcher.Content as EditTeacherUserControl).listTeachers.Items.GetItemAt(_selectedIndex) as TeacherVM).IdTeacher;
            }
        }



        private ICommand _EditTeacher;
        public ICommand EditTeacher
        {
            get
            {
                if (_EditTeacher == null)
                {
                    _EditTeacher = new RelayCommand(action.EditTeacher);
                }

                return _EditTeacher;
            }
        }

        private ICommand _DeleteTeacher;
        public ICommand DeleteTeacher
        {
            get
            {
                if (_DeleteTeacher == null)
                {
                    _DeleteTeacher = new RelayCommand(action.DeleteTeacher);
                }

                return _DeleteTeacher;
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
                    Switcher.Switch(new EditTeacherSubjectUserControl());
                    break;
                case "5":
                    Switcher.Switch(new AddTeacherUserControl());
                    break;


            }
        }
    }
}
