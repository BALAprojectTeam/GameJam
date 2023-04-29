using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoodComponent
{
}
public class AnimalFood : IFoodComponent
{
}
public class Meat : AnimalFood
{

}
public class Vegetable : IFoodComponent
{

}
public class Pork : Meat
{
}