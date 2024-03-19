using System.Collections;
using UnityEngine;

namespace MathWithGames
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private string whatIsBullet;
        [SerializeField] private float speed;
        [SerializeField] private float lifeCycleDuration;
        [SerializeField] private float damage;

        private void Start()
        {
            StartCoroutine(LifeCycle());
        }

        private void FixedUpdate()
        {
            rb.velocity = Vector2.up * speed;
        }

        private IEnumerator LifeCycle()
        {
            yield return new WaitForSeconds(lifeCycleDuration);
            Destroy(gameObject);
            yield return null;
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == whatIsBullet)
            {
                Destroy(gameObject);
                return;
            }
            if (coll.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}