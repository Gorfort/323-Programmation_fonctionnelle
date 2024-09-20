using StarWarsApiCSharp;
using System;
using System.Linq;

namespace Swapi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Film> filmsRepository = new Repository<Film>();
            IRepository<Person> personsRepository = new Repository<Person>();
            IRepository<Planet> planetsRepository = new Repository<Planet>();
            IRepository<Starship> starshipRepository = new Repository<Starship>();


            var films = filmsRepository.GetEntities();
            var persons = personsRepository.GetEntities();
            var planets = planetsRepository.GetEntities();
            var starships = starshipRepository.GetEntities();

            Console.WriteLine("Star Wars Facts :");
            Console.WriteLine();
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Le film Star Wars dont le titre est le plus long
            var longestFilm = films
                .OrderByDescending(film => film.Title.Length)
                .FirstOrDefault();
            Console.WriteLine($"Le film Star Wars dont le titre est le plus long est {longestFilm.Title} !");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Le personnage qui est présent dans le plus de films
            var mostFrequentCharacter = persons
                .Select(person => new {Name = person.Name, FilmCount = films.Count(film => film.Characters.Contains(person.Url))})
                .OrderByDescending(pc => pc.FilmCount)
                .FirstOrDefault();
            Console.WriteLine($"Le personnage {mostFrequentCharacter.Name} apparaît dans le plus de films !");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///// La planète la plus peuplée ?
            var mostPopulatedPlanet = planets
                .OrderByDescending(planet => planet.Residents.Count)
                .FirstOrDefault();
            Console.WriteLine($"La planète la plus peuplée est {mostPopulatedPlanet.Name} !");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Combien de starfighter X-Wing est-ce que je peux m'acheter si je vends un Star Destroyer ?
            var xWingDestroyer = starships
                .Select(starship => starship.Name);
            Console.WriteLine($"La planète la plus peuplée est {xWingDestroyer} !");
            Console.ReadLine();

        }
    }
}

// TODO
////////////////////////////////////////////////////////////////////////////////////////////////////
// Est-ce qu'Obi-wan Kenobi peut piloter un Millennium Falcon ?
////////////////////////////////////////////////////////////////////////////////////////////////////
// Quelle est le vaisseau le plus rapide en vitesse lumière (vmax = vitesse atmosphérique max * ratio hyperespace) ?
////////////////////////////////////////////////////////////////////////////////////////////////////
// Combien de vaisseaux sont plus rapides que la moyenne de la vitesse atmosphérique de tous les vaisseaux ?
////////////////////////////////////////////////////////////////////////////////////////////////////
// Quel est le budget nécessaire (en franc suisse (1 crédit = 0.778 CHF)) à l’achat de la flotte totale ?
////////////////////////////////////////////////////////////////////////////////////////////////////
//Générer un CSV (vaisseau.txt) contenant les infos suivantes des vaisseaux :
// Nom du vaisseau
//    Prix
//    Longueur
//    Films dans lesquels ils apparaissent (nom des films en minuscule séparés par des tirets)
//    Nom des planètes survolées (nom des planètes en minuscule séparées par des tirets)

