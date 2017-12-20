using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer;
using AutoReservation.BusinessLayer.Exceptions;
using AutoReservation.Common.DataTransferObjects.Faults;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        private static void WriteActualMethod() 
            => Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");

        public void addCar(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            autoManager.addCar(auto);
        }

        public void addCustomer(KundeDto kundeDto)
        {
            WriteActualMethod();
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();
            kundeManager.addCustomer(kunde);
        }

        public void addRerservation(ReservationDto reservationDto)
        {
            WriteActualMethod();
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();
            try
            {
                reservationManager.addReservation(reservation);
            }
            catch (InvalidDateRangeException<Reservation> e)
            {
                InvalidDateRange fault = new InvalidDateRange();
                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Ungültiger Zeitraum gewählt!";

                throw new FaultException<InvalidDateRange>(fault);
            }

            catch (AutoUnavailableException<Auto> e) {
                AutoUnavailable fault = new AutoUnavailable();
                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Car is not available";

                throw new FaultException<AutoUnavailable>(fault);
            }
        }

        public List<AutoDto> getAllCars()
        {
            WriteActualMethod();
            AutoManager autoManager = new AutoManager();
            return DtoConverter.ConvertToDtos(autoManager.List);
        }

        public List<KundeDto> getAllCustomers()
        {
            WriteActualMethod();
            KundeManager kundeManager = new KundeManager();
            return DtoConverter.ConvertToDtos(kundeManager.List);
        }

        public List<ReservationDto> getAllReservations()
        {
            WriteActualMethod();
            ReservationManager reservationManager = new ReservationManager();
            return DtoConverter.ConvertToDtos(reservationManager.List);
        }

        public AutoDto getCarById(int id)
        {
            WriteActualMethod();
            AutoManager autoManager = new AutoManager();
            return DtoConverter.ConvertToDto(autoManager.getCarById(id));
        }

        public KundeDto getCustomerById(int id)
        {
            WriteActualMethod();
            KundeManager kundeManager = new KundeManager();
            return DtoConverter.ConvertToDto(kundeManager.getCustomerById(id));
        }

        public ReservationDto getReservationByNr(int nr)
        {
            WriteActualMethod();
            ReservationManager reservationManager = new ReservationManager();
            return DtoConverter.ConvertToDto(reservationManager.getReservationByNr(nr));
        }

        public bool isCarAvailable(ReservationDto reservation, AutoDto auto)
        {
            WriteActualMethod();
            ReservationManager reservationManager = new ReservationManager();
            return reservationManager.IsCarAvailable(DtoConverter.ConvertToEntity(reservation), DtoConverter.ConvertToEntity(auto));
            
        }

        public void modifyCar(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            try
            {
                autoManager.modifyCar(auto);
            }
            catch (OptimisticConcurrencyException<Auto> e) {
                OptimisticConcurrency<AutoDto> fault = new OptimisticConcurrency<AutoDto>();
                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Occurrency Exception!";

                throw new FaultException<OptimisticConcurrency<AutoDto>>(fault);
            }
            
        }

        public void modifyCustomer(KundeDto kundeDto)
        {
            WriteActualMethod();
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();

            try {
                kundeManager.modifyCustomer(kunde);
            }
            catch (OptimisticConcurrencyException<Kunde> e)
            {
                OptimisticConcurrency<KundeDto> fault = new OptimisticConcurrency<KundeDto>();
                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Occurrency Exception!";

                throw new FaultException<OptimisticConcurrency<KundeDto>>(fault);
            }
        }

        public void modifyRerservation(ReservationDto reservationDto)
        {
            WriteActualMethod();
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();

            try {
                reservationManager.modifyReservation(reservation);
            }
            
            catch (OptimisticConcurrencyException<Reservation> e)
            {
                OptimisticConcurrency<ReservationDto> fault = new OptimisticConcurrency<ReservationDto>();
                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Occurrency Exception!";

                throw new FaultException<OptimisticConcurrency<ReservationDto>>(fault);
            }
        }

        public void removeCar(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            autoManager.removeCar(auto);
        }

        public void removeCustomer(KundeDto kundeDto)
        {
            WriteActualMethod();
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();
            kundeManager.removeCustomer(kunde);
        }

        public void removeRerservation(ReservationDto reservationDto)
        {
            WriteActualMethod();
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();
            reservationManager.removeReservation(reservation);
        }
    }
}