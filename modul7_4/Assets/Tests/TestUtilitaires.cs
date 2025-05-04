using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestUtilitaires
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void TestUtilitairesSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    [Test]
    public void TestQuiNePassePas()
    {
       Assert.AreEqual(5,2+2);
    }

    [Test]
    public void PlusGrandElementTableau()
    {
        //Arrange
        int[] tableau = {1,2,3,4,5};
        //Act
        int index = Utilitaires1.PlusGrandElementTableau(tableau);
        //Assert
        Assert.AreEqual(4,index);
    }

    [Test]
    public void PremierElementTableau()
    {
        //Arrange
        int[] tableau = {1,2,3,4,5};
        //Act
        int premierElement = Utilitaires1.PremierElementTableau(tableau);
        //Assert
        Assert.AreEqual(1,premierElement);
    }


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestUtilitairesWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
