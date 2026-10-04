
using System.Diagnostics;
using static Pattern.Builder;
using static Pattern.ProtoType;

namespace Pattern;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SINGLETON: BEFORE ===\n");

        var db = new DatabaseService();
        var ui = new UiService();

        Console.WriteLine();

        db.Config.Theme = "Dark";
        Console.WriteLine("Admin changed theme to Dark.");

        ui.Render();

        Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
        Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");


        Console.WriteLine("\n=== PROTOTYPE: BEFORE ===\n");
 var army = new List<Enemy>();
        Orc Orc = new Orc();
        var sw = Stopwatch.StartNew();
       
        for (int i = 1; i <= 5; i++)
        {
            var proOrc = (Orc)Orc.Clone();
            proOrc.Name = $"Orc-{i}";
            army.Add(proOrc);
        }
        Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");

        Enemy original = new Orc();
        original.Name = "Boss Orc";
        Enemy copy = original.Clone();

        Console.WriteLine($"\nOriginal model id: {original.ModelId}");
        Console.WriteLine($"Copy model id:     {copy.ModelId}");

        copy.Weapon.Damage = 999;
        Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
        Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");

        copy.Abilities.Add("Fire Breath");
        Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");

        Console.WriteLine("\n=== BUILDER: BEFORE ===\n");
        Console.WriteLine(RegistrationCallSites.CreateLiveStudentUgly());
        Console.WriteLine(RegistrationCallSites.CreateVideosOnlyUgly());
    }
}
