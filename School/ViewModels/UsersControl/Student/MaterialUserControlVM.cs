using School.Helpers;
using School.Models;
using School.Views.LogInView;
using School.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Student
{
    class MaterialUserControlVM
    {
        public ObservableCollection<MaterialVM> Materials { get; set; }


        SchoolDBEntities context = new SchoolDBEntities();

        public MaterialUserControlVM()
        {
            Materials = new ObservableCollection<MaterialVM>();

            var temp = context.GetMaterials(StudentUserControlVM.CURRENT_STUDENT);
            foreach (var material in temp)
            {
                Materials.Add(new MaterialVM()
                {
                    IdMaterial = material.id_material,
                    Type = material.type
                });

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
                case "back":
                    Switcher.Switch(new StudentUserControl());
                    break;
                case "log_out":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "exit":
                    Switcher.pageSwitcher.Close();
                    break;
            }
        }
    }
}
