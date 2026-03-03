using MDD4All.EMOF.Apps.EaPlugin.ViewModels;
using System;
using System.Diagnostics;

namespace MDD4All.EMOF.Apps.EaPlugin
{
    public class EmofAddin
    {
        private const string MAIN_MENUNAME = "EMOF Plugin";
        private const string MENU_GENERATE_METAMODEL_FROM_EMOF_JSON = "Generate Metamodel from EMOF";

        private MainViewModel MainViewModel { get; set; }

        public void EA_FileOpen(EA.Repository repository)
        {
            MainViewModel = new MainViewModel
            {
                Repository = repository
            };
        }

        public object EA_GetMenuItems(EA.Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return "-&" + MAIN_MENUNAME;

                case "-&" + MAIN_MENUNAME:
                    string[] menuItems = { 
                                            MENU_GENERATE_METAMODEL_FROM_EMOF_JSON
                                         };
                    return menuItems;
            }
            return "";
        }

        bool IsProjectOpen(EA.Repository repository)
        {
            try
            {
                EA.Collection models = repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EA_GetMenuState(EA.Repository repository, string location,
                                    string menuName, string itemName,
                                    ref bool isEnabled, ref bool isChecked)
        {
            if (IsProjectOpen(repository))
            {
                isEnabled = true;
            }
            else
            {

                isEnabled = false;
            }

        }


        public void EA_MenuClick(EA.Repository repository, string location, string menuName, string itemName)
        {
            try
            {
                switch (itemName)
                {
                    case MENU_GENERATE_METAMODEL_FROM_EMOF_JSON:
                        MainViewModel.GenerateMetamodelFromEmofCommand.Execute(null);
                        break;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //log.Debug(ex.ToString());
            }
        }
    }
}
