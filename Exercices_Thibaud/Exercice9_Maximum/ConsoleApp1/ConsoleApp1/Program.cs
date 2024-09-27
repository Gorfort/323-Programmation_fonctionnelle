namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 players
            List<Player> players = new List<Player>()
            {
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25)
            };

            players.Add(new Player("Boba", 30));

            Console.WriteLine($"Total number of players: {players.Count}");

            // Call the FindOlder method to find the oldest player
            Player elder = FindOlder(players);

            // Print the oldest player's name and age
            Console.WriteLine($"The oldest player is {elder.Name}, who is {elder.Age} years old.");

            Console.ReadKey();
        }

        // Method to find the oldest player in a list
        static Player FindOlder(IEnumerable<Player> players)
        {
            // Start by assuming the first player is the oldest
            Player elder = players.First();

            // Loop through the players to find the oldest
            for (int i = 1; i < players.Count(); i++)  // Start from 1 since we already assigned the first player
            {
                Player p = players.ElementAt(i);
                if (p.Age > elder.Age)
                {
                    elder = p;  // No need to create a new Player object, just assign the existing one
                }
            }

            return elder;  // Return the oldest player
        }

        // Immutable Player class
        public class Player
        {
            private readonly string _name;  // Read-only fields to ensure immutability
            private readonly int _age;

            public Player(string name, int age)
            {
                _name = name;
                _age = age;
            }

            // Public read-only properties
            public string Name => _name;
            public int Age => _age;
        }
    }
}
