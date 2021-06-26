using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float launchPower = 250;

    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    private Rigidbody2D _rigidbody;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _transform = transform;
        _initialPosition = _transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, _transform.position);
        _lineRenderer.SetPosition(1, _initialPosition);

        if (_birdWasLaunched && _rigidbody.velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (_transform.position.y > 10 ||
            _transform.position.y < -10 ||
            _transform.position.x > 10 ||
            _transform.position.x < -20 ||
            _timeSittingAround > 3)
        {
            SceneHandler.RestartLevel();
        }
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
        _lineRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - _transform.position;
        _rigidbody.AddForce(directionToInitialPosition * launchPower);
        _rigidbody.gravityScale = 1;
        _birdWasLaunched = true;
        _lineRenderer.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}