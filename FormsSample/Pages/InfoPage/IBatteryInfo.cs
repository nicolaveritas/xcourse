using System;
namespace FormsSample.Pages.Info
{
    public enum BatteryStatus 
    {
        Charging,
        Discharging,
        Full,
        NotCharging,
        Unknown
    }

    public enum PowerSource 
    {
        Battery,
        Ac,
        Usb,
        Wireless,
        Other
    }

    public interface IBatteryInfo
    {
        int RemaingChargePercent { get; }
        BatteryStatus Status { get; }
        PowerSource Source { get; }
    }
}
