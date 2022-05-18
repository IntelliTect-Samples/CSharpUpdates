using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpUpdates.v11;

[TestClass]
public class StringEnhancementTests
{
    [TestMethod]
    public void SpanLinesWithInterpolatedStrings()
    {
        string name = "Inigo Montoya";
        string greeting = $"Hello! My name is {
            name}.";
        Assert.AreEqual<string>($"Hello! My name is Inigo Montoya.",
            greeting);
    }

    [TestMethod]
    public void RawStringLiteralsWithIndenting()
    {
        string expected = $"    My name is Inigo Montoya.{
            Environment.NewLine}    You killed my father.{
            Environment.NewLine}    Prepare to die!";
        string text = """"
                My name is Inigo Montoya.
                You killed my father.
                Prepare to die!
            """";
        Assert.AreEqual<string>(
            expected, text);
        Assert.AreNotEqual<char>(
            '\n', text[^1]);
    }

    [TestMethod]
    public void RawStringLiteralsWithNumerousQuotes()
    {
        string expected = $"    My name is Inigo Montoya.{Environment.NewLine}    You killed my father.{Environment.NewLine}    Prepare to die!";
        string text = """""
                My name is Inigo Montoya.
                You killed my father.
                Prepare to die!
            """"";
        Assert.AreEqual<string>(
            expected, text);
        Assert.AreNotEqual<char>(
            '\n', text[^1]);
    }

    [TestMethod]
    public void RawStringLiteralsWithSpecialCharacters()
    {
        string expected = $"\\tMy name is Inigo Montoya.{
            Environment.NewLine}\tYou killed my father.{
            Environment.NewLine}Prepare to die!";
        string text = """""
            \tMy name is Inigo Montoya.
            	You killed my father.
            Prepare to die!
            """"";
        Assert.AreEqual<string>(
            expected, text);
    }

    [TestMethod]
    public void RawStringLiteralsWithStringInterpolation()
    {
        string name = "Inigo Montoya";
        string expected = $"My name is \"\"\"{{{name}}}\"\"\".{Environment.NewLine}You killed my father.{Environment.NewLine}Prepare to die!";
        string text = $$""""
            My name is """{{{name}}}""".
            You killed my father.
            Prepare to die!
            """";
        Assert.AreEqual<string>(
            expected, text);
    }
}
