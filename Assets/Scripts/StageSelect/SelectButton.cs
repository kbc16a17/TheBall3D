using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TheBall3D.StageSelect {
    [RequireComponent(typeof(Button))]
    public class SelectButton : MonoBehaviour {
        public SceneObject DestinationStage;

        public void OnClick() {
            SceneManager.LoadScene(DestinationStage);
        }
    }
}