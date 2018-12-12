using System;

namespace Patterns
{

    // вирішив навести приклад на основі травної системи людини
    // біологію вчив давно, тому наскільки правильно тут подано травлення, я не знаю
    // але ідея паттерна повинна залишатися зрозумілою
    class ChainOfResponsibility
    {
        static void _Main(string[] args)
        {
            Food meat = new Food("білок");
            Food cucumber = new Food("вода");// огірки складаються на 95% з води
            Food salo = new Food("жир");
            Food watermelonSeed = new Food("зернятко");//заїжджений приклад =)

            //будуємо травну систему у зворотньому порядку
            Handler thickIntestine = new ThickIntestine(null);
            Handler smallIntestine = new SmallIntestine(thickIntestine);
            Handler stomach = new Stomach(smallIntestine);
            Handler mouthEsofaghus = new MouthEsophagus(stomach);// страшне слово - то стравохід

            mouthEsofaghus.Handle(meat);
            mouthEsofaghus.Handle(cucumber);
            mouthEsofaghus.Handle(salo);
            mouthEsofaghus.Handle(watermelonSeed);

            Console.ReadLine();
        }        
    }

    abstract class Handler
    {
        public Handler Successor { get; private set; }
        public Handler(Handler successor)
        {
            Successor = successor;
        }

        public abstract void Handle(Food food); 
    }

    class MouthEsophagus : Handler
    {
        public MouthEsophagus(Handler successor) : base(successor)
        {
        }
        public override void Handle(Food food)
        {
            Successor.Handle(food);
        }
    }

    class Stomach : Handler
    {
        public Stomach(Handler successor) : base(successor)
        {

        }
        public override void Handle(Food food)
        {
            if(food.Substance=="білок")
            {
                Console.WriteLine("Перетравлено у шлунку.");
            }
            else if(Successor!=null)
            {
                Successor.Handle(food);
            }
        }
    }

    class SmallIntestine:Handler
    {
        public SmallIntestine(Handler successor) : base(successor)
        {

        }
        public override void Handle(Food food)
        {
            if (food.Substance == "жир")
            {
                Console.WriteLine("Перетравлено у тонкому кишківнику.");
            }
            else if(Successor!=null)
            {
                Successor.Handle(food);
            }
        }
    }

    class ThickIntestine:Handler
    {
        public ThickIntestine(Handler successor) : base(successor)
        {

        }
        public override void Handle(Food food)
        {
            if (food.Substance == "вода")
            {
                Console.WriteLine("Перетравлено у товстому кишківнику.");
            }
            else
            {
                Console.WriteLine("Не перетравлено. Вийде з організму відомо як.");
            }
        }

    }

    class Food
    {
        public string Substance { get; private set; }
        public Food(string substance)
        {
            Substance = substance;
        }
    }
}
