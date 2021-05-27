using Microsoft.Win32;
using School.Helpers;
using School.Models;
using School.Models.Actions.Teacher;
using School.Views.LogInView;
using School.Views.MasterView;
using School.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace School.ViewModels.UsersControl.Teacher
{
    class MaterialUserControlVM : BaseVM
    {

        private MaterialAction materialAction = new MaterialAction();

        SchoolDBEntities context = new SchoolDBEntities();

        public MaterialUserControlVM()
        {
            Subjects = new ObservableCollection<SubjectVM>();
            var temp = context.GetAllSubjectsEligible(TeacherUserControlVM.CURRENT_TEACHER);

            foreach (var subject in temp)
            {
                Subjects.Add(new SubjectVM()
                {
                    IdSubject = subject.id_subject,
                    Name = subject.name,
                    Term = subject.term,
                    IdTeacher = TeacherUserControlVM.CURRENT_TEACHER,
                    FkClass = subject.fk_class
                });
            }
        }

        private ICommand _LoadMaterials;
        public ICommand LoadMaterials
        {
            get
            {
                if (_LoadMaterials == null)
                {
                    _LoadMaterials = new RelayCommand(UpdateMaterials);
                }

                return _LoadMaterials;
            }
        }

        private void UpdateMaterials(object obj)
        {
            Materials = new ObservableCollection<MaterialVM>();

            var temp = context.GetMaterialsOfTeacher(TeacherUserControlVM.CURRENT_TEACHER, SelectedSubject.IdSubject);

            foreach (var material in temp)
            {
                Materials.Add(new MaterialVM()
                {
                    IdMaterial = material.id_material,
                    Link = material.link,
                    Type = material.type,
                    Assignment = material.fk_assignment
                });
            }
        }

        private SubjectVM _SelectedSubject;
        public SubjectVM SelectedSubject
        {
            get => _SelectedSubject;
            set => SetProperty(ref _SelectedSubject, value);
        }

        public ObservableCollection<SubjectVM> Subjects { get; set; }

        private ObservableCollection<MaterialVM> _Materials;
        public ObservableCollection<MaterialVM> Materials
        {
            get => _Materials;
            set => SetProperty(ref _Materials, value);
        }

        private ICommand _EditStudent;
        public ICommand EditStudent
        {
            get
            {
                if (_EditStudent == null)
                {
                    _EditStudent = new RelayCommand(materialAction.EditMaterial);
                }

                return _EditStudent;
            }
        }

        private ICommand _DeleteStudent;
        public ICommand DeleteStudent
        {
            get
            {
                if (_DeleteStudent == null)
                {
                    _DeleteStudent = new RelayCommand(materialAction.DeleteStudent);
                }
                return _DeleteStudent;
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
                    Switcher.Switch(new TeacherUserControl());
                    break;
                case "2":
                    Switcher.Switch(new MasterUserControl());
                    break;
                case "3":
                    Switcher.Switch(new LogInUserControl());
                    break;
                case "4":
                    Switcher.pageSwitcher.Close();
                    break;
                case "5":
                    EditMaterial();
                    break;
                case "6":
                    DeleteMaterial();
                    break;
                case "7":
                    AddMaterial();
                    break;
                case "8":
                    SaveMaterial();
                    break;

            }
        }

        private void SaveMaterial()
        {
            throw new NotImplementedException();
        }

        private void OpenFolder()
        {

            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            openFileDialog1.InitialDirectory = @"..\..\";
            openFileDialog1.Filter = "Pdf files(*.pdf) | *.pdf | Office Files | *.doc; *.xls; *.ppt | Txt files(*.txt) | *.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;

                string type = selectedFileName.Split('.').Last();

                context.TeacherAddMaterial(TeacherUserControlVM.CURRENT_TEACHER, SelectedSubject.IdSubject, SelectedSubject.FkClass, selectedFileName, type);

                UpdateMaterials(new object());
                //Switcher.Switch(new MaterialUserControl());

            }

        }
        private void AddMaterial()
        {
            OpenFolder();
        }

        private void DeleteMaterial()
        {

            //context.DeleteMaterial(materi.IdMaterial);

            Switcher.Switch(new MaterialUserControl());
        }

        private void EditMaterial()
        {
            throw new NotImplementedException();
        }
    }
}
