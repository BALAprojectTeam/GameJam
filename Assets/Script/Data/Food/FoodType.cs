using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FoodType
{
    None = 3,
    Meat = 1,
    Vegestables = 2,
}

public enum MeatType
{
    Pork = 1,
    Chichken = 2,
    Beef = 4,
    AllMeat = 1 | 2 | 4
}

public enum NonMeatType
{
    AnimalProtein = 8,
    Vegestable = 16,
    AllNoneMeat = 8 | 16
}
public enum VisionType
{
    None = 0,
    Onion = 32,
    GreenOnion = 64,
    Garlic = 128
}
public enum TasteType
{
    None = 0,
    Sugar = 256,
    Salt = 512,
    Vinegar = 1024
}

public enum ExtraComponent
{
    None = 0,
    Tomato = 1,
    Mushroom = 2,
    Cucumber = 4,
    Grain = 8
}