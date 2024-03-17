using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    //Must choose type first then validate wheelsize for type
    //With Interface Segregation Principle
    public interface ISpecifiyCarType
    {
        public ISpecifyWheelSize OfType(CarType carType);
    }

    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheels(int wheelSize);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl : ISpecifiyCarType, ISpecifyWheelSize, IBuildCar
        {
            private Car car = new Car();
            public ISpecifyWheelSize OfType(CarType carType)
            {
                car.Type = carType;
                return this;
            }

            public IBuildCar WithWheels(int wheelSize)
            {
                switch (car.Type)
                {
                    case CarType.Sedan when wheelSize < 17 || wheelSize > 20:
                    case CarType.Crossover when wheelSize < 15 || wheelSize > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}");
                }
                car.WheelSize = wheelSize;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }

        public static ISpecifiyCarType Create()
        {
            return new Impl();
        }
    }
}
