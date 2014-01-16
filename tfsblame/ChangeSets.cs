using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace BHI.JewelSuite.tools.tfsblame
{
    class ChangeSets
    {
        VersionControlServer versionControlServer;
        TfsTeamProjectCollection tfs;

        public String serverUri { get; set; }
        public void Connect()
        {
            tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(serverUri));
            versionControlServer = tfs.GetService<VersionControlServer>();
        }


        public void GetChangeset(int changesetId)
        {
            Changeset changeset=versionControlServer.GetChangeset(changesetId);
            
        }
    }
}
