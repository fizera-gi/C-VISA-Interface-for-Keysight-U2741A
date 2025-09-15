using System;

namespace Test_U2741A
{
    class Program
    {
        static void Main(string[] args)
        {
            // Visa adress (depends on ypur Keysight/Agilent)
            string visaAddress = "USB0::0x0957::0x4918::MY61170017::0::INSTR";

            try
            {
                using (var dmm = new CentraleMesure(visaAddress))
                {
                    Console.WriteLine("IDN: " + dmm.Idn());

                    
                    dmm.ConfigureVdc(range: 10, nplc: 1, autoZero: false);
                    double vdc = dmm.ReadVdc();
                    Console.WriteLine("Tension DC mesurée: " + vdc + " V");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur: " + ex.Message);
            }

            Console.WriteLine("Appuyez sur Entrée pour quitter...");
            Console.ReadLine();
        }
    }
}
