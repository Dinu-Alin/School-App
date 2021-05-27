using School.Helpers;
using School.ViewModels;
using School.Views.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Actions.Admin
{
    class EditTeacherAction
    {

        public void EditTeacher(object obj)
        {
            TeacherVM teacher = obj as TeacherVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminModifyPerson(teacher.IdTeacher, teacher.Person.FirstName, teacher.Person.LastName, teacher.Person.Username, teacher.Person.Password);

        }

        public void DeleteTeacher(object obj)
        {
            TeacherVM teacher = obj as TeacherVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminDeleteTeacher(teacher.IdTeacher);

            Switcher.Switch(new EditTeacherUserControl());
        }
        
        public void AddTeacher(object obj)
        {
            TeacherVM teacher = obj as TeacherVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminAddTeacher(teacher.IdTeacher, teacher.Person.FirstName, teacher.Person.LastName, teacher.Person.Username, teacher.Person.Password);

            Switcher.Switch(new EditTeacherUserControl());
        }
    }
}
