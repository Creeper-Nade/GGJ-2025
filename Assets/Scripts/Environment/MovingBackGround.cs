using UnityEngine;

namespace AmpFC.Environment
{
    public class MovingBackGround : MonoBehaviour
    {
        public GameObject background;
        public GameObject backgroundReplica;
        public float speed;

        private float backgroundWidth;

        void Start()
        {
            backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void Update()
        {
            MoveBackground(background);
            MoveBackground(backgroundReplica);
        }

        /// <summary>
        /// Moves the background to the left and when it reaches the end, it moves it to the right
        /// </summary>
        /// <param name="bg">The background to move</param>
        void MoveBackground(GameObject bg)
        {
            bg.transform.position += Vector3.left * speed * Time.deltaTime;

            if (bg.transform.position.x <= -backgroundWidth)
            {
            bg.transform.position += Vector3.right * 2 * backgroundWidth;
            }
        }
    }
}