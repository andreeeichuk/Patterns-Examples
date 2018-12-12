using System;

namespace Patterns
{
    class Strategy
    {
        static void _Main(string[] args)
        {
            Character khajiit = new Character("Khajiit takes the quest.");
            khajiit.ChooseStrategy(new ThiefStrategy());
            khajiit.CompleteQuest();
            Character nord = new Character("Now the nord takes the quest.");
            nord.ChooseStrategy(new WarriorStrategy());
            nord.CompleteQuest();
            Character imperial = new Character("Finally, the imperial takes the quest.");
            imperial.ChooseStrategy(new DiplomatStrategy());
            imperial.CompleteQuest();

            Console.ReadLine();
        }
    }

    interface IStrategy
    {
        string HandleQuest();
    }

    class ThiefStrategy : IStrategy
    {
        public string HandleQuest()
        {
            return "He steals the key and enters the House.";
        }
    }

    class WarriorStrategy : IStrategy
    {
        public string HandleQuest()
        {
            return "He kills the guards and enters the House.";
        }
    }

    class DiplomatStrategy : IStrategy
    {
        public string HandleQuest()
        {
            return "He pretends being a valuable guest and enters the House.";
        }
    }

    class Character
    {
        IStrategy strategy;

        public Character(string createMsg)
        {
            Console.WriteLine(createMsg);
        }

        public void ChooseStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void CompleteQuest()
        {
            Console.WriteLine(strategy.HandleQuest());
        }
    }
}
