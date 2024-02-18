using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject CreepPrefab;
    [SerializeField] public GameObject player;
    private GameObject curCreep;

    public int width = 10;
    public int height = 4;

    void Start()
    {
        for (int y = 0; y < height; y += 2)
        {
            for (int x = 0; x < width; x += 2)
            {
                curCreep = Instantiate(CreepPrefab, new Vector3(x, y, 0), Quaternion.identity);
                curCreep.GetComponent<EnemyMovement>().player = this.player; 
            }
        }
    }
}