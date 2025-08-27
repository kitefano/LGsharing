using LGcsharplib80.LGmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace LGcsharplib80Test.LGmodelsTest
{
    [TestClass]
    public class LGjsonTest
    {
        // 测试结构体
        struct TestStruct
        {
            public int Code { get; set; }
            public string Message { get; set; }
        }
        // 测试枚举
        enum TestEnum
        {
            Ok,
            Error,
        }
        // 测试类
        class TestClass
        {
            public int Code { get; set; }
            public string Message { get; set; } = string.Empty;
        }
        public class TestNode
        {
            public string Name { get; set; } = string.Empty;
            public TestNode Next { get; set; } = null!;
        }
        public class TestIntPtr
        {
            public IntPtr Handle { get; set; }
        }
        public class TestType
        {
            public required Type TypeInfo { get; set; }
        }
        class OuterClass
        {
            public int Id { get; set; }
            public TestClass Inner { get; set; } = new();
            public List<TestStruct> StructList { get; set; } = [];
        }

        #region 使用指南 LGjson_UseHelp()
        [TestMethod]
        public void LGjson_UseHelp()
        {
            // struct 
            // 序列化
            TestStruct testStruct = new() { Code = 0, Message = "TestStruct success, 你好。" };
            LGresult<string> lgret = LGjson.Serialize(testStruct);
            if (lgret.Code != 0)
            {
                Console.WriteLine("TestStruct序列化失败: " + lgret.Message);
                return;
            }
            Console.WriteLine("TestStruct序列化结果: " + lgret.Data);
            // 反序列化
            Assert.IsNotNull(lgret.Data);
            string jsonStruct = lgret.Data;
            LGresult<TestStruct> lgret2 = LGjson.Deserialize<TestStruct>(jsonStruct);
            if (lgret2.Code != 0)
            {
                Console.WriteLine("TestStruct反序列化失败: " + lgret2.Message);
                return;
            }
            Assert.IsNotNull(lgret2.Data);
            Console.WriteLine("TestStruct反序列化结果: " + LGjson.Serialize(lgret2.Data).Data);

            // class
            // 序列化
            TestClass testClass = new() { Code = 0, Message = "TestClass success，你好。" };
            lgret = LGjson.Serialize(testClass);
            if (lgret.Code != 0)
            {
                Console.WriteLine("TestClass序列化失败: " + lgret.Message);
                return;
            }
            Console.WriteLine("TestClass序列化结果: " + lgret.Data);
            // 反序列化
            Assert.IsNotNull(lgret.Data);
            string jsonClass = lgret.Data;
            LGresult<TestClass> lgret3 = LGjson.Deserialize<TestClass>(jsonClass);
            if (lgret3.Code != 0)
            {
                Console.WriteLine("TestClass反序列化失败: " + lgret3.Message);
                return;
            }
            Assert.IsNotNull(lgret3.Data);
            Console.WriteLine("TestClass反序列化结果: " + LGjson.Serialize(lgret3.Data).Data);
        }
        #endregion

        #region 测试不同数据类型的序列化和反序列化
        [TestMethod]
        public void LGjson_DifferentDataTypes_Test()
        {
            LGresult<string> lgret;

            // test object 类型
            object testObject = new();
            lgret = LGjson.Serialize(testObject);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试object，序列化结果: " + lgret.Data);
            // 反序列化
            Assert.IsNotNull(lgret.Data);
            LGresult<object> lgretObject = LGjson.Deserialize<object>(lgret.Data);
            Assert.IsTrue(lgretObject.Code == 0);
            Assert.IsTrue(lgretObject.Data != null);
            Console.WriteLine("测试object，反序列化结果：" + LGjson.Serialize(lgretObject.Data).Data);

            //test dynamic
            dynamic dynamicObj = new { Code = 0, Message = "DynamicObj" };
            // 序列化
            lgret = LGjson.Serialize(dynamicObj);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试dynamic, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<dynamic> lgretDynamic = LGjson.Deserialize<dynamic>(lgret.Data);
            Assert.IsTrue(lgretDynamic.Code == 0);
            // Assert.IsTrue(lgretDynamic.Data == null); // dynamic默认是 JsonElement类型，判断非 null 要用 ValueKind
            Assert.IsTrue(lgretDynamic.Data is JsonElement); // 确认 Data 是 JsonElement 类型
            Assert.IsTrue(lgretDynamic.Data.ValueKind != JsonValueKind.Null); // 因为 dynamic 实际是 JsonElement，判断非 null 要用 ValueKind
            Console.WriteLine("测试dynamic, 反序列化结果: " + LGjson.Serialize(lgretDynamic.Data).Data);

            // test bool
            bool testBool = true;
            // 序列化
            lgret = LGjson.Serialize(testBool);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试bool, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<bool> lgretBool = LGjson.Deserialize<bool>(lgret.Data);
            Assert.IsTrue(lgretBool.Code == 0);
            Console.WriteLine("测试bool, 反序列化结果: " + LGjson.Serialize(lgretBool.Data).Data);

            // test byte
            byte testByte = 11;
            // 序列化
            lgret = LGjson.Serialize(testByte);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试byte, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<byte> lgretByte = LGjson.Deserialize<byte>(lgret.Data);
            Assert.IsTrue(lgretByte.Code == 0);
            Console.WriteLine("测试byte, 反序列化结果: " + LGjson.Serialize(lgretByte.Data).Data);
            // test sbyte
            sbyte testSbyte = 12;
            // 序列化
            lgret = LGjson.Serialize(testSbyte);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试sbyte, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<sbyte> lgretSbyte = LGjson.Deserialize<sbyte>(lgret.Data);
            Assert.IsTrue(lgretSbyte.Code == 0);
            Console.WriteLine("测试sbyte, 反序列化结果: " + LGjson.Serialize(lgretSbyte.Data).Data);

            // test short
            short testShort = 13;
            // 序列化
            lgret = LGjson.Serialize(testShort);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试short, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<short> lgretShort = LGjson.Deserialize<short>(lgret.Data);
            Assert.IsTrue(lgretShort.Code == 0);
            Console.WriteLine("测试short, 反序列化结果: " + LGjson.Serialize(lgretShort.Data).Data);
            // test ushort
            ushort testUshort = 14;
            // 序列化
            lgret = LGjson.Serialize(testUshort);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试ushort, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<ushort> lgretUshort = LGjson.Deserialize<ushort>(lgret.Data);
            Assert.IsTrue(lgretUshort.Code == 0);
            Console.WriteLine("测试ushort, 反序列化结果: " + LGjson.Serialize(lgretUshort.Data).Data);

            // 测试int
            int testInt = 15;
            // 序列化
            lgret = LGjson.Serialize(testInt);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试int, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<int> lgretInt = LGjson.Deserialize<int>(lgret.Data);
            Assert.IsTrue(lgretInt.Code == 0);
            Console.WriteLine("测试int, 反序列化结果: " + LGjson.Serialize(lgretInt.Data).Data);
            // test uint
            uint testUint = 16;
            // 序列化
            lgret = LGjson.Serialize(testUint);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试uint, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<uint> lgretUint = LGjson.Deserialize<uint>(lgret.Data);
            Assert.IsTrue(lgretUint.Code == 0);
            Console.WriteLine("测试uint, 反序列化结果: " + LGjson.Serialize(lgretUint.Data).Data);

            // test long
            long testLong = 17;
            // 序列化
            lgret = LGjson.Serialize(testLong);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试long, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<long> lgretLong = LGjson.Deserialize<long>(lgret.Data);
            Assert.IsTrue(lgretLong.Code == 0);
            Console.WriteLine("测试long, 反序列化结果: " + LGjson.Serialize(lgretLong.Data).Data);
            // test ulong
            ulong testUlong = 18;
            // 序列化
            lgret = LGjson.Serialize(testUlong);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试ulong, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<ulong> lgretUlong = LGjson.Deserialize<ulong>(lgret.Data);
            Assert.IsTrue(lgretUlong.Code == 0);
            Console.WriteLine("测试ulong, 反序列化结果: " + LGjson.Serialize(lgretUlong.Data).Data);

            // test float
            float testFloat = 19;
            // 序列化
            lgret = LGjson.Serialize(testFloat);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试float, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<float> lgretFloat = LGjson.Deserialize<float>(lgret.Data);
            Assert.IsTrue(lgretFloat.Code == 0);
            Console.WriteLine("测试float, 反序列化结果: " + LGjson.Serialize(lgretFloat.Data).Data);
            // test double
            double testDouble = 20;
            // 序列化
            lgret = LGjson.Serialize(testDouble);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试double, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<double> lgretDouble = LGjson.Deserialize<double>(lgret.Data);
            Assert.IsTrue(lgretDouble.Code == 0);
            Console.WriteLine("测试double, 反序列化结果: " + LGjson.Serialize(lgretDouble.Data).Data);

            // test decimal
            decimal testDecimal = 21;
            // 序列化
            lgret = LGjson.Serialize(testDecimal);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试decimal, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<decimal> lgretDecimal = LGjson.Deserialize<decimal>(lgret.Data);
            Assert.IsTrue(lgretDecimal.Code == 0);
            Console.WriteLine("测试decimal, 反序列化结果: " + LGjson.Serialize(lgretDecimal.Data).Data);

            // 测试枚举（Enum）
            TestEnum testEnum = TestEnum.Ok;
            // 序列化
            lgret = LGjson.Serialize(testEnum);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试枚举（Enum）, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<TestEnum> lgret9 = LGjson.Deserialize<TestEnum>(lgret.Data);
            Assert.IsTrue(lgret9.Code == 0);
            Console.WriteLine("测试枚举（Enum）, 反序列化结果: " + LGjson.Serialize(lgret9.Data).Data);

            // 测试本地时间（DateTime）， 跨时区（DateTimeOffset)
            DateTime testDateTime = DateTime.Now;
            DateTimeOffset testDateTimeOffset = DateTimeOffset.Now;
            // 序列化
            lgret = LGjson.Serialize(testDateTime);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试DateTime, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<DateTime> lgret11 = LGjson.Deserialize<DateTime>(lgret.Data);
            Assert.IsTrue(lgret11.Code == 0);
            Console.WriteLine("测试DateTime, 反序列化结果: " + lgret11.Data);
            // 序列化
            lgret = LGjson.Serialize(testDateTimeOffset);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试DateTimeOffset, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<DateTimeOffset> lgret12 = LGjson.Deserialize<DateTimeOffset>(lgret.Data);
            Assert.IsTrue(lgret12.Code == 0);
            Console.WriteLine("测试DateTimeOffset, 反序列化结果: " + lgret12.Data);

            // test 结构体类型TestStruct
            // 序列化
            TestStruct testStruct = new() { Code = 0, Message = "TestStruct success" };
            lgret = LGjson.Serialize(testStruct);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("TestStruct 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<TestStruct> lgret2 = LGjson.Deserialize<TestStruct>(lgret.Data);
            Assert.IsTrue(lgret2.Code == 0);
            Console.WriteLine("TestStruct 反序列化结果: " + LGjson.Serialize(lgret2.Data).Data);

            // test char
            char testChar = 'a';
            // 序列化
            lgret = LGjson.Serialize(testChar);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试char, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<char> lgretChar = LGjson.Deserialize<char>(lgret.Data);
            Assert.IsTrue(lgretChar.Code == 0);
            Console.WriteLine("测试char, 反序列化结果: " + LGjson.Serialize(lgretChar.Data).Data);
            // test string
            string testString = "hello";
            // 序列化
            lgret = LGjson.Serialize(testString);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试string, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<string> lgretString = LGjson.Deserialize<string>(lgret.Data);
            Assert.IsTrue(lgretString.Code == 0);
            Console.WriteLine("测试string, 反序列化结果: " + LGjson.Serialize(lgretString.Data).Data);

            // 测试Nullable 类型（可空值类型）
            // 序列化
            int? nullableInt = null;
            var lgretNullInt = LGjson.Serialize(nullableInt);
            Assert.IsTrue(lgretNullInt.Code == 100);
            Assert.IsTrue(lgretNullInt.Data == null);
            Console.WriteLine("测试Nullable 类型（可空值类型）, 序列化结果: " + lgretNullInt.Data);
            // 反序列化
            var ex = Assert.ThrowsException<System.ArgumentNullException>(() => LGjson.Deserialize<int?>(null!));
            Console.WriteLine("测试Nullable 类型（可空值类型）, 反序列化异常信息: " + ex.Message);

            // 测试class
            // 序列化
            TestClass testClass = new() { Code = 0, Message = "TestClass success" };
            lgret = LGjson.Serialize(testClass);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("TestClass 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<TestClass> lgret3 = LGjson.Deserialize<TestClass>(lgret.Data);
            Assert.IsTrue(lgret3.Code == 0);
            Assert.IsTrue(lgret3.Data != null);
            Console.WriteLine("TestClass 反序列化结果: " + LGjson.Serialize(lgret3.Data).Data);

            // 测试匿名类型
            // 序列化
            var unsupportedType = new { Code = -1, Message = "匿名类型" };
            lgret = LGjson.Serialize(unsupportedType);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("匿名类型 序列化结果: " + lgret.Data);
            // 反序列化: System.Text.Json 反序列化成 dynamic 时，默认内部是 JsonElement 类型, JsonElement 是 值类型 struct
            LGresult<dynamic> lgret4 = LGjson.Deserialize<dynamic>(lgret.Data);
            Assert.IsTrue(lgret4.Code == 0);
            //Assert.IsTrue(lgret4.Data != null);  // dynamic 是值类型 struct, 不能直接判断是否为 null
            Assert.IsTrue(lgret4.Data is JsonElement); // 确认 Data 是 JsonElement 类型
            Assert.IsTrue(lgret4.Data.ValueKind != JsonValueKind.Null);  // 因为 dynamic 实际是 JsonElement，判断非 null 要用 ValueKind
            Console.WriteLine("匿名类型 反序列化结果: " + LGjson.Serialize(lgret4.Data).Data);

            // 测试嵌套类(复杂对象)
            // 序列化
            OuterClass outer = new()
            {
                Id = 1,
                Inner = new TestClass { Code = 2, Message = "Inner" },
                StructList = [new TestStruct { Code = 3, Message = "Struct1" }, new TestStruct { Code = 4, Message = "Struct2" }]
            };
            lgret = LGjson.Serialize(outer);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试嵌套类(复杂对象), OuterClass 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<OuterClass> lgret8 = LGjson.Deserialize<OuterClass>(lgret.Data);
            Assert.IsTrue(lgret8.Code == 0);
            Assert.IsTrue(lgret8.Data != null);
            Console.WriteLine("测试嵌套类(复杂对象), OuterClass 反序列化结果: " + LGjson.Serialize(lgret8.Data).Data);

            // 测试集合类List
            // 序列化
            List<TestClass> testList =
            [
                new TestClass() { Code = 0, Message = "TestClass1" },
                new TestClass() { Code = 1, Message = "TestClass2" }
            ];
            lgret = LGjson.Serialize(testList);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("List<TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<List<TestClass>> lgret5 = LGjson.Deserialize<List<TestClass>>(lgret.Data);
            Assert.IsTrue(lgret5.Code == 0);
            Assert.IsTrue(lgret5.Data != null);
            Console.WriteLine("List<TestClass> 反序列化结果: " + LGjson.Serialize(lgret5.Data).Data);
            // 测试集合类 IList
            IList<TestClass> testIList = testList;
            lgret = LGjson.Serialize(testIList);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("IList<TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<IList<TestClass>> lgretIList = LGjson.Deserialize<IList<TestClass>>(lgret.Data);
            Assert.IsTrue(lgretIList.Code == 0);
            Assert.IsTrue(lgretIList.Data != null);
            Console.WriteLine("IList<TestClass> 反序列化结果: " + LGjson.Serialize(lgretIList.Data).Data);

            // 测试集合类Dictionary
            // 序列化
            Dictionary<string, TestClass> testDict = new()
            {
                { "key1", new TestClass() { Code = 0, Message = "TestClass1" } },
                { "key2", new TestClass() { Code = 1, Message = "TestClass2" } }
            };
            lgret = LGjson.Serialize(testDict);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("Dictionary<string, TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<Dictionary<string, TestClass>> lgret6 = LGjson.Deserialize<Dictionary<string, TestClass>>(lgret.Data);
            Assert.IsTrue(lgret6.Code == 0);
            Assert.IsTrue(lgret6.Data != null);
            Console.WriteLine("Dictionary<string, TestClass> 反序列化结果: " + LGjson.Serialize(lgret6.Data).Data);

            // test 测试集合类:枚举迭代器 IEnumerator<T>
            IEnumerator<TestClass> testIEnumerator = testList.GetEnumerator();
            lgret = LGjson.Serialize(testIEnumerator);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("IEnumerator<TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            var ex3 = Assert.ThrowsException<JsonException>(() => LGjson.Deserialize<IEnumerator<TestClass>>(""));
            Console.WriteLine("反序列化不支持的类型IEnumerator时抛出异常6: " + ex3.Message);

            // 测试集合类 IEnumerable
            // 序列化
            IEnumerable<TestClass> testIEnumerable = testList;
            lgret = LGjson.Serialize(testIEnumerable);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("IEnumerable<TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            var ex4 = Assert.ThrowsException<JsonException>(() => LGjson.Deserialize<IEnumerable<TestClass>>(""));
            Console.WriteLine("反序列化不支持的类型IEnumerable时抛出异常7: " + ex4.Message);

            // 测试集合类 ICollection
            // 序列化
            ICollection<TestClass> testICollection = testList;
            lgret = LGjson.Serialize(testICollection);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("ICollection<TestClass> 序列化结果: " + lgret.Data);
            // 反序列化
            var ex5 = Assert.ThrowsException<JsonException>(() => LGjson.Deserialize<ICollection<TestClass>>(""));
            Console.WriteLine("反序列化不支持的类型ICollection时抛出异常8: " + ex5.Message);

            // 测试集合类数组
            // 序列化
            TestClass[] testArray =
            [
                new TestClass() { Code = 0, Message = "TestClass1" },
                new TestClass() { Code = 1, Message = "TestClass2" }
            ];
            lgret = LGjson.Serialize(testArray);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("TestClass[] 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<TestClass[]> lgret7 = LGjson.Deserialize<TestClass[]>(lgret.Data);
            Assert.IsTrue(lgret7.Code == 0);
            Assert.IsTrue(lgret7.Data != null);
            Console.WriteLine("TestClass[] 反序列化结果: " + LGjson.Serialize(lgret7.Data).Data);

            // test Tuple, 是引用类型（class），继承自 System.Tuple 抽象类，实例存储在堆上
            // 序列化
            Tuple<int, string> testTuple = Tuple.Create(1, "Test");
            lgret = LGjson.Serialize(testTuple);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("Tuple<int, string> 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<Tuple<int, string>> lgretTuple = LGjson.Deserialize<Tuple<int, string>>(lgret.Data);
            Assert.IsTrue(lgretTuple.Code == 0);
            Assert.IsTrue(lgretTuple.Data != null);
            Console.WriteLine("Tuple<int, string> 反序列化结果: " + lgretTuple.Data);
            // 确认反序列化后的元组元素
            Assert.IsTrue(lgretTuple.Data.Item1 == 1);
            Assert.IsTrue(lgretTuple.Data.Item2 == "Test");

            // test ValueTuple, 是值类型（struct），定义在 System 命名空间下，实例存储在栈上
            var options = new JsonSerializerOptions
            {
                // ValueTuple 默认是 字段（Field），而 System.Text.Json 默认只序列化 公共属性（public property），不会序列化字段
                IncludeFields = true
            };
            ValueTuple<int, string> testValueTuple = (1, "Test");
            // 序列化
            lgret = LGjson.Serialize(testValueTuple, options);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("ValueTuple<int, string> 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<ValueTuple<int, string>> lgretValueTuple = LGjson.Deserialize<ValueTuple<int, string>>(lgret.Data, options);
            Assert.IsTrue(lgretValueTuple.Code == 0);
            // Assert.IsTrue(lgretValueTuple.Data != null); // 不能用这个判断，因为ValueTuple是值类型，反序列化后，值会被赋值，不会为null。
            // 用下面的判断方法来判断是否反序列化成功
            Assert.IsTrue(lgretValueTuple.Data.Item1 == 1);
            Assert.IsTrue(lgretValueTuple.Data.Item2 == "Test");
            Console.WriteLine("ValueTuple<int, string> 反序列化结果: " + lgretValueTuple.Data);

            // 测试Guid
            Guid testGuid = Guid.NewGuid();
            // 序列化
            lgret = LGjson.Serialize(testGuid);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试Guid, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<Guid> lgret13 = LGjson.Deserialize<Guid>(lgret.Data);
            Assert.IsTrue(lgret13.Code == 0);
            Console.WriteLine("测试Guid, 反序列化结果: " + lgret13.Data);

            // Dictionary<string, object>（弱类型对象）
            Dictionary<string, object> dict = new()
            {
                { "Name", "LG" },
                { "Age", 100 },
                { "IsMale", true }
            };
            // 序列化
            lgret = LGjson.Serialize(dict);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            Console.WriteLine("测试Dictionary<string, object>, 序列化结果: " + lgret.Data);
            // 反序列化
            LGresult<Dictionary<string, object>> lgret14 = LGjson.Deserialize<Dictionary<string, object>>(lgret.Data);
            Assert.IsTrue(lgret14.Code == 0);
            Console.WriteLine("测试Dictionary<string, object>, 反序列化结果: " + LGjson.Serialize(lgret14.Data).Data);
        }
        #endregion

        // 反序列化测试：JSON 结构不完整（缺失字段）,这个其实不会抛异常（会用默认值填充），但值得测试.
        [TestMethod]
        public void LGjson_Deserialize_IncompleteStructure()
        {
            // 反序列化：JSON 结构不完整（缺失字段），缺失第一个字段。
            string jsonMissingField = "{\"Code\":123}";
            LGresult<TestClass> lgret = LGjson.Deserialize<TestClass>(jsonMissingField);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsNotNull(lgret.Data);
            Assert.AreEqual(123, lgret.Data.Code);
            Assert.AreEqual(string.Empty, lgret.Data.Message); // 默认值
            Console.WriteLine("TestClass 反序列化结果：" + LGjson.Serialize(lgret.Data).Data);
            // 反序列化：JSON 结构不完整（缺失字段），缺失第二个字段。
            jsonMissingField = "{\"Message\":\"Hello\"}";
            lgret = LGjson.Deserialize<TestClass>(jsonMissingField);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsNotNull(lgret.Data);
            Assert.AreEqual(0, lgret.Data.Code); // 默认值
            Assert.AreEqual("Hello", lgret.Data.Message);
            Console.WriteLine("TestClass 反序列化结果：" + LGjson.Serialize(lgret.Data).Data);
        }

        [TestMethod]
        public void LGjson_ClassIsNull_Test()
        {
            // 序列化，测试class为null的情况  
            TestClass? testClass = null;
            LGresult<string> lgret = LGjson.Serialize(testClass);
            Assert.IsTrue(lgret.Code != 0);
            Assert.IsTrue(lgret.Code == 100);
            Assert.IsTrue(lgret.Data == null);
            Console.WriteLine("testClass 序列化结果: " + lgret.Data);
            // 反序列化，json串为 "null" 的情况
            string jsonNull = "null";
            LGresult<TestClass> lgret2 = LGjson.Deserialize<TestClass>(jsonNull);
            Assert.IsTrue(lgret2.Code != 0);
            Assert.IsTrue(lgret2.Code == 100);
            Assert.IsTrue(lgret2.Data == null);
            Console.WriteLine("testClass 反序列化结果: " + LGjson.Serialize(lgret2.Data).Data);
        }

        #region 异常测试
        // 测试序列化异常
        [TestMethod]
        public void LGjson_SerializeException_Test()
        {
            // 序列化异常测试
            // 异常1: 循环引用
            TestNode node1 = new() { Name = "Node1" };
            TestNode node2 = new() { Name = "Node2", Next = node1 };
            node1.Next = node2; // 创建循环引用
            var ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Serialize(node1));
            Console.WriteLine("序列化循环引用时抛出异常1: " + ex.Message);

            // 异常2：不支持的类型（IntPtr，type）, System.NotSupportedException
            TestIntPtr testIntPtr = new() { Handle = new IntPtr(12345) };
            var ex2 = Assert.ThrowsException<NotSupportedException>(() => LGjson.Serialize(testIntPtr));
            Console.WriteLine("序列化不支持的类型时抛出异常2: " + ex2.Message);
            TestType testType = new() { TypeInfo = typeof(TestClass) };
            ex2 = Assert.ThrowsException<NotSupportedException>(() => LGjson.Serialize(testType));
            Console.WriteLine("序列化不支持的类型时抛出异常2: " + ex2.Message);

        }

        // 反序列化异常测试
        [TestMethod]
        public void LGjson_ClassExcetion_Test()
        {
            string str = string.Empty;
            // 反序列化，异常情况：json串为 "" 或者其他字符串的情况
            // 异常1: 无效的json tokens
            var ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Deserialize<TestClass>(str));
            Console.WriteLine("反序列化空字符串时抛出异常1: " + ex.Message);
            // 异常2: json串格式不正确时异常: H是无效的开头。
            str = "Hello.";
            ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Deserialize<TestClass>(str));
            Console.WriteLine("反序列化无效json时抛出异常2: " + ex.Message);
            // 异常3：字段对应的类型不匹配，不能正确的转换。
            str = "{\"Code\":\"abc\"}";
            ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Deserialize<TestClass>(str));
            Console.WriteLine("反序列化无效json时抛出异常1: " + ex.Message);
            str = "[1,2,3]";
            ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Deserialize<TestClass>(str));
            Console.WriteLine("反序列化数组时抛出异常3: " + ex.Message);
            // 异常4：JSON 字符串编码或格式错误
            string jsonBadFormat = "{\"Code\":123, \"Message\":\"abc\""; // 缺少结束大括号
            ex = Assert.ThrowsException<System.Text.Json.JsonException>(() => LGjson.Deserialize<TestClass>(jsonBadFormat));
            Console.WriteLine("反序列化数字时抛出异常4: " + ex.Message);
            // 异常5：Nullable 类型（可空值类型）
            var ex2 = Assert.ThrowsException<System.ArgumentNullException>(() => LGjson.Deserialize<TestClass>(null!));
            Console.WriteLine("反序列化null时抛出异常5: " + ex2.Message);
            // 异常6：反序列化不支持的类型IEnumerator
            var ex3 = Assert.ThrowsException<JsonException>(() => LGjson.Deserialize<IEnumerator<TestClass>>(""));
            Console.WriteLine("反序列化不支持的类型IEnumerator时抛出异常6: " + ex3.Message);
        }
        #endregion

        #region Serialize options 测试
        // Serialize 的options 参数测试： 默认情况
        [TestMethod]
        public void LGjson_SerializeOptions_Default_Test()
        {
            LGresult<string> lgret;
            // 测试1：options默认值测试
            TestClass testClass = new() { Code = 123, Message = "你好。" };
            lgret = LGjson.Serialize(testClass);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            // 默认 Encoder = UnsafeRelaxedJsonEscaping，所以应该是原始 "你好。"
            StringAssert.Contains(lgret.Data, "你好。");
            // 默认 WriteIndented = false，所以应该没有换行符
            Assert.IsFalse(lgret.Data.Contains('\n'));
            Console.WriteLine("测试options，输出：" + lgret.Data);
        }
        // Serialize 的options 参数测试： 自定义情况
        [TestMethod]
        public void LGjson_SerializeOptions_Custom_Test()
        {
            LGresult<string> lgret;
            // 自定义options：WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                // Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin) // 中文会被转义

            };
            // 测试2：自定义options测试
            TestClass testClass = new() { Code = 123, Message = "张三" };
            lgret = LGjson.Serialize(testClass, options);
            Assert.IsTrue(lgret.Code == 0);
            Assert.IsTrue(lgret.Data != null);
            // 自定义options：WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            // 所以应该是原始 "张三"
            StringAssert.Contains(lgret.Data, "\\u5F20");
            StringAssert.Contains(lgret.Data, "\\u4E09");
            // 自定义options：WriteIndented = true, 所以应该有换行符
            Assert.IsTrue(lgret.Data.Contains('\n'));
            Console.WriteLine("测试options，输出：" + lgret.Data);
        }
        #endregion
    }
}
