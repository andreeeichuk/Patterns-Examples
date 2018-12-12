using System;
using System.Text;

namespace Patterns
{
    class Builder
    {
        static void _Main(string[] args)
        {
            Weaponsmith gunRunner = new Weaponsmith();

            Gun pistol = gunRunner.Create(new PistolBuilder());
            Console.WriteLine(pistol.ToString());

            Gun combatRifle = gunRunner.Create(new CombatRifleBuilder());
            Console.WriteLine(combatRifle.ToString());

            Gun sniperRifle = gunRunner.Create(new SniperRifleBuilder());
            Console.WriteLine(sniperRifle.ToString());

            Console.ReadLine();
        }
    }

    // оце Director
    class Weaponsmith
    {
        public Gun Create(GunBuilder gunBuilder)
        {
            gunBuilder.CreateGun();

            gunBuilder.SetBarrel();
            gunBuilder.SetGrip();
            gunBuilder.SetMuzzle();
            gunBuilder.SetMagazine();
            gunBuilder.SetReceiver();
            gunBuilder.SetSight();

            Console.WriteLine("New gun assembled.");

            return gunBuilder.Gun;
        }
    }

    abstract class GunBuilder
    {
        public Gun Gun { get; private set; }
        public void CreateGun()
        {
            Gun = new Gun();
        }

        public abstract void SetBarrel();
        public abstract void SetMuzzle();
        public abstract void SetMagazine();
        public abstract void SetReceiver();
        public abstract void SetSight();
        public abstract void SetGrip();
    }

    class PistolBuilder : GunBuilder
    {
        public override void SetBarrel()
        {
            Gun.Barrel = "Short";
        }

        public override void SetGrip()
        {
            Gun.Grip = "Standard";
        }

        public override void SetMagazine()
        {
            Gun.Magazine = "Small";
        }

        // насправді можна було залишити метод пустим, але тоді би треба було перевіряти
        // на null
        public override void SetMuzzle()
        {
            Gun.Muzzle = "No";
        }

        public override void SetReceiver()
        {
            Gun.Receiver = "Light Frame";
        }

        public override void SetSight()
        {
            Gun.Sight = "Iron";
        }
    }

    class SniperRifleBuilder : GunBuilder
    {
        public override void SetBarrel()
        {
            Gun.Barrel = "Long";
        }

        public override void SetGrip()
        {
            Gun.Grip = "Marksman's stock";
        }

        public override void SetMagazine()
        {
            Gun.Magazine = "Medium";
        }

        public override void SetMuzzle()
        {
            Gun.Muzzle = "Suppresor";
        }

        public override void SetReceiver()
        {
            Gun.Receiver = ".50";
        }

        public override void SetSight()
        {
            Gun.Sight = "Long Scope";
        }
    }

    class CombatRifleBuilder : GunBuilder
    {
        public override void SetBarrel()
        {
            Gun.Barrel = "Medium";
        }

        public override void SetGrip()
        {
            Gun.Grip = "Full Stock";
        }

        public override void SetMagazine()
        {
            Gun.Magazine = "Quick Eject";
        }

        public override void SetMuzzle()
        {
            Gun.Muzzle = "Compensator";
        }

        public override void SetReceiver()
        {
            Gun.Receiver = "Rapid Automatic";
        }

        public override void SetSight()
        {
            Gun.Sight = "Reflex";
        }
    }

    class Gun
    {
        // можна ще було і назву додати, щоб було ясніше, але то таке...
        // система на подобу модифікації вогнепалу у Fallout 4
        public string Barrel { get; set; }
        public string Muzzle { get; set; }
        public string Magazine { get; set; }
        public string Receiver { get; set; }
        public string Sight { get; set; }
        public string Grip { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Gun characteristics:\n");
            sb.Append("Barrel: " + Barrel + "\n");
            sb.Append("Muzzle: " + Muzzle + "\n");
            sb.Append("Magazne: " + Magazine + "\n");
            sb.Append("Receiver: " + Receiver + "\n");
            sb.Append("Sight: " + Sight + "\n");
            sb.Append("Grip: " + Grip + "\n");
            return sb.ToString();
        }
        

    }


}
