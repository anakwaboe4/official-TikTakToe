using System.Linq;
using TikTakToe.Core.Enums;
using TikTakToe.Engines;
using TikTakToe.Engines.Engines.perfectOpertunism;

namespace EngineTestFramework
{
    [TestClass]
    public class EngineInterfaceTest
    {
        private List<IEngine> engines;

        public EngineInterfaceTest()
        {
            engines = new List<IEngine>
            {
                new PerfectOpertunism(),
                new TikTakToe.Engines.Engines.random.random()
            };
        }

        [TestMethod]
        public void TestEachClassHasEnumProperty()
        {
            foreach(var engine in engines)
            {
                var enumValue = engine.Engine;
                Assert.IsNotNull(enumValue, $"Engine property is null in class: {engine.GetType().Name}");
                Assert.IsTrue(enumValue.GetType() == typeof(Engines), $"Invalid type for Engine property in class: {engine.GetType().Name}");
            }
        }

        [TestMethod]
        public void TestNoDuplicateEnumValues()
        {
            var usedEnumValues = new List<Engines>();

            foreach(var engine in engines)
            {
                var enumValue = engine.Engine;
                Assert.IsFalse(usedEnumValues.Contains(enumValue), $"Duplicate use of enum value: {enumValue} in class: {engine.GetType().Name}");
                usedEnumValues.Add(enumValue);
            }
        }

        [TestMethod]
        public void TestAllEnumValuesPresentInClassNames()
        {
            var enumValues = Enum.GetValues(typeof(Engines))
                .Cast<Engines>()
                .Where(e => e != Engines.Player);

            var missingEnumValues = enumValues.Where(enumValue => !engines.Any(engine => engine.Engine == enumValue));
            Assert.IsFalse(missingEnumValues.Any(), $"Missing enum values in classes: {string.Join(", ", missingEnumValues)}");
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
