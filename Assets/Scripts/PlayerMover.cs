using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position += Movement * _MovementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            transform.position += new Vector3(0, _MovementSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.Q))
            transform.position -= new Vector3(0, _MovementSpeed * Time.deltaTime, 0);
    }
}
