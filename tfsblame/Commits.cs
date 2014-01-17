// =============================================================================
// =
// = FILE: Commits.cs
// =
// =============================================================================
// =                                                                        
// = COPYRIGHT: Title to, ownership of and copyright of this software is
// = vested in Copyright 2003-2013  Baker Hughes Reservoir Software BV.
// = is a wholly-owned subsidiary of Baker Hughes Incorporated.
// = All rights reserved.
// =
// = Neither the whole nor any part of this software may be
// = reproduced, copied, stored in any retrieval system or
// = transmitted in any form or by any means without prior
// = written consent of the copyright owner.
// =
// = This software and the information and data it contains is
// = confidential. Neither the whole nor any part of the
// = software and the data and information it contains may be
// = disclosed to any third party without the prior written
// = consent of Copyright 2003-2013 Baker Hughes Reservoir Software BV, a
// = wholly-owned subsidiary of Baker Hughes Incorporated 
// =                                                                          
// =============================================================================
using System;
using System.Collections.Generic;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace BHI.JewelSuite.Tools.TfsBlame
{
    public class Commits : ICommits
    {

        private VersionControlServer versionControlServer;

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
            using (var tfs = new TfsTeamProjectCollection(wi.ServerUri))
            {
                versionControlServer = tfs.GetService<VersionControlServer>();
            }

        }
    }

}
