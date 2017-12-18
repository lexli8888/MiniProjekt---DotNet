using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public int Basistarif { get; set; }
        public AutoKlasse AutoKlasse { get; set; }
        [Timestamp]
        public DateTime RowVersion { get; set; }

        public override string ToString()
            => $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}; {RowVersion}";
    }

}
