using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " is destroyed " + " by " + this.gameObject.name);

        Destroy(collision.gameObject,0.5f);


    }
}
