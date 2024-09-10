/*
Constants

The const modifier can be (and generally should be) applied to any field where its value is known at compile time and will not change during the lifetime of the program.
private const int num = 1729;
public const string title = "Grand" + " Master";
The readonly modifier can be (and generally should be) applied to any field that cannot be made const where its value will not change during the lifetime of the program and is either set by an inline initializer or during instantiation (by the constructor or a method called by the constructor).

Defensive Copying
In security sensitive situations (or even simply on a large code-base where developers have different priorities and agendas) you should avoid allowing a class's public API to be circumvented by accepting and storing a method's mutable parameters or by exposing a mutable member of a class through a return value or as an out parameter.
Readonly Collections
While the readonly modifier prevents the value or reference in a field from being overwritten, it offers no protection for the members of a reference type.

To ensure that all members of a reference type are protected the fields can be made readonly and automatic properties can be defined without a set accessor.

The Base Class Library (BCL) provides some readonly versions of collections where there is a requirement to stop members of a collections being updated. These come in the form of wrappers:
    ReadOnlyDictionary<T> exposes a Dictionary<T> as read-only.
    ReadOnlyCollection<T> exposes a List<T> as read-only.

Instructions
The authentication system that you last saw in developer-privileges is in need of some attention. You have been tasked with cleaning up the code. Such a cleanup project will not only make life easy for future maintainers but will expose and fix some security vulnerabilities.
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private Identity admin;

    private static readonly ReadOnlyDictionary<string, Identity> developers = 
        new ReadOnlyDictionary<string, Identity>(new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        });

    public Identity Admin
    {
        get { return admin; }
    }

    public ReadOnlyDictionary<string, Identity> GetDevelopers()
    {
        return developers;
    }
}

public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
}
