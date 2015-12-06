using UnityEngine;
using System.Collections;

public class DragInput : MonoBehaviour,IUserInput {

    Vector2 currentDirection;
    public KeyCode leftKeyCode;
    public KeyCode rightKeyCode;

    // Update is called once per frame
    void Start()
    {
        currentDirection = new Vector3(0, 0, 0);
    }

	void Update () {
        GetInputVector();
	}

    public Vector2 GetInputVector()
    {
        return currentDirection + new Vector2((Input.GetKey(leftKeyCode) ? -1 : 0) + (Input.GetKey(rightKeyCode) ? 1 : 0), 0)*2;
        ;
    }

    void OnMouseDrag()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        currentDirection = (cursorPosition - transform.position);
        currentDirection.y= 0;
        Debug.Log(currentDirection);
    }

    void OnMouseUp()
    {
        currentDirection = new Vector2(0,0);
        Debug.Log("Drag ended!");
    }
}
