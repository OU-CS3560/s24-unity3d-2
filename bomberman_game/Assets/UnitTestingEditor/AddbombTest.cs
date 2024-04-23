using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AddbombTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void Extra_Bombs_Test()
    {
        //Arrange

        var powerupsobject = new GameObject("Extra Bombs Powerup Test");
        var powerupscomponent = powerupsobject.AddComponent<Powerups>();
        powerupscomponent.type = Powerups.ItemType.ExtraBombs;

        powerupscomponent.EnemyPrefab = null;

        BoxCollider2D collider = powerupsobject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2 (1f, 1f);

        var playerGO = new GameObject("Player");
        var bombcomponent = playerGO.AddComponent<Bomb>();
        bombcomponent.bombs_had = 1;

        //Act
        powerupscomponent.OnItemPickUp(playerGO);

        //Assert
        Assert.AreEqual(2, bombcomponent.bombs_had, "Bombs had amount should increase by 1");
        
        //Clean Up
        GameObject.DestroyImmediate(powerupsobject);
        GameObject.DestroyImmediate(playerGO);

    }

    [Test]
    public void Blast_Radius_Test()
    {
        //Arrange

        var powerupsobject = new GameObject("Increae blast radius Powerup Test");
        var powerupscomponent = powerupsobject.AddComponent<Powerups>();
        powerupscomponent.type = Powerups.ItemType.BlastRadius;

        powerupscomponent.EnemyPrefab = null;

        BoxCollider2D collider = powerupsobject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1f, 1f);

        var playerGO = new GameObject("Player");
        var bombcomponent = playerGO.AddComponent<Bomb>();
        bombcomponent.explosion_radius = 1;

        //Act
        powerupscomponent.OnItemPickUp(playerGO);

        //Assert
        Assert.AreEqual(2, bombcomponent.explosion_radius, "Explosion Radius should increase by 1");

        //Clean Up
        GameObject.DestroyImmediate(powerupsobject);
        GameObject.DestroyImmediate(playerGO);

    }

    [Test]
    public void Bomb_pushing_Test()
    {
        //Arrange

        var powerupsobject = new GameObject("Allow bomb pushing Powerup Test");
        var powerupscomponent = powerupsobject.AddComponent<Powerups>();
        powerupscomponent.type = Powerups.ItemType.Bombpush;

        powerupscomponent.EnemyPrefab = null;

        BoxCollider2D collider = powerupsobject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1f, 1f);

        var playerGO = new GameObject("Player");
        var playercomponent = playerGO.AddComponent<MovementController>();
        playercomponent.player = playerGO.GetComponent<Rigidbody2D>();
        playercomponent.player.mass = 1;

        //Act
        powerupscomponent.OnItemPickUp(playerGO);

        //Assert
        Assert.AreEqual(1000000, playercomponent.player.mass, "Player mass should increase then allow to push");

        //Clean Up
        GameObject.DestroyImmediate(powerupsobject);
        GameObject.DestroyImmediate(playerGO);

    }

    [Test]
    public void Shield_Test()
    {
        //Arrange

        var powerupsobject = new GameObject("Shield Powerup Test");
        var powerupscomponent = powerupsobject.AddComponent<Powerups>();
        powerupscomponent.type = Powerups.ItemType.Shield;

        powerupscomponent.EnemyPrefab = null;

        BoxCollider2D collider = powerupsobject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1f, 1f);

        var playerGO = new GameObject("Player");
        var playercomponent = playerGO.AddComponent<MovementController>();
        playercomponent.player = playerGO.GetComponent<Rigidbody2D>();
        playercomponent.shield = false;

        //Act
        powerupscomponent.OnItemPickUp(playerGO);

        //Assert
        Assert.IsTrue(playercomponent.shield, "Shield should be true after pickup");

        //Clean Up
        GameObject.DestroyImmediate(powerupsobject);
        GameObject.DestroyImmediate(playerGO);

    }
}
