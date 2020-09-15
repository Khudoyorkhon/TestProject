using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private Camera _currentCamera = null;

    private Vector2 _screenSize, _spawnPoint;
    private float _rectWidth, _rectHeigth;
    private float _timer, _timeChanger = 0.02f;
    private float _radiusMultiplier = 1.1f, _radius = 0;

    [SerializeField] private int _objectMinRadius = 1, _objectMaxRadius = 10;


    public float RectWidth => _rectWidth;
    public float RectHeigth => _rectHeigth;
    public int TimeSpawn = 3;

    public CreateBigOne CreateBigOne;
    public GameObject[] PrefabGameObject;

    // Start is called before the first frame update
    void Awake()
    {
        GetScreenSize();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += _timeChanger;

        if(_timer >= TimeSpawn)
        {
            CreateObject(PrefabGameObject[0]);
            _timer = 0;
        }


    }

    private void GetScreenSize()
    {
        _screenSize = _currentCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _rectHeigth = _screenSize.y;
        _rectWidth = _screenSize.x;
        print("heigth: " + _rectHeigth + " width: " + _rectWidth);
    }

    private void CreateObject(GameObject prefab)
    {
        _radius = Random.Range(_objectMinRadius, _objectMaxRadius + 1);

        _radius = _radius * _radiusMultiplier;
        _spawnPoint = new Vector2(Random.Range(-_screenSize.x, _screenSize.x+1), Random.Range(-_screenSize.y + 1, _screenSize.y+1));
        GameObject GO = Instantiate(prefab, _spawnPoint, Quaternion.identity,transform) as GameObject;
        GO.GetComponent<Bubble>().SetData(_radius, CreateBigOne);
        GO.transform.localScale = new Vector3(_radius, _radius, _radius);
    }
}
