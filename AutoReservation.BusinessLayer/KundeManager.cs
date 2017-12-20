using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal.Entities;

namespace AutoReservation.BusinessLayer
{
    public class KundeManager: ManagerBase
    {
        AutoReservationContext context = new AutoReservationContext();
        public List<Kunde> List
        {
            get
            {
                {
                    return context.Kunden.ToList();
                }
            }
        }

        public Kunde getCustomerById(int id)
        {

            return context.Kunden.Where(x => x.Id == id).FirstOrDefault();

        }

        public void addCustomer(Kunde kunde)
        {
            context.Entry(kunde).State = EntityState.Added;
            context.SaveChanges();
        }

        public void removeCustomer(Kunde kunde)
        {
            context.Entry(kunde).State = EntityState.Deleted;
            context.SaveChanges();
        }


        public void modifyCustomer(Kunde kunde) {
            try
            {
                context.Entry(kunde).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw CreateOptimisticConcurrencyException<Kunde>(context, kunde);
            }
        }
    }
}