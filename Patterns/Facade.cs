using System;

namespace Patterns
{
    // мегапроста реалізація патерну
    // насправді фасад може приймати всякі різні параметри,
    // управляти складними алгоритмами, коли від дії одних класів
    // залежить наступні дії інших класів і т.д.
    class Facade
    {
        static void _Main(string[] args)
        {
            ProductionOrders newOrders = new ProductionOrders();
            newOrders.DoPeaceProduction();
            Console.WriteLine("Оголошується війна.");
            newOrders.DoWarProduction();
            Console.WriteLine("Олімпійські ігри, оголошується мир.");
            newOrders.DoOlympicProduction();
            Console.ReadLine();
        }
    }


    class ProductionOrders
    {
        Architecht architecht;
        Smith smith;
        Tailor tailor;

        public ProductionOrders()
        {
            architecht = new Architecht();
            smith = new Smith();
            tailor = new Tailor();
        }
        public void DoWarProduction()
        {
            architecht.BuildFortifications();
            smith.MakeSwords();
            tailor.MakeUniform();
        }

        public void DoPeaceProduction()
        {
            architecht.BuildHouses();
            smith.MakeInstruments();
            tailor.MakeClothes();
        }

        public void DoOlympicProduction()
        {
            architecht.BuildStadium();
        }
    }
    
    class Architecht
    {
        public void BuildHouses()
        {
            Console.WriteLine("Архітектор будує житлові будинки.");
        }

        public void BuildFortifications()
        {
            Console.WriteLine("Архітектор будує фортифікації.");
        }

        public void BuildStadium()
        {
            Console.WriteLine("Архітектор будує стадіон.");
        }
    }

    class Smith
    {
        public void MakeSwords()
        {
            Console.WriteLine("Коваль кує мечі.");
        }

        public void MakeInstruments()
        {
            Console.WriteLine("Коваль кує інструменти.");
        }
    }

    class Tailor
    {
        public void MakeUniform()
        {
            Console.WriteLine("Кравець шиє уніформу.");
        }

        public void MakeClothes()
        {
            Console.WriteLine("Кравець шиє одяг.");
        }
    }

}
