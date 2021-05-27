using School.Helpers;
using School.Models;
using School.ViewModels.UsersControl.Student;
using School.Views.LogInView;
using School.Views.MasterView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Teacher
{
    class AbsenceUserControlVM : BaseVM
    {
        private SubjectVM _SelectedSubject;
        public SubjectVM SelectedSubject
        {
            get => _SelectedSubject;
            set => SetProperty(ref _SelectedSubject, value);
        }

        private StudentVM _SelectedStudent;
        public StudentVM SelectedStudent
        {
            get => _SelectedStudent;
            set => SetProperty(ref _SelectedStudent, value);
        }

        private AbsenceVM _SelectedAbsence;
        public AbsenceVM SelectedAbsence
        {
            get => _SelectedAbsence;
            set => SetProperty(ref _SelectedAbsence, value);
        }

        private ObservableCollection<AbsenceVM> _Absences;
        public ObservableCollection<AbsenceVM> Absences
        {
            get
            {
                if (_Absences == null)
                {
                    _Absences = new ObservableCollection<AbsenceVM>();
                }

                return _Absences;
            }
            set
            {
                SetProperty(ref _Absences, value);
            }
        }

        public ObservableCollection<SubjectVM> Subjects { get; set; }

        private ObservableCollection<StudentVM> _Students;
        public ObservableCollection<StudentVM> Students
        {
            get
            {
                if (_Students == null)
                {
                    _Students = new ObservableCollection<StudentVM>();
                }
                return _Students;
            }

            set
            {
                SetProperty(ref _Students, value);
            }
        }

        SchoolDBEntities context = new SchoolDBEntities();

        public AbsenceUserControlVM()
        {
            Subjects = new ObservableCollection<SubjectVM>();
            var temp = context.GetAllTeacherSubject(TeacherUserControlVM.CURRENT_TEACHER);

            foreach (var subject in temp)
            {
                Subjects.Add(new SubjectVM()
                {
                    IdSubject = subject.id_subject,
                    Name = subject.name,
                    Term = subject.term,
                    IdTeacher = TeacherUserControlVM.CURRENT_TEACHER
                });
            }
        }

        private void UpdateStudents(object obj)
        {
            Students = new ObservableCollection<StudentVM>();
            if (SelectedSubject != null)
            {
                var temp = context.TeacherGetStudentsBySubject(TeacherUserControlVM.CURRENT_TEACHER, SelectedSubject.IdSubject);

                foreach (var student in temp)
                {
                    Students.Add(new StudentVM()
                    {
                        Id = student.id_student,
                        Person = new PersonVM()
                        {
                            FirstName = student.first_name,
                            LastName = student.last_name
                        },
                        IdClass = (int)student.fk_class
                    });
                }
            }
        }

        private void UpdateAbsences(object obj)
        {
            Absences = new ObservableCollection<AbsenceVM>();

            if (SelectedStudent != null)
            {
                var temp = context.GetAllAbsenceBySubject(SelectedSubject.IdSubject, SelectedStudent.Id);

                foreach (var absence in temp)
                {
                    Absences.Add(new AbsenceVM()
                    {
                        IdAbsence = absence.id_absence,
                        Date = absence.date,
                        IsJustified = absence.is_justified,
                        CanBeJustified = absence.can_be_justified
                    });
                }
            }
        }

        private ICommand _LoadStudents;
        public ICommand LoadStudents
        {
            get
            {
                if (_LoadStudents == null)
                {
                    _LoadStudents = new RelayCommand(UpdateStudents);
                }

                return _LoadStudents;
            }
        }

        private ICommand _LoadAbsences;
        public ICommand LoadAbsences
        {
            get
            {
                if (_LoadAbsences == null)
                {
                    _LoadAbsences = new RelayCommand(UpdateAbsences);
                }

                return _LoadAbsences;
            }
        }

        private ICommand _SaveAbsences;
        public ICommand SaveAbsences
        {
            get
            {
                if (_SaveAbsences == null)
                {
                    _SaveAbsences = new RelayCommand(SaveAbsence);
                }

                return _SaveAbsences;
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
                    Switcher.Switch(new TeacherUserControl());
                    break;
                case "2":
                    Switcher.Switch(new MasterUserControl());
                    break;
                case "3":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "4":
                    Switcher.pageSwitcher.Close();
                    break;
                case "5":
                    JustifyAbsence();
                    break;
                case "6":
                    AddAbsence();
                    break;

            }
        }

        private void SaveAbsence(object obj)
        {
            if (obj != null)
            {
                var absence = obj as AbsenceVM;

                context.TeacherAddAbsence(TeacherUserControlVM.CURRENT_TEACHER, SelectedStudent.Id, SelectedSubject.IdSubject, SelectedSubject.Term, absence.Date, true);

                UpdateAbsences(new object());

            }
            else
            {
                MessageBox.Show("Invald fields entered!");
            }
        }

        private void AddAbsence()
        {
            SelectedAbsence = null;
        }

        private void JustifyAbsence()
        {
            if (SelectedAbsence.CanBeJustified)
            {
                SelectedAbsence.IsJustified = true;

                var temp = context.TeacherJustifyAbsence(TeacherUserControlVM.CURRENT_TEACHER, SelectedStudent.Id, SelectedSubject.IdSubject, SelectedSubject.Term, SelectedAbsence.IdAbsence);
            }
            else
            {
                MessageBox.Show("This absence can't be justified!");
            }
        }
    }
}
