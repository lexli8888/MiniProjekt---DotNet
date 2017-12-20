using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationUpdateTest
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation testReservation = Target.getReservationByNr(1);
            testReservation.Bis = new DateTime(2020, 1, 20);
            Target.modifyReservation(testReservation);
            Assert.AreEqual(Target.getReservationByNr(1).Bis, new DateTime(2020, 1, 20));
        }
    }
}
