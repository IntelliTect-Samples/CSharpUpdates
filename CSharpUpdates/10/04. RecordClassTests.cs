using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialCSharp10.Tests;

public class RecordClassTests
{
    // Write a test to verify the constructor behavior.

    // Write a test to verify whether the struct is read-only or not?
    // Modify the record so it is the opposite of the way it starts read-only => read/write or vice-versa

    // Modify the Minutes so they are "init" only.
    // Write tests to demonstrate the difference between init and read-only properties.

    // Write a test to verify the behavior of the ToString() method.

    // Write a method that modifies seconds and verify the behavior

    // Write a test to verify the behavior of the deconstructor (both to variables and a typle).

    // EXTRA CREDIT: Implement a + operator for the following test.
    [TestMethod]
    [DataRow(0,0,0,          0,0,0,      0,0,0)]
    [DataRow(359, 59, 0,     0,1,0,      0,0,0)]
    [DataRow(360,59,59,      0,1,1,      1,1,0)]
    [DataRow(359,59,59,      0,1,1,      0,1,0)]
    public void PlusOperator(
        int firstDegrees, int firstMinutes, int firstSeconds,
        int secondDegrees, int secondMinutes, int secondSeconds, 
        int sumDegrees, int sumMinutes, int sumSeconds)
    {
        //Assert.AreEqual(
        //    new Angle(sumDegrees, sumMinutes, sumSeconds),
        //    new Angle(firstDegrees, firstMinutes, firstSeconds) 
        //        + new Angle (secondDegrees, secondMinutes, secondSeconds)
        //);
    }
}
