using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator
    {        
        public Fruit CreateFruit(string fruit)
        {
            Fruit newFruit = new Fruit { Name = fruit };
            return newFruit;
        }
        public List<Fruit> AddToList(List<Fruit> fruits, string fruitName)
        {
            fruits.Add(CreateFruit(fruitName));
            return fruits;
        }

        public Fruit ExtractFromList(List<Fruit> fruits, string fruitName)
        {
            Fruit fruit = fruits.Find(f => f.Name == fruitName);
            try
            {
                fruits.Remove(fruit);
            }
            catch (Exception)
            {
                fruit = null;
            }
            return fruit;
            
        }

        public int CountList(List<Fruit> fruits)
        {
            return fruits.Count;
        }
        public List<Fruit> CreateList()
        {
            List<Fruit> Fruits = new List<Fruit>();
            Fruits.Add(CreateFruit("Apple"));
            Fruits.Add(CreateFruit("Banana"));
            Fruits.Add(CreateFruit("Strawberry"));
            return Fruits;
        }


    }
}