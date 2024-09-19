/*
Tuples
In C#, a tuple is a data structure which organizes data, holding two or more fields of any type.
A tuple is typically created by placing 2 or more expressions separated by commas, within a set of parentheses.
A tuple can be used in assignment and initialization operations, as a return value or a method argument.
Fields are extracted using dot syntax. By default, the first field is Item1, the second Item2, etc. Non-default names are discussed below.
Field names Item1 etc. do not make for readable code. The code below shows 2 ways to name the fields of tuples. Note also, in the code below, that var can be used with tuples and the type inferred. This works equally well for tuples with named and unnamed fields.

// name items in declaration
(bool success, string message) results = (true, "well done!");
bool mySuccess = results.success;
string myMessage = results.message;

Instructions
This exercise has you analyze phone numbers.
You are asked to implement 2 features.
Phone numbers passed to the routines are guaranteed to be in the form NNN-NNN-NNNN e.g. 212-515-9876 and non-null.
*/

using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) => 
        (phoneNumber.Substring(0, 3) == "212", phoneNumber.Substring(4, 3) == "555", phoneNumber.Substring(8, 4));

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
