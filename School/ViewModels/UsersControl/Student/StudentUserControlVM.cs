using School.Helpers;
using School.Models;
using School.Views.LogInView;
using School.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Student
{
    class StudentUserControlVM
    {

        public ObservableCollection<SubjectVM> Subjects { get; set; }

        public static int CURRENT_STUDENT { get; set; }
        public static int CURRENT_SUBJECT { get; set; }

        SchoolDBEntities context = new SchoolDBEntities();

        public StudentUserControlVM()
        {
            Subjects = new ObservableCollection<SubjectVM>();

            var temp = context.StudentViewSubjects(CURRENT_STUDENT);
            foreach (var subject in temp)
            {
                Subjects.Add(new SubjectVM()
                {
                    IdSubject = subject.id_subject, 
                    Name = subject.name, 
                    Term = subject.term
                }
                );
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

                CURRENT_SUBJECT = ((Switcher.pageSwitcher.Content as StudentUserControl).listSubject.Items.GetItemAt(_selectedIndex) as SubjectVM).IdSubject;
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
                case "log_out":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "exit":
                    Switcher.pageSwitcher.Close();
                    break;
                case "absence":
                    Switcher.Switch(new AbsenceUserControl());
                    break;
                case "grade":
                    Switcher.Switch(new GradeUserControl());
                    break;
                case "material":
                    Switcher.Switch(new MaterialUserControl());
                    break;
            }
        }
    }
}
