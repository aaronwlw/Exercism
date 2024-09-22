/*
Extension Methods

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. 
They are defined as static methods but are called by using instance method syntax. 
Their first parameter is preceded by the this modifier, and specifies which type the method operates on, and are brought into scope at the namespace level.

Instructions
In this exercise you'll be processing log-lines.
Each log line is a string formatted as follows: "[<LEVEL>]: <MESSAGE>".
There are three different log levels:
    INFO
    WARNING
    ERROR
You have several tasks, each of which will take a log line and ask you to do something with it.
*/

using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string line, string delimiter) => line[(line.IndexOf(delimiter) + delimiter.Length)..];

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string line, string delimiter1, string delimiter2) => line[(line.IndexOf(delimiter1) + delimiter1.Length)..line.IndexOf(delimiter2)];
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string line) => line.SubstringAfter(": ");

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string line) => line.SubstringBetween("[", "]");
}
