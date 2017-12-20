using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;
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
        [FaultContract(typeof(AutoUnavailable))]
        [FaultContract(typeof(InvalidDateRange))]
        void addRerservation(ReservationDto reservationDto);
        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrency<AutoDto>))]
        void modifyCar(AutoDto autoDto);
        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrency<KundeDto>))]
        void modifyCustomer(KundeDto kundeDto);
        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrency<ReservationDto>))]
        [FaultContract(typeof(AutoUnavailable))]
        [FaultContract(typeof(InvalidDateRange))]
        void modifyRerservation(ReservationDto reservationDto);
        [OperationContract]
        void removeCar(AutoDto autoDto);
        [OperationContract]
        void removeCustomer(KundeDto kundeDto);
        [OperationContract]
        void removeRerservation(ReservationDto reservationDto);
        [OperationContract]
        [FaultContract(typeof(AutoUnavailable))]
        bool isCarAvailable(ReservationDto reservation, AutoDto auto);

    }
}
