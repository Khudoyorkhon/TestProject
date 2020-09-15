using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigOne : MonoBehaviour
{
    public GameObject Prefab;
    private float _radius = 0f, _radiusMultiplier=1.1f;

    private bool _canCreate = false;

    private Vector3 _spawnPoint;

    public float Radius { get => _radius; set => _radius = value; }
    public bool CanCreate { get => _canCreate; set => _canCreate = value; }
    public Vector3 SpawnPoint { get => _spawnPoint; set => _spawnPoint = value; }

    private void Start()
    {
        _canCreate = false;
    }

    private void Update()
    {
        Create();
    }

    private void Create()
    {
        if(_canCreate == true)
        {
            Radius = Radius * _radiusMultiplier;
            GameObject gameObject = Instantiate(Prefab, SpawnPoint, Quaternion.identity, transform) as GameObject;

            gameObject.GetComponent<Bubble>().SetData(Radius, this);
            gameObject.transform.localScale = new Vector3(Radius, Radius, Radius);

            _canCreate = false;
        }

    }
}
