using System;
using System.Management;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace TegraAutoSmash
{
    class Program
    {
        static void Main()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("TegraAutoSmash", $"\"{AppDomain.CurrentDomain.BaseDirectory+AppDomain.CurrentDomain.FriendlyName}\"");
            }

            while (true)
            {
                var alreadyConnected = false;
                using (var devices = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity WHERE DeviceID like 'USB\\VID_0955&PID_7321%'"))
                    foreach (var device in devices.Get())
                    {
                        if (!alreadyConnected && (bool)device.GetPropertyValue("Present"))
                        {
                            alreadyConnected = true;
                            Console.WriteLine("Switch Detected. Running payload.");
                            var command = File.ReadAllText("config.txt");
                            var args = command.Split(' ');
                            var proccess = new Process()
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    Arguments = args[1],
                                    CreateNoWindow = true,
                                    FileName = args[0],

                                }
                            };
                            Process.Start(args[0], args[1]);
                        }
                        else if (!(bool)device.GetPropertyValue("Present")) alreadyConnected = false;
                    }
                System.Threading.Thread.Sleep(6000);
            }
        }
    }
}