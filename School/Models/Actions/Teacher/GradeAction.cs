using School.Helpers;
using School.ViewModels;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Actions.Teacher
{
    class GradeAction
    {
        public void DeleteStudent(object obj)
        {

            if (obj != null)
            {
                GradeVM grade = obj as GradeVM;

                SchoolDBEntities context = new SchoolDBEntities();

                context.TeacherDeleteGrade(grade.IdGrade);

                Switcher.Switch(new GradeUserControl());
            }

        }
    }
}
