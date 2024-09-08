/*
Structs
C# structs are closely related classs. They have state and behavior. They have constructors that take arguments, instances can be assigned, tested for equality and stored in collections.

Instructions
You have been tasked by the claims department of Isaacs Asteroid Exploration Co. to improve the performance of their land claim system.
Every time a new asteroid is ready for exploitation speculators are invited to stake their claim to a plot of land. The asteroid's land is divided into 4 sided plots. Speculators claim the land by specifying its dimensions.
Your goal is to develop a performant system to handle the land rush that has in the past caused the website to crash.
The unit of measure is 100 meters but can be ignored in these tasks.
*/

using System;
using System.Collections.Generic;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    // TODO: Complete implementation of the Plot struct
    private Coord _coord1 { get; }
    private Coord _coord2 { get; }
    private Coord _coord3 { get; }
    private Coord _coord4 { get; }
    
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        _coord1 = coord1;
        _coord2 = coord2;
        _coord3 = coord3;
        _coord4 = coord4;
    }

    public int LongestSide() => 
        Math.Max(
            Math.Max(Math.Abs(_coord1.X - _coord2.X), Math.Abs(_coord3.X - _coord4.X)),
            Math.Max(Math.Abs(_coord1.Y - _coord3.Y), Math.Abs(_coord2.Y - _coord4.Y))
		);
}

public class ClaimsHandler
{
    private HashSet<Plot> _claims = new HashSet<Plot>();
    private Plot _lastClaim;
    
    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => Object.Equals(plot, _lastClaim);

    public Plot GetClaimWithLongestSide()
    {
        int longest = 0;
        Plot result = default;

        foreach (Plot current in _claims)
        {
            if (current.LongestSide() > longest)
            {
                result = current;
                longest = current.LongestSide();
            }
        }

        return result;
    }
}
  
