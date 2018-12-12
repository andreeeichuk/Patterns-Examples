using System;
using System.Collections.Generic;

namespace Patterns
{
    // Оскільки люблю стратегічні ігри, в тому числі Hearts of Iron 3,
    // то зробив як там було:
    // Мікроменеджмент структури армії!
    // Деревоподібна структура армії ідеально підходить під цей шаблон.
    // Можна ще б було додати функціонал, який рахує кількість особового складу і техніки.
    // Але тоді б я, як перфекціоніст, хотів би додати усі ланки.
    // Бо більшість людей і техніки б належала саме найнижчим ланкам.
    // А щоб приклад не був велетенським, обмежився рівнем дивізії.
    class Composite
    {
        static void _Main(string[] args)
        {            
            MilitaryUnit division1 = new Division(1, "стрілецька");
            MilitaryUnit division2 = new Division(2, "стрілецька", " ім. Богдана Хмельницького");
            MilitaryUnit division3 = new Division(3, "танкова");
            MilitaryUnit division4 = new Division(4, "моторизована");
            MilitaryUnit corps1 = new Corps(1, "стрілецький");
            MilitaryUnit corps2 = new Corps(2, "танковий");
            MilitaryUnit army1 = new Army(1,"танкова", "\"Північ\"");
            army1.Add(corps1);
            army1.Add(corps2);
            corps1.Add(division1);
            corps1.Add(division2);
            corps2.Add(division3);
            corps2.Add(division4);

            army1.GetTroops();
            Console.WriteLine();
            corps2.GetTroops();
            Console.WriteLine();
            division2.GetTroops();

            Console.ReadLine();
        }
    }

    // можна ще й парента тут додати, щоб швидко дізнатися керівництво...
    internal abstract class MilitaryUnit
    {
        protected int number;
        protected string type;
        protected string name;
        protected string specialName;

        private List<MilitaryUnit> Components { get; set; }

        public MilitaryUnit(int number,string type,string specialName="")
        {
            this.number = number;
            this.type = type;            
            this.specialName = specialName;
        }

        public virtual void Add(MilitaryUnit component)
        {
            if (Components == null)
                Components = new List<MilitaryUnit>();
            Components.Add(component);
        }

        public virtual void Remove(MilitaryUnit component)
        {
            if (Components == null||!Components.Contains(component))
                return;
            Components.Remove(component);
        }

        public virtual void GetTroops(int tabs=0)
        {
            if(Components!=null)
            {
                Console.WriteLine(GetName() + ", складається з:");
                tabs++;
                for(int i=0;i<Components.Count;i++)
                {
                    Console.Write(new string('\t', tabs));
                    Components[i].GetTroops(tabs);
                }
            }
            else
            {
                Console.WriteLine(GetName());
            }
        }

        public abstract string GetName();
    }

    class Army : MilitaryUnit
    {
        public Army(int number, string type, string specialName = null) : base(number, type, specialName)
        {
            name = "армія";
        }

        public override string GetName()
        {
            return $"{number}-а {type} {name}{specialName}";
        }
    }

    class Corps : MilitaryUnit
    {
        public Corps(int number, string type, string specialName = null) : base(number, type, specialName)
        {
            name = "корпус";
        }

        public override string GetName()
        {
            return $"{number}-ий {type} {name}{specialName}";
        }
    }

    class Division : MilitaryUnit
    {
        public Division(int number, string type, string specialName = null) : base(number, type, specialName)
        {
            name = "дивізія";
        }

        public override string GetName()
        {
            return $"{number}-а {type} {name}{specialName}";
        }
    }
}
