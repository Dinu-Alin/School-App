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
using System.Windows.Controls;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Admin
{

    class EditTeacherSubjectUserControlVM
    {
        public ObservableCollection<SubjectVM> Subjects { get; set; }

        EditTeacherSubjectAction action = new EditTeacherSubjectAction();


        SchoolDBEntities context = new SchoolDBEntities();

        public EditTeacherSubjectUserControlVM()
        {
            Subjects = new ObservableCollection<SubjectVM>();

            var temp = context.GetAllTeacherSubject(EditTeacherUserControlVM.CURRENT_TEACHER);

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

        private ICommand _EditSubject;
        public ICommand EditSubject
        {
            get
            {
                if (_EditSubject == null)
                {
                    _EditSubject = new RelayCommand(action.EditSubject);
                }

                return _EditSubject;
            }
        }

        private ICommand _DeleteSubject;
        public ICommand DeleteSubject
        {
            get
            {
                if (_DeleteSubject == null)
                {
                    _DeleteSubject = new RelayCommand(action.DeleteSubject);
                }

                return _DeleteSubject;
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
                case "4":
                    Switcher.Switch(new AddTeacherSubjectUserControl()); ;
                    break;
            }
        }
    }
}
