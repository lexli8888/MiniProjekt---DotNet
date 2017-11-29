﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.BusinessLayer.Exceptions
{
    public class InvalidDateRangeException<Reservation> : Exception
    {
        public InvalidDateRangeException(string message) {
            Console.WriteLine(message);
        }
    }
}
