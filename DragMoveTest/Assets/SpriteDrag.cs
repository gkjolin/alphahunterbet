using UnityEngine;
using System.Collections;

public class SpriteDrag : MonoBehaviour
{
    public Sprite sprite;
    private float z = 10f;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDrag()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, z));
        transform.position = transform.position + (cursorPosition-transform.position)/5;
    }
}