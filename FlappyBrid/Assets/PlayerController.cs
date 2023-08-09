using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }

            return _instance;
        }
    }

    public int Score => _score;

    public event Action OnScoreUpdate;
    public event Action OnGameLoose;

    private int _score;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _rigidbody.velocity = Vector3.up*jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            _score++;
            OnScoreUpdate?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnGameLoose?.Invoke();
            Time.timeScale = 0;
        }
    }
}