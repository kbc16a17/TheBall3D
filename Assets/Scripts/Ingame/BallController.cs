using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheBall3D.Ingame {
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour {
        [SerializeField]
        private GameManager manager;
        [SerializeField]
        private float lowerLimitPosition;

        private Vector3 startPosition;
        private new Rigidbody rigidbody;
        public bool IsFalling => !rigidbody.isKinematic;

        private void Awake() {
            startPosition = transform.position;
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (transform.position.y < lowerLimitPosition) {
                manager.Reset();
            }
        }

        public void Reset() {
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
        }

        public void Drop() {
            rigidbody.isKinematic = false;
        }
    }
}