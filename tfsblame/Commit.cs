using System;

using Microsoft.TeamFoundation.VersionControl.Client;

namespace BHI.JewelSuite.tools.tfsblame
{
    internal class Commit
    {
        public DateTime TimeStamp { get; set; }
        public int Key { get; set; }
        public String Author { get; set; }

        public Commit(Changeset changeset)
        {
            TimeStamp = changeset.CreationDate;
            Key = changeset.ChangesetId;
            Author = changeset.Committer;
        }

        public override string ToString()
        {
            return Key + " " + Author + " " + TimeStamp.ToUniversalTime();
        }
    }
}


