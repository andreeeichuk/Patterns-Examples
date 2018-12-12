using System;

namespace Patterns
{

    // можна було робити б і простий клас з віртуальним методом
    // який у Clone би повертав завжди по-дефолту MemberwiseClone
    // і можна було б його переробляти в дочірніх
    // але написати один рядочок краще, ніж потім не мати можливості ніякі інші класи успадковувати...
    interface IPrototype
    {
        IPrototype Clone();
    }

    class Stormtrooper : IPrototype
    {
        public string Color { get; set; }
        public MotherPlanet Planet { get; private set; }
        public Commander CurrentCommander { get; set; }


        public Stormtrooper(string color)
        {
            Color = color;
            Planet = new MotherPlanet("Earth", "Solar System");
            CurrentCommander = new Commander();
        }

        public IPrototype Clone()
        {
            Stormtrooper stormtrooper = (Stormtrooper) MemberwiseClone();
            // тут захотіли щоб командира можна було міняти окремо для кожного штурмовика
            // і тому робимо клас командира так, щоб він реалізовував прототип
            // а рідна планета залишатиметься одна для всіх
            // в даному випадку private set не дає нам зробити реткон =) і тупо поміняти історію створення штурмовиків
            // але можна було би придумати якийсь містичний зв'язок з усіма штурмовиками
            // і тоді він би мінявся у всіх разом, бо MemeberwiseClone залишає типи-посилання спільними для клонів
            Commander copiedCommander = (Commander)stormtrooper.CurrentCommander.Clone();
            stormtrooper.CurrentCommander = copiedCommander;
            return stormtrooper;
        }
    }

    class MotherPlanet
    {
        public string Name { get; set; }
        public string System { get; set; }

        public MotherPlanet(string name, string system)
        {
            Name = name;
            System = system;
        }
    }

    class Commander:IPrototype
    {
        public string Name { get; set; }

        public Commander()
        {
            Name = "Darth Vader";
        }

        // звісно прототип може містити не тільки один метод а й якісь спільні властисвості,
        // але тоді він уже буде не універсальний прототип для всіх класів, а якийсь специфічний
        public IPrototype Clone()
        {
            return (Commander)MemberwiseClone();
        }
    }

    class Client
    {
        static void _Main(string[] args)
        {
            Stormtrooper s1 = new Stormtrooper("white");
            Stormtrooper s2 = (Stormtrooper)s1.Clone();
            Console.WriteLine(s2.Color);
            s1.Color = "black";
            Console.WriteLine(s2.Color);
            s2.CurrentCommander.Name = "Han Solo";
            Console.WriteLine("Second stormtrooper's commander: " + s2.CurrentCommander.Name);
            Console.WriteLine("First stormtrooper's commander: " + s1.CurrentCommander.Name);

            Console.ReadLine();
        }
    }
}
