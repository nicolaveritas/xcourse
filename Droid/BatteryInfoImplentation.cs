using System;
using Android.App;
using FormsSample.Droid;
using Android.Content;
using Android.OS;
using FormsSample.Pages.Info;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryInfoImplentation))]
namespace FormsSample.Droid
{
    public class BatteryInfoImplentation : IBatteryInfo
    {
        public BatteryInfoImplentation()
        {
        }

        public int RemaingChargePercent 
        {
            get 
            {
                try 
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged)) 
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter)) 
                        {
                            var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                            var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);

                            return (int)Math.Floor(level * 100D / scale);
                        }
                    }
                }
                catch 
                {
                    System.Diagnostics.Debug.WriteLine("Error retreiving battery info");
                    throw;
                }
            }
        } 

        public FormsSample.Pages.Info.BatteryStatus Status 
        {
            get 
            {
                try 
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged)) 
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter)) 
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)Android.OS.BatteryStatus.Charging || status == (int)Android.OS.BatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);
                            if (isCharging)
                                return FormsSample.Pages.Info.BatteryStatus.Charging;

                            switch (status)
                            {
                                case (int)Android.OS.BatteryStatus.Charging:
                                    return FormsSample.Pages.Info.BatteryStatus.Charging;
                                case (int)Android.OS.BatteryStatus.Discharging:
                                    return FormsSample.Pages.Info.BatteryStatus.Discharging;
                                case (int)Android.OS.BatteryStatus.Full:
                                    return FormsSample.Pages.Info.BatteryStatus.Full;
                                case (int)Android.OS.BatteryStatus.NotCharging:
                                    return FormsSample.Pages.Info.BatteryStatus.NotCharging;
                                default:
                                    return FormsSample.Pages.Info.BatteryStatus.Unknown;
                            }
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Error retreiving battery info");
                    throw;
                }
            }
        }

        public PowerSource Source
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)Android.OS.BatteryStatus.Charging || status == (int)Android.OS.BatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;

                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);

                            if (!isCharging)
                                return FormsSample.Pages.Info.PowerSource.Battery;
                            else if (usbCharge)
                                return FormsSample.Pages.Info.PowerSource.Usb;
                            else if (acCharge)
                                return FormsSample.Pages.Info.PowerSource.Ac;
                            else if (wirelessCharge)
                                return FormsSample.Pages.Info.PowerSource.Wireless;
                            else
                                return FormsSample.Pages.Info.PowerSource.Other;
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }
    }
}
