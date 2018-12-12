using System;

namespace Patterns
{
    /*
     * З цим паттерном у мене відбулась миттєва асоціація одразу після першого ознайомлення.
     * Він дуже сильно нагадує процес одягання взимку - "вкутання як капуста".
     * От ніби буде собі самостійно клас "Спідня білизна", як мінімум, в якому можна ходити (вдома).
     * А поверх неї можна надягати різний одяг. Неодноразово. "Декоруватися".
     * І чим більше одягу надягнув, тим більший мороз можеш терпіти.
     * Допустимо буде константа 25 градусів, при якій можна в спідньому ходити.
     * А далі кожен елемент буде віднімати від цього трішки.
     * Звісно, в мене приклад недосконалий, бо далі в перспективі можна буде надягнути
     * светр на куртку і т.д.
     * Але загальна ідея зрозуміла.
     * 
     * А светр може бути на кілька розмірів більший, що якраз поверх куртки...
     */
    class Decorator
    {
        static void _Main(string[] args)
        {
            // назва трохи погана, бо вона відображає лиш намір спочатку
            // а стан тільки у кінці
            // але най буде так
            Clothes autumnSet = new Underwear();
            autumnSet = new Shirt(autumnSet);
            autumnSet = new Coat(autumnSet);
            GetResult(autumnSet);

            Clothes springSet = new Underwear();
            springSet = new Shirt(springSet);
            springSet = new Cloak(springSet);
            GetResult(springSet);

            Clothes coldSummerSet = new Underwear();
            coldSummerSet = new Shirt(coldSummerSet);
            coldSummerSet = new Sweater(coldSummerSet);
            GetResult(coldSummerSet);

            Clothes winterSet = new Underwear();
            winterSet = new Sweater(winterSet);
            winterSet = new Sweater(winterSet);
            winterSet = new FurCoat(winterSet);
            GetResult(winterSet);

            Console.ReadLine();
        }

        static void GetResult(Clothes set)
        {
            Console.WriteLine($"{set.Description} \nДопустима температура: {set.GetTemparature()}\n");
        }
    }

    abstract class Clothes
    {
        public string Description { get; set; }
        public Clothes(string s)
        {
            Description = s;
        }
        public abstract int GetTemparature();
    }

    class Underwear : Clothes
    {
        public Underwear() : base("Спідня білизна")
        {
        }

        public override int GetTemparature()
        {
            return 25;
        }
    }

    // декоратор власною персоною
    abstract class AdditionalClothes : Clothes
    {
        // посилання на попередній шар
        protected Clothes clothes; 
        public AdditionalClothes(string s, Clothes clothes) : base(s)
        {
            this.clothes = clothes;
        }
    }

    class Shirt : AdditionalClothes
    {
        public Shirt(Clothes clothes) : base(clothes.Description + " + сорочка", clothes)
        {
        }

        public override int GetTemparature()
        {
            return clothes.GetTemparature() - 4;
        }
    }

    class Sweater : AdditionalClothes
    {
        public Sweater(Clothes clothes) : base(clothes.Description + " + светр", clothes)
        {
        }

        public override int GetTemparature()
        {
            return clothes.GetTemparature() - 7;
        }
    }

    class Coat : AdditionalClothes
    {
        public Coat(Clothes clothes) : base(clothes.Description + " + пальто", clothes)
        {
        }

        public override int GetTemparature()
        {
            return clothes.GetTemparature() - 13;
        }
    }

    class Cloak : AdditionalClothes
    {
        public Cloak(Clothes clothes) : base(clothes.Description + " + плащ", clothes)
        {
        }

        public override int GetTemparature()
        {
            return clothes.GetTemparature() - 10;
        }
    }

    class FurCoat : AdditionalClothes
    {
        public FurCoat(Clothes clothes) : base(clothes.Description + " + шуба", clothes)
        {
        }

        public override int GetTemparature()
        {
            return clothes.GetTemparature() - 18;
        }
    }
}
