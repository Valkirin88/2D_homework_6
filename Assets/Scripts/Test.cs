using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Transform _point2;

    [SerializeField]
    private float _timeMove = 10;

    private float _timer;
    private Vector3 _startPosition;

    private void Start()
    {
        _timer = Time.time;
        _startPosition = transform.position;
    }

    private void Update()
    {
        var t = (Time.time - _timer) / _timeMove;

        transform.position = Vector3.Lerp(_startPosition, _point2.position, t);
    }
}
