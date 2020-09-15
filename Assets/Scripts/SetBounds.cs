using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBounds : MonoBehaviour
{
    public BubbleSpawner Spawner;
    public GameObject[] XBounds;
    public GameObject[] YBounds;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < XBounds.Length; i++)
        {
            switch (i)
            {
                case 0:
                    XBounds[0].transform.position = new Vector2(Spawner.RectWidth, 0);
                    XBounds[0].GetComponent<BoxCollider2D>().size = new Vector2(0.2f, Spawner.RectHeigth * 2);
                    break;
                case 1:
                    XBounds[1].transform.position = new Vector2(-Spawner.RectWidth, 0);
                    XBounds[1].GetComponent<BoxCollider2D>().size = new Vector2(0.2f, Spawner.RectHeigth * 2);
                    break;
            }
        }

        for (int i = 0; i < YBounds.Length; i++)
        {
            switch (i)
            {
                case 0:
                    YBounds[0].transform.position = new Vector2(0, Spawner.RectHeigth);
                    YBounds[0].GetComponent<BoxCollider2D>().size = new Vector2(Spawner.RectWidth * 2, 0.2f);
                    break;
                case 1:
                    YBounds[1].transform.position = new Vector2(0, -Spawner.RectHeigth);
                    YBounds[1].GetComponent<BoxCollider2D>().size = new Vector2(Spawner.RectWidth * 2,0.2f);
                    break;
            }
        }
    }
    
}
