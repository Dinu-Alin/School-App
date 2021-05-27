using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class StudentVM: BaseVM
    {

        public StudentVM(Models.Student student)
        {
            _Id = student.id_student;
            _IsDebtor = student.is_debtor;
            _AnnualGrade = student.annual_grade;
            _Person = new PersonVM(student.Person);
            _IdClass = student.Class.id_class;
        }
        public StudentVM()
        {

        }

        private int _Id;
        public int Id
        {
            get => _Id;
            set => SetProperty(ref _Id, value);
        }


        private bool? _IsDebtor;
        public bool? IsDebtor
        {
            get => _IsDebtor;
            set => SetProperty(ref _IsDebtor, value);
        }


        private double? _AnnualGrade;
        public double? AnnualGrade
        {
            get => _AnnualGrade;
            set => SetProperty(ref _AnnualGrade, value);
        }


        //private int _FkClass;
        //public int FkClass
        //{
        //    get => _FkClass;
        //    set => SetProperty(ref _FkClass, value);
        //}

        private PersonVM _Person;
        public PersonVM Person
        {
            get => _Person;
            set => SetProperty(ref _Person, value);
        }

        private int _IdClass;
        public int IdClass
        {
            get => _IdClass;
            set => SetProperty(ref _IdClass, value);
        }
    }
}
