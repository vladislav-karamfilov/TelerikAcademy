namespace FacadeExample
{
    using System;

    class FacadeExample
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Example for 'Facade' design pattern***");
            Console.Write(decorationLine);

            Facade.Instance.MethodA();
            Facade.Instance.MethodB();
            Facade.Instance.MethodC();
        }
    }
}
