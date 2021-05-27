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
    class EditClassAction
    {
        //public void EditStudent(object obj)
        //{
        //    StudentVM student = obj as StudentVM;

        //    SchoolDBEntities context = new SchoolDBEntities();

        //    context.AdminModifyPerson(student.Id, student.Person.FirstName, student.Person.LastName, student.Person.Username, student.Person.Password);
        //    context.AdminModifyStudent(student.Id, student.IdClass);
        //}

        //public void AddStudent(object obj)
        //{
        //    StudentVM student = obj as StudentVM;

        //    SchoolDBEntities context = new SchoolDBEntities();

        //    // add student 

        //    Switcher.Switch(new EditStudentUserControl());
        //}


        //public void DeleteStudent(object obj)
        //{
        //    StudentVM student = obj as StudentVM;

        //    SchoolDBEntities context = new SchoolDBEntities();
        //    context.AdminDeleteStudent(student.Id);
        //    // Switcher.Switch(new EditStudentUserControl());

        //}

        public void EditClass(object obj)
        {
            ClassVM @class = obj as ClassVM;

            SchoolDBEntities context = new SchoolDBEntities();

            if(@class.FkClassmaster == 0)
            {
                @class.FkClassmaster = null;
            }

            context.AdminModifyClass(@class.IdClass, @class.Name, @class.Year, @class.Field, @class.FkClassmaster);

            Switcher.Switch(new EditClassUserControl());

        }

        public void AddClass(object obj)
        {
            ClassVM @class = obj as ClassVM;

            SchoolDBEntities context = new SchoolDBEntities();

            if (@class.FkClassmaster == 0)
            {
                @class.FkClassmaster = null;
            }

            context.AdminAddClass(@class.IdClass, @class.Name, @class.Year, @class.Field, @class.FkClassmaster);

            Switcher.Switch(new EditClassUserControl());
        }

        public void DeleteClass(object obj)
        {
            ClassVM @class = obj as ClassVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminDeleteClass(@class.IdClass);

            Switcher.Switch(new EditClassUserControl());
        }
    }
}
