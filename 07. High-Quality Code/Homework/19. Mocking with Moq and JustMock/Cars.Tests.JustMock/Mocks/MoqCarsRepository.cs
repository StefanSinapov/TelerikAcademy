namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            //mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());

            //Search mock
            mockedCarsRepository.Setup(r => r.Search(It.Is<string>(a => string.IsNullOrEmpty(a)))).Throws(new ArgumentNullException());

            //Sort
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).Take(2).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).Take(2).ToList());

            //GetById
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(id => id == 0))).Returns<Car>(null);
            mockedCarsRepository.Setup(r => r.GetById(It.IsInRange<int>(1, int.MaxValue, Range.Inclusive))).Returns(this.FakeCarCollection.First());

            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
