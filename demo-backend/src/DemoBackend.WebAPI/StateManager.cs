using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Security {

  public static class StateManager {

    //this is an exposed instance
    //it will be automatically set from the incomming request-sidechannel (by the AmbienceHub)
    private static AmbientField _CurrentTenant = new AmbientField("Tenant", exposedInstance: true);

    /// <summary>
    /// SOURCE: FLOWED VIA SIDECHANNEL
    /// </summary>
    public static string CurrentTenant {
      get { return _CurrentTenant.Value; }
      set { _CurrentTenant.Value = value; }
    }

    private static AmbientField _CurrentIdentityLabel = new AmbientField("IdentityLabel");
    private static AmbientField _CurrentAuthScopes = new AmbientField("AuthScopes");

    /// <summary>
    /// SOURCE IS THE CURRENT AUTH-TOKEN
    /// </summary>
    public static string CurrentIdentityLabel {
      get { return _CurrentIdentityLabel.Value; }
      set { _CurrentIdentityLabel.Value = value;}
    }

    /// <summary>
    /// SOURCE IS THE CURRENT AUTH-TOKEN
    /// </summary>
    public static string[] CurrentAuthScopes {
      //special case: in the OAuth world the scopes are usually separated by a SPACE-char!
      get { return _CurrentIdentityLabel.Value.Split(" "); }
      set { _CurrentIdentityLabel.Value = string.Join(" ",value); }
    }

    #region " Helpers for easy wire-up with remoting frameworks "

    public static void ApplyCurrentAuthTokenInformation(string subject, List<string> permittedScopes) {
      CurrentIdentityLabel = subject;
      CurrentAuthScopes = permittedScopes.ToArray();
    }

    public static string[] GetCurrentScopes(string dimensionName) {

      //our idea - if there is a tenant, passed by the sidechannel,
      //it will override the the tenant information comming from the token
      // (thats only for the demo - in real life this makes no sense)
      if (dimensionName == "Tenant" && !string.IsNullOrWhiteSpace(CurrentTenant)) {
        return new string[] {CurrentTenant};
      }

      //other dimensions comming from the token
      string[] clearances = (
        CurrentAuthScopes.Where(   
          (s) => s.StartsWith(dimensionName + ":")
        ).Select(
          (s) => s.Substring(s.IndexOf(":") + 1)
        )
      ).ToArray();

      return clearances;
    }

    #endregion 

  }

}
