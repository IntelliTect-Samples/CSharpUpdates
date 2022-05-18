#region TurnOffCodeWarningsUntilIGetAroungToFixingThemNextTimeIEditTheFile
//#pragma warning disable CS0219 // Variable is assigned but its value is never used
#endregion // TurnOffCodeWarningsUntilIGetAroungToFixingThemNextTimeIEditTheFile
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CSharpUpdates.v08;

//namespace BobsYourUncle
//{ }

[TestClass]
public class NullableReferenceTypeTests
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Address? Address { get; set; }
    }
    public class Address
    {

        public Address(string street1, string? street2, string city, string state, string zip, string country) =>
                    (Street1, Street2, City, State, Zip, Country) = (street1, street2, city, state, zip, country);

        private string? _Street1;
        public string Street1
        {
            get => _Street1!;
            private set => _Street1=value??throw new ArgumentNullException(nameof(value));
        }

        private string? _Street2;
        public string Street2
        {
            get => _Street2!;
            private set => _Street2=value??throw new ArgumentNullException(nameof(value));
        }
        private string? _City;
        public string City
        {
            get => _City!;
            private set => _City=value??throw new ArgumentNullException(nameof(value));
        }
        private string? _State;
        public string State
        {
            get => _State!;
            private set => _State=value??throw new ArgumentNullException(nameof(value));
        }


        private string? _Zip;
        public string Zip 
        { 
            get => _Zip!; 
            private set => _Zip=value??throw new ArgumentNullException(nameof(value)); 
        }

        private string? _Country;
        public string Country
        {
            get => _Country!;
            private set => _Country=value??throw new ArgumentNullException(nameof(value));
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    [ExpectedException<ArgumentNullException>()]
    public void Address_Create_Success()
    {
        // Without a constructor, read only properties cannot be set - even in initializers
        // Address add = new Address() { City = "Stokholm" };
        _ = new Address(
            street1: "10 Downing Street",
            street2: null,
            city: "London",
            state: "",
            zip: "99035",
            country: "United Kingdom");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Address_CreateWitNullZip_ThrowException()
    {
        // Without a constructor, read only properties cannot be set - even in initializers
        // Address add = new Address() { City = "Stokholm" };
        _ = new Address(
            street1: "10 Downing Street",
            street2: null,
            city: "London",
            state: "",
            zip: null!,
            country: "United Kingdom");
    }

    [TestMethod]
    public void ReferenceEquals_GivenNull_NullCheckNotDetected()
    {
        string? text = null;
        Assert.AreEqual<int>(0, text.Length);
        if (DateTime.Now != DateTime.Now)  // Fool the compiler
        {
            text = "";
        }
        Assert.AreEqual<int>(0, text!.Length);
        Assert.AreEqual<int?>(0, text?.Length);
        Assert.AreEqual<int?>(0, text == null?null:text.Length);
        if (text == null)
        {
            text = "";
        }
        Assert.AreEqual<int>(0, text.Length);
    }

    [TestMethod]
    public void NullableGenericStruct()
    {
        Nullable<int> number1 = 42;
        int? number2 = 77;
        Assert.AreEqual<Type>(number1.GetType(), number2.GetType());
    }

    [TestMethod]
    public void NullableReferenceType()
    {
        string text1 = "Inigo";
        string? text2 = "Princess Buttercup";
        Assert.AreEqual<Type>(text1.GetType(), text2.GetType());
    }
}
