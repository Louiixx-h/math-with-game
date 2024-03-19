using System.Collections;
using UnityEngine;

namespace MathWithGames
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;
        [SerializeField] private float lifeCycleDuration;
        private Vector2 _direction = Vector2.zero;

        private void Start()
        {
            StartCoroutine(LifeCycle());
        }

        private void FixedUpdate()
        {
            rb.velocity = _direction * speed;
        }

        public void SetDirections(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        private IEnumerator LifeCycle()
        {
            yield return new WaitForSeconds(lifeCycleDuration);
            Destroy(gameObject);
            yield return null;
        }
    }
}