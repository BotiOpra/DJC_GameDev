using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float _xScaleFactor;
    [SerializeField] private float _YScaleFactor;

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _xScaleFactor = 2.0f;
        transform.localScale = new Vector3(_xScaleFactor, _YScaleFactor, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetMouseButton(0))
            transform.position = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
    }
}
