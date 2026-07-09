using MDD4All.EMOF.Apps.EaPlugin.ViewModels;
using System;
using System.Diagnostics;

namespace MDD4All.EMOF.Apps.EaPlugin
{
    public class EmofAddin
    {
        private const string MAIN_MENUNAME = "EMOF Plugin";
        private const string MENU_GENERATE_METAMODEL_FROM_EMOF_JSON = "Generate Metamodel from EMOF";
        private const string MENU_SHOW_WEB_VIEW_FORM = "Show Web Wiev Form";
        private const string MENU_ABOUT = "About...";

        private MainViewModel MainViewModel { get; set; } = new MainViewModel();

        public void EA_FileOpen(EA.Repository repository)
        {
            MainViewModel.Repository = repository;
        }

        public object EA_GetMenuItems(EA.Repository repository, string location, string menuName)
        {
            object result = "";
            switch (menuName)
            {
                case "":
                    result = "-&" + MAIN_MENUNAME;
                    break;

                case "-&" + MAIN_MENUNAME:
                    string[] mainMenuItems = {
                                            //MENU_SHOW_WEB_VIEW_FORM
                                            MENU_ABOUT
                                         };

                    string[] treeMenuItems = {
                                            MENU_GENERATE_METAMODEL_FROM_EMOF_JSON
                                         };

                    if (location == "MainMenu")
                    {
                        result = mainMenuItems;
                    }
                    else if (location == "TreeView")
                    {
                        result = treeMenuItems;
                    }
                    break;
            }
            return result;
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
            isEnabled = true;
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

                    case MENU_SHOW_WEB_VIEW_FORM:
                        MainViewModel.ShowWebViewFormCommand.Execute(null);
                        break;

                    case MENU_ABOUT:
                        MainViewModel.ShowAboutDialogCommand.Execute(null);
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
