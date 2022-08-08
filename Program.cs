using System;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;

namespace VoxDataThermalPrinterPaperStatus
{
    class Program
    {
       {
        static SerialPrinter printer;
        static ICommandEmitter e;
        static void StatusChanged(object sender, EventArgs ps)

        {
            var status = (PrinterStatus)ps;
            Console.WriteLine($"Low Paper? {status.IsPaperLow}");
            Console.WriteLine($"Cover Open? {status.IsCoverOpen}");
            Console.WriteLine("________________________________");
            Console.WriteLine("             Update             ");
            Console.WriteLine("________________________________");
        }
        static void setUp()
        {
            printer.Write(e.EnableAutomaticStatusBack());
            printer.StatusChanged += StatusChanged;
        }
        static void Main(string[] args)
        {

            printer = new SerialPrinter(portName: "COM5", int.Parse("115200"));
            e = new EPSON();
            printer.StartMonitoring();
            setUp();
        }
    }
}
