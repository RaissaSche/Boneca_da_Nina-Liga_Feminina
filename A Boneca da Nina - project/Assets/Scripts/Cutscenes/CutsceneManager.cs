using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cutscenes {

    public class CutsceneManager : MonoBehaviour {

        public event Action OnFinished;
        public List<GameObject> actionObjects;
        public List<ICutsceneAction> actions = new List<ICutsceneAction> ();
        public bool buttonPressed = false;

        public int activeIndex = 0;

        void Awake () {
            Cursor.visible = false;
            foreach (GameObject obj in actionObjects)
                actions.Add (obj.GetComponent<ICutsceneAction> ());
        }

        public void Begin () {
            StartCoroutine (SetupAction (actions[0]));
        }

        private void ActionEnded (ICutsceneAction obj) {
            activeIndex++;
            if (activeIndex < actionObjects.Count)
                SetupAction (actions[activeIndex]);
            else if (OnFinished != null)
                OnFinished ();
            else
                Debug.Log ("No More Actions");
        }

        IEnumerator SetupAction (ICutsceneAction action) {
            buttonPressed = false;
            while (buttonPressed == false) {
                //Wait for the button to be pressed
                yield return null;
            }
            //Continue with more stuff after the button has been pressed
            action.OnEnded += ActionEnded;
            action.Start ();
        }

        public void ButtonPress () {
            Debug.Log ("press");
            buttonPressed = true;
        }
    }
}