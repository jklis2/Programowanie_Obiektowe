using System;

namespace Zadanie3
{
    class Program
    {
        static void Main()
        {
            var xeroxp = new Printer();
            var xeroxs = new Scanner();
            var xeroxf = new Fax();
            var xerox = new Copier(xeroxp, xeroxs);
            var xeroxm = new MultidimensionalDevice(xeroxp, xeroxs, xeroxf);
            xeroxf.PowerOn();
            xerox.PowerOn();
            xeroxm.PowerOn();
            IDocument doc1 = new PDFDocument("dokument.pdf");
            xerox.Print(in doc1);
            IDocument doc2;

            xeroxf.Send(doc1);
            xerox.Scan(out doc2);
            xerox.Scan(out doc2, formatType: IDocument.FormatType.JPG);
            xeroxm.Send(doc1);
            


            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xeroxp.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

        }
    }
}
