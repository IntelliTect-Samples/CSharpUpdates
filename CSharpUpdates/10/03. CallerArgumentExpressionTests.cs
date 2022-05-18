using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EssentialCSharp10.Tests;

[TestClass]
public class SampleUnitTest
{
    class Person
    {
        public Person(string name) { Name = name; }

        // Add validation that ensures Name will not be null.
        public string Name 
        { 
            get => _Name!;
            set => _Name = 
                NotNull(value);
            
        }
        private string? _Name;
    }

    [TestMethod]
    public void NotNull_GivenNullForName_BreakOnNameProperty()
    {
        _ = new Person(null);
    }
}
