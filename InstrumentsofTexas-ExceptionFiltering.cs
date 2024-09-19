/*
Exception Filtering
when is the keyword in filtering exceptions. It is placed after the catch statement and can take a boolean expression containing any values in scope at the time. If the expression evaluates to true then the block associated with that catch statement is executed otherwise the next catch statement, if any, is checked.

User Defined Exceptions
A user-defined exception is any class defined in your code that is derived from System.Exception. It is subject to all the rules of class inheritance but in addition the compiler and language runtime treat such classes in a special way allowing their instances to be thrown and caught outside the normal control flow as discussed in the exceptions exercise.
User-defined exceptions are often used to carry extra information such as a message and other relevant data to be made available to the catching routines.
Instructions
While working at Instruments of Texas, you are tasked to work on an experimental calculator written in C#. You are building a test harness to verify a number of calculator functions starting with multiplication. You will see that there is particular concern when the two operands of the multiplication are negative.
The Calculator class has been provided for you and should not be modified.
*/

using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
        Operand1 = operand1;
        Operand2 = operand2;
        ErrorMessage = message;
        Inner = inner;
    }
    
    public int Operand1 { get; }
    public int Operand2 { get; }
    
    public string ErrorMessage { get; }
    public Exception Inner { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException e)
        {
            if (x < 0 && y < 0)
            {
                return $"Multiply failed for negative operands. {e.Inner.Message}";
            } 
            else
            {
                return $"Multiply failed for mixed or positive operands. {e.Inner.Message}";
            }
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException e)
        {
            throw new CalculationException(x, y, "Overflow exception during multiplication", e);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
