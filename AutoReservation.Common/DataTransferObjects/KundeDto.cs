﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        [Timestamp]
        public DateTime RowVersion { get; set; }
        public override string ToString()
            => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}; {RowVersion}";
    }

}
