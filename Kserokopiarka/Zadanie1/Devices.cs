using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public interface IDevice
    {
        enum State { on, off };

        void PowerOn(); // uruchamia urządzenie, zmienia stan na `on`
        void PowerOff(); // wyłącza urządzenie, zmienia stan na `off
        State GetState(); // zwraca aktualny stan urządzenia

        int Counter { get; }  // zwraca liczbę charakteryzującą eksploatację urządzenia,
                              // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
    }

    public abstract class BaseDevice : IDevice
    {
        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
        }

        public int Counter { get; private set; } = 0;
    }

    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        void Print(in IDocument document);
    }

    public interface IScanner : IDevice
    {
        // dokument jest skanowany, jeśli urządzenie włączone
        // w przeciwnym przypadku nic się dzieje
        void Scan(out IDocument document, IDocument.FormatType formatType);
    }
    
    public class Copier : IPrinter, IScanner
    {
        public int Counter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public int PrintCounter { get; private set; } = 0;

        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Counter++;
            }
            Console.WriteLine("Device is on ...");
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                PrintCounter++;
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
            }
            
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument("dokument.pdf");
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument("dokument.jpg");
            }
            else
            {
                document = new TextDocument("dokument.txt");
            }

            if (state == IDevice.State.on)
            {
                ScanCounter++;
                Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
            }
        }

        public void ScanAndPrint()
        {
            if (state ==IDevice.State.on)
            {
                IDocument doc;
                Scan(out doc, formatType: IDocument.FormatType.JPG);
                Print(doc);
            }
        }
    }
}