using UnityEngine;

public class Ball : MonoBehaviour, IPoolable
{
    public bool IsActive => gameObject.activeInHierarchy;

    public int Damage => _damage;
    public int Score => _score;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private BallParticleSystem _particleSystem;

    private Color _color;

    private float _speed;
    private int _damage;
    private int _score;

    public void Init(Color color, float speed, int damage, int score)
    {
        _speed = speed;
        _spriteRenderer.color = color;
        _color = color;
        _damage = damage;
        _score = score;
    }
    public void OnHitBy()
    {
        var particleSystem = Instantiate(_particleSystem);
        particleSystem.SetColor(_color);
        particleSystem.SetPosition(transform.position);
    }
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Translate(0, -_speed * Time.deltaTime, 0);
    }

}
