using LGcsharplib80.LGmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80Test.LGmodelsTest
{
    [TestClass]
    public class LGresultTest
    {
        // 临时测试结构体：
        struct TestStruct
        {
            public int XPoint { get; set; }
            public string YPoint { get; set; } // 此处没有设置为 string.Empty, 所以创建时默认值为 null。
        }
        // 测试枚举
        enum TestEnum
        {
            Ok,
            Error,
        }

        // 临时测试接口。
        interface ITestInterface
        {
            int TestInt { get; set; }
            string TestString { get; set; }
        }
        // 临时测试类：
        class TestClass : ITestInterface
        {
            public int TestInt { get; set; } = 0;
            public string TestString { get; set; } = string.Empty;
            public TestClass()
            {
                TestInt = 1;
                TestString = "1";
            }
        }
        // 临时测试事件：
        // event EventHandler TestEvent = delegate { };
        // event EventHandler<TestClass> TestEventClass = delegate { };

        #region test LGresult_DefaultValues_AreCorrect(): 测试 LGresult<T>的默认值
        [TestMethod]
        public void LGresult_DifferentDataTypes_Test()
        {
            // test void :  LGresult<T>的Data不能为void 类型，void 是一个特殊的类型，表示没有返回值的方法或操作。

            // test object
            LGresult<object> lgretObject = new();
            Assert.AreEqual(-1, lgretObject.Code);
            Assert.AreEqual(string.Empty, lgretObject.Message);
            Assert.AreEqual(default, lgretObject.Data);
            Assert.AreEqual(null, lgretObject.Data);
            Assert.AreNotEqual(string.Empty, lgretObject.Data);

            //test dynamic
            LGresult<dynamic> lgretDynamic = new();
            Assert.AreEqual(-1, lgretDynamic.Code);
            Assert.AreEqual(string.Empty, lgretDynamic.Message);
            // Assert.AreEqual(default(dynamic), lgretDynamic.Data);
            // Assert.AreEqual(null, lgretDynamic.Data);

            // test bool 
            LGresult<bool> lgretBool = new();
            Assert.AreEqual(-1, lgretBool.Code);
            Assert.AreEqual(string.Empty, lgretBool.Message);
            Assert.AreEqual(default, lgretBool.Data);
            Assert.AreEqual(false, lgretBool.Data);

            // test byte
            LGresult<byte> lgretByte = new();
            Assert.AreEqual(-1, lgretByte.Code);
            Assert.AreEqual(string.Empty, lgretByte.Message);
            Assert.AreEqual(default, lgretByte.Data);
            Assert.AreEqual(0, lgretByte.Data);
            // test sbyte
            LGresult<sbyte> lgretSByte = new();
            Assert.AreEqual(-1, lgretSByte.Code);
            Assert.AreEqual(string.Empty, lgretSByte.Message);
            Assert.AreEqual(default, lgretSByte.Data);
            Assert.AreEqual(0, lgretSByte.Data);

            // test short
            LGresult<short> lgretShort = new();
            Assert.AreEqual(-1, lgretShort.Code);
            Assert.AreEqual(string.Empty, lgretShort.Message);
            Assert.AreEqual(default, lgretShort.Data);
            Assert.AreEqual(0, lgretShort.Data);
            // test ushort
            LGresult<ushort> lgretUShort = new();
            Assert.AreEqual(-1, lgretUShort.Code);
            Assert.AreEqual(string.Empty, lgretUShort.Message);
            Assert.AreEqual(default, lgretUShort.Data);
            Assert.AreEqual(0, lgretUShort.Data);

            // test int
            LGresult<int> lgretInt = new();
            Assert.AreEqual(-1, lgretInt.Code);
            Assert.AreEqual(string.Empty, lgretInt.Message);
            Assert.AreEqual(default, lgretInt.Data);
            Assert.AreEqual(0, lgretInt.Data);
            // test uint
            LGresult<uint> lgretUInt = new();
            Assert.AreEqual(-1, lgretUInt.Code);
            Assert.AreEqual(string.Empty, lgretUInt.Message);
            Assert.AreEqual(default, lgretUInt.Data);
            Assert.AreEqual(0u, lgretUInt.Data);

            // test long
            LGresult<long> lgretLong = new();
            Assert.AreEqual(-1, lgretLong.Code);
            Assert.AreEqual(string.Empty, lgretLong.Message);
            Assert.AreEqual(default, lgretLong.Data);
            Assert.AreEqual(0, lgretLong.Data);
            // test ulong
            LGresult<ulong> lgretULong = new();
            Assert.AreEqual(-1, lgretULong.Code);
            Assert.AreEqual(string.Empty, lgretULong.Message);
            Assert.AreEqual(default, lgretULong.Data);
            Assert.AreEqual(0ul, lgretULong.Data);
            Assert.AreEqual((ulong)0, lgretULong.Data);

            // test float
            LGresult<float> lgretFloat = new();
            Assert.AreEqual(-1, lgretFloat.Code);
            Assert.AreEqual(string.Empty, lgretFloat.Message);
            Assert.AreEqual(default, lgretFloat.Data);
            Assert.AreEqual(0, lgretFloat.Data);
            // test double
            LGresult<double> lgretDouble = new();
            Assert.AreEqual(-1, lgretDouble.Code);
            Assert.AreEqual(string.Empty, lgretDouble.Message);
            Assert.AreEqual(default, lgretDouble.Data);
            Assert.AreEqual(0, lgretDouble.Data);

            // test decimal
            LGresult<decimal> lgretDecimal = new();
            Assert.AreEqual(-1, lgretDecimal.Code);
            Assert.AreEqual(string.Empty, lgretDecimal.Message);
            Assert.AreEqual(default, lgretDecimal.Data);
            Assert.AreEqual(0, lgretDecimal.Data);

            // test Enum
            LGresult<TestEnum> lgretTestEnum = new();
            Assert.AreEqual(-1, lgretTestEnum.Code);
            Assert.AreEqual(string.Empty, lgretTestEnum.Message);
            Assert.AreEqual(default, lgretTestEnum.Data);
            Assert.AreEqual(TestEnum.Ok, lgretTestEnum.Data);
            Assert.AreEqual(0, (int)lgretTestEnum.Data);

            // 测试本地时间（DateTime）， 跨时区（DateTimeOffset)
            LGresult<DateTime> lgretDateTime = new();
            Assert.AreEqual(-1, lgretDateTime.Code);
            Assert.AreEqual(string.Empty, lgretDateTime.Message);
            Assert.AreEqual(default, lgretDateTime.Data);
            Assert.AreEqual(DateTime.MinValue, lgretDateTime.Data);
            Console.WriteLine("测试本地时间（DateTime）, 默认值: " + lgretDateTime.Data);
            // 测试跨时区（DateTimeOffset）
            LGresult<DateTimeOffset> lgretDateTimeOffset = new();
            Assert.AreEqual(-1, lgretDateTimeOffset.Code);
            Assert.AreEqual(string.Empty, lgretDateTimeOffset.Message);
            Assert.AreEqual(default, lgretDateTimeOffset.Data);
            Assert.AreEqual(DateTimeOffset.MinValue, lgretDateTimeOffset.Data);
            Console.WriteLine("测试跨时区（DateTimeOffset）, 默认值: " + lgretDateTimeOffset.Data);
            // 测试跨时区（DateTimeOffset）
            DateTimeOffset testDateTimeOffset = new(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
            lgretDateTimeOffset.SetData(testDateTimeOffset);
            Assert.AreEqual(2023, lgretDateTimeOffset.Data.Year);
            Assert.AreEqual(1, lgretDateTimeOffset.Data.Month);
            Assert.AreEqual(1, lgretDateTimeOffset.Data.Day);
            Assert.AreEqual(0, lgretDateTimeOffset.Data.Hour);
            Assert.AreEqual(0, lgretDateTimeOffset.Data.Minute);
            Assert.AreEqual(0, lgretDateTimeOffset.Data.Second);
            Assert.AreEqual(TimeSpan.Zero, lgretDateTimeOffset.Data.Offset);

            // test 结构体类型TestStruct
            LGresult<TestStruct> lgretTestStruct = new();
            Assert.AreEqual(-1, lgretTestStruct.Code);
            Assert.AreEqual(string.Empty, lgretTestStruct.Message);
            Assert.AreEqual(default, lgretTestStruct.Data);
            Assert.AreEqual(0, lgretTestStruct.Data.XPoint);
            Assert.AreEqual(null, lgretTestStruct.Data.YPoint);
            //Assert.AreEqual(null, lgretTestStruct.Data); // struct是值类型，默认值不会是null。
            // test 结构体类型TestStruct
            TestStruct testStruct = new() { XPoint = 1, YPoint = "1" };
            lgretTestStruct.SetData(testStruct);
            Assert.AreEqual(1, lgretTestStruct.Data.XPoint);
            Assert.AreEqual("1", lgretTestStruct.Data.YPoint);

            // test char
            LGresult<char> lgretChar = new();
            Assert.AreEqual(-1, lgretChar.Code);
            Assert.AreEqual(string.Empty, lgretChar.Message);
            Assert.AreEqual(default, lgretChar.Data);
            Assert.AreEqual(0, lgretChar.Data);
            // test string
            LGresult<string> lgretString = new();
            Assert.AreEqual(-1, lgretString.Code);
            Assert.AreEqual(string.Empty, lgretString.Message);
            Assert.AreEqual(default, lgretString.Data);
            Assert.AreEqual(null, lgretString.Data);
            Assert.AreNotEqual(string.Empty, lgretString.Data);

            // test Nullable Types
            LGresult<int?> lgretIntNullable = new();
            Assert.AreEqual(-1, lgretIntNullable.Code);
            Assert.AreEqual(string.Empty, lgretIntNullable.Message);
            Assert.AreEqual(default, lgretIntNullable.Data);
            Assert.AreEqual(null, lgretIntNullable.Data);
            // test Nullable Types
            LGresult<string?> lgretStringNullable = new();
            Assert.AreEqual(-1, lgretStringNullable.Code);
            Assert.AreEqual(string.Empty, lgretStringNullable.Message);
            Assert.AreEqual(default, lgretStringNullable.Data);
            Assert.AreEqual(null, lgretStringNullable.Data);
            // test Nullable Types
            LGresult<TestClass?> lgretTestClassNullable = new();
            Assert.AreEqual(-1, lgretTestClassNullable.Code);
            Assert.AreEqual(string.Empty, lgretTestClassNullable.Message);
            Assert.AreEqual(default, lgretTestClassNullable.Data);
            Assert.AreEqual(null, lgretTestClassNullable.Data);

            // test class
            LGresult<TestClass> lgretTestClass = new();
            Assert.AreEqual(-1, lgretTestClass.Code);
            Assert.AreEqual(string.Empty, lgretTestClass.Message);
            Assert.AreEqual(default, lgretTestClass.Data);
            Assert.AreEqual(null, lgretTestClass.Data);

            // test Interface
            LGresult<ITestInterface> lgretTestInterface = new();
            Assert.AreEqual(-1, lgretTestInterface.Code);
            Assert.AreEqual(string.Empty, lgretTestInterface.Message);
            Assert.AreEqual(default, lgretTestInterface.Data);
            Assert.AreEqual(null, lgretTestInterface.Data);

            // test Array
            LGresult<TestClass[]> lgretTestClassArray = new();
            Assert.AreEqual(-1, lgretTestClassArray.Code);
            Assert.AreEqual(string.Empty, lgretTestClassArray.Message);
            Assert.AreEqual(default, lgretTestClassArray.Data);
            Assert.AreEqual(null, lgretTestClassArray.Data);

            // test Delegate
            LGresult<Action> lgretAction = new();
            Assert.AreEqual(-1, lgretAction.Code);
            Assert.AreEqual(string.Empty, lgretAction.Message);
            Assert.AreEqual(default, lgretAction.Data);
            Assert.AreEqual(null, lgretAction.Data);
            // test Action<T>
            LGresult<Action<int>> lgretActionInt = new();
            Assert.AreEqual(-1, lgretActionInt.Code);
            Assert.AreEqual(string.Empty, lgretActionInt.Message);
            Assert.AreEqual(default, lgretActionInt.Data);
            Assert.AreEqual(null, lgretActionInt.Data);
            // test Func<T>
            LGresult<Func<int>> lgretFuncInt = new();
            Assert.AreEqual(-1, lgretFuncInt.Code);
            Assert.AreEqual(string.Empty, lgretFuncInt.Message);
            Assert.AreEqual(default, lgretFuncInt.Data);
            Assert.AreEqual(null, lgretFuncInt.Data);
            // test Func<T, TResult>
            LGresult<Func<int, string>> lgretFuncIntString = new();
            Assert.AreEqual(-1, lgretFuncIntString.Code);
            Assert.AreEqual(string.Empty, lgretFuncIntString.Message);
            Assert.AreEqual(default, lgretFuncIntString.Data);
            Assert.AreEqual(null, lgretFuncIntString.Data);
            // test 事件
            LGresult<EventHandler> lgretEvent = new();
            Assert.AreEqual(-1, lgretEvent.Code);
            Assert.AreEqual(string.Empty, lgretEvent.Message);
            Assert.AreEqual(default, lgretEvent.Data);
            Assert.AreEqual(null, lgretEvent.Data);
            // test 事件参数
            LGresult<EventArgs> lgretEventArgs = new();
            Assert.AreEqual(-1, lgretEventArgs.Code);
            Assert.AreEqual(string.Empty, lgretEventArgs.Message);
            Assert.AreEqual(default, lgretEventArgs.Data);
            Assert.AreEqual(null, lgretEventArgs.Data);

            // test 集合类型 List泛型类型
            LGresult<List<int>> lgretListInt = new();
            Assert.AreEqual(-1, lgretListInt.Code);
            Assert.AreEqual(string.Empty, lgretListInt.Message);
            Assert.AreEqual(default, lgretListInt.Data);
            Assert.AreEqual(null, lgretListInt.Data);
            // test 集合类型 List泛型类型
            LGresult<List<string>> lgretListString = new();
            Assert.AreEqual(-1, lgretListString.Code);
            Assert.AreEqual(string.Empty, lgretListString.Message);
            Assert.AreEqual(default, lgretListString.Data);
            Assert.AreEqual(null, lgretListString.Data);
            // test 集合类型 List泛型类型
            LGresult<List<TestClass>> lgretListTestClass = new();
            Assert.AreEqual(-1, lgretListTestClass.Code);
            Assert.AreEqual(string.Empty, lgretListTestClass.Message);
            Assert.AreEqual(default, lgretListTestClass.Data);
            Assert.AreEqual(null, lgretListTestClass.Data);

            // test IList集合类型
            LGresult<IList<int>> lgretIListInt = new();
            Assert.AreEqual(-1, lgretIListInt.Code);
            Assert.AreEqual(string.Empty, lgretIListInt.Message);
            Assert.AreEqual(default, lgretIListInt.Data);
            Assert.AreEqual(null, lgretIListInt.Data);
            // test IList集合类型
            LGresult<IList<string>> lgretIListString = new();
            Assert.AreEqual(-1, lgretIListString.Code);
            Assert.AreEqual(string.Empty, lgretIListString.Message);
            Assert.AreEqual(default, lgretIListString.Data);
            Assert.AreEqual(null, lgretIListString.Data);
            // test IList集合类型
            LGresult<IList<TestClass>> lgretIListTestClass = new();
            Assert.AreEqual(-1, lgretIListTestClass.Code);
            Assert.AreEqual(string.Empty, lgretIListTestClass.Message);
            Assert.AreEqual(default, lgretIListTestClass.Data);
            Assert.AreEqual(null, lgretIListTestClass.Data);

            // test 集合类型 Dictionary泛型类型
            LGresult<Dictionary<int, string>> lgretDictionaryIntString = new();
            Assert.AreEqual(-1, lgretDictionaryIntString.Code);
            Assert.AreEqual(string.Empty, lgretDictionaryIntString.Message);
            Assert.AreEqual(default, lgretDictionaryIntString.Data);
            Assert.AreEqual(null, lgretDictionaryIntString.Data);
            // test 集合类型 Dictionary泛型类型
            LGresult<Dictionary<int, TestClass>> lgretDictionaryIntTestClass = new();
            Assert.AreEqual(-1, lgretDictionaryIntTestClass.Code);
            Assert.AreEqual(string.Empty, lgretDictionaryIntTestClass.Message);
            Assert.AreEqual(default, lgretDictionaryIntTestClass.Data);
            Assert.AreEqual(null, lgretDictionaryIntTestClass.Data);

            // test 测试集合类:枚举迭代器IEnumerabor<T>
            LGresult<IEnumerator<int>> lgretIEnumeratorInt = new();
            Assert.AreEqual(-1, lgretIEnumeratorInt.Code);
            Assert.AreEqual(string.Empty, lgretIEnumeratorInt.Message);
            Assert.AreEqual(default, lgretIEnumeratorInt.Data);
            Assert.AreEqual(null, lgretIEnumeratorInt.Data);
            // test 测试集合类:枚举迭代器IEnumerabor<T>
            lgretIEnumeratorInt.SetData(((IEnumerable<int>)[1, 2, 3]).GetEnumerator());
            if (lgretIEnumeratorInt == null)
            {
                Assert.Fail("lgretIEnumeratorInt is null.");
            }
            if (lgretIEnumeratorInt.Data == null)
            {
                Assert.Fail("lgretIEnumeratorInt.Data is null.");
            }
            else
            {
                lgretIEnumeratorInt.Data.MoveNext();
                Assert.AreEqual(1, lgretIEnumeratorInt.Data.Current);
                lgretIEnumeratorInt.Data.MoveNext();
                Assert.AreEqual(2, lgretIEnumeratorInt.Data.Current);
                lgretIEnumeratorInt.Data.MoveNext();
                Assert.AreEqual(3, lgretIEnumeratorInt.Data.Current);
                lgretIEnumeratorInt.Data.MoveNext();
                Assert.AreEqual(false, lgretIEnumeratorInt.Data.MoveNext());
            }

            // test 集合类型 IEnumerable
            LGresult<IEnumerable<int>> lgretIEnumerableInt = new();
            Assert.AreEqual(-1, lgretIEnumerableInt.Code);
            Assert.AreEqual(string.Empty, lgretIEnumerableInt.Message);
            Assert.AreEqual(default, lgretIEnumerableInt.Data);
            Assert.AreEqual(null, lgretIEnumerableInt.Data);
            // test IEnumerable集合类型
            LGresult<IEnumerable<string>> lgretIEnumerableString = new();
            Assert.AreEqual(-1, lgretIEnumerableString.Code);
            Assert.AreEqual(string.Empty, lgretIEnumerableString.Message);
            Assert.AreEqual(default, lgretIEnumerableString.Data);
            Assert.AreEqual(null, lgretIEnumerableString.Data);
            // test IEnumerable集合类型
            LGresult<IEnumerable<TestClass>> lgretIEnumerableTestClass = new();
            Assert.AreEqual(-1, lgretIEnumerableTestClass.Code);
            Assert.AreEqual(string.Empty, lgretIEnumerableTestClass.Message);
            Assert.AreEqual(default, lgretIEnumerableTestClass.Data);
            Assert.AreEqual(null, lgretIEnumerableTestClass.Data);

            // test 集合类型 ICollection
            LGresult<ICollection<int>> lgretICollectionInt = new();
            Assert.AreEqual(-1, lgretICollectionInt.Code);
            Assert.AreEqual(string.Empty, lgretICollectionInt.Message);
            Assert.AreEqual(default, lgretICollectionInt.Data);
            Assert.AreEqual(null, lgretICollectionInt.Data);
            // test ICollection集合类型
            LGresult<ICollection<string>> lgretICollectionString = new();
            Assert.AreEqual(-1, lgretICollectionString.Code);
            Assert.AreEqual(string.Empty, lgretICollectionString.Message);
            Assert.AreEqual(default, lgretICollectionString.Data);
            Assert.AreEqual(null, lgretICollectionString.Data);
            // test ICollection集合类型
            LGresult<ICollection<TestClass>> lgretICollectionTestClass = new();
            Assert.AreEqual(-1, lgretICollectionTestClass.Code);
            Assert.AreEqual(string.Empty, lgretICollectionTestClass.Message);
            Assert.AreEqual(default, lgretICollectionTestClass.Data);
            Assert.AreEqual(null, lgretICollectionTestClass.Data);

            // test Tuple, 是引用类型（class），继承自 System.Tuple 抽象类，实例存储在堆上
            LGresult<Tuple<int, string>> lgretTupleIntString = new();
            Assert.AreEqual(-1, lgretTupleIntString.Code);
            Assert.AreEqual(string.Empty, lgretTupleIntString.Message);
            Assert.AreEqual(default, lgretTupleIntString.Data);
            Assert.AreEqual(null, lgretTupleIntString.Data);
            // test Tuple
            LGresult<Tuple<int, string, TestClass>> lgretTupleIntStringTestClass = new();
            Assert.AreEqual(-1, lgretTupleIntStringTestClass.Code);
            Assert.AreEqual(string.Empty, lgretTupleIntStringTestClass.Message);
            Assert.AreEqual(default, lgretTupleIntStringTestClass.Data);
            Assert.AreEqual(null, lgretTupleIntStringTestClass.Data);

            // test ValueTuple, 是值类型（struct），定义在 System 命名空间下，实例存储在栈上
            LGresult<ValueTuple<int, string>> lgretValueTupleIntString = new();
            Assert.AreEqual(-1, lgretValueTupleIntString.Code);
            Assert.AreEqual(string.Empty, lgretValueTupleIntString.Message);
            Assert.AreEqual(default, lgretValueTupleIntString.Data);
            Assert.AreEqual((0, null), lgretValueTupleIntString.Data);
            // test ValueTuple
            LGresult<ValueTuple<int, string, TestClass>> lgretValueTupleIntStringTestClass = new();
            Assert.AreEqual(-1, lgretValueTupleIntStringTestClass.Code);
            Assert.AreEqual(string.Empty, lgretValueTupleIntStringTestClass.Message);
            Assert.AreEqual(default, lgretValueTupleIntStringTestClass.Data);
            Assert.AreEqual((0, null, null), lgretValueTupleIntStringTestClass.Data);

            // 测试Guid
            LGresult<Guid> lgretGuid = new();
            Assert.AreEqual(-1, lgretGuid.Code);
            Assert.AreEqual(string.Empty, lgretGuid.Message);
            Assert.AreEqual(default, lgretGuid.Data);
            Assert.AreEqual(Guid.Empty, lgretGuid.Data);
            Console.WriteLine("测试Guid，默认值：" + lgretGuid.Data);

            // test 异步类型Task
            LGresult<Task> lgretTask = new();
            Assert.AreEqual(-1, lgretTask.Code);
            Assert.AreEqual(string.Empty, lgretTask.Message);
            Assert.AreEqual(default, lgretTask.Data);
            Assert.AreEqual(null, lgretTask.Data);
            // test 异步类型Task<T>
            LGresult<Task<int>> lgretTaskInt = new();
            Assert.AreEqual(-1, lgretTaskInt.Code);
            Assert.AreEqual(string.Empty, lgretTaskInt.Message);
            Assert.AreEqual(default, lgretTaskInt.Data);
            Assert.AreEqual(null, lgretTaskInt.Data);
            // test 异步类型Task<T>
            LGresult<Task<string>> lgretTaskString = new();
            Assert.AreEqual(-1, lgretTaskString.Code);
            Assert.AreEqual(string.Empty, lgretTaskString.Message);
            Assert.AreEqual(default, lgretTaskString.Data);
            Assert.AreEqual(null, lgretTaskString.Data);
            // test 异步类型Task<T>
            LGresult<Task<TestClass>> lgretTaskTestClass = new();
            Assert.AreEqual(-1, lgretTaskTestClass.Code);
            Assert.AreEqual(string.Empty, lgretTaskTestClass.Message);
            Assert.AreEqual(default, lgretTaskTestClass.Data);
            Assert.AreEqual(null, lgretTaskTestClass.Data);
        }
        #endregion

        #region test SetData()
        [TestMethod]
        public void LGresult_SetData_AreCorrect()
        {
            // test Data is int
            LGresult<int> lgretInt = new();
            lgretInt.SetData(1);
            Assert.AreEqual(1, lgretInt.Data);
            // test Data is string
            LGresult<string> lgretString = new();
            lgretString.SetData("1");
            Assert.AreEqual("1", lgretString.Data);

            // test Data is TestClass
            LGresult<TestClass> lgretTestClass = new();
            lgretTestClass.SetData(new TestClass());
            Assert.AreNotEqual(new TestClass(), lgretTestClass.Data); // AreEqual 是使用引用比较的，所以不相等
            Assert.IsNotNull(lgretTestClass.Data);
            Assert.AreEqual(1, lgretTestClass.Data.TestInt);
            // test Data is null
            if (lgretTestClass == null)
            {
                Assert.Fail("lgretTestClass is null.");
            }
            var ex = Assert.ThrowsException<Exception>(() => lgretTestClass.SetData(null));
            Assert.AreEqual("LGresult<T>: 传入的值data为空。", ex.Message);

            // test Data is TestStruct
            LGresult<TestStruct> lgretTestStruct = new();
            lgretTestStruct.SetData(new TestStruct { XPoint = 1, YPoint = "1" });
            Assert.AreEqual(1, lgretTestStruct.Data.XPoint);
            Assert.AreEqual("1", lgretTestStruct.Data.YPoint);
            // test Data is null
            // lgretTestStruct.SetData(null); // 结构体是值类型，不能为null            
        }
        #endregion

        #region test GetData()
        [TestMethod]
        public void LGresult_GetData_AreCorrect()
        {
            // test int
            LGresult<int> lgretInt = new();
            lgretInt.SetData(1);
            Assert.AreEqual(1, lgretInt.GetData());
            // test string
            LGresult<string> lgretString = new();
            lgretString.SetData("1");
            Assert.AreEqual("1", lgretString.GetData());
            // test TestClass
            LGresult<TestClass> lgretTestClass = new();
            TestClass testClass = new();
            lgretTestClass.SetData(testClass);
            Assert.AreEqual(testClass, lgretTestClass.GetData()); // AreEqual 是使用引用比较的，所以不相等
            Assert.AreNotEqual(new TestClass(), lgretTestClass.GetData()); // AreEqual 是使用引用比较的，所以不相等
            Assert.AreEqual(1, lgretTestClass.GetData().TestInt);
            // test TestStruct
            LGresult<TestStruct> lgretTestStruct = new();
            TestStruct testStruct = new() { XPoint = 1, YPoint = "1" };
            lgretTestStruct.SetData(testStruct);
            Assert.AreEqual(1, lgretTestStruct.GetData().XPoint);
            Assert.AreEqual("1", lgretTestStruct.GetData().YPoint);

            // test TestClass is null
            if (lgretTestClass == null)
            {
                Assert.Fail("lgretTestClass is null.");
            }
            lgretTestClass.Data = null;
            var ex = Assert.ThrowsException<Exception>(() => lgretTestClass.GetData());
            Assert.AreEqual("LGresult<T>: Data is null.", ex.Message);

            // test TestStruct is null, 结构体是值类型，不能为null
            //ex = Assert.ThrowsException<Exception>(() => lgretTestStruct.GetData());
        }
        #endregion
    }
}
