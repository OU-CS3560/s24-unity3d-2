using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    public float destroy_time = 1f;

    private void Start(){
        Destroy(gameObject, destroy_time);
    }
}
