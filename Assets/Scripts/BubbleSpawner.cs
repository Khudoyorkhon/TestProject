using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private Camera _currentCamera = null;

    private Vector2 _screenSize, _spawnPoint;
    private float _rectWidth, _rectHeigth;
    private float _timer, _timeChanger = 0.02f;
    private float _radiusMultiplier = 1.1f, _radius = 0,_xSize,_ySize;

    private int _index = 0;

    private int _objectMinRadius = 1, _objectMaxRadius = 10;

    public float RectWidth => _rectWidth;
    public float RectHeigth => _rectHeigth;

    public int TimeSpawn = 3;

    public CreateBigOne CreateBigOne;
    public GameObject[] PrefabGameObject;

    private float MinXSize,MaxXSize, MinYSize,MaxYSize;

    private int Counter;

    public bool IsSquare = false;

    public GameData Data;

    // Start is called before the first frame update
    void Awake()
    {
        MinXSize = Data.MinSquareWidth;
        MaxXSize = Data.MaxSquareWidth;
        MinYSize = Data.MinSquareHeigth;
        MaxYSize = Data.MaxSquareHeigth;

        Counter = Data.OjectCount;

        _objectMinRadius = Data.ObjectMinRadius;
        _objectMaxRadius = Data.ObjectMaxRadius;

        GetScreenSize();

        for(int i = 0; i < Counter; i++)
        {
            CreateObject(PrefabGameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += _timeChanger;

        if(_timer >= TimeSpawn)
        {
            CreateObject(PrefabGameObject);
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

    private void CreateObject(GameObject[] prefab)
    {
        if(IsSquare == true)
        {
            _index = Random.Range(0, prefab.Length);

            print(_index);

            switch (_index)
            {
                case 0:
                    _radius = Random.Range(_objectMinRadius, _objectMaxRadius + 1);

                    _radius = _radius * _radiusMultiplier;
                    _spawnPoint = new Vector2(Random.Range(-_screenSize.x, _screenSize.x + 1), Random.Range(-_screenSize.y + 1, _screenSize.y + 1));
                    GameObject GO = Instantiate(prefab[0], _spawnPoint, Quaternion.identity, transform) as GameObject;
                    GO.GetComponent<Bubble>().SetData(_radius, CreateBigOne);
                    GO.transform.localScale = new Vector3(_radius, _radius, _radius);

                    Debug.Log("Game object is created and name of game object  is " + GO.gameObject.name);
                    break;

                case 1:

                    _xSize = Random.Range(MinXSize, MaxXSize);
                    _ySize = Random.Range(MinYSize, MaxYSize);

                    _xSize = _xSize * _radiusMultiplier;
                    _ySize = _ySize * _radiusMultiplier;

                    _spawnPoint = new Vector2(Random.Range(-_screenSize.x, _screenSize.x + 1), Random.Range(-_screenSize.y + 1, _screenSize.y + 1));
                    GameObject Rect = Instantiate(prefab[1], _spawnPoint, Quaternion.identity, transform) as GameObject;
                    Rect.transform.localScale = new Vector3(_xSize, _ySize, 0);

                    Debug.Log("Game object is created and name of game object  is " + Rect.gameObject.name);
                    break;
            }
        }
        else
        {
            _radius = Random.Range(_objectMinRadius, _objectMaxRadius + 1);

            _radius = _radius * _radiusMultiplier;
            _spawnPoint = new Vector2(Random.Range(-_screenSize.x, _screenSize.x + 1), Random.Range(-_screenSize.y + 1, _screenSize.y + 1));
            GameObject GO = Instantiate(prefab[0], _spawnPoint, Quaternion.identity, transform) as GameObject;
            GO.GetComponent<Bubble>().SetData(_radius, CreateBigOne);
            GO.transform.localScale = new Vector3(_radius, _radius, _radius);

            Debug.Log("Game object is created and name of game object  is " + GO.gameObject.name);
        }

    }
}
