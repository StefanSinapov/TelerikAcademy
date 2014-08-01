namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        #region already existing tests

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        #endregion

        [TestMethod]
        public void SortingByMakeShoudReturnAllCarsInAscendingOrderByModel()
        {
            var sortedCarsByMakeModel = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(2, sortedCarsByMakeModel.Count);
            Assert.AreEqual("Audi", sortedCarsByMakeModel.First().Make);
            Assert.AreEqual("BMW", sortedCarsByMakeModel.ElementAt(1).Make);
        }

        [TestMethod]
        public void SortingByYearShoudReturnAllCarsInAscendingOrderByYear()
        {
            var sortedCarsByYear = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2, sortedCarsByYear.Count());
            Assert.AreEqual(2005, sortedCarsByYear.First().Year);
            Assert.AreEqual(2007, sortedCarsByYear.ElementAt(1).Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByNullArgumentShoudThrowArgumentException()
        {
            var sortedCarsByNull = (IList<Car>)this.GetModel(() => this.controller.Sort(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByInvalidArgumentShoudThrowArgumentException()
        {
            var sortedCarsByInvalidProp = (IList<Car>)this.GetModel(() => this.controller.Sort("Invalid"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchingWithNullArgumentShoudThrowArgumentNullException()
        {
            var searchedCar = this.controller.Search(null);
        }

        [TestMethod]
        public void SearchByCriteriaShoudReturnAllFoundCars()
        {
            var searchedCar = (IList<Car>)this.GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual(2, searchedCar.Count());
            Assert.AreEqual("BMW", searchedCar.First().Make);
            Assert.AreEqual("BMW", searchedCar.ElementAt(1).Make);
            Assert.AreEqual(2, searchedCar.First().Id);
            Assert.AreEqual(3, searchedCar.ElementAt(1).Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsShoudThrowExceptionIfCarIsNull()
        {
            var carInfo = (Car)this.GetModel(() => this.controller.Details(0));
        }

        [TestMethod]
        public void DetailsShoudReturnInfoForCarByID()
        {
            var carInfo = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual("Audi", carInfo.Make);
            Assert.AreEqual(2005, carInfo.Year);
        }


        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
