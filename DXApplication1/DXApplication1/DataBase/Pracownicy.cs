//------------------------------------------------------------------------------
// <auto-generated>
//    Ten kod źródłowy został wygenerowany na podstawie szablonu.
//
//    Ręczne modyfikacje tego pliku mogą spowodować nieoczekiwane zachowanie aplikacji.
//    Ręczne modyfikacje tego pliku zostaną zastąpione w przypadku ponownego wygenerowania kodu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXApplication1.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pracownicy
    {
        public int ID { get; set; }
        public Nullable<int> ID_adres { get; set; }
        public Nullable<int> ID_kontakt { get; set; }
        public string nazwa_użytkownika { get; set; }
        public string hasło { get; set; }
        public string nazwisko { get; set; }
        public string imię { get; set; }
        public System.DateTime data_zatrudnienia { get; set; }
        public Nullable<System.DateTime> data_zwolnienia { get; set; }
    
        public virtual Adresy Adresy { get; set; }
        public virtual Kontakty Kontakty { get; set; }
    }
}
