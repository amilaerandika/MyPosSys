using System;
using System.Runtime.InteropServices;

public class RawPrinterHelper
{
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
    static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

    [DllImport("winspool.Drv", SetLastError = true)]
    static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
    static extern bool StartDocPrinter(IntPtr hPrinter, int Level, IntPtr pDocInfo);

    [DllImport("winspool.Drv", SetLastError = true)]
    static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", SetLastError = true)]
    static extern bool WritePrinter(IntPtr hPrinter, byte[] pBytes, int dwCount, out int dwWritten);

    public static bool SendBytesToPrinter(string printerName, byte[] bytes)
    {
        IntPtr hPrinter;
        if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
            return false;

        StartDocPrinter(hPrinter, 1, IntPtr.Zero);
        StartPagePrinter(hPrinter);
        WritePrinter(hPrinter, bytes, bytes.Length, out _);
        EndPagePrinter(hPrinter);
        EndDocPrinter(hPrinter);
        ClosePrinter(hPrinter);

        return true;
    }
}
