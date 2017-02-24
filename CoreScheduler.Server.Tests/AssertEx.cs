using System;
using System.Collections;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreScheduler.Tests.Server
{
    public static class AssertEx
    {
        public static void PropertyValuesAreEquals(object actual, object expected)
        {
            PropertyInfo[] properties = expected.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expected, null);
                object actualValue = property.GetValue(actual, null);

                //if (actualValue is IList)
                //    CollectionAssert.AreEqual((IList)actualValue, (IList)expectedValue);
                if (expectedValue == null && actualValue == null)
                    continue;
                if (actualValue.GetType().IsPrimitive || actualValue is string || actualValue is DateTime ||
                    actualValue is decimal)
                    Assert.AreEqual(expectedValue, actualValue, "Prop: " + expected.GetType().Name + "." + property.Name);
                else if (actualValue is ICollection)
                    CollectionAssert.AreEqual((ICollection) expectedValue, (ICollection) actualValue,
                        "Prop: " + expected.GetType().Name + "." + property.Name);
                else
                    PropertyValuesAreEquals(actualValue, expectedValue);
            }
        }

        /// <summary>
        /// Calles the passed function, and asserts that it threw an Exception.
        /// </summary>
        /// <param name="act">Function to call</param>
        public static void Throws<TException>(Action act)
        {
            bool threw = false;
            try
            {
                act();
            }
            catch (Exception ex)
            {
                if (ex is TException)
                    threw = true;
                else throw;
            }
            Assert.IsTrue(threw);
        }

        /// <summary>
        /// Calls the passed function, and asserts that it threw an Exception
        /// </summary>
        /// <typeparam name="TReturn">Return Type</typeparam>
        /// <param name="func">Function to test</param>
        /// <returns>Value of func if assert fails, or default(T) if exception is thrown</returns>
        public static TReturn Throws<TException, TReturn>(Func<TReturn> func)
        {
            bool threw = false;
            TReturn value = default(TReturn);
            try
            {
                value = func();
            }
            catch (Exception ex)
            {
                if (ex is TException)
                    threw = true;
                else throw;
            }
            Assert.IsTrue(threw);
            return value;
        }
    }
}
