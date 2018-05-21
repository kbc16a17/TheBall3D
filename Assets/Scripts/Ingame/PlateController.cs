using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheBall3D.Ingame {
    public class PlateController : MonoBehaviour, IBeginDragHandler, IDragHandler {
        [SerializeField]
        private BallController controller;

        private Vector3 prePosition;

        public bool IsActive => !controller.IsFalling;

        private Vector3 toCameraPosition(Vector3 position) {
            position.z = transform.position.z - Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(position);
        }

        public void OnBeginDrag(PointerEventData data) {
            if (!IsActive) { return; }
            var position = toCameraPosition(data.position);
            prePosition = position;
        }

        public void OnDrag(PointerEventData data) {
            if (!IsActive) { return; }
            var position = toCameraPosition(data.position);
            var diff = position - prePosition;
            transform.Translate(Vector3.right * diff.x, Space.World);
            transform.Translate(Vector3.up * diff.y, Space.World);
            prePosition = position;
        }
    }

}