using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoManager : ManagerBase
    {
        AutoReservationContext context = new AutoReservationContext();
        // Example
        public List<Auto> List
        {
            get
            {                
                {
                    return context.Autos.ToList();
                }
            }
        }

        public Auto getCarById(int id) {
            
                return (Auto) context.Autos.Where(x => x.Id == id);
            
        }

        public void addCar(Auto auto) {
            context.Entry(auto).State = EntityState.Added;
            context.SaveChanges();
        }

        public void removeCar(Auto auto) {
            context.Entry(auto).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void updateCar(Auto auto) {
            try
            {
                context.Entry(auto).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                CreateOptimisticConcurrencyException<Auto>(context, auto);
            }
        }

        
    }
}