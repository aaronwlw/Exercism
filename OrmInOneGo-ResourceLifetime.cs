/*
Resource Lifetime

resource-cleanup uses the IDispose interface to signal that some object's resource or other program state needed to be released or reset when the object was no longer required (and that relying on the garbage collector would not achieve this or provide the required level of control) and that IDisposable.Dispose() method was the natural place for such cleanup operations.
There is another construct, the using block, that enables, from the caller's perspective, all the resource lifetime management to be gathered into a single statement.
C# 8 introduces a refinement to the pattern. A using statement can placed at the beginning of a block.

using var drawingResource = some_provided_or_new_object;
try
{
    drawingResource.DrawSomething();
}
catch (Exception)
{
    throw;
}

Instructions

You are back working on the ORM (Object Relationship Mapping) system introduced in object-relational-mapping.
Our ORM usage analysis shows that 95% of transactions are executed from within one calling method, and it has been decided that it would be more appropriate to have a single ORM method that opened, wrote and committed a transaction.
The database has the following instance methods:
    Database.BeginTransaction() starts a transaction on the database.
    Database.Write(string data) writes data to the database within the transaction. If it receives bad data an exception will be thrown. An attempt to call this method without BeginTransaction() having been called will cause an exception to be thrown. If successful the internal state of the database will change to DataWritten.
    Database.EndTransaction() commits the transaction to the database. It may throw an exception if it can't close the transaction or if Database.BeginTransaction() had not been called.
    A call toDatabase.Dispose() will clean up the database if an exception is thrown during a transaction. This will change the state of the database to Closed.
*/

using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using var databaseResource = this.database;
        try
        {
            databaseResource.BeginTransaction();
            databaseResource.Write(data);
            databaseResource.EndTransaction();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        using var databaseResource = this.database;
        try
        {
            databaseResource.BeginTransaction();
            databaseResource.Write(data);
            databaseResource.EndTransaction();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
