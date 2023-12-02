using System;
using System.Collections;
using System.IO;

string[] lines = File.ReadAllLines("d1input.txt");

int first = -2;
int last = 0;
int total = 0;

foreach (string s in lines)
{
    first = -2;
    last = 0;
    foreach (char c in s)
    {
        if( c == '1' ||
        c == '2' ||
        c == '3' ||
        c == '4' ||
        c == '5' ||
        c == '6' ||
        c == '7' ||
        c == '8' ||
        c == '9' )
        {
            if (first == -2)
            { 
                first = int.Parse(c.ToString()); 
            }
            last = int.Parse(c.ToString());
        }
    }
    total += (10 * first) + last;
}
Console.WriteLine(total);

//Part 2
total = 0;
int index = 0;
int word = 0;
string sub;
foreach (string s in lines)
{
    first = -2;
    last = 0;
    index = 0;
    word = 0;
    foreach (char c in s)
    {
        //Instead of stapling on a word check to the previous part we can just check both words and numbers at the same time
        sub = s.Substring(index);
        if(sub.StartsWith("one") || sub.StartsWith("1")){word = 1;}
        else if(sub.StartsWith("two") || sub.StartsWith("2")){word = 2;}
        else if(sub.StartsWith("three") || sub.StartsWith("3")){word = 3;}
        else if(sub.StartsWith("four") || sub.StartsWith("4")){word = 4;}
        else if(sub.StartsWith("five") || sub.StartsWith("5")){word = 5;}
        else if(sub.StartsWith("six") || sub.StartsWith("6")){word = 6;}
        else if(sub.StartsWith("seven") || sub.StartsWith("7")){word = 7;}
        else if(sub.StartsWith("eight") || sub.StartsWith("8")){word = 8;}
        else if(sub.StartsWith("nine") || sub.StartsWith("9")){word = 9;}

        if(word != 0)
        {
            if (first == -2)
            {
                first = word;
            }
            last = word;
        }
        word = 0;
        index++;
    }
    total += (10 * first) + last;
}
Console.WriteLine(total);