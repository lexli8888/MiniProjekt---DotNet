using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        List<AutoDto> getAllCars();
        [OperationContract]
        List<KundeDto> getAllCustomers();
        [OperationContract]
        List<ReservationDto> getAllReservations();
        [OperationContract]
        AutoDto getCarById(int id);
        [OperationContract]
        KundeDto getCustomerById(int id);
        [OperationContract]
        ReservationDto getReservationByNr(int nr);
        [OperationContract]
        void addCar(AutoDto autoDto);
        [OperationContract]
        void addCustomer(KundeDto kundeDto);
        [OperationContract]
        void addRerservation(ReservationDto reservationDto);
        [OperationContract]
        void modifyCar(AutoDto autoDto);
        [OperationContract]
        void modifyCustomer(KundeDto kundeDto);
        [OperationContract]
        void modifyRerservation(ReservationDto reservationDto);
        [OperationContract]
        void removeCar(AutoDto autoDto);
        [OperationContract]
        void removeCustomer(KundeDto kundeDto);
        [OperationContract]
        void removeRerservation(ReservationDto reservationDto);
        [OperationContract]
        bool isCarAvailable(ReservationDto reservation, AutoDto auto);

    }
}
