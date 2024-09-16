/*
String Formatting

There are two principal mechanisms for formatting strings in C#/.NET. Use of String.Format() and string interpolation.

Composite Formatting
String.Format() takes a string (referred to in the documentation as a composite format) comprising fixed text and placeholders (known in the documentation as format items), and a variable number of arguments. The return value resolves each format item using the corresponding argument and combines the resolved values with the fixed text.
This mechanism is technically known as composite formatting.

String Interpolation
Interpolated strings are prefixed with a $ and include run-time expressions enclosed in braces. The format item has the following syntax: $"{<interpolationExpression>}". They do away with the need for a separate list of arguments. The result is functionally equivalent to the String.Format() mechanism.

Format Items
The text in braces, placeholders in the case of the composite format and interpolated expressions in the case of string interpolation is known as a format item.
A format item can comprise up to 3 parts. The first is the mandatory expression or argument placeholder as seen in the example code above. In addition, there is an optional alignment (introduced with a comma, ",") and an optional format string (introduced with a colon ":").
{<interpolationExpression>[,<alignment>][:<formatString>]
The alignment specifies the length of the "field" in which the text is placed, padded to the left with spaces if the alignment is positive or to the right if it is negative.
The format string specifies the shape of the text output such as whether thousands separators should be included for a number or whether the date part only of a DateTime object should be output.

Culture
Each thread has a default culture Thread.CurrentThread.CurrentCulture encapsulated in an instance of CultureInfo. The thread's culture determines how dates and numbers are formatted with respect to regional variations such as the difference in conventional date format between the UK DD/MM/YYYY and the US MM/DD/YYYY.
CultureInfo implements the IFormatProvider interface which can be passed to certain overloads of String.Format(). This can be used to override the thread culture.

Verbatim Strings
Verbatim strings allow multi-line strings. They are introduced with an @.

Instructions
In this exercise, you are going to help high school sweethearts profess their love on social media.
*/

using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA,29} ♡ {studentB,-29}";

    public static string DisplayBanner(string studentA, string studentB)
    {
        string heartTemplate = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";

        return string.Format(heartTemplate, studentA, studentB);
    }

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours) => 
        string.Format(new CultureInfo("de-DE", false), "{0} and {1} have been dating since {2:d} - that's {3} hours", studentA, studentB, start, hours.ToString("N2", CultureInfo.GetCultureInfo("de-DE")));
}

