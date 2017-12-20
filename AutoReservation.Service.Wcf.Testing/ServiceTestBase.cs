
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
                Auto = service.getCarById(1),
                Kunde = service.getCustomerById(1)
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
            ReservationDto testReservation = service.getReservationByNr(2);
            service.removeRerservation(testReservation);
            Assert.IsNull(service.getReservationByNr(2));
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
            ReservationDto testReservation = service.getReservationByNr(1);
            testReservation.Bis = new DateTime(2020, 1, 31);
            service.modifyRerservation(testReservation);
            Assert.AreEqual(service.getReservationByNr(1).Bis, new DateTime(2020, 1, 31));
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrency<AutoDto>>))]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            AutoDto testAuto1 = service.getCarById(1);
            AutoDto testAuto2 = service.getCarById(1);
            testAuto1.Marke = "Porsche";
            testAuto2.Marke = "Maserati";
            service.modifyCar(testAuto1);
            service.modifyCar(testAuto1);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrency<KundeDto>>))]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            KundeDto testKunde1 = service.getCustomerById(1);
            KundeDto testKunde2 = service.getCustomerById(1);
            testKunde1.Nachname = "Johnson";
            testKunde2.Nachname = "Graham";
            service.modifyCustomer(testKunde1);
            service.modifyCustomer(testKunde2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrency<ReservationDto>>))]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto testReservation1 = service.getReservationByNr(1);
            ReservationDto testReservation2 = service.getReservationByNr(1);
            testReservation1.Kunde = service.getCustomerById(1);
            testReservation2.Kunde = service.getCustomerById(2);
            service.modifyRerservation(testReservation1);
            service.modifyRerservation(testReservation2);
        }

        #endregion

        #region Insert / update invalid time range

        [TestMethod]
        [ExpectedException (typeof(FaultException<InvalidDateRange>))]
        public void InsertReservationWithInvalidDateRangeTest()
        {
                service.addRerservation(
                    new ReservationDto {
                        Von = new DateTime(2017, 1, 1),
                        Bis = new DateTime(2016, 12, 31),
                        Auto = service.getCarById(2),
                        Kunde = service.getCustomerById(1) });
           
        }

        [TestMethod]
        public void InsertReservationWithAutoNotAvailableTest()
        {
            service.addRerservation(new ReservationDto
            {
                Von = new DateTime(2020, 1, 12),
                Bis = new DateTime(2020, 1, 15),
                Kunde = service.getCustomerById(1),
                Auto = service.getCarById(1)
            });
        }

        [TestMethod]
        [ExpectedException (typeof (FaultException<InvalidDateRange>))]
        public void UpdateReservationWithInvalidDateRangeTest()
        {
            ReservationDto testReservation = service.getReservationByNr(1);
            testReservation.Bis = new DateTime(2017, 1, 1);
            service.modifyRerservation(testReservation);
        }

        [TestMethod]
        [ExpectedException (typeof(FaultException<AutoUnavailable>))]
        public void UpdateReservationWithAutoNotAvailableTest()
        {
            ReservationDto testReservation = service.getReservationByNr(1);
            testReservation.Auto = service.getCarById(2);
            service.modifyRerservation(testReservation);
        }

        #endregion

        #region Check Availability

        [TestMethod]
        public void CheckAvailabilityIsTrueTest()
        {
            Assert.IsTrue(service.isCarAvailable(new ReservationDto
            {
                Von = new DateTime(2021, 1, 12),
                Bis = new DateTime(2021, 1, 15),
                Kunde = service.getCustomerById(1),
                Auto = service.getCarById(1)
            }, service.getCarById(1)));
        }

        [TestMethod]
        [ExpectedException (typeof(FaultException<AutoUnavailable>))]
        public void CheckAvailabilityIsFalseTest()
        {
            service.addRerservation(new ReservationDto
            {
                Von = new DateTime(2020, 1, 12),
                Bis = new DateTime(2020, 1, 15),
                Kunde = service.getCustomerById(1),
                Auto = service.getCarById(1)
            });
        }

        #endregion
    }
}
