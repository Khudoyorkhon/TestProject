using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 51)]
public class GameData : ScriptableObject
{
    [SerializeField] private float _rectMinWidth = 0.0f, _rectMathWidth, _rectMinHeigth, _rectMaxHeigth;
    [SerializeField] private int _objectMinRadius = 1, _objectMaxRadius = 10, _ojectCount;
    [SerializeField] private float _minSquareWidth, _maxSquareWidth, _minSquareHeigth, _maxSquareHeigth;


    public float RectMinWidth => _rectMinWidth;
    public float RectMathWidth => _rectMathWidth;
    public float RectMinHeigth => _rectMinHeigth;
    public float RectMaxHeigth => _rectMaxHeigth;
    public int ObjectMinRadius => _objectMinRadius;
    public int ObjectMaxRadius => _objectMaxRadius;
    public int OjectCount => _ojectCount;

    public float MinSquareWidth => _minSquareWidth; 
    public float MaxSquareWidth => _maxSquareWidth; 
    public float MinSquareHeigth => _minSquareHeigth; 
    public float MaxSquareHeigth => _maxSquareHeigth; 
}
