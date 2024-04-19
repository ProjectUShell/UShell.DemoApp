using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UShell;

namespace DepotManagement.PortfolioHandling {
  public class PortfolioService {

    public static PortfolioDescription GetPortfolioDescription(string portfolioUrl) {
      if (portfolioUrl == "default.portfolio") {
        return GetPortfolioChoserPortfolio();
      }
      if (portfolioUrl == "DepotManager") {
        return GetDepotManagerPortfolio();
      }
      return null;
    }

    private static PortfolioDescription GetDepotManagerPortfolio() {
      PortfolioDescription result = new PortfolioDescription();
      result.ApplicationTitle = "Depot Manager";
      result.ModuleDescriptionUrls = new string[] { "https://localhost:7288/Module/DepotManager.json" };
      result.LandingWorkspaceName = "People";
      result.AnonymouseAccess = new AnonymousAccessDescription() {
        AuthIndependentCommands = new string[] { "showPeople", "showFonds" }
      };

      return result;
    }

    private static PortfolioDescription GetPortfolioChoserPortfolio() {
      PortfolioDescription result = new PortfolioDescription();
      result.ApplicationTitle = "Portfolio Choser";
      result.ModuleDescriptionUrls = new string[] { "https://localhost:7288/Module/PortfolioChoser.json" };
      result.LandingWorkspaceName = "PortfolioChoser";
      return result;
    }

    public static ModuleDescription GetModuleDescription(string moduleUrl) {
      if (moduleUrl == "PortfolioChoser") {
        return GetPortfolioChoserModule();
      }
      if (moduleUrl == "DepotManager") {
        return GetDepotManagerModule();
      }
      return null;
    }

    public static ModuleDescription GetDepotManagerModule() {
      ModuleDescription result = new ModuleDescription();
      result.ModuleTitle = "Depot Manager";
      result.ModuleUid = "902FB942-2F53-4CA3-96A7-88EEDCFA4E53";

      result.Workspaces = new List<WorkspaceDescription>();
      result.Usecases = new List<UsecaseDescription>();
      result.Commands = new List<CommandDescription>();
      result.StaticUsecaseAssignments = new List<StaticUsecaseAssignment>();

      result.Workspaces.Add(
        new WorkspaceDescription() {
          WorkspaceKey = "People"
        }
      );
      result.Workspaces.Add(
        new WorkspaceDescription() {
          WorkspaceKey = "Fonds"
        }
      );

     
      result.Usecases.Add(
        new UsecaseDescription() {
          UsecaseKey = "PersonGuifad",
          WidgetClass = "guifad",
          Title = "People",
          SingletonActionkey = "PersonGuifad",
          UnitOfWorkDefaults = new IDynamicParamObject {
            { "entityName", "Person" }
          }
        }
      ); 

      result.Usecases.Add(
        new UsecaseDescription() {
          UsecaseKey = "FondsGuifad",
          WidgetClass = "guifad",
          Title = "Fonds",
          SingletonActionkey = "FondsGuifad",
          UnitOfWorkDefaults = new IDynamicParamObject {
            { "entityName", "Fund" }            
          }
        }
      );

      result.Commands.Add(
        new CommandDescription() {
          UniqueCommandKey = "showPeople",
          Label = "People",
          CommandType = "activate-workspace",
          TargetWorkspacePath = "Admin\\People",
          MenuFolder = "Admin",
          TargetWorkspaceKey = "People",
          IconKey = "fa-solid fa-heart"
        }
      );

      result.Commands.Add(
        new CommandDescription() {
          UniqueCommandKey = "showFonds",
          Label = "Fonds",
          CommandType = "activate-workspace",
          TargetWorkspacePath = "Admin\\Fonds",
          MenuFolder = "Admin",
          TargetWorkspaceKey = "Fonds",
          IconKey = "fa-solid fa-heart"
        }
      );

      result.StaticUsecaseAssignments.Add(
        new StaticUsecaseAssignment() {
          UsecaseKey = "PersonGuifad",
          TargetWorkspaceKey = "People"
        }
      );

      result.StaticUsecaseAssignments.Add(
        new StaticUsecaseAssignment() {
          UsecaseKey = "FondsGuifad",
          TargetWorkspaceKey = "Fonds"
        }
      );

      result.Datastores = new List<DatastoreDescription>();
      result.Datastores.Add(
        new DatastoreDescription() {
          Key = "AccountManagementStore",
          ProviderArguments = new Dictionary<string, string>() {
            { "url", "https://localhost:7288/AccountManagement/" },
            { "routePattern", "body" }
          },
          ProviderClass = "fuse",
        }
      );
      result.Datastores.Add(
        new DatastoreDescription() {
          Key = "FundsManagementStore",
          ProviderArguments = new Dictionary<string, string>() {
            { "url", "https://localhost:7288/FundsManagement/" },
            { "routePattern", "route" }
          },
          ProviderClass = "fuse",
        }
      );
      return result;
    }

    public static ModuleDescription GetPortfolioChoserModule() {
      ModuleDescription result = new ModuleDescription();
      result.ModuleTitle = "Portfolio Chooser";
      result.ModuleUid = "745C55BD-B3D6-4024-8445-9582F538A313";

      result.Workspaces = new List<WorkspaceDescription>();
      result.Usecases = new List<UsecaseDescription>();
      result.Commands = new List<CommandDescription>();
      result.StaticUsecaseAssignments = new List<StaticUsecaseAssignment>();

      result.Workspaces.Add(
        new WorkspaceDescription() {
          WorkspaceKey = "PortfolioChoser"
        }
      );

      result.Usecases.Add(
        new UsecaseDescription() {
          UsecaseKey = "PortfolioChoser",
          WidgetClass = "portfolioChooser",
          Title = "Portfolio Chooser",
          SingletonActionkey = "portfolioChooser",
        }
      );

      result.StaticUsecaseAssignments.Add(
        new StaticUsecaseAssignment() {
          UsecaseKey = "PortfolioChoser",
          TargetWorkspaceKey = "PortfolioChoser"
        }
      );

      return result;
    }

  }
}
