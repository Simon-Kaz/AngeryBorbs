using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float launchPower = 250;
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    private Rigidbody2D _rigidbody;
    private ThrowLineRenderer _throwLineLineRenderer;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;

    public static event Action OnBirdResetRequired;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
        _initialPosition = _transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _throwLineLineRenderer = new ThrowLineRenderer(GetComponent<LineRenderer>());
    }

    private void Update()
    {
        _throwLineLineRenderer.SetPosition(_initialPosition, _transform.position);

        if (_birdWasLaunched && _rigidbody.velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (IsPlayerOutOfBounds(_transform.position) || _timeSittingAround > 3)
        {
            OnBirdResetRequired?.Invoke();
        }
    }

    private static bool IsPlayerOutOfBounds(Vector3 position)
    {
        return position.y > 10 ||
               position.y < -10 ||
               position.x > 10 ||
               position.x < -20;
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
        _throwLineLineRenderer.Enable();
    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
        ThrowBird();
        _throwLineLineRenderer.Disable();
    }

    private void ThrowBird()
    {
        var directionToInitialPosition = (Vector2) (_initialPosition - _transform.position);
        _rigidbody.AddForce(directionToInitialPosition * launchPower);
        _rigidbody.gravityScale = 1;
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        var newPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}