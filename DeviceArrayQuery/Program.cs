public class Device
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Cost { get; set; }

    public Device(string name, string manufacturer, decimal cost)
    {
        Name = name;
        Manufacturer = manufacturer;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Manufacturer: {Manufacturer}, Cost: {Cost:C}";
    }
}

class Program
{
    static void Main()
    {
        var devices1 = new[]
        {
            new Device("Device1", "ManufacturerA", 500),
            new Device("Device2", "ManufacturerB", 300),
            new Device("Device3", "ManufacturerC", 450)
        };

        var devices2 = new[]
        {
            new Device("Device4", "ManufacturerA", 600),
            new Device("Device5", "ManufacturerD", 700),
            new Device("Device6", "ManufacturerC", 400)
        };

        var difference = devices1
            .Where(d1 => !devices2.Any(d2 => d2.Manufacturer == d1.Manufacturer))
            .ToArray();
        Console.WriteLine("Difference (devices in first array not in second):");
        foreach (var device in difference)
        {
            Console.WriteLine(device);
        }

        var intersection = devices1
            .Where(d1 => devices2.Any(d2 => d2.Manufacturer == d1.Manufacturer))
            .ToArray();
        Console.WriteLine("\nIntersection (common devices in both arrays):");
        foreach (var device in intersection)
        {
            Console.WriteLine(device);
        }

        var union = devices1
            .Union(devices2)
            .GroupBy(d => d.Manufacturer)
            .Select(g => g.First())
            .ToArray();
        Console.WriteLine("\nUnion (devices of both arrays without duplicates by manufacturer):");
        foreach (var device in union)
        {
            Console.WriteLine(device);
        }
    }
}
