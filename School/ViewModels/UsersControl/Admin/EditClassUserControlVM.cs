using School.Helpers;
using School.Models;
using School.Models.Actions.Admin;
using School.Views.AdminView;
using School.Views.LogInView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Admin
{
    class EditClassUserControlVM
    {
        public ObservableCollection<ClassVM> Classes { get; set; }

        public static int CURRENT_CLASS { get; set; }

        EditClassAction action = new EditClassAction();

        SchoolDBEntities context = new SchoolDBEntities();

        public EditClassUserControlVM()
        {
            Classes = new ObservableCollection<ClassVM>();

            var temp = context.AdminGetAllClasses();
            foreach (var @class in temp)
            {
                Classes.Add(new ClassVM()
                {
                    IdClass = @class.id_class,
                    Name = @class.name,
                    Year = @class.year,
                    Field = @class.field,
                    FkClassmaster = @class.fk_classmaster
                });
            }

        }



        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;

            set
            {
                if (_selectedIndex == value)
                {
                    return;
                }


                _selectedIndex = value;

                CURRENT_CLASS = ((Switcher.pageSwitcher.Content as EditClassUserControl).listClasses.Items.GetItemAt(_selectedIndex) as ClassVM).IdClass;
            }
        }



        private ICommand _EditClass;
        public ICommand EditClass
        {
            get
            {
                if (_EditClass == null)
                {
                    _EditClass = new RelayCommand(action.EditClass);
                }

                return _EditClass;
            }
        }

        private ICommand _DeleteClass;
        public ICommand DelteClass
        {
            get
            {
                if (_DeleteClass == null)
                {
                    _DeleteClass = new RelayCommand(action.DeleteClass);
                }

                return _DeleteClass;
            }
        }


        private ICommand openUserControlCommand;
        public ICommand OpenUserControlCommand
        {
            get
            {
                if (openUserControlCommand == null)
                {
                    openUserControlCommand = new RelayCommand(OpenUserControl);
                }
                return openUserControlCommand;
            }
        }

        public void OpenUserControl(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    Switcher.Switch(new AdminUserControl());
                    break;
                case "2":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "3":
                    Switcher.pageSwitcher.Close();
                    break;
                case "4":
                    Switcher.Switch(new AddClassUserControl());
                    break;


            }
        }
    }
}
