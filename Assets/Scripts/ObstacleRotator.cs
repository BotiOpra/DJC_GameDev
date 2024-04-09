using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float _RotationSpeed = 30.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * _RotationSpeed * Time.deltaTime);
    }
}
