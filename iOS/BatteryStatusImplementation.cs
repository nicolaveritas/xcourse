using System;
using FormsSample.iOS;
using FormsSample.Pages.Info;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryStatusImplementation))]
namespace FormsSample.iOS
{
    public class BatteryStatusImplementation : IBatteryInfo
    {
        public BatteryStatusImplementation()
        {
            UIDevice.CurrentDevice.BatteryMonitoringEnabled = true;
        }

        public int RemaingChargePercent
        {
            get
            {
                return (int)(UIDevice.CurrentDevice.BatteryLevel * 100F);
            }
        }

        public BatteryStatus Status
        {
            get
            {
                switch (UIDevice.CurrentDevice.BatteryState)
                {
                    case UIDeviceBatteryState.Charging:
                        return BatteryStatus.Charging;
                    case UIDeviceBatteryState.Full:
                        return BatteryStatus.Full;
                    case UIDeviceBatteryState.Unplugged:
                        return BatteryStatus.Discharging;
                    default:
                        return BatteryStatus.Unknown;
                }
            }
        }

        public PowerSource Source
        {
            get
            {
                switch (UIDevice.CurrentDevice.BatteryState)
                {
                    case UIDeviceBatteryState.Charging:
                        return PowerSource.Ac;
                    case UIDeviceBatteryState.Full:
                        return PowerSource.Ac;
                    case UIDeviceBatteryState.Unplugged:
                        return PowerSource.Battery;
                    default:
                        return PowerSource.Other;
                }
            }
        }

    }
}
