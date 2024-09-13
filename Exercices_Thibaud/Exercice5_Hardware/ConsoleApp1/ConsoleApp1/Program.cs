using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {

        public class ComputerHardware
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public double Price { get; set; }
            public double ClockSpeed { get; set; }
            public int Cores { get; set; }
            public string Brand { get; set; }
        }

        static void Main(string[] args)
        {
            List<ComputerHardware> computerHardware = new List<ComputerHardware>() {
                new ComputerHardware() { Name = "Intel Core i7-9700K", Type = "CPU", Price = 400, ClockSpeed = 3.6, Cores = 3, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 9 5950X", Type = "CPU", Price = 700, ClockSpeed = 3.4, Cores = 16, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080", Type = "GPU", Price = 700, ClockSpeed = 1.7, Cores = 8704, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6800 XT", Type = "GPU", Price = 650, ClockSpeed = 2.0, Cores = 72, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i5-10400", Type = "CPU", Price = 200, ClockSpeed = 2.9, Cores = 6, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 5 5600X", Type = "CPU", Price = 300, ClockSpeed = 3.7, Cores = 6, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3060 Ti", Type = "GPU", Price = 400, ClockSpeed = 1.6, Cores = 4864, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6700 XT", Type = "GPU", Price = 400, ClockSpeed = 2.4, Cores = 40, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i9-11900K", Type = "CPU", Price = 500, ClockSpeed = 3.2, Cores = 10, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 7 5800X", Type = "CPU", Price = 350, ClockSpeed = 3.9, Cores = 8, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3090", Type = "GPU", Price = 1500, ClockSpeed = 1.4, Cores = 10496, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6900 XT", Type = "GPU", Price = 1000, ClockSpeed = 2.0, Cores = 80, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i3-10100", Type = "CPU", Price = 150, ClockSpeed = 3.6, Cores = 4, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 3 5600X", Type = "CPU", Price = 250, ClockSpeed = 3.6, Cores = 6, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3070", Type = "GPU", Price = 500, ClockSpeed = 1.5, Cores = 5888, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6700", Type = "GPU", Price = 350, ClockSpeed = 2.3, Cores = 36, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i9-9900K", Type = "CPU", Price = 450, ClockSpeed = 3.2, Cores = 8, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 7 3700X", Type = "CPU", Price = 300, ClockSpeed = 3.6, Cores = 8, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080 Ti", Type = "GPU", Price = 1200, ClockSpeed = 1.6, Cores = 5888, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6800", Type = "GPU", Price = 600, ClockSpeed = 1.8, Cores = 64, Brand = "AMD" }
            };
            var filter = computerHardware.Where(x => x.ClockSpeed < 100 && x.Cores < 100).Where(y => (y.Brand.Contains("AMD"))).Where(z => !(z.Brand.Contains("CPU"))).Where(a => !(a.Price < 500));
            foreach (var computerResult in filter)
            {
                Console.WriteLine(computerResult.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Les GPUs qui ont au moins 32 coeurs :");
            var gpu = computerHardware.Where(b => b.Type.Contains("GPU") && b.Cores > 32);
            foreach (var computerResult in gpu)
            {
                Console.WriteLine($"GPUs :{computerResult.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Les CPUs avec au moins 8 coeurs :");
            var cpu = computerHardware.Where(c => c.Type.Contains("CPU") && c.Cores < 8);
            foreach (var computerResult in cpu)
            {
                Console.WriteLine($"CPUs :{computerResult.Name}");
            }
            Console.Read();
        }
    }
}

// Les configs AMD DONE
// Les pièces n'étaint pas des "CPU" DONE
// Les pièces qui dépassent un prix de 500 DONE
// Les CPUs qui ont une horloge < 3ghz et moins que 4 coeurs. DONE
// Les GPUs qui ont au moins 32 coeurs et les CPUs avec au moins 8 coeurs. DONE
