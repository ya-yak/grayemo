using System.Diagnostics;
using System.Text.Json;

if (Process.GetProcessesByName("grayemoService").Length == 1)
{

    string jsonString = File.ReadAllText("data.json");

    if (jsonString != null)
    {

        DataSet data = JsonSerializer.Deserialize<DataSet>(jsonString);

        while (true)
        {

            foreach (Game game in data.games)
            {

                foreach (string prcToKill in game.prcToKill)
                {

                    if (Process.GetProcessesByName(prcToKill).Length != 0)
                    {

                        foreach (Process process in Process.GetProcessesByName(prcToKill))
                            process.Kill();

                    }

                    

                }
                foreach (string prcToRun in game.prcToRun)
                {

                    if (Process.GetProcessesByName(prcToRun).Length == 0)
                        Process.Start(prcToRun);

                }
            }

            Thread.Sleep(120000);

        }
    }
    else Environment.Exit(0);

}
else Environment.Exit(0);
