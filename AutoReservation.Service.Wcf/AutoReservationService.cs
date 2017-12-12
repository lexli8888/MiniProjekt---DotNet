using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        private static void WriteActualMethod() 
            => Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");

        public void addCar(AutoDto autoDto)
        {
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            autoManager.addCar(auto);
        }

        public void addCustomer(KundeDto kundeDto)
        {
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();
            kundeManager.addCustomer(kunde);
        }

        public void addRerservation(ReservationDto reservationDto)
        {
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();
            reservationManager.addReservation(reservation);
        }

        public List<AutoDto> getAllCars()
        {
            AutoManager autoManager = new AutoManager();
            return DtoConverter.ConvertToDtos(autoManager.List);
        }

        public List<KundeDto> getAllCustomers()
        {
            KundeManager kundeManager = new KundeManager();
            return DtoConverter.ConvertToDtos(kundeManager.List);
        }

        public List<ReservationDto> getAllReservations()
        {
            ReservationManager reservationManager = new ReservationManager();
            return DtoConverter.ConvertToDtos(reservationManager.List);
        }

        public AutoDto getCarById(int id)
        {
            AutoManager autoManager = new AutoManager();
            return DtoConverter.ConvertToDto(autoManager.getCarById(id));
        }

        public KundeDto getCustomerById(int id)
        {
            KundeManager kundeManager = new KundeManager();
            return DtoConverter.ConvertToDto(kundeManager.getCustomerById(id));
        }

        public ReservationDto getReservationByNr(int nr)
        {
            ReservationManager reservationManager = new ReservationManager();
            return DtoConverter.ConvertToDto(reservationManager.getReservationByNr(nr));
        }

        public bool isCarAvailable(ReservationDto reservation, AutoDto auto)
        {
            ReservationManager reservationManager = new ReservationManager();
            return reservationManager.IsCarAvailable(DtoConverter.ConvertToEntity(reservation), DtoConverter.ConvertToEntity(auto));
            
        }

        public void modifyCar(AutoDto autoDto)
        {
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            autoManager.modifyCar(auto);
        }

        public void modifyCustomer(KundeDto kundeDto)
        {
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();
            kundeManager.modifyCustomer(kunde);
        }

        public void modifyRerservation(ReservationDto reservationDto)
        {
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();
            reservationManager.modifyReservation(reservation);
        }

        public void removeCar(AutoDto autoDto)
        {
            Auto auto = DtoConverter.ConvertToEntity(autoDto);
            AutoManager autoManager = new AutoManager();
            autoManager.removeCar(auto);
        }

        public void removeCustomer(KundeDto kundeDto)
        {
            Kunde kunde = DtoConverter.ConvertToEntity(kundeDto);
            KundeManager kundeManager = new KundeManager();
            kundeManager.removeCustomer(kunde);
        }

        public void removeRerservation(ReservationDto reservationDto)
        {
            Reservation reservation = DtoConverter.ConvertToEntity(reservationDto);
            ReservationManager reservationManager = new ReservationManager();
            reservationManager.removeReservation(reservation);
        }
    }
}