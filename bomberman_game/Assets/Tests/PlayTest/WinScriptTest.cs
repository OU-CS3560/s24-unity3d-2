// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;

// public class NewTestScript
// {
//     // `yield return null;` to skip a frame.
//     [UnityTest]
//     public IEnumerator Player1Wins()
//     {
//         // Use the Assert class to test conditions.
//         // Use yield to skip a frame.

//         //Setup
//         var gameObject = new GameObject();
//         var win_script = gameObject.AddComponent<WinnerScript>();

//         var player1 = gameObject.AddComponent<MovementController>();
//         var player2 = gameObject.AddComponent<MovementController>();

//         player1.deaths = 0;
//         player2.deaths = 1;

//         yield return null;

//         Assert.AreEqual("WHITE CHICKEN WINS!", win_script.who_win(player1, player2));


//     }
// }
