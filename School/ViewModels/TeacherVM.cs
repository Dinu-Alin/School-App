using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class TeacherVM : BaseVM
    {
        public TeacherVM(Models.Teacher teacher)
        {
            _IdTeacher = teacher.id_teacher;
            _Person = new PersonVM(teacher.Person);
        }
        public TeacherVM()
        {
      
        }

        private int _IdTeacher;
        public int IdTeacher
        {
            get => _IdTeacher;
            set => SetProperty(ref _IdTeacher, value);
        }

        private PersonVM _Person;
        public PersonVM Person
        {
            get => _Person;
            set => SetProperty(ref _Person, value);
        }
    }
}
