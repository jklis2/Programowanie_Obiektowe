using DXApplication1.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Serwisy
{
    public class PracownicyService
    {
        public List<Pracownicy> WszyscyPracownicy()
        {
            PROJEKTNGEntities dbContext = new PROJEKTNGEntities();
            return dbContext.Pracownicy.ToList();
        }
    }
}
