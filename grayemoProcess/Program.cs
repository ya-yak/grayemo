using System.Diagnostics;
using System.Text.Json;

//-- IF NO ANOTHER 'GRAYEMOPROCESS' IS OPEN --

if (Process.GetProcessesByName("grayemoProcess").Length < 2)
{

    string jsonString = File.ReadAllText("data.json");

    //-- IF JSON IS NOT EMPTY --

    if (jsonString != null)
    {

        DataSet data = JsonSerializer.Deserialize<DataSet>(jsonString);

        while (true)
        {

            foreach (Game game in data.games)
            {

                //-- PROCESSES TO KILL --

                foreach (string prcToKill in game.prcToKill)
                {

                    //-- IF PROCESS IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0
                        && Process.GetProcessesByName(prcToKill).Length != 0)
                    {

                        foreach (Process process in Process.GetProcessesByName(prcToKill))
                            process.Kill();

                    }

                    //-- IF PROCESS IS NOT OPEN --

                    else Process.Start(prcToKill);



                }

                //-- PROCESSES TO RUN --

                foreach (string prcToRun in game.prcToRun)
                {

                    //-- IF PROCESS IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0
                        && Process.GetProcessesByName(prcToRun).Length == 0)
                        Process.Start(prcToRun);

                    //-- IF PROCESS IS NOT OPEN --

                    else
                    {

                        foreach (Process process in Process.GetProcessesByName(prcToRun))
                            process.Kill();

                    }

                }
            }

            //-- SLEEP FOR 2 MINUTES --

            Thread.Sleep(120000);

        }
    }

    //-- EXIT --

    else Environment.Exit(0);

}

//-- EXIT --

else Environment.Exit(0);
