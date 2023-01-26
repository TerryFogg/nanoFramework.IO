using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.IO.RP2040;



namespace RP2040TestIO
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            RP2040.Gpio x = RP2040.Gpio.Gpio0;

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
