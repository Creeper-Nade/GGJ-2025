using UnityEngine;

namespace AmpFC.Environment
{
    public class MovingBackGround : MonoBehaviour
    {
        public GameObject background;
        public GameObject backgroundReplica;
        public float speed;
        public bool Horizontal;
        private float backgroundWidth;
        private float backgroundHeight;

        void Start()
        {
            backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x - 0.42f;
            backgroundHeight = background.GetComponent<SpriteRenderer>().bounds.size.y - 0.3f;
        }

        void Update()
        {
            if (Horizontal)
            {
                MoveBackground(background);
                MoveBackground(backgroundReplica);
            }
            else
            {
                MoveBackgroundVertical(background);
                MoveBackgroundVertical(backgroundReplica);
            }
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

        void MoveBackgroundVertical(GameObject bg)
        {
            bg.transform.position += Vector3.down * speed * Time.deltaTime;

            if (bg.transform.position.y <= -backgroundHeight)
            {
                bg.transform.position += Vector3.up * 2 * backgroundHeight;
            }
        }
    }
}