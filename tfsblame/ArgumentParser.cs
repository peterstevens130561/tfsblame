using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace tfsblame
{
    public class ArgumentParser
    {
        private string file;
        public void Parse(String[] arguments)
        {
            foreach (var argument in arguments)
            {
                if (!argument.Equals("/noprompt"))
                {
                    file = argument;
                }
            }
        }
        public String getFile()
        {
            return file;
        }
    }
}
