using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class GradeVM : BaseVM
    {
        public GradeVM(Models.Grade grade)
        {
            _IdGrade = grade.id_grade;
            _Mark = grade.mark;
            _Date = grade.date;
            _IsMidterm = grade.is_midterm;
        }
        public GradeVM()
        {

        }

        private int _IdGrade;
        public int IdGrade
        {
            get => _IdGrade;
            set => SetProperty(ref _IdGrade, value);
        }

        private int _Mark;
        public int Mark
        {
            get => _Mark;
            set => SetProperty(ref _Mark, value);
        }

        private System.DateTime _Date;
        public System.DateTime Date
        {
            get => _Date;
            set => SetProperty(ref _Date, value);
        }

        private bool _IsMidterm;
        public bool IsMidterm
        {
            get => _IsMidterm;
            set => SetProperty(ref _IsMidterm, value);
        }

        //private int _FkSituation;
        //public int FkSituation
        //{
        //    get => _FkSituation;
        //    set => SetProperty(ref _FkSituation, value);
        //}
    }
}
