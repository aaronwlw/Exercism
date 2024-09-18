/*
Regular Expressions
The .NET base class libraries provide the Regex class for processing of regular expressions.

Instructions
This exercise addresses the parsing of log files.
After a recent security review you have been asked to clean up the organization's archived log files.
All strings passed to the methods are guaranteed to be non-null and without leading and trailing spaces.

Task 1
You need some idea of how many log lines in your archive do not comply with current standards. You believe that a simple test reveals whether a log line is valid. To be considered valid a line should begin with one of the following strings:
[TRC], [DBG], [INF], [WRN], [ERR], [FTL]
Implement the LogParser.IsValidLine() method to return false if a string is not valid otherwise true.

Task 2
A new team has joined the organization, and you find their log files are using a strange separator for "fields". Instead of something sensible like a colon ":" they use a string such as "<--->" or "<=>" (because it's prettier) in fact any string that has a first character of "<" and a 
last character of ">" and any combination of the following characters "^", "*", "=" and "-" in between.
Implement the LogParser.SplitLogLine() method that takes a line and returns an array of strings each of which contains a field.

Task 3
The team needs to know about passwords occurring in quoted text so that they can be examined manually. Implement the LogParser.CountQuotedPasswords() method to provide an indication of the likely scale of the manual exercise.
Identify log lines where the literal string "password", which may be in any combination of upper or lower case, is surrounded by quotation marks. You should account for the possibility of additional content between the quotation marks before and after "password".
*/

using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, "^\\[(TRC|DBG|INF|WRN|ERR|FTL)\\]");

    public string[] SplitLogLine(string text) => Regex.Split(text, @"\<\S+\>");

    public int CountQuotedPasswords(string lines)
    {
        string[] splitStrings;
        splitStrings = lines.Split(Environment.NewLine);

        int count = 0;

        foreach (string line in splitStrings) 
        {
            if (Regex.IsMatch(line, @"\"".*password.*\""", RegexOptions.IgnoreCase))
                count++;
        }

        return count;
    }

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> processed = new List<string>();

        foreach (string line in lines)
        {
            Match password = Regex.Match(line, @"password\S+", RegexOptions.IgnoreCase);
            
            if (password != Match.Empty)
            {
                processed.Add($"{password.Value}: {line}");
            }
            else
            {
                processed.Add($"--------: {line}");
            }
        }

        return processed.ToArray();
    }
}
