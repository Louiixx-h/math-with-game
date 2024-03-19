using System;
using TMPro;
using UnityEngine;

namespace MathWithGames 
{
    public class Tower : MonoBehaviour, IDamageable
    {
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private TextMeshProUGUI angleText;
        [SerializeField] private TextMeshProUGUI vectorText;
        private Vector2 _targetPosition = Vector2.zero;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var angle = Vector2.Angle(Vector2.up, _targetPosition.normalized);
                if (_targetPosition.x > 0) {
                    angle *= -1;
                }
                var rotation = Quaternion.Euler(0, 0, angle);
                transform.rotation = rotation;

                angleText.SetText($"θ = {Math.Round(angle, 2)}°");
                vectorText.SetText($"u = {_targetPosition}");
            }

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                var bulletObj = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
                if (bulletObj.TryGetComponent(out Bullet bullet))
                {
                    bullet.SetDirections(_targetPosition);
                }
            }
        }

        public void ApplyDamage(float damage)
        {
            Destroy(gameObject);
        }
    }
}
