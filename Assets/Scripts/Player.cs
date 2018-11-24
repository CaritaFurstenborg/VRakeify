using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

namespace Balettinakit
{
    public class Player : MonoBehaviour
    {
        public GameObject BodyPicePrefab;
        public float Speed;
        private Rigidbody playerRb;
        private Vector3 direction;
        private Vector3 rotationAngle;
        private Vector3 lastPos;
        private Vector3 lastHorizontalVec;
        private Vector3 lastBodypicePos;
        private Queue<GameObject> body = new Queue<GameObject>();
        [SerializeField] private Text scoreText;
        private int counter = 0;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            direction = Vector3.forward;
            lastHorizontalVec = direction;
            scoreText.text = "Score: " + body.Count.ToString();
            Speed = 2.4f;
        }

        void Update()
        {
            ParseInput();
            if (counter == 30)
            {
                counter = 0;
                if (body.Count > 0)
                {
                    var b = body.Dequeue();
                    b.transform.position = lastPos;
                    body.Enqueue(b);
                    lastPos = transform.position;
                }
            }
            counter++;
        }

        void FixedUpdate()
        {
            playerRb.MovePosition(transform.position + direction * Time.deltaTime * Speed);
        }

        public void AddBodyPice()
        {
            lastPos = transform.position - (transform.InverseTransformDirection(direction) * 1.2f);
            var bodyPart = Instantiate(BodyPicePrefab, lastPos, Quaternion.identity);
            body.Enqueue(bodyPart);
            Speed += 0.2f;
            scoreText.text = "Score: " + body.Count.ToString();
        }

        private void SetRotation(Vector3 direction)
        {
            if (direction == Vector3.forward)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (direction == Vector3.left)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else if (direction == Vector3.right)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (direction == Vector3.back)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }

        private void ParseInput()
        {
            if (Input.GetButtonDown("LeftTrigger"))
            {
                if (direction == Vector3.forward)
                {
                    direction = Vector3.left;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.left)
                {
                    direction = Vector3.back;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.back)
                {
                    direction = Vector3.right;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.right)
                {
                    direction = Vector3.forward;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
            }
            if (Input.GetButtonDown("RightTrigger"))
            {
                if (direction == Vector3.forward)
                {
                    direction = Vector3.right;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.right)
                {
                    direction = Vector3.back;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.back)
                {
                    direction = Vector3.left;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
                else if (direction == Vector3.left)
                {
                    direction = Vector3.forward;
                    lastHorizontalVec = direction;
                    SetRotation(direction);
                    return;
                }
            }
            if (Input.GetButtonDown("LeftFinger"))
            {
                if (direction == Vector3.up)
                {
                    direction = lastHorizontalVec;
                    return;
                }
                else if (direction != Vector3.down)
                {
                    direction = Vector3.up;
                    return;
                }
            }
            if (Input.GetButtonDown("RightFinger"))
            {
                if (direction == Vector3.down)
                {
                    direction = lastHorizontalVec;
                    return;
                }
                else if (direction != Vector3.up)
                {
                    direction = Vector3.down;
                    return;
                }
            }
        }
    }
}
