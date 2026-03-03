using CommunityToolkit.Mvvm.Input;
using MDD4All.EnterpriseArchitect.ModelGeneration;
using System.Windows.Forms;
using System.Windows.Input;

namespace MDD4All.EMOF.Apps.EaPlugin.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel() {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GenerateMetamodelFromEmofCommand = new RelayCommand(ExecuteGenerateMetamodelFromEMOF);
        }

        public EA.Repository Repository { get; set; }

        public ICommand GenerateMetamodelFromEmofCommand { get; private set; }

        private void ExecuteGenerateMetamodelFromEMOF()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                MetamodelFromEmofGenerator generator = new MetamodelFromEmofGenerator(Repository,
                                                                                      openFileDialog.FileName,
                                                                                      Repository.GetTreeSelectedPackage());

                generator.ConvertEmofToMetamodel();
            }
        }
    }
}
