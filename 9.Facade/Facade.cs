using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._9.Facade
{
    using System;

    // Complex subsystem classes
    class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("Subsystem A: OperationA");
        }
    }

    class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("Subsystem B: OperationB");
        }
    }

    class SubsystemC
    {
        public void OperationC()
        {
            Console.WriteLine("Subsystem C: OperationC");
        }
    }

    // Facade class
    class Facade
    {
        private SubsystemA subsystemA;
        private SubsystemB subsystemB;
        private SubsystemC subsystemC;

        public Facade()
        {
            subsystemA = new SubsystemA();
            subsystemB = new SubsystemB();
            subsystemC = new SubsystemC();
        }

        // Facade methods that simplify the interface to the subsystem
        public void Operation1()
        {
            Console.WriteLine("Facade: Operation 1\n");
            subsystemA.OperationA();
            subsystemB.OperationB();
        }

        public void Operation2()
        {
            Console.WriteLine("Facade: Operation 2\n");
            subsystemB.OperationB();
            subsystemC.OperationC();
        }
    }

    // Client code
    class Client
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            // Client interacts with the facade, which in turn interacts with the subsystem
            facade.Operation1();
            facade.Operation2();
        }
    }

}
