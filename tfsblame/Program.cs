using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHI.JewelSuite.tools.tfsblame;

namespace tfsblame
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentParser parser = new ArgumentParser();
            parser.Parse(args);
            String file = parser.getFile();
            Commits commits = new Commits();
            commits.Connect();
            Blame blame = new Blame(commits);

            String result=blame.RunAnnotate(file);
            Console.WriteLine(result);
        }
    }
}
