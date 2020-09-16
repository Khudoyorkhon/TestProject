using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject, 2f);
        Debug.Log("Game obj " + this.gameObject.name + " is " + " destroyed by " + collision.gameObject.name);
    }
}
