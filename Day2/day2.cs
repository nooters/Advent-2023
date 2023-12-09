using System;
using System.IO;

internal class Day2
{
    private static void Main2(string[] args)
    {
        //colors = red, green, blue
        int[] power = { 0, 0, 0, 0 };
        string sub;
        string[] lines = File.ReadAllLines("d2input.txt");
        int game = 0, score = 0, color = 0;
        bool poss;

        foreach (string s in lines)
        {
            poss = true;
            sub = s;
            game = int.Parse(sub.Substring(5, sub.IndexOf(':') - 5));
            sub = sub.Substring(6 + game.ToString().Length);
            Console.WriteLine(sub);
            while(sub != "")
            {
                sub = sub.Trim();
                //Parse number
                color = int.Parse(sub.Substring(0, sub.IndexOf(' ')));
                sub = sub.Substring(color.ToString().Length + 1);
    
                //Determine color, determine if the pull was possible
                if(sub.StartsWith("red"))
                {
                    if(color > 12)
                    {
                        //impossible combo
                        poss = false;
                    }
                    if(color > power[0])
                    {
                        power[0] = color;
                    }
                    sub = sub.Substring(3);
                }
                else if(sub.StartsWith("green"))
                {
                    if(color > 13)
                    {
                        //impossible combo
                        poss = false;
                    }
                    if(color > power[1])
                    {
                        power[1] = color;
                    }
                    sub = sub.Substring(5);
                }
                else if(sub.StartsWith("blue"))
                {
                    if(color > 14)
                    {
                        //impossible combo
                        poss = false;
                    }
                    if(color > power[2])
                    {
                        power[2] = color;
                    }
                    sub = sub.Substring(4);
                }
                else
                {
                    //Something broke!
                    Console.WriteLine("Something Broke! Fix it.");
                    break;
                }
                    
                if(sub.StartsWith(',') || sub.StartsWith(';'))
                {
                    sub = sub.Substring(1);
                }
                
            }
            if(poss == true)
            {
                score += game;
                Console.WriteLine("Game {0} possible", game);
                Console.WriteLine("Score is now {0}", score);
            }
            else
            {
                Console.WriteLine("Game {0} is impossible", game);
            }
            power[3] += power[0] * power[1] * power[2];
            Console.WriteLine("Power values: Red {0}, Green {1}, Blue {2}", power[0], power[1], power[2]);
            Console.WriteLine("Power is now at {0}", power[3]);
            power[0] = 0;
            power[1] = 0;
            power[2] = 0;

            
            
        }



    }
}