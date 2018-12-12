using System;
using System.Collections.Generic;

namespace Patterns
{
    class AbstractFactory
    {
        static void _Main(string[] args)
        {
            EquipmentSet footballset = new EquipmentSet(new FootballEquipmentFactory());
            footballset.ShowSet();
            EquipmentSet basketballset = new EquipmentSet(new BasketballEquipmentFactory());
            basketballset.ShowSet();
            EquipmentSet handballset = new EquipmentSet(new HandballEquipmentFactory());
            handballset.ShowSet();

            Console.ReadLine();
        }
    }


    // тут можна понапридумувати насправді інтерфейси під різні види спорту
    // розділяючи їх якось за тим, які в них предмети використовуються
    // і за І принципом з SOLID реалізовувати по декілька, але не факт що вони гарно поділяться
    interface ISportsEquipmentFactory
    {
        Ball GetBall();
        Goal GetGoal();
    }

    class FootballEquipmentFactory : ISportsEquipmentFactory
    {
        public Ball GetBall()
        {
            return new FootballBall();
        }

        public Goal GetGoal()
        {
            return new FootballGoal();
        }
    }

    class BasketballEquipmentFactory : ISportsEquipmentFactory
    {
        public Ball GetBall()
        {
            return new BasketballBall();
        }

        public Goal GetGoal()
        {
            return new BasketballGoal();
        }
    }

    class HandballEquipmentFactory : ISportsEquipmentFactory
    {
        public Ball GetBall()
        {
            return new HandballBall();
        }

        public Goal GetGoal()
        {
            return new HandballGoal();
        }
    }

    abstract class SportsEquipment
    {
        public string Name { get; set; }

        public SportsEquipment(string name)
        {
            Name = name;
        }

    }

    //можна додавати сюди параметри м'ячів
    abstract class Ball : SportsEquipment
    {
        public Ball(string name) : base(name)
        {
        }
    }

    //можна додавати сюди параметри воріт
    abstract class Goal : SportsEquipment
    {
        public Goal(string name) : base(name)
        {
        }
    }

    class FootballBall : Ball
    {
        public FootballBall(): base("футбольний м'яч")
        {
        }
    }

    class BasketballBall : Ball
    {
        public BasketballBall() : base("баскетбольний м'яч")
        {
        }
    }

    class HandballBall : Ball
    {
        public HandballBall() : base("гандбольний м'яч")
        {
        }
    }

    class FootballGoal : Goal
    {
        public FootballGoal() : base("футбольні ворота")
        {
        }
    }

    class BasketballGoal : Goal
    {
        public BasketballGoal() : base("баскетбольна корзина")
        {
        }
    }

    class HandballGoal : Goal
    {
        public HandballGoal() : base("гандбольні ворота")
        {
        }
    }


    class EquipmentSet
    {
        public static int currentBatch;
        public int BatchID { get; set; }
        List<SportsEquipment> sportsEquipment;

        public EquipmentSet(ISportsEquipmentFactory factory)
        {
            BatchID = ++currentBatch;
            sportsEquipment = new List<SportsEquipment>
            {
                factory.GetBall(),
                factory.GetGoal(),
                factory.GetGoal()
            };
        }

        public void ShowSet()
        {
            Console.WriteLine("{0}-й набір містить:",BatchID);
            foreach (SportsEquipment item in sportsEquipment)
            {
                Console.WriteLine(item.Name);
            }
        }
        
    }

}
