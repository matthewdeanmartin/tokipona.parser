using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using NUnit.Framework;

namespace BasicTypes.FundamentalTests
{
    [TestFixture]
    public class TestEquality
    {
        [Test]
        public void ForAllPossibleObjecs_DifferentOnesArentEqual()
        {
            EqualByValue_DiffferentAreNotEqual<Word>(Words.Dictionary.Values.ToArray(),WordByValue.Instance);
        }

        [Test]
        public void ForAllPossibleObjecs_EqualByValue_CopiesAreEqual()
        {
            EqualByValue_CopiesAreEqual<Word>(Words.Dictionary.Values.ToArray(), WordByValue.Instance);
        }

        //TODO
        //public void EqualByValue(ValueType[] ojects)
        //{
        //    
        //}

        //Should not be implemented on the object itself.
        //
        public void EqualByValue_DiffferentAreNotEqual<T>(object[] objects, IEqualityComparer<T> comparer )
            where T: class 
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if(i<objects.Length-2)
                    Assert.IsFalse(comparer.Equals(objects[i] as T, objects[i + 1] as T), objects[i].ToString() + " vs " + objects[i+1]); 
            }

           
        }

        public void EqualByValue_CopiesAreEqual<T>(object[] objects, IEqualityComparer<T> comparer)
            where T : class
        {
            BinaryFormatterCopier<T> copier = new BinaryFormatterCopier<T>();
             
            foreach (object o in objects)
            {
                T clone = copier.Copy(o as T);
                Assert.IsTrue(comparer.Equals(o as T, clone as T));

                //Only if we are overriding IEquatable?
                // Assert.AreEqual(clone.GetHashCode(), o.GetHashCode(), clone.ToString() +" vs "+ o.ToString());
            }

            for (int i = 0; i < objects.Length; i++)
            {
                if (i < objects.Length - 2)
                {
                    T clone = copier.Copy(objects[i + 1] as T);
            
                    Assert.IsFalse(comparer.Equals(objects[i] as T, clone as T), objects[i].ToString() + " vs " + objects[i + 1]);
            
                }
            }
        }
    }
}
