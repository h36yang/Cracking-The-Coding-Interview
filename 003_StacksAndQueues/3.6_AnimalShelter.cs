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

            public DateTime ShelterTime { get; set; }

            public Animal(int id)
            {
                Id = id;
            }
        }

        public class Dog : Animal
        {
            public Dog(int id) : base(id) { }
        }

        public class Cat : Animal
        {
            public Cat(int id) : base(id) { }
        }

        public class AnimalShelter
        {
            private readonly LinkedList<Dog> _dogsList = new LinkedList<Dog>();
            private readonly LinkedList<Cat> _catsList = new LinkedList<Cat>();

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <param name="animal"></param>
            public void Enqueue(Animal animal)
            {
                animal.ShelterTime = DateTime.Now;
                if (animal is Dog)
                {
                    _dogsList.AddLast(animal as Dog);
                }
                else
                {
                    _catsList.AddLast(animal as Cat);
                }
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public Animal DequeueAny()
            {
                if (_dogsList.Count == 0 && _catsList.Count == 0)
                {
                    throw new InvalidOperationException("No animals in the shelter.");
                }
                Animal oldestDog = _dogsList.Count > 0 ? _dogsList.First.Value : null;
                Animal oldestCat = _catsList.Count > 0 ? _catsList.First.Value : null;
                if (oldestDog == null)
                {
                    return DequeueCat();
                }
                else if (oldestCat == null)
                {
                    return DequeueDog();
                }
                else
                {
                    if (oldestDog.ShelterTime < oldestCat.ShelterTime)
                    {
                        return DequeueDog();
                    }
                    else
                    {
                        return DequeueCat();
                    }
                }
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public Dog DequeueDog()
            {
                if (_dogsList.Count == 0)
                {
                    throw new InvalidOperationException("No dogs in the shelter.");
                }
                Dog oldestDog = _dogsList.First.Value;
                _dogsList.RemoveFirst();
                return oldestDog;
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public Cat DequeueCat()
            {
                if (_catsList.Count == 0)
                {
                    throw new InvalidOperationException("No cats in the shelter.");
                }
                Cat oldestCat = _catsList.First.Value;
                _catsList.RemoveFirst();
                return oldestCat;
            }
        }
    }
}
