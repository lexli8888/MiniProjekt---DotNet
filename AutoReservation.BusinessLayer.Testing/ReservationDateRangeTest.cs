using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationDateRangeTest
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
            
            Assert.IsTrue(
                Target.dateRangeCheck(new Reservation
                {
                    Von = new DateTime(2017, 1, 1),
                    Bis = new DateTime(2017, 7, 1)

                })
                );
        }

        [TestMethod]
        public void ScenarioOkay02Test()
        {
            Assert.IsTrue(
                Target.dateRangeCheck(new Reservation
                {
                    Von = new DateTime(2017, 8, 23),
                    Bis = new DateTime(2017, 9, 4)

                })
                );
        }

        [TestMethod]
        public void ScenarioNotOkay01Test()
        {
            Assert.IsFalse(
                Target.dateRangeCheck(new Reservation
                {
                    Von = new DateTime(2017, 7, 1),
                    Bis = new DateTime(2017, 6, 1)

                })
                );
        }

        [TestMethod]
        public void ScenarioNotOkay02Test()
        {
            Assert.IsFalse(
                Target.dateRangeCheck(new Reservation
                {
                    Von = new DateTime(2017, 7, 1),
                    Bis = new DateTime(2017, 7, 1)

                })
                );
        }

        [TestMethod]
        public void ScenarioNotOkay03Test()
        {
            Assert.IsFalse(
                Target.dateRangeCheck(new Reservation
                {
                    Von = new DateTime(2017, 5, 1),
                    Bis = new DateTime(2016, 6, 1)

                })
                );
        }
    }
}
