
using System;


namespace SystemManager
{


    class MainClass
    {


        public static void Main(string[] args)
        {
			SystemManagement sys = new LinuxManagement();
			sys.Restart();

            Console.WriteLine("Hello World!");
        } // End Sub Main


    } // End Class MainClass


} // End Namespace SystemManager
