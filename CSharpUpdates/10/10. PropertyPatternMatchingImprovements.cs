using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialCSharp10.Tests;

[TestClass]
public class PropertyPatternMatchingImprovements
{
    public record LineItem(Guid ProductId, double Quantity) { }
    public record Order(
        int OrderNumber, string CustomerName, List<LineItem> Items) {}

    // Complete assignment below before present C# 10 syntax.

    record class Person(string Name){}
    static Person AssertValidPerson(Person person)
    {
        // Assignment
        // Check that Person name is not null or zero length using
        // C# 8.0 pattern matching.
        if(person == null)
        {
            throw new InvalidOperationException(
                @$"Invalid {
                    nameof(Person.Name)}.");
        }
        return person;
    }

    [TestMethod]
    public void PropertyPatternMatching_GivenPersonWithValidName_Success()
    {
        Person person = new("Inigo Montoya");

        AssertValidPerson(person);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PropertyPatternMatching_GivenPersonWithEmptyName_Trhow()
    {
        Person person = new("");

        AssertValidPerson(person);
    }

}