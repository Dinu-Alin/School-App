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
    class EditStudentAction
    {
        public void EditStudent(object obj)
        {
            StudentVM student = obj as StudentVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminModifyPerson(student.Id, student.Person.FirstName, student.Person.LastName, student.Person.Username, student.Person.Password);
            context.AdminModifyStudent(student.Id, student.IdClass);
        }
        
        public void AddStudent(object obj)
        {
            StudentVM student = obj as StudentVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminAddStudentWithPerson(student.Id, student.IdClass, student.Person.FirstName, student.Person.LastName, student.Person.Username, student.Person.Password);

            Switcher.Switch(new EditStudentUserControl());
        }


        public void DeleteStudent(object obj)
        {
            StudentVM student = obj as StudentVM;

            SchoolDBEntities context = new SchoolDBEntities();
            context.AdminDeleteStudent(student.Id);

           Switcher.Switch(new EditStudentUserControl());

        }
    }
}
