﻿using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.BusinessLayer.Exceptions;

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

            return (Reservation)context.Reservations.Where(x => x.ReservationsNr == nr);

        }

        public void addReservation (Reservation reservation)
        {
            context.Entry(reservation).State = EntityState.Added;
            context.SaveChanges();
        }

        public void removeReservation (Reservation reservation)
        {
            context.Entry(reservation).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void updateReservation(Reservation reservation) {
            try
            {
                context.Entry(reservation).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                CreateOptimisticConcurrencyException<Reservation>(context, reservation);
            }
        }

        // need to edit Check for 24 hours difference
        public bool dateRangeCheck(Reservation reservation) {
            if (reservation.Bis > reservation.Von) {
                return false;
            }
            return true;
        }


        protected static InvalidDateRangeException<Reservation> CreateInvalidDateRangeException<Reservation> (Reservation reservation)
           
        {
            return new InvalidDateRangeException<Reservation>($"Update Timerange of: " + reservation.ToString() +" Eine Reservation muss länger als 24 Stunden dauern!");
        }
    }
}