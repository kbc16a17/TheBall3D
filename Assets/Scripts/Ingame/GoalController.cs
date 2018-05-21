using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TheBall3D.Common;

namespace TheBall3D.Ingame {
    [RequireComponent(typeof(Collider))]
    public class GoalController : MonoBehaviour {
        [SerializeField]
        private GameObject ball;

        public UnityEvent OnClear;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.Equals(ball)) {
                OnClear.Invoke();
                Invoke("backToStageSelect", 3.0f);
            }
        }

        private void backToStageSelect() {
            SceneManager.LoadScene(Constants.StageSelectScene);
        }
    }
}