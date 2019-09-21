using System;
using System.Collections.Generic;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.6) Animal Shelter:
    /// An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first out" basis.
    /// People must adopt either the "oldest" (based on arrival time) of all animals at the shelter, 
    /// or they can select whether they would prefer a dog or a cat (and will receive the oldest animal of that type).
    /// They cannot select which specific animal they would like.
    /// Create the data structures to maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog, and dequeueCat.
    /// You may use the built-in LinkedList data structure.
    /// </summary>
    public class Question_3_6
    {
        public abstract class Animal
        {
            public int Id { get; protected set; }
        }

        public class Dog : Animal
        {
            public Dog(int id)
            {
                Id = id;
            }
        }

        public class Cat : Animal
        {
            public Cat(int id)
            {
                Id = id;
            }
        }

        public class AnimalShelter
        {
            private readonly LinkedList<Animal> _shelterList = new LinkedList<Animal>();

            public void Enqueue(Animal animal)
            {
                _shelterList.AddLast(animal);
            }

            public Animal DequeueAny()
            {
                if (_shelterList.Count == 0)
                {
                    throw new InvalidOperationException("No animals in the shelter.");
                }
                LinkedListNode<Animal> oldestAnimal = _shelterList.First;
                _shelterList.RemoveFirst();
                return oldestAnimal.Value;
            }

            public Dog DequeueDog()
            {
                if (_shelterList.Count == 0)
                {
                    throw new InvalidOperationException("No animals in the shelter.");
                }
                LinkedListNode<Animal> temp = _shelterList.First;
                while (temp != null)
                {
                    if (temp.Value is Dog)
                    {
                        _shelterList.Remove(temp);
                        return temp.Value as Dog;
                    }
                    temp = temp.Next;
                }
                throw new InvalidOperationException("No dogs in the shelter.");
            }

            public Cat DequeueCat()
            {
                if (_shelterList.Count == 0)
                {
                    throw new InvalidOperationException("No animals in the shelter.");
                }
                LinkedListNode<Animal> temp = _shelterList.First;
                while (temp != null)
                {
                    if (temp.Value is Cat)
                    {
                        _shelterList.Remove(temp);
                        return temp.Value as Cat;
                    }
                    temp = temp.Next;
                }
                throw new InvalidOperationException("No cats in the shelter.");
            }
        }
    }
}
