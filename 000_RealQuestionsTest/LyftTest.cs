using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class LyftTest
    {
        [TestMethod]
        public void IntersectionIteratorTest()
        {
            /*
             * Test 1
             */
            var it1 = new Lyft.IntersectionIterator(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 3, 5 });
            Assert.IsTrue(it1.HasNext());
            Assert.AreEqual(1, it1.Next());
            Assert.IsTrue(it1.HasNext());
            Assert.AreEqual(5, it1.Next());
            Assert.IsFalse(it1.HasNext());
            Assert.ThrowsException<InvalidOperationException>(() => it1.Next());

            /*
             * Test 2
             */
            var it2 = new Lyft.IntersectionIterator(new int[] { 1, 2, 4, 5, 6 }, new int[] { 3, 7, 8, 9 });
            Assert.IsFalse(it2.HasNext());
            Assert.ThrowsException<InvalidOperationException>(() => it2.Next());

            /*
             * Test 3
             */
            var it3 = new Lyft.IntersectionIterator(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(it3.HasNext());
            Assert.AreEqual(1, it3.Next());
            Assert.IsTrue(it3.HasNext());
            Assert.AreEqual(2, it3.Next());
            Assert.IsTrue(it3.HasNext());
            Assert.AreEqual(3, it3.Next());
            Assert.IsTrue(it3.HasNext());
            Assert.AreEqual(4, it3.Next());
            Assert.IsFalse(it3.HasNext());
            Assert.ThrowsException<InvalidOperationException>(() => it3.Next());
        }
    }
}
