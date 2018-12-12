using System;
using System.Collections.Generic;

namespace Patterns
{
    class Visitor
    {
        static void _Main(string[] args)
        {            
            Neighborhood neighborhood = new Neighborhood(5);

            Console.WriteLine("На перший рік до району прийшов добрий Миколай...");

            IVisitor goodM = new GoodMykolai();
            neighborhood.Accept(goodM);

            Console.WriteLine("А наступного року уже прийшов справедливий Миколай...");

            IVisitor fairM = new FairMykolai();
            neighborhood.Accept(fairM);

            Console.ReadLine();
        }
    }

    class Neighborhood:IVisitable
    {
        public List<House> Houses { get; private set; }
        public Neighborhood(int housesCount)
        {
            Houses = new List<House>();
            Random r = new Random();
            for (int i=0;i<housesCount;i++)
            {                
                Houses.Add(new House(r.Next(0,5)));
            }
        }

        public void Accept(IVisitor visitor)
        {
            foreach(House h in Houses)
            {
                h.Accept(visitor);
            }
        }
    }

    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    interface IVisitor
    {        
        void VisitChild(Child child);
    }

    class GoodMykolai : IVisitor
    {
        public void VisitChild(Child child)
        {
            switch(child.Behaviour)
            {
                case "good":
                    Console.WriteLine("Добрий Миколай приніс слухняній дитині подарунок");
                    break;
                case "bad":
                    Console.WriteLine("Добрий Миколай приніс неслухняній дитині подарунок");
                    break;
            }
        }
    }

    class FairMykolai : IVisitor
    {
        public void VisitChild(Child child)
        {
            switch (child.Behaviour)
            {
                case "good":
                    Console.WriteLine("Справедливий Миколай приніс слухняній дитині подарунок");
                    break;
                case "bad":
                    Console.WriteLine("Справедливий Миколай приніс неслухняній дитині різочку");
                    break;
            }
        }
    }

    class House:IVisitable
    {
        public int ChildrenCount { get; private set; }
        public List<Child> Children { get; private set; }
        public House(int childrenCount)
        {
            if(childrenCount>0)
            {
                Children = new List<Child>();
                Random r = new Random();
                for (int i=0;i<childrenCount;i++)
                {                                        
                    if(r.Next(0,2)==0)
                    {
                        Children.Add(new Child("bad"));
                    }
                    else
                    {
                        Children.Add(new Child("good"));
                    }
                }
            }
        }

        public void Accept(IVisitor visitor)
        {
            if (Children!=null)
            {
                foreach (Child c in Children)
                {
                    c.Accept(visitor);
                }
            }
        }
    }

    class Child:IVisitable
    {
        public string Behaviour { get; private set; }
        public Child (string behaviour)
        {
            Behaviour = behaviour;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitChild(this);
        }
    }
}
