using System;

namespace Patterns
{
    class TemplateMethod
    {
        static void _Main(string[] args)
        {
            Hairdresser beautySalon = new FemaleHairdresser();
            Hairdresser barbershop = new Barber();

            Person female = new Person("Ann", 0, 30);
            Person male = new Person("Robert", 1, 5);

            female.GetHairDescription();
            beautySalon.DoService(female);
            female.GetHairDescription();

            male.GetHairDescription();
            barbershop.DoService(male);
            male.GetHairDescription();

            Console.ReadLine();
        }        
    }

    class Person
    {
        public string Name { get; set; }
        public int BeardSize { get; set; }
        public int HairSize { get; set; }

        public Person(string name, int beardSize, int hairSize)
        {
            Name = name;
            BeardSize = beardSize;
            HairSize = hairSize;
        }

        // в цьому методі перейшов на інтерполяцію рядків
        public void GetHairDescription()
        {
            if (BeardSize > 0)
                Console.WriteLine($"{Name} has {HairSize} cm of hair and {BeardSize} cm of beard.");
            else
                Console.WriteLine($"{Name} has {HairSize} cm of hair.");
        }
    }

    abstract class Hairdresser 
    {
        // оце шаблонний метод власною персоною, спільний для дітей
        public void DoService(Person client)
        {
            CutHair(client);
            DoRest(client);            
        }

        // а оці методи діти можуть собі переробляти
        // стрижка, як базова річ, обов'язково мусить бути визначена в дітях-конкретних-перукарнях
        protected abstract void CutHair(Person client);
        // а решта послуг необов'язкові, тому я зробив пустий virtual
        protected virtual void DoRest(Person client) { }
        
    }

    class Barber : Hairdresser
    {
        protected override void CutHair(Person client)
        {
            client.HairSize -= 2;
        }

        protected override void DoRest(Person client)
        {
            client.BeardSize = 0;
        }
    }

    // в даному випадку в нас перукарня тільки для жінок, і тому нам не треба
    // стригти бороди, а інші послуги я не придумаві
    class FemaleHairdresser : Hairdresser
    {
        protected override void CutHair(Person client)
        {
            client.HairSize -= 5;
        }
    }
}
