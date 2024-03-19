using System.Collections;
using UnityEngine;

namespace MathWithGames
{
    public class BalloonSpawn : MonoBehaviour
    {
        [SerializeField] GameObject balloonPrefab;
        [SerializeField] Transform startSpawn;
        [SerializeField] Transform endSpawn;
        [SerializeField] float cooldown;
        private bool _canSpawn = true;

        private void Start()
        {
            StartCoroutine(CreateBalloon());
        }

        private IEnumerator CreateBalloon()
        {
            while (_canSpawn)
            {
                var xPosition = Random.Range(startSpawn.position.x, endSpawn.position.x);
                var position = new Vector2(xPosition, startSpawn.position.y);
                Instantiate(balloonPrefab, position, Quaternion.identity);
                yield return new WaitForSeconds(cooldown);
            }
        }
    }
}