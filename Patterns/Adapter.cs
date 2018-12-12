using System;

namespace Patterns
{

    // придумав для цього патерну казочку про богатиря і драконів
    // приклад цікавий, але архітектура жахлива, підігнана під приклад
    class Adapter
    {
        static void _Main(string[] args)
        {
            IBeast dragon = new SimpleDragon();
            Bogatyr illiaMuromets = new Bogatyr();

            illiaMuromets.KillBeast(dragon);
            if(!dragon.HeadIsPresent)
            {
                Console.WriteLine("Перший дракон обезголовлений і мертвий.");
            }

            // на місце мертворо дракона приходить новий
            // і цього разу в нього не одна, а 3 голови
            MultiheadedDragon resurrectedDragon = new MultiheadedDragon(3);

            // illiaMuromets.KillBeast(resurrectedDragon); - не вийшло зразу подолати нового дракона(

            // але прийшов адаптер і напоумив богатиря
            NewBeastAsOld dragonIsTheSame = new NewBeastAsOld(resurrectedDragon);
            illiaMuromets.KillBeast(dragonIsTheSame);

            if (!dragonIsTheSame.HeadIsPresent)
            {
                Console.WriteLine("Другий дракон обезголовлений і мертвий.");
            }

            Console.ReadLine();
        }
    }

    class Bogatyr
    {
        public void KillBeast(IBeast beast)
        {
            beast.LooseHead();
        }
    }

    interface IBeast
    {
        bool HeadIsPresent { get; set; }
        void LooseHead();
    }

    interface INewBeast
    {
        bool HeadsArePresent { get; set; }
        void LooseHeads();
    }

    class NewBeastAsOld:IBeast
    {
        MultiheadedDragon multiheadedDragon;

        public bool HeadIsPresent
        {
            get
            {
                for (int i = 0; i < multiheadedDragon.Heads.Length; i++)
                {
                    if (multiheadedDragon.Heads[i] == true)
                        return true;
                }
                return false;
            }
            set
            {
                for (int i = 0; i < multiheadedDragon.Heads.Length; i++)
                {
                    multiheadedDragon.Heads[i] = value;
                }
            }
        }

        public NewBeastAsOld(MultiheadedDragon m)
        {
            multiheadedDragon = m;
        }
        public void LooseHead()
        {
            multiheadedDragon.LooseHeads();
        }
    }


    class SimpleDragon:IBeast
    {
        public bool HeadIsPresent { get; set; }
        public SimpleDragon()
        {
            HeadIsPresent = true;
        }
        public void LooseHead()
        {
            HeadIsPresent = false;
        }
    }

    class MultiheadedDragon : INewBeast
    {
        public bool HeadsArePresent
        {
            get
            {
                for (int i = 0; i < Heads.Length; i++)
                {
                    if (Heads[i] == true)
                        return true;                    
                }
                return false;
            }
            set
            {
                for (int i = 0; i < Heads.Length; i++)
                {
                    Heads[i] = value;
                }
            }
            
        }
        public bool[] Heads { get; private set; }
        public MultiheadedDragon(int headCount)
        {
            Heads = new bool[headCount];
            HeadsArePresent = true;
        }
        public void LooseHeads()
        {
            HeadsArePresent = false;
        }
    }
}
