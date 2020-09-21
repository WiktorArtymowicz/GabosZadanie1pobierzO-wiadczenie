using System;

namespace GabosZadanie1pobierzOświadczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            Oswiadczenie oswiadczenie = new Oswiadczenie("WiktorArtymowicz");
            Console.WriteLine(oswiadczenie.CreateXML());
        }
    }
}
