using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Этот скрипт удаляет обьекты которые вне игрового поля или если обьект задевает его границы
 */

public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " is destroyed " + " by " + this.gameObject.name);

        Destroy(collision.gameObject,0.5f);


    }
}
