using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationAvailabilityTest
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());
        

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void ScenarioOkay01Test()
        {
            Auto auto = new StandardAuto { };
            Reservation reservation1 = 
                new Reservation {
                    Von = new DateTime(2017,1,1),
                    Bis = new DateTime(2017,1,5),
                    Auto = auto };
            Reservation reservation2 = new Reservation { };
            Target.addReservation(reservation1);
            Assert.IsTrue(
                Target.IsCarAvailable(new Reservation
                {
                    Von = new DateTime(2017, 1, 7),
                    Bis = new DateTime(2017, 1, 8),
                    Auto = auto
                }, auto
                ));
        }

        [TestMethod]
        public void ScenarioOkay02Test()
        {
            Auto auto = new StandardAuto { };
            Reservation reservation1 =
                new Reservation
                {
                    Von = new DateTime(2017, 1, 1),
                    Bis = new DateTime(2017, 1, 5),
                    Auto = auto
                };
            Reservation reservation2 = new Reservation { };
            Target.addReservation(reservation1);
            Assert.IsTrue(
                Target.IsCarAvailable(new Reservation
                {
                    Von = new DateTime(2017, 1, 7),
                    Bis = new DateTime(2017, 1, 8),
                    Auto = auto
                }, auto
                ));
        }
        
        [TestMethod]
        public void ScenarioNotOkay01Test()
        {
            Auto auto = new StandardAuto { };
            Reservation reservation1 =
                new Reservation
                {
                    Von = new DateTime(2017, 1, 1),
                    Bis = new DateTime(2017, 1, 5),
                    Auto = auto
                };
            Reservation reservation2 = new Reservation { };
            Target.addReservation(reservation1);
            Assert.IsFalse(
                Target.IsCarAvailable(new Reservation
                {
                    Von = new DateTime(2017, 1, 7),
                    Bis = new DateTime(2017, 1, 7),
                    Auto = auto
                }, auto
                ));
        }

        [TestMethod]
        public void ScenarioNotOkay02Test()
        {
            Auto auto = new StandardAuto { };
            Reservation reservation1 =
                new Reservation
                {
                    Von = new DateTime(2017, 1, 1),
                    Bis = new DateTime(2017, 1, 5),
                    Auto = auto
                };
            Reservation reservation2 = new Reservation { };
            Target.addReservation(reservation1);
            Assert.IsFalse(
                Target.IsCarAvailable(new Reservation
                {
                    Von = new DateTime(2017, 1, 7),
                    Bis = new DateTime(2017, 1, 6),
                    Auto = auto
                }, auto
                ));
        }

        [TestMethod]
        public void ScenarioNotOkay03Test()
        {
            Auto auto = new StandardAuto { };
            Reservation reservation1 =
                new Reservation
                {
                    Von = new DateTime(2017, 1, 1),
                    Bis = new DateTime(2017, 1, 5),
                    Auto = auto
                };
            Reservation reservation2 = new Reservation { };
            Target.addReservation(reservation1);
            Assert.IsFalse(
                Target.IsCarAvailable(new Reservation
                {
                    Von = new DateTime(2017, 1, 7),
                    Bis = new DateTime(2016, 1, 8),
                    Auto = auto
                }, auto
                ));
        }
    }
}
