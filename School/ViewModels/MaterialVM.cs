using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ViewModels
{
    class MaterialVM : BaseVM
    {
        public MaterialVM(Models.Material material)
        {
            _IdMaterial = material.id_material;
            _Link = material.link;
            _Type = material.type;
            _Assignment = material.fk_assignment;
        }
        public MaterialVM()
        {

        }

        private int _IdMaterial;
        public int IdMaterial
        {
            get => _IdMaterial;
            set => SetProperty(ref _IdMaterial, value);
        }

        private string _Type;
        public string Type
        {
            get => _Type;
            set => SetProperty(ref _Type, value);
        }

        private string _Link;
        public string Link
        {
            get => _Link;
            set => SetProperty(ref _Link, value);
        }

        private int _Assignment;
        public int Assignment
        {
            get => _Assignment;
            set => SetProperty(ref _Assignment, value);
        }


    }
}
