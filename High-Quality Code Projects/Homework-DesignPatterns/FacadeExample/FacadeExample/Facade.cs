namespace FacadeExample
{
    using System;

    public class Facade
    {
        private static readonly Facade facade;

        private SubsystemOne subSystemOne;
        private SubsystemTwo subSystemTwo;
        private SubsystemThree subSystemThree;

        private Facade()
        {
            this.subSystemOne = new SubsystemOne();
            this.subSystemTwo = new SubsystemTwo();
            this.subSystemThree = new SubsystemThree();
        }

        static Facade()
        {
            facade = new Facade();
        }

        public static Facade Instance
        {
            get { return facade; }
        }

        public void MethodA()
        {
            Console.WriteLine("Facade MethodA called:");
            this.subSystemOne.MethodOne();
            this.subSystemThree.MethodOne();
            Console.WriteLine();
        }

        public void MethodB()
        {
            Console.WriteLine("Facade MethodB called:");
            this.subSystemTwo.MethodOne();
            this.subSystemThree.MethodOne();
            Console.WriteLine();
        }

        public void MethodC()
        {
            Console.WriteLine("Facade MethodC called:");
            this.subSystemOne.MethodOne();
            this.subSystemTwo.MethodOne();
            Console.WriteLine();
        }
    }
}
