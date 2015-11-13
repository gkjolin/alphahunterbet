using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplainDisplay : MonoBehaviour {

    int stageNumber;
    Text _textRef;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManagerScript.SetTrigger("ExplainFinished");            
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManagerScript.SetTrigger("ExplainFinished");
        }
    }
}
