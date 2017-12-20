using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class KundeUpdateTest
    {
        private KundeManager target;
        private KundeManager Target => target ?? (target = new KundeManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde testKunde = Target.getCustomerById(1);
            testKunde.Nachname = "Stoffel";
            Target.modifyCustomer(testKunde);
            Assert.AreEqual(Target.getCustomerById(1).Nachname, "Stoffel");
        }
    }
}
