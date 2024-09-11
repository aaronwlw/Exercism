/*
Namespaces
Namespaces are a way to group related code and to avoid name clashes and are generally present in all but the most trivial code base.
The syntax is as follows:
namespace MyNameSpace
{
    public class MyClass {}
    public class OtherClass {}
}
Types enclosed in namespaces are referred to outside the scope of the namespace by prefixing the type name with the dot syntax. Alternatively, and more usually, you can place a using directive at the top of the file (or within a namespace) and type can be used without the prefix. Within the same namespace there is no need to qualify type names.
You can alias a namespace with the syntax using MyAlias = MySpace; and then use the alias anywhere that the namespace could be used.

Instructions
Management are starting to apply Darwinian principles to the Remote Control Car project remote-control-competition. The developers have been split into two teams, Red and Blue, and are tasked with improving the design independently of each other. They don't need to concern themselves with design decisions of the other team.
You have been asked to take a look at the code and see how you can best combine the two efforts for testing purposes.
*/

namespace RedRemoteControlCarTeam
{
    public class RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry, RunningGear runningGear);
    public class RunningGear;
    public class Telemetry;
    public class Chassis;
    public class Motor;
}

namespace BlueRemoteControlCarTeam
{
    public class RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry);
    public class Telemetry;
    public class Chassis;
    public class Motor;
}

namespace Combined
{
    using Red = RedRemoteControlCarTeam;
    using Blue = BlueRemoteControlCarTeam;

    public static class CarBuilder
    {
        public static Red.RemoteControlCar BuildRed()
        {
            return new Red.RemoteControlCar(
                new Red.Motor(),
                new Red.Chassis(),
                new Red.Telemetry(),
                new Red.RunningGear()
            );
        }
    
        public static Blue.RemoteControlCar BuildBlue()
        {
            return new Blue.RemoteControlCar(
                new Blue.Motor(),
                new Blue.Chassis(),
                new Blue.Telemetry()
            );
        }
    }
}
