using System;
using UnityEngine;

namespace MathWithGames 
{
    public class CalculateRotateAngle : MonoBehaviour
    {
        [SerializeField] 
        private GameObject robot;
        [SerializeField] 
        private float rotationSpeed;

        void Update()
        {
            AngleFromAtan2();
        }

        private void AngleFromAtan2()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            var angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg * -1;
            var targetRotation = Quaternion.Euler(0, 0, angle);
            var newRotation = Quaternion.Slerp(robot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            robot.transform.rotation = newRotation;
            print(angle);
        }

        private void AngleBetweenTwoVectorsUnity() 
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            var a = new Vector2(x, 0);
            var b = new Vector2(0, y);

            var angle = Vector2.Angle(a, b);

            print(angle);   
        }

        private void AngleBetweenTwoVectors()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            var a = new Vector2(x, 0).normalized;
            var b = new Vector2(0, y).normalized;

            var result = Vector2.Dot(a, b)/(a.magnitude * b.magnitude);

            var angle  = Math.Cosh(result);

            print(angle);   
        }
    }
}