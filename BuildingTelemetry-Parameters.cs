/*
Parameters
This exercise discusses some details of method parameters and their use in C#.
Parameters convey information from a calling method to a called method.
    The behavior of parameters can be modified by the use of modifiers such as ref and out.
    A parameter with the out modifier conveys a value back from the called method to the caller. The parameter can be passed to the called method without being initialized and in any case it is treated within the called method as if, on entry, it had not been initialized. An understanding of the behavior and rules regarding parameter modifiers can be gained most easily through examples (see below) and compiler messages.
    out parameters must be assigned to within a called method.
    A parameter with the ref modifier passes a value into a called method. When the method returns the caller will find any updates made by the called method in that parameter.
    ref parameters must be variables as the called method will be operating directly on the parameter as seen by the caller.
    The out and ref modifiers are required both in the called method signature and at the call site.

Instructions
The remote control car project you kicked off in the classes exercise has gone well (congratulations!) and due to a number of recent sponsorship deals there is money in the budget for enhancements.
Part of the budget is being used to provide some telemetry.
To keep the sponsors sweet a panel has been installed on the car to display the sponsors names as it goes round the track.
You will note that the introduction of these fancy new technologies has dramatically reduced the car's battery life.
*/

using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = sponsors;
    }

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < latestSerialNum)
        {
            serialNum = latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
        else
        {
            latestSerialNum = serialNum;
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
        
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage = 0;
        int distanceDrivenInMeters = 0;
        
        if (car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters))
        {
            if (distanceDrivenInMeters == 0)
                return "no data";

            return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
        }
        else
        {
            return "no data";
        } 
    }
}
