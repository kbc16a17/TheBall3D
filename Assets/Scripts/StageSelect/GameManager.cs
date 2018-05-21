using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheBall3D.StageSelect {
    public class GameManager : MonoBehaviour {
        [SerializeField]
        private SceneObject[] stages;
        [SerializeField]
        private Transform buttonContainer;
        [SerializeField]
        private GameObject buttonPrefab;

        private void Awake() {
            for (int i = 0; i < stages.Length; i++) {
                var button = Instantiate(buttonPrefab);
                button.GetComponent<SelectButton>().DestinationStage = stages[i];
                button.GetComponentInChildren<Text>().text = (i + 1).ToString();
                button.transform.SetParent(buttonContainer);
            }
        }
    }
}