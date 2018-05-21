using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TheBall3D.Common;

namespace TheBall3D.Ingame {
    public class GameManager : MonoBehaviour {
        [SerializeField]
        private BallController ball;
        [SerializeField]
        private Button backButton;
        [SerializeField]
        private Button goButton;

        private void Awake() {
            backButton.onClick.AddListener(onClickBackButton);
            goButton.onClick.AddListener(onClickGoButton);
        }

        public void Reset() {
            goButton.GetComponentInChildren<Text>().text = @"GO";
            ball.Reset();
        }

        public void Drop() {
            goButton.GetComponentInChildren<Text>().text = @"Reset";
            ball.Drop();
        }

        private void onClickBackButton() {
            SceneManager.LoadScene(Constants.StageSelectScene);
        }

        private void onClickGoButton() {
            if (!ball.IsFalling) {
                Drop();
            } else {
                Reset();
            }
        }
    }
}