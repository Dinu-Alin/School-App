using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class PersonVM : BaseVM
    {
        public PersonVM()
        {

        }

        public PersonVM(Models.Person person)
        {
            _IdPerson = person.id_person;
            _FirstName =person.first_name;
            _LastName = person.last_name;
            _Username = person.username;
            _Password = person.password;
        }

        private int _IdPerson;
        public int IdPerson
        {
            get => _IdPerson;
            set => SetProperty(ref _IdPerson, value);
        }


        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set => SetProperty(ref _FirstName, value);
        }


        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set => SetProperty(ref _LastName, value);
        }


        private string _Username;
        public string Username
        {
            get => _Username;
            set => SetProperty(ref _Username, value);
        }


        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }
    }
}
