using System;

namespace Patterns
{
    class State
    {
        static void _Main(string[] args)
        {
            Human boy = new Human(new ChildState());

            // пишемо коротеньку біографію якоїсь людини

            boy.GetJob();
            boy.BecomeOlder();
            boy.GetJob();
            boy.GetJob();
            boy.QuitJob();
            boy.GetJob();
            boy.BecomeOlder();
            boy.QuitJob();
            boy.BecomeOlder();
            boy.BecomeOlder();
            
            Console.ReadLine();
        }
    }

    class Human
    {
        public IHumanState state { get; set; }

        public Human(IHumanState personState)
        {
            state = personState;
        }

        public void BecomeOlder()
        {
            state.BecomeOlder(this);
        }

        public void GetJob()
        {
            state.GetJob(this);
        }

        public void QuitJob()
        {
            state.QuitJob(this);
        }
    }

    interface IHumanState
    {
        void BecomeOlder(Human human);
        void GetJob(Human human);
        void QuitJob(Human human);
    }

    class ChildState : IHumanState
    {
        public void BecomeOlder(Human human)
        {
            human.state = new UnemployedState();
            Console.WriteLine("Дитина виросла і стала безробітною.");
        }

        public void GetJob(Human human)
        {
            Console.WriteLine("Дитині за місцевими законами заборонено працювати!");
        }        
        public void QuitJob(Human human)
        {
            Console.WriteLine("Неможливо звільнитися не маючи роботи!");
        }
    }

    class UnemployedState : IHumanState
    {
        public void BecomeOlder(Human human)
        {
            human.state = new RetiredState();
            Console.WriteLine("Доросла людина постаріла і стала пенсіонером.");
        }

        public void GetJob(Human human)
        {
            human.state = new EmployedState();
            Console.WriteLine("Людина влаштувалася на роботу.");
        }

        public void QuitJob(Human human)
        {
            Console.WriteLine("Неможливо звільнитися не маючи роботи!");
        }
    }

    class EmployedState : IHumanState
    {
        public void BecomeOlder(Human human)
        {
            human.state = new RetiredState();
            Console.WriteLine("Доросла людина постаріла і стала пенсіонером.");
        }

        public void GetJob(Human human)
        {
            Console.WriteLine("Людина миттєво перейшла з однієї роботи на іншу.");
        }

        public void QuitJob(Human human)
        {
            human.state = new UnemployedState();
            Console.WriteLine("Людина покинула роботу і стала безробітною.");
        }
    }

    class RetiredState : IHumanState
    {
        public void BecomeOlder(Human human)
        {
            human.state = new DeadState();
            Console.WriteLine("Людина померла зі старості.");
        }

        public void GetJob(Human human)
        {
            Console.WriteLine("Пенсіонери не працюють!");
        }

        public void QuitJob(Human human)
        {
            Console.WriteLine("Неможливо звільнитися не маючи роботи!");
        }
    }

    class DeadState : IHumanState
    {
        public void BecomeOlder(Human human)
        {
            Console.WriteLine("Труп розкладається... =)");
        }

        public void GetJob(Human human)
        {
            Console.WriteLine("Мертві люди уже не здатні нічого зробити.");
        }

        public void QuitJob(Human human)
        {
            Console.WriteLine("Неможливо звільнитися не маючи роботи!");
        }
    }

}
