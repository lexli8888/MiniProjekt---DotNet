using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.BusinessLayer.Exceptions;
using AutoReservation.Dal.Entities;

namespace AutoReservation.BusinessLayer
{
    public class ReservationManager : ManagerBase
    {
        AutoReservationContext context = new AutoReservationContext();

        public List<Reservation> List
        {
            get
            {
                {
                    return context.Reservations.ToList();
                }
            }
        }

        public Reservation getReservationByNr(int nr)
        {

            return context.Reservations.Where(x => x.ReservationsNr == nr).FirstOrDefault();

        }

        public void addReservation (Reservation reservation)
        {
            if (dateRangeCheck(reservation))
            {
                if (IsCarAvailable(reservation, reservation.Auto))
                {
                    context.Entry(reservation).State = EntityState.Added;
                    context.SaveChanges();
                }
                else {
                    throw CreateAutoUnavailableException(reservation, reservation.Auto);
                }
            }
            else {
                throw CreateInvalidDateRangeException(reservation);
            }
        }

        public void removeReservation (Reservation reservation)
        {
            context.Entry(reservation).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void modifyReservation(Reservation reservation) {
            try
            {
                context.Entry(reservation).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw CreateOptimisticConcurrencyException<Reservation>(context, reservation);
            }
        }

        // need to edit Check for 24 hours difference
        public bool dateRangeCheck(Reservation reservation) {
            if (reservation.Bis > reservation.Von) {
                return true;
            }
            return false;
        }

        public bool IsCarAvailable(Reservation reservation, Auto auto)
        {
            Auto test = auto;
            return context.Reservations.Where(x => x.Auto == auto 
            && x.Von < reservation.Von 
            && reservation.Von < x.Bis) == null ? false : true;
            
        }

        protected static InvalidDateRangeException<Reservation> CreateInvalidDateRangeException<Reservation> (Reservation reservation)
           
        {
            return new InvalidDateRangeException<Reservation>($"Update Timerange of: " + reservation.ToString() +" Eine Reservation muss länger als 24 Stunden dauern!");
        }

        public static AutoUnavailableException<Auto> CreateAutoUnavailableException(Reservation reservation, Auto auto)
        {
            return new AutoUnavailableException<Auto>("Das Auto ist für diesen Zeitraum nicht verfügbar.");
        }

        
    }
}