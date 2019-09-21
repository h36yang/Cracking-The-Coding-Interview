using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_6_Test
    {
        [TestMethod]
        public void DequeueAnyTest()
        {
            var shelter = new Question_3_6.AnimalShelter();
            shelter.Enqueue(new Question_3_6.Dog(1)); // Dog 1
            shelter.Enqueue(new Question_3_6.Cat(2)); // Dog 1 -> Cat 2
            shelter.Enqueue(new Question_3_6.Cat(3)); // Dog 1 -> Cat 2 -> Cat 3
            shelter.Enqueue(new Question_3_6.Dog(4)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4
            Assert.AreEqual(1, shelter.DequeueAny().Id, "Incorrect Animial returned.");
            Assert.AreEqual(2, shelter.DequeueAny().Id, "Incorrect Animial returned.");
            Assert.AreEqual(3, shelter.DequeueAny().Id, "Incorrect Animial returned.");
            Assert.AreEqual(4, shelter.DequeueAny().Id, "Incorrect Animial returned.");

            try
            {
                shelter.DequeueAny();
                Assert.Fail("Empty shelter check failed.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("No animals in the shelter.", e.Message, "Incorrect exception caught.");
            }
        }

        [TestMethod]
        public void DequeueDogTest()
        {
            var shelter = new Question_3_6.AnimalShelter();
            shelter.Enqueue(new Question_3_6.Dog(1)); // Dog 1
            shelter.Enqueue(new Question_3_6.Cat(2)); // Dog 1 -> Cat 2
            shelter.Enqueue(new Question_3_6.Cat(3)); // Dog 1 -> Cat 2 -> Cat 3
            shelter.Enqueue(new Question_3_6.Dog(4)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4
            shelter.Enqueue(new Question_3_6.Dog(5)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4 -> Dog 5
            shelter.Enqueue(new Question_3_6.Cat(6)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4 -> Dog 5 -> Cat 6
            Assert.AreEqual(1, shelter.DequeueDog().Id, "Incorrect Animial returned.");
            Assert.AreEqual(4, shelter.DequeueDog().Id, "Incorrect Animial returned.");
            Assert.AreEqual(5, shelter.DequeueDog().Id, "Incorrect Animial returned.");

            try
            {
                shelter.DequeueDog();
                Assert.Fail("No dogs check failed.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("No dogs in the shelter.", e.Message, "Incorrect exception caught.");
            }
        }

        [TestMethod]
        public void DequeueCatTest()
        {
            var shelter = new Question_3_6.AnimalShelter();
            shelter.Enqueue(new Question_3_6.Dog(1)); // Dog 1
            shelter.Enqueue(new Question_3_6.Cat(2)); // Dog 1 -> Cat 2
            shelter.Enqueue(new Question_3_6.Cat(3)); // Dog 1 -> Cat 2 -> Cat 3
            shelter.Enqueue(new Question_3_6.Dog(4)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4
            shelter.Enqueue(new Question_3_6.Dog(5)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4 -> Dog 5
            shelter.Enqueue(new Question_3_6.Cat(6)); // Dog 1 -> Cat 2 -> Cat 3 -> Dog 4 -> Dog 5 -> Cat 6
            Assert.AreEqual(2, shelter.DequeueCat().Id, "Incorrect Animial returned.");
            Assert.AreEqual(3, shelter.DequeueCat().Id, "Incorrect Animial returned.");
            Assert.AreEqual(6, shelter.DequeueCat().Id, "Incorrect Animial returned.");

            try
            {
                shelter.DequeueCat();
                Assert.Fail("No cats check failed.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("No cats in the shelter.", e.Message, "Incorrect exception caught.");
            }
        }
    }
}
