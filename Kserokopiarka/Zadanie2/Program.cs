using System;

namespace Zadanie2
{
    class Program
    {
        static void Main()
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("dokument.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            //xerox.Scan(out doc2, formatType: IDocument.FormatType.JPG);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

            var xerox2 = new MultiFunctionalDevice();
            xerox2.PowerOn();
            IDocument doc3 = new PDFDocument("dokument.pdf");
            xerox2.Send(doc3);
        }
    }
}