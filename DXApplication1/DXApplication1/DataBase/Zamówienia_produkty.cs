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
    
    public partial class Zamówienia_produkty
    {
        public int ID { get; set; }
        public Nullable<int> ID_Zamówienia { get; set; }
        public Nullable<int> ID_Produkt { get; set; }
    
        public virtual Produkt Produkt { get; set; }
        public virtual Zamowienia Zamowienia { get; set; }
    }
}
