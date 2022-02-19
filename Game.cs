using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grayemo
{
    internal class Game
    {

        public string name { set; get; }
        public List<string> prcToKill { set; get; }
        public List<string> prcToRun { set; get; }
        public List<string> runOnStart { set; get; }
        public List<string> runOnExit { set; get; }

        public Game(string name)
        {

            this.name = name;
            prcToKill = new List<string>();
            prcToRun = new List<string>();
            runOnStart = new List<string>();
            runOnExit = new List<string>();

        }
    }
}
