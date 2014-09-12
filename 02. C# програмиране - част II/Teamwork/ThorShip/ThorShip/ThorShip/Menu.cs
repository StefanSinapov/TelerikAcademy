using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ThorShip
{
    class Menu
    {
        string[] title = new string[6];
        string[] gameover = new string[6];
        string username;
        string controls;

        public Menu()
        {
            title[0] = "  _______ _    _  ____  _____     _____ _    _ _____ _____ ";
            title[1] = " |__   __| |  | |/ __ \\|  __ \\   / ____| |  | |_   _|  __ \\";
            title[2] = "     | |  | |__| | |  | | |__) | | (___ | |__| | | | | |__) |";
            title[3] = "    | |  |  __  | |  | |  _  /   \\___ \\|  __  | | | |  ___/";
            title[4] = "    | |  | |  | | |__| | | \\ \\   ____) | |  | |_| |_| |    ";
            title[5] = "    |_|  |_|  |_|\\____/|_|  \\_\\ |_____/|_|  |_|_____|_|    ";
            controls = "Use arrow keys for movement, WASD for shooting.";

            gameover[0] = " _____          __  __ ______    ______      ________ _____";
            gameover[1] = @" / ____|   /\   |  \/  |  ____|  / __ \ \    / |  ____|  __ \";
            gameover[2] = @" | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) | ";
            gameover[3] = @" | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  /  ";
            gameover[4] = @" | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \  ";
            gameover[5] = @"  \_____/_/    \_|_|  |_|______|  \____/   \/   |______|_|  \_\ ";

        }

        private Dictionary<string, int> ReadScores(string pathToFile)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();

            using (StreamReader scoresFile = new StreamReader(pathToFile))
                for (string score; (score = scoresFile.ReadLine()) != null; )
                    scores.Add(score.Split(' ')[0], int.Parse(score.Split(' ')[1]));

            return scores;
        }

        private Dictionary<string, int> CheckNewScore(string name, int score, string pathToFile)
        {
            Dictionary<string, int> scores = ReadScores(pathToFile);

            try
            {
                scores.Add(name, score);
            }
            catch
            {
                scores[name] = Math.Max(scores[name], score);
            }

            scores = scores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return scores;
        }

        private void WriteNewScore(string name, int score, string pathToFile)
        {
            Dictionary<string, int> newscores = CheckNewScore(name, score, pathToFile);

            using (StreamWriter file = new StreamWriter(pathToFile))
                foreach (var item in newscores)
                    file.WriteLine(item.Key + " " + item.Value.ToString());
        }

        public void WelcomeScreen(bool hasUser)
        {
            Field.Score = 0;
            Field.LivesCount = 3;

            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string line in title)
                Console.WriteLine("{0," + ((Console.WindowWidth + line.Length) / 2) + "}", line);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 16);

            string user = "Enter your name: ";
            string start = "Press the Enter key to start...";
            if (hasUser)
                Console.WriteLine("{0," + ((Console.WindowWidth + start.Length) / 2) + "}", start);
            else
                Console.WriteLine("{0," + ((Console.WindowWidth + user.Length) / 2 - 6) + "}", user);

            if (!hasUser)
            {
                Console.SetCursorPosition((Console.WindowWidth + user.Length) / 2 - 6, 16);
                this.username = Console.ReadLine();
                Console.Clear();
                this.WelcomeScreen(true);
            }

            if (hasUser)
            {
                try
                {
                    Dictionary<string, int> results = this.ReadScores("DATA/Highscores.txt");
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine("TOP SCORES:");
                
                    Console.WriteLine(results.ElementAt(0).Key + ": " + results.ElementAt(0).Value);
                    Console.WriteLine(results.ElementAt(1).Key + ": " + results.ElementAt(1).Value);
                    Console.WriteLine(results.ElementAt(2).Key + ": " + results.ElementAt(2).Value);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Plese create DATA/Highscores.txt in the directory of your ThorShip.exe file.");
                    Console.WriteLine("Press any key to exit!");
                    Console.Read();
                    Environment.Exit(0);
                }
                catch
                {

                }

                Console.WriteLine();
                Console.WriteLine("{0," + ((Console.WindowWidth + controls.Length) / 2) + "}", controls);
                Console.CursorVisible = false;

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape) Environment.Exit(0);
                    else if (key.Key == ConsoleKey.Enter) break;
                }
            }
        }

        public void GameOverScreen(int score)
        {
            this.WriteNewScore(this.username, score, "DATA/Highscores.txt");
                       
            Console.Clear();

            Console.SetCursorPosition(0, 3);
            foreach (string line in gameover)
                Console.WriteLine("{0," + ((Console.WindowWidth + line.Length) / 2) + "}", line);

            Console.SetCursorPosition(0, 14);

            string info = "Your score: " + score;
            Console.WriteLine("{0," + (Console.WindowWidth + info.Length) / 2 + "}", info);

            string tips = "Press Escape to exit, Enter to restart";
            Console.WriteLine("{0," + (Console.WindowWidth + tips.Length) / 2 + "}", tips);
            try
            {
                Dictionary<string, int> results = this.ReadScores("DATA/Highscores.txt");
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("TOP SCORES");
            

                Console.WriteLine(results.ElementAt(0).Key + ": " + results.ElementAt(0).Value);
                Console.WriteLine(results.ElementAt(1).Key + ": " + results.ElementAt(1).Value);
                Console.WriteLine(results.ElementAt(2).Key + ": " + results.ElementAt(2).Value);
                Console.WriteLine(results.ElementAt(3).Key + ": " + results.ElementAt(3).Value);
                Console.WriteLine(results.ElementAt(4).Key + ": " + results.ElementAt(4).Value);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("TOP SCORES:");
                Console.WriteLine("Someone has stollen\nTop Scores!\nFind and Destroy!");
            }
            catch
            {

            }
            Console.WriteLine();
            Console.WriteLine("{0," + ((Console.WindowWidth + controls.Length) / 2) + "}", controls);
            Console.CursorVisible = false;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) Environment.Exit(0);
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    this.WelcomeScreen(true);
                    break;
                }
            }
        }
    }
}
