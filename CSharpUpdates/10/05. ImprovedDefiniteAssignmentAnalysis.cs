using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialCSharp10.Tests;

public static class StringNormalizationExtensions
{
    public static bool TryIntParse(this string text, out int number) =>
        int.TryParse(text, out number);
}

[TestClass]
public class ImprovedDefiniteAssignmentAnalysisTests
{
    [TestMethod]
    public void TryIntParse_WithNullCoalesceOperator_Compiles()
    {
        string text = "forty-two";
        if (text?.TryIntParse(out int number) == true)
        {
            number.ToString(); // Undefined CS0165 no longer occurs
        }
    }
}