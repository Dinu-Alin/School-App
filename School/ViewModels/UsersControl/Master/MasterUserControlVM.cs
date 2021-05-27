using School.Helpers;
using School.Models;
using School.ViewModels.UsersControl.Teacher;
using School.Views.LogInView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Master
{
    class MasterUserControlVM : BaseVM
    {


        SchoolDBEntities context = new SchoolDBEntities();

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

        private void UpdateStudents(object obj)
        {
            Students = new ObservableCollection<StudentVM>();
            var temp = context.GetAllStudentsInAClass(TeacherUserControlVM.CURRENT_TEACHER);

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
                    IdClass = (int)student.fk_class,
                    AnnualGrade = student.annual_grade
                });
            }
        }

        private void UpdateAbsences(object obj)
        {
            Absences = new ObservableCollection<AbsenceVM>();


            var temp = context.GetAllAbsencesFromClass(TeacherUserControlVM.CURRENT_TEACHER);

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
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
                case "4":
                    ShowAllStudents();
                    break;
                case "5":
                    ShowStudentTermSituation();
                    break;
                case "6":
                    ShowClassSituation();
                    break;
                case "7":
                    SworAwardStudents();
                    break;
                case "8":
                    ShowCorrectingStudents();
                    break;
                case "9":
                    ShowExpelledStudents();
                    break;
                case "10":
                    JustifyAbsence();
                    break;
                case "11":
                    ShowUnjustifyAbsence();
                    break;
                case "12":
                    AllAbsence();
                    break;
                case "13":
                    AllUnjustifyAbsence();
                    break;


            }
        }

        private void AllAbsence()
        {
            throw new NotImplementedException();
        }

        private void AllUnjustifyAbsence()
        {
            throw new NotImplementedException();
        }

        private void ShowUnjustifyAbsence()
        {
            Absences = new ObservableCollection<AbsenceVM>();


            var temp = context.GetAllAbsencesFromClass(TeacherUserControlVM.CURRENT_TEACHER);

            foreach (var absence in temp)
            {
                if (!absence.is_justified)
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

        private void JustifyAbsence()
        {
            if (SelectedAbsence.CanBeJustified)
            {
                SelectedAbsence.IsJustified = true;
                var SelectedSubject = (from absence in context.Absences
                                       join teacher_subjet in context.Teacher_Subject on absence.fk_teacher_subject equals teacher_subjet.id_teacher_subject
                                       join subject in context.Subjects on teacher_subjet.fk_subject equals subject.id_subject
                                       where absence.fk_student == SelectedStudent.Id
                                       select subject).First();
                int selectedSubjectId = SelectedSubject.id_subject;


                var temp = context.TeacherJustifyAbsence(TeacherUserControlVM.CURRENT_TEACHER, SelectedStudent.Id, selectedSubjectId, SelectedSubject.term, SelectedAbsence.IdAbsence);
            }
            else
            {
                MessageBox.Show("This absence can't be justified!");
            }
        }

        private void ShowExpelledStudents()
        {
            throw new NotImplementedException();
        }

        private void ShowCorrectingStudents()
        {
            throw new NotImplementedException();
        }

        private void SworAwardStudents()
        {
            throw new NotImplementedException();
        }

        private void ShowClassSituation()
        {
            throw new NotImplementedException();
        }

        private void ShowStudentTermSituation()
        {
            throw new NotImplementedException();
        }

        private void ShowAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}
