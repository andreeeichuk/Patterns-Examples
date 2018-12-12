using System;

namespace Patterns
{
    class FactoryMethod
    {
       static void _Main(string[] args)
       {
            //тут ми створюємо об'єкти не конкретного типу, а типу інтерфесів
            IBackery backery = new BreadBackery();
            BackeryProduct product = backery.CreateBackery("Орільський");// топовий хліб франкіської залізничної пекарні

            ShowResult(product);

            backery = new PunBackery();
            product = backery.CreateBackery("з маком");

            ShowResult(product);

            backery = new BaguetteBackery();
            product = backery.CreateBackery("французький");

            ShowResult(product);

            Console.ReadLine();
        }

        static void ShowResult(BackeryProduct product)
        {
            Console.WriteLine("Пекарня спекла {0} {1} вагою {2} грамів.", product.Type , product.Name , product.Size);
        }

        interface IBackery
        {
            // ось це ФАБРИЧНИЙ МЕТОД власною персоною
            BackeryProduct CreateBackery(string name);
        }

        class BreadBackery : IBackery
        {
            // ця пекарня і наступні печуть за стандартами ваги, тому вага "захардкоджена"
            // а от назви продуктів придумують маркетологи чи піарники =)
            public BackeryProduct CreateBackery(string name)
            {
                return new Bread(name, 800);
            }
        }

        class PunBackery : IBackery
        {
            public BackeryProduct CreateBackery(string name)
            {
                return new Pun(name, 300);
            }
        }

        class BaguetteBackery : IBackery
        {
            public BackeryProduct CreateBackery(string name)
            {
                return new Baguette(name, 600);
            }
        }

        abstract class BackeryProduct
        {
            public string Name { get; set; }
            public int Size { get; private set; }
            public string Type { get;private set; }

            public BackeryProduct(string name, int size, string type)
            {
                Name = name;
                Size = size;
                Type = type;
            }
        }

        class Bread : BackeryProduct
        {
            public Bread(string name, int size) : base(name, size,"хліб")
            {                
            }
        }

        class Pun : BackeryProduct
        {
            public Pun(string name, int size) : base(name, size, "булочку")
            {                
            }
        }

        class Baguette : BackeryProduct
        {
            public Baguette(string name, int size) : base(name, size, "багет")
            {               
            }
        }

        
    }
}
