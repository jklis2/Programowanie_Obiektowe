using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using Time_TimePeriod;
using TimeLib;

namespace Time_TimePeriod_UnitTest
{
    [TestClass]
    public class UnitTestsTimeandTimePeriodConstructors
    {
        private static byte defaultTime = 0;

        private void AssertTime(Time t, byte expectedH, byte expectedM, byte expectedS)
        {
            Assert.AreEqual(expectedH, t.Hours);
            Assert.AreEqual(expectedM, t.Minutes);
            Assert.AreEqual(expectedS, t.Seconds);
        }

        private void AssertTimePeriod(TimePeriod tP, long expectedH, long expectedM, long expectedS)
        {
            Assert.AreEqual(expectedH, tP.Hours);
            Assert.AreEqual(expectedM, tP.Minutes);
            Assert.AreEqual(expectedS, tP.Seconds);
        }

        #region Constuctor tests

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_Default_Time()
        {
            Time t = new Time();

            Assert.AreEqual(defaultTime, t.Hours);
            Assert.AreEqual(defaultTime, t.Minutes);
            Assert.AreEqual(defaultTime, t.Minutes);
        }

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_Default_TimePeriod()
        {
            TimePeriod tP = new TimePeriod();

            Assert.AreEqual(defaultTime, tP.Hours);
            Assert.AreEqual(defaultTime, tP.Minutes);
            Assert.AreEqual(defaultTime, tP.Minutes);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1,(byte) 1, (byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)8, (byte)23, (byte)59, (byte)8, (byte)23, (byte)59)]
        [DataRow((byte)12, (byte)7, (byte)9, (byte)12, (byte)7, (byte)9)]
        [DataRow((byte)23, (byte)40, (byte)54, (byte)23, (byte)40, (byte)54)]
        public void Constructor_3param(byte h, byte m, byte s, byte expectedH, byte expectedM, byte expectedS)
        {
            Time t = new Time(h, m, s);

            AssertTime(t, expectedH, expectedM, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((long)100, (long)1, (long)1, (long)100, (long)1, (long)1)]
        [DataRow((long)8, (long)23, (long)59, (long)8, (long)23, (long)59)]
        [DataRow((long)12, (long)7, (long)9, (long)12, (long)7, (long)9)]
        [DataRow((long)23, (long)40, (long)54, (long)23, (long)40, (long)54)]
        public void Constructor_3param_TimePeriod(long h, long m, long s, long expectedH, long expectedM, long expectedS)
        {
            TimePeriod tP = new TimePeriod(h, m, s);

            AssertTimePeriod(tP, expectedH, expectedM, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)8, (byte)23, (byte)8, (byte)23)]
        [DataRow((byte)12, (byte)7, (byte)12, (byte)7)]
        [DataRow((byte)23, (byte)40, (byte)23, (byte)40)]
        public void Constructor_2param(byte h, byte m, byte expectedH, byte expectedM)
        {
            Time t = new Time(h, m);

            AssertTime(t, expectedH, expectedM, expectedS: 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((long)100, (long)1, (long)100, (long)1)]
        [DataRow((long)8, (long)23, (long)8, (long)23)]
        [DataRow((long)12, (long)7, (long)12, (long)7)]
        [DataRow((long)23, (long)40, (long)23, (long)40)]
        public void Constructor_2param_TimePeriod(long h, long m, long expectedH, long expectedM)
        {
            TimePeriod tP = new TimePeriod(h, m);

            AssertTimePeriod(tP, expectedH, expectedM, expectedS: 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1)]
        [DataRow((byte)8, (byte)8)]
        [DataRow((byte)12, (byte)12)]
        [DataRow((byte)23, (byte)23)]
        public void Constructor_1param(byte h, byte expectedH)
        {
            Time t = new Time(h);

            AssertTime(t, expectedH, expectedM: 0, expectedS: 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((long)100, (long)100)]
        [DataRow((long)8, (long)8)]
        [DataRow((long)12, (long)12)]
        [DataRow((long)23, (long)23)]
        public void Constructor_1param_TimePeriod(long h, long expectedH)
        {
            TimePeriod tP = new TimePeriod(h);

            AssertTimePeriod(tP, expectedH, expectedM: 0, expectedS: 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)23, (byte)9, (byte)40, "23:09:40")]
        [DataRow((byte)23, (byte)0, (byte)0, "23:00:00")]
        [DataRow((byte)9, (byte)39, (byte)8, "09:39:08")]
        public void Constructor_ToString(byte h, byte m, byte s, string time)
        {
            Time t = new Time(h, m, s);


            Assert.AreEqual(time, t.ToString());

        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((long)100, (long)1, (long)1, "100:01:01")]
        [DataRow((long)8, (long)23, (long)59, "8:23:59")]
        [DataRow((long)12, (long)7, (long)9, "12:07:09")]
        [DataRow((long)23, (long)40, (long)54, "23:40:54")]
        public void Constructor_ToString_TimePeriod(long  h, long m, long s, string timePeriod)
        {
            TimePeriod tP = new TimePeriod(h, m ,s);


            Assert.AreEqual(timePeriod, tP.ToString());
        }


        [DataTestMethod, TestCategory("Constructors")]
        [DataRow("23:09:40", (byte)23, (byte)9, (byte)40)]
        [DataRow("23:00:00", (byte)23, (byte)0, (byte)0)]
        [DataRow("09:39:08", (byte)9, (byte)39, (byte)8)]
        public void Constructor_StringParam(string time, byte expectedH, byte expectedM, byte expectedS)
        {
            Time t = new Time(time);


            AssertTime(t, expectedH, expectedM, expectedS);

        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow("100:01:01", (long)100,(long)1, (long)1)]
        [DataRow("08:23:59", (long)8, (long)23, (long)59)]
        [DataRow("12:07:09", (long)12, (long)7, (long)9)]
        [DataRow("23:40:54",(long)23, (long)40, (long)54)]
        public void Constructor_StringParam_TimePeriod(string timePeriod, long expectedH, long expectedM, long expectedS)
        {
            TimePeriod tP = new TimePeriod(timePeriod);

            AssertTimePeriod(tP,expectedH, expectedM, expectedS);
        }

        // -----------

        public static IEnumerable<object[]> DataSetTime_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] { (byte)25, (byte)70, (byte)1 },
            new object[] { (byte)1, (byte)77, (byte)90 },
            new object[] { (byte)13, (byte)80, (byte)8 },
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSetTime_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3param_Default_ArgumentOutOfRangeException(byte h, byte m, byte s)
        {
            new Time(h, m, s);
        }

        public static IEnumerable<object[]> DataSetTime2param_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] { (byte)25, (byte)70 },
            new object[] { (byte)30, (byte)77 },
            new object[] { (byte)155, (byte)80 },
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSetTime2param_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2param_ArgumentOutOfRangeException(byte h, byte m)
        {
            new Time(h, m);
        }

        public static IEnumerable<object[]> DataSetTime1param_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] { (byte)245 },
            new object[] { (byte)50 },
            new object[] { (byte)75 },
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSetTime1param_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_ArgumentOutOfRangeException(byte h)
        {
            new Time(h);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)38)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_DefaultMeters_ArgumentOutOfRangeException(byte h)
        {
            new Time(h);
        }


        #endregion

        #region ToString tests

        [TestMethod, TestCategory("String representation")]
        public void TimeToString()
        {
            var t = new Time(4, 13);
            var tP = new TimePeriod(4, 13);
            string expectedString = "04:13:00";
            string expectedStringTP = "4:13:00";

            Assert.AreEqual(expectedString, t.ToString());
            Assert.AreEqual(expectedStringTP, tP.ToString());
        }

        #endregion

        #region Equals 
        // ToDo
        [DataTestMethod]
        [DataRow((byte)4, (byte)23, (byte)4, (byte)4, (byte)23, (byte)4, true)]
        [DataRow((byte)12, (byte)3, (byte)59, (byte)4, (byte)10, (byte)24, false)]
        public void Equals(byte h, byte m, byte s, byte expectedH, byte expectedM, byte expectedS, bool expectedResult)
        {
            Time t1 = new Time(h, m, s);
            Time t2 = new Time(expectedH, expectedM, expectedS);

            Assert.AreEqual(expectedResult, t1.Equals(t2));
        }

        #endregion

        #region Operators overloading

        [DataTestMethod, TestCategory("Overloading")]

        public void EqualsOperator()
        {
            Time t1 = new Time(4, 23, 4);
            Time t2 = new Time(4, 23, 4);
            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 10, 23);

            Assert.AreEqual(true, t1 == t2);
            Assert.AreEqual(false, tP1 == tP2);
        }

        [DataTestMethod, TestCategory("Overloading")]
        public void NotEqualOperator()
        {
            Time t1 = new Time(4, 23, 2);
            Time t2 = new Time(4, 23, 4);
            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 9, 23);

            Assert.AreEqual(true, t1 != t2);
            Assert.AreEqual(false, tP1 != tP2);
        }

        [DataTestMethod, TestCategory("Overloading")]
        public void MoreThanOperator()
        {
            Time t1 = new Time(4, 23, 2);
            Time t2 = new Time(4, 23, 4);
            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 9, 23);
            Assert.AreEqual(false, t1 > t2);
            Assert.AreEqual(false, tP1 > tP2);

        }

        [DataTestMethod, TestCategory("Overloading")]
        public void LessThanOperator()
        {
            Time t1 = new Time(4, 23, 2);
            Time t2 = new Time(4, 23, 4);
            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 9, 23);
            Assert.AreEqual(true, t1 < t2);
            Assert.AreEqual(false, tP1 < tP2);
        }

        [DataTestMethod, TestCategory("Overloading")]
        public void MoreOrEqualThanOperator()
        {
            Time t1 = new Time(4, 23, 4);
            Time t2 = new Time(4, 23, 4);
            Time t3 = new Time(12, 3, 59);
            Time t4 = new Time(4, 10, 24);

            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 9, 23);
            TimePeriod tP3 = new TimePeriod(3, 3, 59);
            TimePeriod tP4 = new TimePeriod(17, 29);

            Assert.AreEqual(true, t1 >= t2);
            Assert.AreEqual(true, t3 >= t4);
            Assert.AreEqual(true, tP1 >= tP2);
            Assert.AreEqual(false, tP3 >= tP4);
        }

        [DataTestMethod, TestCategory("Overloading")]

        public void LessOrEqualThenOperator()
        {
            Time t1 = new Time(4, 23, 4);
            Time t2 = new Time(4, 23, 4);
            Time t3 = new Time(12, 3, 59);
            Time t4 = new Time(4, 10, 24);

            TimePeriod tP1 = new TimePeriod(7, 9, 23);
            TimePeriod tP2 = new TimePeriod(7, 9, 23);
            TimePeriod tP3 = new TimePeriod(3, 3, 59);
            TimePeriod tP4 = new TimePeriod(17, 29);

            Assert.AreEqual(true, t1 <= t2);
            Assert.AreEqual(false, t3 <= t4);
            Assert.AreEqual(true, tP1 <= tP2);
            Assert.AreEqual(true, tP3 <= tP4);
        }
        #endregion

        #region Arithmetic operations

        [DataTestMethod, TestCategory("Time arithmetic operations")]
        public void TimeOne_Plus_TimeTwo_Operation()
        {
            Time t1 = new Time(12, 30, 30);
            Time t2 = new Time(14, 40, 40);
            Time t3 = new Time(3, 11, 10);

            Time t4 = new Time(11, 23, 6);
            Time t5 = new Time(13, 18, 30);
            Time t6 = new Time(0, 41, 36);

            TimePeriod tP1 = new TimePeriod(10, 55, 43);
            TimePeriod tP2 = new TimePeriod(17, 30, 20);
            TimePeriod tP3 = new TimePeriod(28, 26, 3);

            TimePeriod tP4 = new TimePeriod(2, 35, 30);
            TimePeriod tP5 = new TimePeriod(14, 10, 10);
            TimePeriod tP6 = new TimePeriod(16, 45, 40);

            Assert.AreEqual(t3, t1 + t2);
            Assert.AreEqual(t6, t4 + t5);

            Assert.AreEqual(tP3, tP1 + tP2);
            Assert.AreEqual(tP6, tP4 + tP5);
        }

        [DataTestMethod, TestCategory("Time arithmetic operations")]
        public void TimeOne_Minus_TimeTwo_Operation()
        {
            Time t1 = new Time(12, 30, 20);
            Time t2 = new Time(14, 35, 30);
            Time t3 = new Time(21, 54, 50);

            Time t4 = new Time(11, 23, 6);
            Time t5 = new Time(13, 18, 30);
            Time t6 = new Time(22, 4, 36);

            TimePeriod tP1 = new TimePeriod(10, 55, 43);
            TimePeriod tP2 = new TimePeriod(17, 30, 20);
            TimePeriod tP3 = new TimePeriod(6, 34, 37);

            TimePeriod tP4 = new TimePeriod(2, 35, 30);
            TimePeriod tP5 = new TimePeriod(14, 40, 56);
            TimePeriod tP6 = new TimePeriod(12, 5, 26);

            Assert.AreEqual(t3, t1 - t2);
            Assert.AreEqual(t6, t4 - t5);

            Assert.AreEqual(tP3, tP1 - tP2);
            Assert.AreEqual(tP6, tP4 - tP5);
        }
        #endregion

        #region Time and TimePeriod methods

        [DataTestMethod, TestCategory("Methods")]
        public void TimePlusTimePeriod_1param()
        {
            Time t1 = new Time(11, 39, 8);
            Time t2 = new Time(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            Time t3 = new Time(17, 29, 11);
            Time t4 = new Time(5, 12, 56);
            Assert.AreEqual(t3, t1.Plus(tP1));
            Assert.AreEqual(t4, t2.Plus(tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePlusTimePeriod_2param()
        {
            Time t1 = new Time(11, 39, 8);
            Time t2 = new Time(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            Time t3 = new Time(17, 29, 11);
            Time t4 = new Time(5, 12, 56);
            Assert.AreEqual(t3, Time.Plus(t1, tP1));
            Assert.AreEqual(t4, Time.Plus(t2, tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimeMinusTimePeriod_1param()
        {
            Time t1 = new Time(11, 39, 8);
            Time t2 = new Time(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            Time t3 = new Time(5, 49, 5);
            Time t4 = new Time(0, 50, 58);
            Assert.AreEqual(t3, t1.Minus(tP1));
            Assert.AreEqual(t4, t2.Minus(tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimeMinusTimePeriod_2param()
        {
            Time t1 = new Time(11, 39, 8);
            Time t2 = new Time(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            Time t3 = new Time(5, 49, 5);
            Time t4 = new Time(0, 50, 58);
            Assert.AreEqual(t3, Time.Minus(t1, tP1));
            Assert.AreEqual(t4, Time.Minus(t2, tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePeriodPlusTimePeriod_1param()
        {
            TimePeriod t1 = new TimePeriod(11, 39, 8);
            TimePeriod t2 = new TimePeriod(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            TimePeriod t3 = new TimePeriod(41, 29, 11);
            TimePeriod t4 = new TimePeriod(53, 12, 56);
            Assert.AreEqual(t3, t1.Plus(tP1));
            Assert.AreEqual(t4, t2.Plus(tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePeriodPlusTimePeriod_2param()
        {

            TimePeriod t1 = new TimePeriod(11, 39, 8);
            TimePeriod t2 = new TimePeriod(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            TimePeriod t3 = new TimePeriod(41, 29, 11);
            TimePeriod t4 = new TimePeriod(53, 12, 56);
            Assert.AreEqual(t3, TimePeriod.Plus(t1, tP1));
            Assert.AreEqual(t4, TimePeriod.Plus(t2, tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePeriodMinusTimePeriod_1param()
        {
            TimePeriod t1 = new TimePeriod(11, 39, 8);
            TimePeriod t2 = new TimePeriod(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            TimePeriod t3 = new TimePeriod(18, 10, 55);
            TimePeriod t4 = new TimePeriod(47, 9, 2);
            Assert.AreEqual(t3, t1.Minus(tP1));
            Assert.AreEqual(t4, t2.Minus(tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePeriodMinusTimePeriod_2param()
        {

            TimePeriod t1 = new TimePeriod(11, 39, 8);
            TimePeriod t2 = new TimePeriod(3, 1, 57);

            TimePeriod tP1 = new TimePeriod(29, 50, 3);
            TimePeriod tP2 = new TimePeriod(50, 10, 59);

            TimePeriod t3 = new TimePeriod(18, 10, 55);
            TimePeriod t4 = new TimePeriod(47, 9, 2);
            Assert.AreEqual(t3, TimePeriod.Minus(t1, tP1));
            Assert.AreEqual(t4, TimePeriod.Minus(t2, tP2));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimeMultiply()
        {
            Time t1 = new Time(11, 39, 8);
            Time t2 = new Time(3, 1, 57);

            Time t3 = new Time(10, 57, 24);
            Time t4 = new Time(15, 9, 45);
            Assert.AreEqual(t3, t1.Multiply(3));
            Assert.AreEqual(t4, t2.Multiply(5));
        }

        [DataTestMethod, TestCategory("Methods")]
        public void TimePeriodMultiply()
        {
            TimePeriod t1 = new TimePeriod(11, 39, 8);
            TimePeriod t2 = new TimePeriod(3, 1, 57);

            TimePeriod t3 = new TimePeriod(23, 18, 16);
            TimePeriod t4 = new TimePeriod(18, 11, 42);
            Assert.AreEqual(t3, t1.Multiply(2));
            Assert.AreEqual(t4, t2.Multiply(6));
        }

        #endregion
    }
}
