using System;
using System.IO;
using System.Text.RegularExpressions;

internal class Day3
{
    private static void Main(string[] args)
    {
        string pattern = @"(\d+)";
        string pattern2 = @"(\*)";
        string[] lines = File.ReadAllLines("d3input.txt");
        int counter = 0;
        int total = 0;
        string value;
        string strippedString;
        Regex patternz = new Regex("[0-9.]");
        foreach( string l in lines )
        {
            //Part 1
            var match = Regex.Matches(l, pattern);
            foreach( Match m in match )
            {
                // Console.WriteLine(m);
                // if i should check [direction]
                bool partNumber = false;
                bool lookUp = counter > 1;
                bool lookLeft = m.Index > 1;
                bool lookRight = m.Index + m.Length < l.Length;
                bool lookDown = counter < lines.Count() - 1;

                //look above
                if (lookUp == true)
                {
                    string aboveLine = lines[counter-1];
                    value = aboveLine.Substring(m.Index + (lookLeft?-1:0), m.Length + (lookLeft?1:0) + (lookRight?1:0));
                    strippedString = patternz.Replace(value, "");
                    if (strippedString.Length > 0) {
                        partNumber = true;
                    }

                }
                //look below
                if (lookDown == true)
                {
                    string belowLine = lines[counter+1];
                    value = belowLine.Substring(m.Index + (lookLeft?-1:0), m.Length + (lookLeft?1:0) + (lookRight?1:0));
                    strippedString = patternz.Replace(value, "");
                    if (strippedString.Length > 0) {
                        partNumber = true;
                    }
                }
                //look center
                value = lines[counter].Substring(m.Index + (lookLeft?-1:0), m.Length + (lookLeft?1:0) + (lookRight?1:0));
                strippedString = patternz.Replace(value, "");
                if (strippedString.Length > 0) {
                    partNumber = true;
                }
                
                if(partNumber == true)
                {
                    Console.WriteLine("{0} on line {1} is a part number!", int.Parse(m.Value), counter);
                    total += int.Parse(m.Value);
                }
                
            }
            counter++;
        }
        Console.WriteLine(total);

        
        counter = 0;
        total = 0;
        int adjacent = 0;
        foreach( string l in lines )
        {
            //Part 2
            var match = Regex.Matches(l, pattern2);
            foreach( Match m in match )
            {
                // if i should check [direction]
                bool lookUp = counter > 0;
                bool lookLeft = m.Index > 1;
                bool lookRight = m.Index < l.Length;
                bool lookDown = counter < lines.Count() - 1;
                int[] numerals = {0, 0};

                //look above
                if (lookUp == true)
                {
                    string aboveLine = lines[counter-1];
                    value = aboveLine.Substring(m.Index + (lookLeft?-1:0), 1 + (lookLeft?1:0) + (lookRight?1:0));
                    //Find numbers
                    var partsAdjU = Regex.Matches(value, pattern);
                    
                    foreach(Match a in partsAdjU)
                    {
                        var r = Regex.Matches(lines[counter-1], @"\d*" + Regex.Escape(a.Value) + @"\d*");
                        //Find the correct number using the index as a valid range
                        foreach( Match t in r )
                        {
                            if(a.Index + m.Index - 1 - t.Index <= 2)
                            {
                                numerals[adjacent] = int.Parse(t.Value);
                                adjacent++;
                                break;
                            }
                        }
                    }
                }
                //look below
                if (lookDown == true)
                {
                    string belowLine = lines[counter+1];
                    value = belowLine.Substring(m.Index + (lookLeft?-1:0), 1 + (lookLeft?1:0) + (lookRight?1:0));
                    //Find numbers
                    var partsAdjD = Regex.Matches(value, pattern);

                    foreach(Match a in partsAdjD)
                    {
                        var r = Regex.Matches(lines[counter+1], @"\d*" + Regex.Escape(a.Value) + @"\d*");
                        //Find the correct number using the index as a valid range
                        foreach( Match t in r )
                        {
                            if(a.Index + m.Index - 1 - t.Index <= 2)
                            {
                                numerals[adjacent] = int.Parse(t.Value);
                                adjacent++;
                                break;
                            }
                        }
                    }
                }
                //look center
                value = lines[counter].Substring(m.Index + (lookLeft?-1:0), 1 + (lookLeft?1:0) + (lookRight?1:0));
                var partsAdjC = Regex.Matches(value, pattern);
                foreach(Match a in partsAdjC)
                    {
                        var r = Regex.Matches(lines[counter], @"\d*" + Regex.Escape(a.Value) + @"\d*");
                        //Find the correct number using the index as a valid range
                        foreach( Match t in r )
                        {
                            if(a.Index + m.Index - 1 - t.Index <= 2)
                            {
                                numerals[adjacent] = int.Parse(t.Value);
                                adjacent++;
                                break;
                            }
                        }
                    }
                if(adjacent == 2)
                {
                    Console.WriteLine("Gear is adjacent to parts {0} and {1}", numerals[0], numerals[1]);
                    total += numerals[0] * numerals[1];
                }
                adjacent = 0;
            }
            counter++;
        }
        Console.WriteLine(total);
    }
}