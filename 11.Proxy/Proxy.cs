using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._11.Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven");
        }

        public class Driver
        {
            public int age { get; set; }
        }
        //Proxy
        public class CarProxy : ICar
        {
            private Car car = new Car();
            private Driver driver;

            public CarProxy(Driver driver)
            {
                this.driver = driver;
            }

            public void Drive()
            {
                if (driver.age >= 16)
                {
                    car.Drive();
                }
                else
                {
                    Console.WriteLine("Too young");
                }
            }
        }
    }
}
