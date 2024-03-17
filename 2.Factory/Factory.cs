using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Factory
{
    //Factory
    public class PointFactory
    {
        public static Point NewCartessianPoint(double x, double y) => new Point(x, y);
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //if you want to change your constructors accessiblity from public to private you can make move PointFactory class as an inner class in Point
        //private Point(double X, double Y)
        //{
        //    this.X = X;
        //    this.Y = Y;
        //}
        //Inner factory
        //public static class PointFactory
        //{
        //    public static Point NewCartessianPoint(double x, double y) => new Point(x, y);
        //    public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        //}
    }
}
