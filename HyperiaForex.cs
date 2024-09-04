/*
Operator Overloading
The principal arithmetic and comparison operators can be adapted for use by your own classes and structs. This is known as operator overloading.
Most operators have the form:
static <return type> operator <operator symbols>(<parameters>);
Cast operators have the form:
static (explicit|implicit) operator <cast-to-type>(<cast-from-type> <parameter name>);
Operators behave in the same way as static methods. An operator symbol takes the place of a method identifier, and they have parameters and a return type. The type rules for parameters and return type follow your intuition and you can rely on the compiler to provide detailed guidance.
Instructions
You've been tempted back to Hyperia (with the high inflation) for an eye watering daily rate.
The Central Bank is contemplating introducing the US Dollar as a second currency so all the accounting systems have to be adapted to handle multiple currencies.
You have been asked to implement the currency amount object.
*/

using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public decimal Amount
    {
        get => amount;
    }

    public string Currency
    {
        get => currency;
    }
    
    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount x, CurrencyAmount y) 
    { 
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return x.Amount == y.Amount;
    }

    public static bool operator !=(CurrencyAmount x, CurrencyAmount y) 
    {
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return x.Amount != y.Amount;
    }
    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount x, CurrencyAmount y) 
    { 
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return x.Amount > y.Amount;
    }

    public static bool operator <(CurrencyAmount x, CurrencyAmount y) 
    { 
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return x.Amount < y.Amount;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount x, CurrencyAmount y) 
    { 
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return new CurrencyAmount((x.Amount + y.Amount), x.Currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount x, CurrencyAmount y) 
    { 
        if (x.Currency != y.Currency)
            throw new ArgumentException();
        
        return new CurrencyAmount((x.Amount - y.Amount), x.Currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount x, decimal y) => new CurrencyAmount((x.Amount * y), x.Currency);

    public static CurrencyAmount operator /(CurrencyAmount x, decimal y) => new CurrencyAmount((x.Amount / y), x.Currency);
    
    // TODO: implement type conversion operators
    public static implicit operator double(CurrencyAmount x) => (double)x.Amount;

    public static implicit operator decimal(CurrencyAmount x) => (decimal)x.Amount;
}
