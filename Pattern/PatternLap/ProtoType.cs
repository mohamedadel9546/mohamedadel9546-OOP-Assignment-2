using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using static Pattern.ProtoType;

namespace Pattern;


public class ProtoType
{
    public interface IProtoType<T>
    {
        T Clone();
    }

    public class Weapon: IProtoType<Weapon>
    {
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon Clone()
        {
            return new Weapon(this.Name,this.Damage);
        }
    }

    public abstract class Enemy : IProtoType<Enemy>
    {
        private string _modelData;

        public string Name { get; set; }
        public int Health { get; set; }
        public Weapon Weapon { get; set; }
        public List<string> Abilities { get; set; } = new();
        public string ModelId => _modelData;

        protected Enemy()
        {
            Console.WriteLine("   ...loading 3D model (slow)...");

            _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
        }
        public abstract Enemy Clone();
       
    }

    public class Orc : Enemy
    {
        public Orc()
        {
            Name = "Orc";
            Health = 100;
            Weapon = new Weapon ( "Axe", 25);
            Abilities.Add("Rage");
        }
        private Orc(Orc or)
        {
            this.Name = or.Name;
            this.Health = or.Health;
            this.Weapon = or.Weapon.Clone();
            this.Abilities = new List<string>(or.Abilities);
        }
        public override Enemy Clone()
        {
            return new Orc(this);
        }
    }
    public class Elf : Enemy
    {
        public Elf()
        {
            Name = "Elf";
            Health = 70;
            Weapon = new Weapon ("Bow", 18 );
            Abilities.Add("Stealth");
        }
        private Elf(Elf or)
        {
            this.Name = or.Name;
            this.Health = or.Health;
            this.Weapon = or.Weapon.Clone();
            this.Abilities = new List<string>(or.Abilities);
        }
        public override Enemy Clone()
        {
            return new Elf(this);
        }
    }
}