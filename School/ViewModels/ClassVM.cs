using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class ClassVM : BaseVM
    {
        public ClassVM(Models.Class @class)
        {
            _IdClass = @class.id_class;
            _Name = @class.name;
            _Year = @class.year;
            _Field = @class.field;
            _FkClassmaster = @class.fk_classmaster;
        }
        public ClassVM()
        {

        }

        private int _IdClass;
        public int IdClass
        {
            get => _IdClass;
            set => SetProperty(ref _IdClass, value);
        }


        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }


        private int _Year;
        public int Year
        {
            get => _Year;
            set => SetProperty(ref _Year, value);
        }


        private string _Field;
        public string Field
        {
            get => _Field;
            set => SetProperty(ref _Field, value);
        }

        private int? _FkClassmaster;
        public int? FkClassmaster
        {
            get => _FkClassmaster;
            set => SetProperty(ref _FkClassmaster, value);
        }
    }
}
