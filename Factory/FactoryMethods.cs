using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Point
    {
        public double X;
        public double Y;

        //FactoryMethod
        public static Point NewCartessianPoint(double x, double y) => new Point(x, y);
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));


        private Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
