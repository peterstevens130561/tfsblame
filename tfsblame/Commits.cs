using System;
using System.Collections.Generic;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace BHI.JewelSuite.tools.tfsblame
{
    internal interface ICommits
    {
        String  GetFormattedCommit(int changesetId);
        String serverUri { get; set; }
        void Connect();
    }

    public class Commits : ICommits
    {

        VersionControlServer versionControlServer;

        public String serverUri { get; set; }
        private IDictionary<int, Commit> commits = new Dictionary<int, Commit>();

        public Commits()
        {
            
        }

        public Commits(VersionControlServer versionControlServer)
        {
            this.versionControlServer = versionControlServer;
        }



        public virtual String  GetFormattedCommit(int changesetId)
        {
            if (!commits.ContainsKey(changesetId))
            {
                Changeset changeset = versionControlServer.GetChangeset(changesetId);
                commits.Add(changesetId, new Commit(changeset));
            }
            return commits[changesetId].ToString();
        }



        public virtual void Connect()
        {
            WorkspaceInfo wi = Workstation.Current.GetLocalWorkspaceInfo(Environment.CurrentDirectory);
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(wi.ServerUri);
            //TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(serverUri));
            versionControlServer = tfs.GetService<VersionControlServer>();
        }

    }
}
