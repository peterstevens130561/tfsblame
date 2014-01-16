using System;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics ;
using Microsoft.TeamFoundation.Client;

namespace BHI.JewelSuite.tools.tfsblame
{

    class Blame
    {
        private Commits commits = new Commits();

        public Blame()
        {
            
        }

        public Blame(Commits commits)
        {
            this.commits = commits;
        }

        public String RunAnnotate(String fileName)
        {
            StringBuilder standardOutput = new StringBuilder();
            StringBuilder standardError = new StringBuilder();
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "tfpt.exe";
                myProcess.StartInfo.Arguments = "annotate /noprompt " + fileName;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                myProcess.OutputDataReceived += (sender, args) => standardOutput.AppendLine(DecorateLine(args.Data));
                myProcess.ErrorDataReceived += (sender, args) => standardError.AppendLine(args.Data);
                myProcess.Start();
                myProcess.BeginOutputReadLine();
                myProcess.BeginErrorReadLine();
                //myProcess.Start();
                myProcess.WaitForExit();
                int exitCode=myProcess.ExitCode;
                if (exitCode > 0)
                {
                    throw new ApplicationException(standardError.ToString());
                }
            }
            return standardOutput.ToString();

        }


        public String DecorateLine(String line)
        {
            String changeSetpattern = "^[0-9]+";
            String beforeLinePattern = changeSetpattern + "\\s+";
            if (line == null)
            {
                return String.Empty;
            }
            MatchCollection matches = Regex.Matches(line, changeSetpattern);
            if (matches.Count == 0)
            {
                return String.Empty;
            }

            String changesetKey = matches[0].Value;
            int changesetId = Convert.ToInt32(changesetKey);
            String formattedCommit = commits.GetFormattedCommit(changesetId);
            String lineWithoutChangesetId = Regex.Replace(line, beforeLinePattern, "");
            return formattedCommit  + " " + lineWithoutChangesetId;
        }
    }

}
