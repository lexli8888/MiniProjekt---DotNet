using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }
        AutoReservationService service;

        [TestInitialize]
        public void InitializeTestData()
        {
            service = new AutoReservationService();
            TestEnvironmentHelper.InitializeTestData();
        }

        #region Read all entities

        [TestMethod]
        public void GetAutosTest()
        {
            Assert.AreEqual(service.getAllCars().Count(), 3);
        }

        [TestMethod]
        public void GetKundenTest()
        {
            Assert.AreEqual(service.getAllCustomers().Count(), 4);
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            Assert.AreEqual(service.getAllReservations().Count(), 3);
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            Assert.IsNotNull(service.getCarById(1));
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            Assert.IsNotNull(service.getCustomerById(1));
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            Assert.IsNotNull(service.getReservationByNr(1));
        }

        #endregion

        #region Get by not existing ID

        [TestMethod]
        public void GetAutoByIdWithIllegalIdTest()
        {
            Assert.IsNull(service.getCarById(50));
        }

        [TestMethod]
        public void GetKundeByIdWithIllegalIdTest()
        {
            Assert.IsNull(service.getCustomerById(50));
        }

        [TestMethod]
        public void GetReservationByNrWithIllegalIdTest()
        {
            Assert.IsNull(service.getReservationByNr(50));
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertAutoTest()
        {
            service.addCar(new AutoDto
            {
                AutoKlasse = AutoKlasse.Standard,
                Basistarif = 0,
                Tagestarif = 100,
                Marke = "Porsche 911"
            });

            AutoDto testAuto = service.getCarById(4);
            Assert.IsNotNull(testAuto);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            service.addCustomer(new KundeDto
            {
                Vorname = "Hans",
                Nachname = "Sarpei",
                Geburtsdatum = new DateTime(1980, 1, 1),
            });
            Assert.IsNotNull(service.getCustomerById(5));
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            service.addRerservation(new ReservationDto
            {
                Von = new DateTime(2017, 12, 24),
                Bis = new DateTime(2017, 12, 31),
                Auto = new AutoDto { },
                Kunde = new KundeDto { }
            });
            Assert.IsNotNull(service.getReservationByNr(4));
        }

        #endregion

        #region Delete  

        [TestMethod]
        public void DeleteAutoTest()
        {
            AutoDto testAuto = service.getCarById(1);
            service.removeCar(testAuto);
            Assert.IsNull(service.getCarById(1));
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            KundeDto testKunde = service.getCustomerById(1);
            service.removeCustomer(testKunde);
            Assert.IsNull(service.getCustomerById(1));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            ReservationDto testReservation = service.getReservationByNr(1);
            service.removeRerservation(testReservation);
            Assert.IsNull(service.getReservationByNr(1));
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto testAuto = service.getCarById(1);
            testAuto.Marke = "Ferrari";
            service.modifyCar(testAuto);
            Assert.AreEqual("Ferrari", service.getCarById(1).Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto testKunde = service.getCustomerById(1);
            testKunde.Nachname = "Strobel";
            service.modifyCustomer(testKunde);
            Assert.AreEqual("Strobel", service.getCustomerById(1).Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto testReseration = service.getReservationByNr(1);
            testReseration.Bis = new DateTime(2020, 1, 31);
            service.modifyRerservation(testReseration);
            Assert.AreEqual(new DateTime(2020, 1, 31), service.getReservationByNr(1).Bis);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        #endregion

        #region Insert / update invalid time range

        [TestMethod]
        public void InsertReservationWithInvalidDateRangeTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void InsertReservationWithAutoNotAvailableTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateReservationWithInvalidDateRangeTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateReservationWithAutoNotAvailableTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        #endregion

        #region Check Availability

        [TestMethod]
        public void CheckAvailabilityIsTrueTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void CheckAvailabilityIsFalseTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        #endregion
    }
}
