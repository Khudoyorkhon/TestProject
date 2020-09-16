using DG.Tweening;
using UnityEngine;

/*
 * Этот скрипт увеличивает радиус пузыня на 10% и поределяет точку соприкосновения
 */

public class Bubble : MonoBehaviour
{
    private float _radius, _radiusMultiplier=1.1f, _newRadius = 0f;
    private CreateBigOne _createBig;

    public float Radius { get => _radius; set => _radius = value; }

    private void Start()
    {
        _newRadius = _radius * 0.1f;
        _radius = (_radius + _newRadius) * _radiusMultiplier;
        transform.DOScale(_radius, 1f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contact = collision.contacts[0];
        collision.transform.TryGetComponent<Bubble>(out Bubble bubble);
        if(bubble != null)
        {
            _radius = bubble.Radius + _radius;
            _radius = _radius * _radiusMultiplier;

            _createBig.Radius = _radius;
            _createBig.SpawnPoint = contact.point;
            _createBig.CanCreate = true;

            Destroy(collision.gameObject);
        }
    }

    public void SetData(float radius, CreateBigOne createBig)
    {
        _createBig = createBig;
        _radius = radius;
    }
}
