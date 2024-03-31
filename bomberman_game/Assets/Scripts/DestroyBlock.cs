using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    [Header("Pathfinder object")]   // helps update the pathfinding when a block is destroyed
    public GameObject PF_object;

    public float destroy_time = 1f;

    [Range(0f, 1f)]
    public float ItemSpawnChance = 0.2f;

    public GameObject[] powerupsspawn;
    private void Start(){
        Destroy(gameObject, destroy_time);
        new WaitForSeconds(1);
        PF_object.GetComponent<AstarPath>().Scan();
    }

    private void OnDestroy()
    {
        if (powerupsspawn.Length>0 && Random.value < ItemSpawnChance)
        {
            int randomIndex = Random.Range(0, powerupsspawn.Length);
            Instantiate(powerupsspawn[randomIndex],transform.position, Quaternion.identity);
        }
    }
}
