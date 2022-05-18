namespace CSharpUpdates.v08;

// Generic attributes are now supported in C# 11.
public class ExpectedExceptionAttribute<T> : Attribute
{
}

[TestClass]
public class SampleTests
{
    [ExpectedException<ArgumentNullException>()]
    public void SampleTest() { }
}