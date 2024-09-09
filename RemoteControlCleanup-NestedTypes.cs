/*
Nested Types
C# types can be defined within the scope of a class or struct. The enclosing type provides a kind of namespace. Access to the type is through the enclosing type with dot syntax.

class Outer
{
    public interface IInner {}
    public enum EInner {}
    public class CInner {}
    public struct SInner {}
}

var outer = new Outer();
var inner = new Outer.CInner();

You can set access levels for inner types.
Private members of the outer type are in scope for members of the inner type but not vice versa.
*/

public class RemoteControlCar
{
    public RemoteControlCar() 
    {
        Telemetry = new TelemetryClass(this);
    }

    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public TelemetryClass Telemetry;
    
    // TODO encapsulate the methods suffixed with "_Telemetry" in their own class
    // dropping the suffix from the method name
    public class TelemetryClass
    {
        private RemoteControlCar _car;

        public TelemetryClass(RemoteControlCar car)
        {
            _car = car;
        }
        
        public void Calibrate()
        {
        }

        public bool SelfTest() => true;


        public void ShowSponsor(string sponsorName) => _car.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
    
            _car.SetSpeed(new Speed(amount, speedUnits));
        }
    }
    
    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}
