using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependecy_Injection_Example
{
    //Classes would normally be seperated into respective files, but this is all for example
    interface IWeapon
    {
        void AttackWithMe();
    }

    interface IHero
    {
        void Attack();
    }

    internal class Sword : IWeapon
    {
        public string SwordName { get; set; }
        public Sword(string swordName)
        {
            SwordName = swordName;
        }
        public Sword()
        {
            SwordName = "Sad sword";
        }

        public void AttackWithMe()
        {
            Console.WriteLine($"{SwordName} slices through the air, devatsting all enemies");
        }
    }

    public class HeroThatOnlyUsesSwords : IHero
    {
        public string Name { get; set; }
        public HeroThatOnlyUsesSwords(string name)
        {
            Name = name;
        }
        public HeroThatOnlyUsesSwords() { Name = "Generic Hero. No name given"; }

        public void Attack()
        {
            Sword sword = new Sword("Excalibur");
            Console.WriteLine($"{Name} prepares themselves for the battle");
            sword.AttackWithMe();
        }
    }

    internal class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name { get; set; }
        public IWeapon MyWeapon { get; set; }

        public HeroThatCanUseAnyWeapon(string name, IWeapon myWeapon)
        {
            Name = name;
            MyWeapon = myWeapon;
        }
        public HeroThatCanUseAnyWeapon()
        {
            Name = "Mr. Nobody. No name provided";
            MyWeapon = null;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} prepares to attack");
            MyWeapon.AttackWithMe();
        }
    }
    internal class Grenade : IWeapon
    {
        public string WeaponName { get; set; }
        public Grenade(string weaponName)
        {
            WeaponName = weaponName;
        }
        public Grenade()
        {
            WeaponName = "Pathetic grenade. No name provided";
        }

        public void AttackWithMe()
        {
            Console.WriteLine($"{WeaponName} sizzles for a moment and then explodes into a shower of deadly metal fragments");
        }
    }

    internal class Bullet
    {
        public string Name { get; set; }
        public int GramsOfPoweder { get; set; }

        public Bullet(string name, int gramsOfPoweder)
        {
            Name = name;
            GramsOfPoweder = gramsOfPoweder;
        }
    }

    internal class Gun : IWeapon
    {
        public string Name { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Gun(string name, List<Bullet> bullets)
        {
            Name = name;
            Bullets = bullets;
        }

        public void AttackWithMe()
        {
            if(Bullets.Count > 0)
            {
                Console.WriteLine($"{Name} fires the round called {Bullets[0].Name}. The victim now has a dealy hold in them");
                Bullets.RemoveAt(0);
                return;
            }
            Console.WriteLine($"{Name} has no bullets. Nothing happens");
        }
    }
}
