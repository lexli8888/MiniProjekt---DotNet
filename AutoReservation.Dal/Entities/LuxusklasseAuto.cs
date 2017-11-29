using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal
{
    class LuxusklasseAuto : Auto
    {
        new public int Basistarif {get; set;}
    }
}
