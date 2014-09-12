﻿namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System;
    using System.Linq;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            //Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt)).Returns(this.FakeCarCollection.First());

            //Search mock
            Mock.Arrange(() => this.CarsData.Search(Arg.NullOrEmpty)).Throws(new ArgumentNullException());

            //Sort mock
            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).Take(2).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).Take(2).ToList());

            //GetById
            Mock.Arrange(() => this.CarsData.GetById(Arg.Is<int>(0))).Returns<Car>(null);
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange<int>(1, int.MaxValue, RangeKind.Inclusive))).Returns(this.FakeCarCollection.First());
        }
    }
}
