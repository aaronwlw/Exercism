/*
Resource Cleanup

If a class implements the IDisposable interface then its Dispose() method must be called whenever an instance is no longer required. This is typically done from a catch or finally clause or from the Dispose() routine of some caller. Dispose() provides an opportunity for unmanaged resources such as operating system objects (which are not managed by the .NET runtime) to be released and the internal state of managed resources to be reset.
Instructions
You are implementing an ORM (Object Relational Mapping) system over a database which has been provided by another team.
The database is capable of handling a single transaction at one time.
No logging or other error handling is required at this stage.
Note that, internally, the database transitions through a number of state: Closed, TransactionStarted, DataWritten, Invalid, Closed. You can rely on the fact that the database is in a Closed state at the start of each exercise.
The database has the following instance methods:
    Database.BeginTransaction() starts a transaction on the database. If this is called when the database is not in a Closed state then an exception is thrown. If successful the internal state of the database will change to TransactionStarted.
    Database.Write(string data) writes data to the database within the transaction. If it receives bad data an exception will be thrown. An attempt to call this method without BeginTransaction() having been called will cause an exception to be thrown. If successful the internal state of the database will change to DataWritten.
    Database.EndTransaction() commits the transaction to the database. It may throw an exception if it can't close the transaction or if Database.BeginTransaction() had not been called.
    A call toDatabase.Dispose() will clean up the database if an exception is thrown during a transaction. This will change the state of the database to Closed.
*/

using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        try 
        {
            database.Write(data);
        }
        catch(Exception e) 
        {
            database.Dispose();
        }
    }

    public void Dispose() 
    {
        database.Dispose();
    } 
    
    public void Commit()
    {
        try 
        {
            database.EndTransaction();
        }
        catch(Exception e) 
        {
            database.Dispose();
        }
    }
}
