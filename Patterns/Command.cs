using System;
using System.Collections.Generic;

namespace Patterns
{
    // тут креатив скінчився
    // бо для того, щоб щось цікаве продемонструвати, треба писати багато коду
    // а в маленькому масштабі цей паттерн (як і всі інші =)) непотрібні

    class Command
    {
        static void _Main(string[] args)
        {           
            // оце най буде receiver
            int chyslo = 10;
            Console.WriteLine("Число на старті: " + chyslo);
            Invoker inv = new Invoker(ref chyslo);
            inv.Execute(new AddFive());
            inv.Execute(new SubtractTwo());
            inv.Cancel();
            inv.Cancel();

            Console.ReadLine();
        }        
    }    

    interface ICommand
    {
        void Do(ref int x);
        void Undo(ref int x);
    }

    class AddFive : ICommand
    {
        public void Do(ref int x)
        {
            x += 5;
        }

        public void Undo(ref int x)
        {
            x -= 5;
        }
    }

    class Invoker
    {
        Stack<ICommand> commands = new Stack<ICommand>();
        int variable;
        public Invoker(ref int x)
        {
            variable = x;
        }
        public void Execute(ICommand com)
        {
            commands.Push(com);
            com.Do(ref variable);
            Console.WriteLine(variable);
        }
        public void Cancel()
        {
            if(commands.Count>0)
                commands.Pop().Undo(ref variable);
            Console.WriteLine(variable);
        }
    }

    class SubtractTwo : ICommand
    {
        public void Do(ref int x)
        {
            x -= 2;
        }

        public void Undo(ref int x)
        {
            x += 2;
        }
    }
}
