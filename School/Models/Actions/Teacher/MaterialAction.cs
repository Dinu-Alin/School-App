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
    class MaterialAction
    {
        public void EditMaterial(object obj)
        {
            MaterialVM material = obj as MaterialVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.TeacherModifyMaterial(material.IdMaterial, material.Link, material.Type);

            
        }

        public void DeleteStudent(object obj)
        {
            MaterialVM material = obj as MaterialVM;

            SchoolDBEntities context = new SchoolDBEntities();

            context.DeleteMaterial(material.IdMaterial);
           
            Switcher.Switch(new MaterialUserControl());

        }
    }
}
