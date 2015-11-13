using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {

    int stageNumber;
    Text _textRef;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManagerScript.SetTrigger("ToTitle");            
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManagerScript.SetTrigger("ToTitle");
        }
    }
}
