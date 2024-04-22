using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WinnerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BlackChickenWins()
    {
        // Use the Assert class to test conditions
        var gameObject = new GameObject();
        var win_script = gameObject.AddComponent<WinnerScript>();
        Assert.AreEqual("BLACK CHICKEN WINS!", win_script.who_win(2, 1));
    }
    [Test]
    public void WhiteChickenWins()
    {
        // Use the Assert class to test conditions
        var gameObject = new GameObject();
        var win_script = gameObject.AddComponent<WinnerScript>();
        Assert.AreEqual("WHITE CHICKEN WINS!", win_script.who_win(4, 8));
    }
    [Test]
    public void TieGame()
    {
        // Use the Assert class to test conditions
        var gameObject = new GameObject();
        var win_script = gameObject.AddComponent<WinnerScript>();
        Assert.AreEqual("TIE!", win_script.who_win(4, 4));
    }
}
