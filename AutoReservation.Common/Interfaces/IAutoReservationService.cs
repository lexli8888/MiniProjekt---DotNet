using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
         List<AutoDto> getAllCars();
        List<KundeDto> getAllCustomers();
        List<ReservationDto> getAllReservations();
        AutoDto getCarById(int id);
        KundeDto getCustomerById(int id);
        ReservationDto getReservationByNr(int nr);
        void addCar(AutoDto autoDto);
        void addCustomer(KundeDto kundeDto);
        void addRerservation(ReservationDto reservationDto);
        void modifyCar(AutoDto autoDto);
        void modifyCustomer(KundeDto kundeDto);
        void modifyRerservation(ReservationDto reservationDto);
        void removeCar(AutoDto autoDto);
        void removeCustomer(KundeDto kundeDto);
        void removeRerservation(ReservationDto reservationDto);
        void isCarAvailable(AutoDto auto);

    }
}
