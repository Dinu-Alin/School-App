using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class AbsenceVM : BaseVM
    {
        public AbsenceVM(Models.Absence absence)
        {
            _IdAbsence = absence.id_absence;
            _Date = absence.date;
            _IsJustified = absence.is_justified;
            _CanBeJustified = absence.can_be_justified;
        }
        public AbsenceVM()
        {

        }

        private int _IdAbsence;
        public int IdAbsence
        {
            get => _IdAbsence;
            set => SetProperty(ref _IdAbsence, value);
        }

        private System.DateTime _Date;
        public System.DateTime Date
        {
            get => _Date;
            set => SetProperty(ref _Date, value);
        }

        private bool _IsJustified;
        public bool IsJustified
        {
            get => _IsJustified;
            set => SetProperty(ref _IsJustified, value);
        }

        private bool _CanBeJustified;
        public bool CanBeJustified
        {
            get => _CanBeJustified;
            set => SetProperty(ref _CanBeJustified, value);
        }

        //private int _FkStudent;
        //public int FkStudent
        //{
        //    get => _FkStudent;
        //    set => SetProperty(ref _FkStudent, value);
        //}

        //private int _FkTeacherSubject;
        //public int FkTeacherSubject
        //{
        //    get => _FkTeacherSubject;
        //    set => SetProperty(ref _FkTeacherSubject, value);
        //}
    }
}
