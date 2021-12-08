using UnityEngine;

public class BallParticleSystem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;
    private void OnEnable()
    {
        Destroy(gameObject, _particleSystem.main.startLifetime.constant);
    }
    public void SetColor(Color color)
    {
        var particles = _particleSystem.main;
        particles.startColor = color;
    }
    public void SetPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }
}
