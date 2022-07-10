using System;
using System.Collections.Generic;
using Dependecy_Injection_Example;
using Microsoft.Extensions.DependencyInjection;


#region Previous Implementation

/*
HeroThatOnlyUsesSwords hero1 = new("Ultralord");
hero1.Attack();
Console.WriteLine();

HeroThatCanUseAnyWeapon hero2 = new("Eregon", new Sword("Brisinger"));
hero2.Attack();
Console.WriteLine();

HeroThatCanUseAnyWeapon hero3 = new("The joker", new Grenade("The Pineapple"));
hero3.Attack();
Console.WriteLine();

HeroThatCanUseAnyWeapon hero4 =
   new("GI Joe", new Gun("Six Shooter",
       new List<Bullet>
       {
           new Bullet("Silver Slug", 10),
           new Bullet("Lead Ball", 20),
           new Bullet("Rusty Nail", 3),
           new Bullet("Hollow Point", 5)
       }
   ));

for (int i = 0; i < 5; i++)
{
   hero4.Attack();
}
*/
#endregion


ServiceCollection services = new ServiceCollection();

//services.AddTransient<IWeapon, Grenade>(grenade => new Grenade("Exploding Pen"));
//services.AddTransient<IWeapon, Sword>(s => new Sword("The Sword of Gryffindor"));
services.AddTransient<IWeapon, Gun>(g => new Gun("Six Shooter",
       new List<Bullet>
       {
           new Bullet("Silver Slug", 10),
           new Bullet("Lead Ball", 20),
           new Bullet("Rusty Nail", 3),
           new Bullet("Hollow Point", 5)
       }));

services.AddTransient<IHero, HeroThatCanUseAnyWeapon>(
    hero => new HeroThatCanUseAnyWeapon("Jonny Englinsh", hero.GetService<IWeapon>())
    );

ServiceProvider provider = services.BuildServiceProvider();

var hero5 = provider.GetService<IHero>();

hero5.Attack();
Console.WriteLine();
Console.ReadLine();

