using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
            transform.Rotate(_RotationSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.Y))
            transform.Rotate(0, _RotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.Z))
            transform.Rotate(0, 0, _RotationSpeed * Time.deltaTime);
    }
}
