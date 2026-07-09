using CommunityToolkit.Mvvm.Input;
using MDD4All.EMOF.Apps.EaPlugin.Views;
using MDD4All.EnterpriseArchitect.ModelGeneration;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;

namespace MDD4All.EMOF.Apps.EaPlugin.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GenerateMetamodelFromEmofCommand = new RelayCommand(ExecuteGenerateMetamodelFromEMOF);
            ShowWebViewFormCommand = new RelayCommand(ExecuteShowWebWiewForm);
            ShowAboutDialogCommand = new RelayCommand(ExecuteShowAboutDialog);
        }

        public EA.Repository Repository { get; set; }

        public ICommand GenerateMetamodelFromEmofCommand { get; private set; }

        public ICommand ShowWebViewFormCommand { get; private set; }

        public ICommand ShowAboutDialogCommand { get; private set; }

        private void ExecuteGenerateMetamodelFromEMOF()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    MetamodelFromEmofGenerator generator = new MetamodelFromEmofGenerator(Repository,
                                                                                          openFileDialog.FileName,
                                                                                          Repository.GetTreeSelectedPackage());

                    generator.ConvertEmofToMetamodel();

                    MessageBox.Show("Data model generation finished.");
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
        }

        private void ExecuteShowAboutDialog()
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }

        private void ExecuteShowWebWiewForm()
        {
            WebWiewForm webWiewForm = new WebWiewForm();
            webWiewForm.ShowDialog();
        }
    }
}
