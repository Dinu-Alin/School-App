using School.Helpers;
using School.ViewModels;
using School.ViewModels.UsersControl.Admin;
using School.Views.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Actions.Admin
{
    class EditTeacherSubjectAction
    {
        public void EditSubject(object obj)
        {
            SubjectVM subject = obj as SubjectVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminModifySubject(subject.IdSubject, subject.Name, subject.Term);

        }

        public void DeleteSubject(object obj)
        {
            SubjectVM subject = obj as SubjectVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminDeleteSubject(subject.IdSubject);

            Switcher.Switch(new EditTeacherSubjectUserControl());
        }
        
        public void AddSubject(object obj)
        {
            SubjectVM subject = obj as SubjectVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.AdminAddSubject(subject.IdSubject, subject.Name, subject.Term);
            context.MakeConnectionTeacherSubject(subject.IdSubject, EditTeacherUserControlVM.CURRENT_TEACHER);

            Switcher.Switch(new EditTeacherSubjectUserControl());
        }
    }
}
