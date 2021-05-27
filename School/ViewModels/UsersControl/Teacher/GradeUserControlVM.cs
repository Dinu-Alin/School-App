using School.Helpers;
using School.Models;
using School.Models.Actions.Teacher;
using School.Views.LogInView;
using School.Views.MasterView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Teacher
{
    class GradeUserControlVM : BaseVM
    {
        private int? final_grade;

        GradeAction gradeAction = new GradeAction();
        public int? FINAL_GRADE
        {

            get => final_grade;
            set => SetProperty(ref final_grade, value);
        }

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

        private AbsenceVM _SelectedGrade;
        public AbsenceVM SelectedGrade
        {
            get => _SelectedGrade;
            set => SetProperty(ref _SelectedGrade, value);
        }

        private ObservableCollection<GradeVM> _Grades;
        public ObservableCollection<GradeVM> Grades
        {
            get
            {
                if (_Grades == null)
                {
                    _Grades = new ObservableCollection<GradeVM>();
                }

                return _Grades;
            }
            set
            {
                SetProperty(ref _Grades, value);
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

        public GradeUserControlVM()
        {

            //FINAL_GRADE = (context.TeacherUpdateSituation(SelectedSubject.IdSubject, SelectedStudent.Id, TeacherUserControlVM.CURRENT_TEACHER)).First();

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

        private void UpdateGrades(object obj)
        {
            Grades = new ObservableCollection<GradeVM>();

            if (SelectedStudent != null)
            {
                var temp = context.GetAllGradesBySubject(SelectedSubject.IdSubject, SelectedStudent.Id);

                foreach (var grade in temp)
                {
                    Grades.Add(new GradeVM()
                    {
                        IdGrade = grade.id_grade,
                        Date = grade.date,
                        IsMidterm = grade.is_midterm,
                        Mark = grade.mark
                    });
                }
            }

            MakeSituation();
        }
        private void AddGradeFunc(object obj)
        { 

            if(obj!=null)
            {
                var id = context.TeacherGetSituation(TeacherUserControlVM.CURRENT_TEACHER, SelectedStudent.Id, SelectedSubject.Name, SelectedSubject.Term).First();
                
                var grade = obj as GradeVM;

                context.TeacherAddGrade(grade.Mark, grade.Date, grade.IsMidterm, id);

                UpdateGrades(new object());
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

        private ICommand _AddGrade;
        public ICommand AddGrade
        {
            get
            {
                if (_AddGrade == null)
                {
                    _AddGrade = new RelayCommand(AddGradeFunc);
                }

                return _AddGrade;
            }
        }

        private ICommand _LoadGrades;
        public ICommand LoadGrades
        {
            get
            {
                if (_LoadGrades == null)
                {
                    _LoadGrades = new RelayCommand(UpdateGrades);
                }

                return _LoadGrades;
            }
        }

        private ICommand _DeleteGrade;
        public ICommand DeleteGrade
        {
            get
            {
                if (_DeleteGrade == null)
                {
                    _DeleteGrade = new RelayCommand(gradeAction.DeleteStudent);
                }

                return _DeleteGrade;
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
                    //CancelsGrade();
                    break;
                case "6":
                    //AddGrade();
                    break;
                case "7":
                    //SaveGrade();
                    break;
                case "8":
                    MakeSituation();
                    break;
            }
        }

        private void MakeSituation()
        {
            FINAL_GRADE = (context.TeacherUpdateSituation(SelectedSubject.IdSubject, SelectedStudent.Id)).First();
        }
    }
}
