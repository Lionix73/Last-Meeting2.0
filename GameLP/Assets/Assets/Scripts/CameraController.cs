using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public class CameraFollow : MonoBehaviour
    {
        public Transform player;
        public float smoothing;

        void Update()
        {
            transform.position = player.position;
        }

    }

}
