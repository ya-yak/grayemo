using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

string pattern = @"(?<=\\)[^\\/:*?<>|]+(?=.exe)|(?<=\\)[^\\/:*?<>|]+$";
Regex regex = new Regex(pattern);
MatchCollection matchCollection;

//-- IF NO ANOTHER 'GRAYEMOPROCESS' IS OPEN --

if (Process.GetProcessesByName("grayemoProcess").Length < 2)
{

    string jsonString = File.ReadAllText("data.json");

    //-- IF JSON IS NOT EMPTY --

    if (jsonString != null)
    {

        DataSet data = JsonSerializer.Deserialize<DataSet>(jsonString);

        bool gameMode = false;

        while (true)
        {

            foreach (Game game in data.games)
            {

                //-- PROCESSES TO KILL --

                foreach (string prcToKill in game.prcToKill)
                {

                    //-- IF PROCESS IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0
                        && Process.GetProcessesByName(regex.Matches(prcToKill)[0].Value).Length != 0)
                    {

                        foreach (Process process in Process.GetProcessesByName(regex.Matches(prcToKill)[0].Value))
                            process.Kill();

                    }

                    //-- IF PROCESS IS NOT OPEN --

                    else if (Process.GetProcessesByName(regex.Matches(prcToKill)[0].Value).Length == 0) runProcess(prcToKill);

                }

                //-- PROCESSES TO RUN --

                foreach (string prcToRun in game.prcToRun)
                {

                    //-- IF PROCESS IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0
                        && Process.GetProcessesByName(regex.Matches(prcToRun)[0].Value).Length == 0)
                        runProcess(prcToRun);

                    //-- IF PROCESS IS NOT OPEN --

                    else if (Process.GetProcessesByName(regex.Matches(prcToRun)[0].Value).Length != 0)
                    {

                        foreach (Process process in Process.GetProcessesByName(regex.Matches(prcToRun)[0].Value))
                            process.Kill();

                    }
                }

                //-- RUN ON START

                foreach (string runOnStart in game.runOnStart)
                {

                    if (Process.GetProcessesByName(game.name).Length != 0
                        && Process.GetProcessesByName(regex.Matches(runOnStart)[0].Value).Length == 0 && !gameMode)
                        runProcess(runOnStart);

                }

                //-- RUN ON EXIT

                foreach (string runOnExit in game.runOnExit)
                {

                    if (Process.GetProcessesByName(game.name).Length == 0
                        && Process.GetProcessesByName(regex.Matches(runOnExit)[0].Value).Length == 0 && gameMode)
                        runProcess(runOnExit);

                }

                if (Process.GetProcessesByName(game.name).Length != 0) break;

            }

            //-- SET GAME MODE --

            gameMode = false;

            foreach (Game game in data.games)
                if (Process.GetProcessesByName(game.name).Length != 0) gameMode = true;

            //-- SLEEP FOR 2 MINUTES --

            Thread.Sleep(120000);

        }
    }

    //-- EXIT --

    else Environment.Exit(0);

}

//-- EXIT --

else Environment.Exit(0);

//-- CREATE COMMAND PROMPT PROCESS --

void runProcess(string prc)
{

    Process process = new Process();
    ProcessStartInfo startInfo = new ProcessStartInfo();

    startInfo.CreateNoWindow = true;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = "/C " + prc;

    process.StartInfo = startInfo;
    process.Start();

}