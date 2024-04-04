using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject CreepPrefab;
    [SerializeField] public GameObject player;
    [SerializeField] public LayerMask grid_layer;

    private GameObject curCreep;

    public int width = 10;
    public int height = 4;
    GameObject[] blocks;

    void Start()
    {
        int maxY = 2, minY = -10;
        int maxX = 5, minX = -7;
        /*
        for (int i = 0; i < this.blocks.Length; i++)
        {
            var tmp = blocks[i].transform.position;
            print(tmp.x);
            if (maxY < tmp.y) maxY = (int)tmp.y;
            if (maxX < tmp.x) maxX = (int)tmp.x;
            if (minY > tmp.y) minY = (int)tmp.y;
            if (minX > tmp.x) minX = (int)tmp.x;

        }*/
        // y is up/down a.k.a row
        /*
        for (int y = minY; y < maxY; y += 2)
        {
            for (int x = minX; x < maxX; x += 2)
            {
                if (!isBlock(x, y))
                {
                    curCreep = Instantiate(CreepPrefab, new Vector3(x, y, 0), Quaternion.identity);
                    curCreep.GetComponent<Pathfinding.AIDestinationSetter>().target = this.player.transform;
                }
            }
        }*/
    }
    bool isBlock(int x, int y)
    {
        if (Physics2D.OverlapBox(new Vector2(x, y), Vector2.one / 2f, 0f, grid_layer)) { 
            return true;
        }
        else
        {
            return false;
        }
    }
}