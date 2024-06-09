var heroes = new List<Hero>
{
    new("Clark", "Kent", "Superman", true),
    new("Bruce", "Wayne", "Batman", false),
    new("Diana", "Prince", "Wonder Woman", false),
    new("Peter", "Parker", "Spider-Man", false),
    new("Tony", "Stark", "Iron Man", true),
    new("Steve", "Rogers", "Captain America", false),
    new(string.Empty, string.Empty, "Thor", true),
    new("Barry", "Allen", "The Flash", false),
    new("Hal", "Jordan", "Green Lantern", true),
    new("Natasha", "Romanoff", "Black Widow", false)
};

// static List<Hero> FilterHeroesWhoCanFly(List<Hero> heroes)
// {
//     var heroesWhoCanFly = heroes.Where(hero => hero.CanFly).ToList();

//     return heroesWhoCanFly;
// }

// static List<Hero> FilterHeroesWhoLastNameIsUnknow(List<Hero> heroes)
// {
//     var heroesWhoCanFly = heroes.Where(hero => string.IsNullOrEmpty(hero.LastName)).ToList();

//     return heroesWhoCanFly;
// }


// reusable function
static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> f)
{
    foreach (var item in collection)
        if (f(item))
            yield return item;
}

foreach (var hero in Filter(heroes, hero => hero.CanFly))
    Console.WriteLine($"Hero name: {hero.HeroName} can fly!");

foreach (var hero in Filter(heroes, hero => string.IsNullOrEmpty(hero.LastName)))
    Console.WriteLine($"Hero name: {hero.HeroName} have no last name!");


// Data structs
public record Hero(string FirstName, string LastName, string HeroName, bool CanFly);
