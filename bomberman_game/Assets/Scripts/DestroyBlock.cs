using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    [Header("Pathfinder object")]   // helps update the pathfinding when a block is destroyed
    public GameObject PF_object;

    public float destroy_time = 1f;

    private void Start(){
        Destroy(gameObject, destroy_time);
        new WaitForSeconds(1);
        PF_object.GetComponent<AstarPath>().Scan();
    }
}
