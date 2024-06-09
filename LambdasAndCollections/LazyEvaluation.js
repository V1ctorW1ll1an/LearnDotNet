// Data struct
class Hero {
  constructor(firstName, lastName, heroName, canFly) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.heroName = heroName;
    this.canFly = canFly;
  }
}

// List of heroes
const heroes = [
  new Hero("Clark", "Kent", "Superman", true),
  new Hero("Bruce", "Wayne", "Batman", false),
  new Hero("Diana", "Prince", "Wonder Woman", false),
  new Hero("Peter", "Parker", "Spider-Man", false),
  new Hero("Tony", "Stark", "Iron Man", true),
  new Hero("Steve", "Rogers", "Captain America", false),
  new Hero("", "", "Thor", true),
  new Hero("Barry", "Allen", "The Flash", false),
  new Hero("Hal", "Jordan", "Green Lantern", true),
  new Hero("Natasha", "Romanoff", "Black Widow", false),
];

function* filter(collection, predicate) {
  for (const item of collection) if (predicate(item)) yield item;
}

// Filter heroes who can fly
const heroesWhoCanFly = filter(heroes, (hero) => hero.canFly);
for (const hero of heroesWhoCanFly) {
  console.log(`Hero name: ${hero.heroName} can fly!`);
}

// Filter heroes who have no last name
const heroesWithNoLastName = filter(heroes, (hero) => !hero.lastName);
for (const hero of heroesWithNoLastName) {
  console.log(`Hero name: ${hero.heroName} have no last name!`);
}
