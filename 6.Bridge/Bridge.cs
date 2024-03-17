using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._6.Bridge
{
    // The 'Abstraction' class
    public abstract class Shape
    {
        protected IDrawAPI drawAPI;
        protected Shape(IDrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }
        public abstract void Draw();
    }

    // The 'RefinedAbstraction' class
    public class Circle : Shape
    {
        public Circle(IDrawAPI drawAPI) : base(drawAPI) { }
        public override void Draw()
        {
            drawAPI.DrawCircle();
        }
    }

    // The 'Implementor' interface
    public interface IDrawAPI
    {
        void DrawCircle();
    }

    // The 'ConcreteImplementorA' class
    public class RedCircle : IDrawAPI
    {
        public void DrawCircle()
        {
            Console.WriteLine("Drawing Circle[ color: red ]");
        }
    }

    // The 'ConcreteImplementorB' class
    public class GreenCircle : IDrawAPI
    {
        public void DrawCircle()
        {
            Console.WriteLine("Drawing Circle[ color: green ]");
        }
    }

    public class Demo
    {
        Shape redCircle = new Circle(new RedCircle());
        Shape greenCircle = new Circle(new GreenCircle());

        public Demo()
        {
            redCircle = new Circle(new RedCircle());
            greenCircle = new Circle(new GreenCircle());
        }
    }
}

