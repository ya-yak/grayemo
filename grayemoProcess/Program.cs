using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

string pattern = @"(?<=\\)[^\\/:*?<>|]+(?=.exe)|(?<=\\)[^\\/:*?<>|]+$";
Regex regex = new Regex(pattern);
MatchCollection matchCollection;

string jsonString = File.ReadAllText("data.json");

DataSet data = JsonSerializer.Deserialize<DataSet>(jsonString);

//-- IF NO ANOTHER 'GRAYEMOPROCESS' IS OPEN --

if (Process.GetProcessesByName("grayemoProcess").Length < 2 && data.settings["autoload"] == "true")
{

    Dictionary<string, bool> queue;

    List<string> gamesRunning = new List<string>();

    //-- IF JSON IS NOT EMPTY --

    if (jsonString != null)
    {

        while (true)
        {

            queue = new Dictionary<string, bool>();

            foreach (Game game in data.games)
            {

                //-- PROCESSES TO KILL --

                foreach (string prcToKill in game.prcToKill)
                {

                    //-- KILL IF GAME IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0)
                        queue[prcToKill] = false;

                    //-- RUN IF GAME IS NOT OPEN --

                    else
                    {

                        if (!queue.ContainsKey(prcToKill) || queue[prcToKill] != false)
                            queue[prcToKill] = true;

                    }
                }

                //-- PROCESSES TO RUN --

                foreach (string prcToRun in game.prcToRun)
                {

                    //-- RUN IF GAME IS OPEN --

                    if (Process.GetProcessesByName(game.name).Length != 0)
                        queue[prcToRun] = true;

                    //-- KILL IF GAME IS NOT OPEN --

                    else
                    {

                        if (!queue.ContainsKey(prcToRun) || queue[prcToRun] != true)
                            queue[prcToRun] = false;

                    }
                }

                //-- RUN ON START --

                if (Process.GetProcessesByName(game.name).Length != 0 && !gamesRunning.Contains(game.name))
                {

                    foreach (string runOnStart in game.runOnStart)
                        runProcess(runOnStart);

                    gamesRunning.Add(game.name);

                }


                //-- RUN ON EXIT --

                if (Process.GetProcessesByName(game.name).Length == 0 && gamesRunning.Contains(game.name))
                {

                    foreach (string runOnExit in game.runOnExit)
                        runProcess(runOnExit);

                    gamesRunning.Remove(game.name);

                }
            }

            //-- ACTIONS FOR EACH PROCESS --

            foreach (KeyValuePair<string, bool> prc in queue)
            {

                if (prc.Value == true)
                {

                    if (Process.GetProcessesByName(regex.Matches(prc.Key)[0].Value).Length == 0)
                        runProcess(prc.Key);

                }
                else
                {

                    if (Process.GetProcessesByName(regex.Matches(prc.Key)[0].Value).Length != 0)
                        killProcess(prc.Key);

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

//-- KILL PROCESS BY NAME --

void killProcess(string prc)
{

    foreach (Process process in Process.GetProcessesByName(regex.Matches(prc)[0].Value))
        process.Kill();

}