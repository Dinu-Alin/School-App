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
    class GradeUserControlVM : BaseVM
    {
        public ObservableCollection<GradeVM> Grades { get; set; }

        private int? final_grade;
        public int? FINAL_GRADE
        {

            get => final_grade;
            set => SetProperty(ref final_grade, value);
        }

        SchoolDBEntities context = new SchoolDBEntities();

        public GradeUserControlVM()
        {
            Grades = new ObservableCollection<GradeVM>();

            FINAL_GRADE = (context.TeacherUpdateSituation(StudentUserControlVM.CURRENT_SUBJECT, StudentUserControlVM.CURRENT_STUDENT)).First();

            var temp = context.GetAllGradesBySubject(StudentUserControlVM.CURRENT_SUBJECT, StudentUserControlVM.CURRENT_STUDENT);
            foreach (var grade in temp)
            {
                Grades.Add(new GradeVM()
                {
                    IdGrade = grade.id_grade, 
                    Date = grade.date,
                    Mark = grade.mark, 
                    IsMidterm = grade.is_midterm
                }
                );
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
                case "back":
                    Switcher.Switch(new StudentUserControl());
                    break;
                case "log_out":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "exit":
                    Switcher.pageSwitcher.Close();
                    break;
            }
        }
    }
}
