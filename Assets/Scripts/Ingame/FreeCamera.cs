using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheBall3D.Ingame {
    [RequireComponent(typeof(Camera))]
    public class FreeCamera : MonoBehaviour {
        [SerializeField, Range(0.1f, 10.0f)]
        private float zoomSpeed = 5.0f;
        [SerializeField, Range(0.005f, 0.05f)]
        private float mouseMoveSpeed = 0.01f;
        [SerializeField, Range(0.1f, 10.0f)]
        private float keyMoveSpeed = 0.25f;

        private Vector3 prePosition;

        private void Update() {
            if (Input.GetKey(KeyCode.W)) {
                transform.Translate(Vector3.up * keyMoveSpeed);
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(-Vector3.up * keyMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * keyMoveSpeed);
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(-Vector3.right * keyMoveSpeed);
            }

            var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheel != 0.0f) {
                var position = transform.position + transform.forward * scrollWheel * zoomSpeed;
                position.z = Mathf.Clamp(position.z, -20.0f, -2.0f);
                transform.position = position;
            }

            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
                prePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
                var diff = Input.mousePosition - prePosition;
                transform.Translate(-diff * mouseMoveSpeed);
                prePosition = Input.mousePosition;
            }
        }
    }
}