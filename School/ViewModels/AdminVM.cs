using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class AdminVM : BaseVM
    {
        public AdminVM()
        {

        }

        public AdminVM(Models.Admin admin)
        {
            _IdAdmin = admin.id_admin;
            _Person = new PersonVM(admin.Person);
        }


        private int _IdAdmin;
        public int IdAdmin
        {
            get => _IdAdmin;
            set => SetProperty(ref _IdAdmin, value);
        }


        private PersonVM _Person;
        public PersonVM Person
        {
            get => _Person;
            set => SetProperty(ref _Person, value);
        }
    }
}
