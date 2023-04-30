using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FoodType
{
    Meat = 1,
    HalfMeat = 2,
    Vegestables = 4,
}

public enum MeatType
{
    Pork = 8,
    Chichken = 16,
    Beef = 32,
    All = 8 | 16 | 32
}

public enum NonMeatType
{
    AnimalProtein = 64,
    Vegestable = 128,
    All = 64 | 128
}
public enum VisionType
{
    None = 0,
    Onion = 256,
    Ginger = 512,
    Garlic = 1024
}
public enum TasteType
{
    None = 0,
    Sugar = 2048,
    Salt = 4096,
    Vinegar = 8192
}

public enum ExtraComponent
{
    None = 0,
    Tomato = 1,
    Mushroom = 2,
    Cucumber = 4,
    Grain = 8
}