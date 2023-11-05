namespace EngineTestFramework
{
    [TestClass]
    public class EngineInterfaceTest
    {
        private List<string> classNames;
        public EngineInterfaceTest()
        {
            classNames = new List<string>
            {
                "TikTakToe.Engines.Engines.perfectOpertunism.PerfectOpertunism",
                "TikTakToe.Engines.Engines.random.random",
            };
        }
        [TestMethod]
        public void TestEachClassHasEnumProperty()
        {
            foreach(var className in classNames)
            {
                Type type = Type.GetType(className);

                if(type != null)
                {
                    var enumProperty = type.GetProperty("Engine");
                    Assert.IsNotNull(enumProperty, $"Missing 'Engine' property in class: {className}");
                    Assert.IsTrue(enumProperty.PropertyType == typeof(TikTakToe.Core.Enums.Engines), $"Invalid type for 'Engine' property in class: {className}");
                }
                else
                {
                    Assert.Fail($"Type not found: {className}");
                }
            }
        }


        [TestMethod]
        public void TestNoDuplicateEnumValues()
        {
            var enumValues = Enum.GetValues(typeof(TikTakToe.Core.Enums.Engines))
                .Cast<TikTakToe.Core.Enums.Engines>()
                .Where(e => e != TikTakToe.Core.Enums.Engines.Player);

            var usedEnumValues = new List<TikTakToe.Core.Enums.Engines>();

            foreach(var className in classNames)
            {
                Type type = Type.GetType(className);
                if(type != null)
                {
                    var enumProperty = type.GetProperty("Engine");
                    var enumValue = (TikTakToe.Core.Enums.Engines)enumProperty.GetValue(Activator.CreateInstance(type));
                    Assert.IsFalse(usedEnumValues.Contains(enumValue), $"Duplicate use of enum value: {enumValue} in class: {className}");
                    usedEnumValues.Add(enumValue);
                }
            }
        }


        [TestMethod]
        public void TestAllEnumValuesPresentInClassNames()
        {
            var enumValues = Enum.GetValues(typeof(TikTakToe.Core.Enums.Engines))
                .Cast<TikTakToe.Core.Enums.Engines>()
                .Where(e => e != TikTakToe.Core.Enums.Engines.Player);

            var missingEnumValues = enumValues.Where(enumValue => !classNames.Any(className => className.Contains(enumValue.ToString())));
            Assert.IsFalse(missingEnumValues.Any(), $"Missing enum values in class names: {string.Join(", ", missingEnumValues)}");
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}