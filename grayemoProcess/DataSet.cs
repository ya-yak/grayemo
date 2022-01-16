using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class DataSet
{

    public Dictionary<string, string> settings { get; set; }
    public List<Game> games { get; set; }

    public DataSet()
    {

        settings = new Dictionary<string, string>();
        games = new List<Game>();

    }

}
