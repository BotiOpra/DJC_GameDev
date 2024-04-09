using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private float _ScaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentScale = transform.localScale.x;
        if(Input.GetKey(KeyCode.P))
            transform.localScale += new Vector3(_ScaleFactor, _ScaleFactor, _ScaleFactor);
        if(currentScale > 1 && Input.GetKey(KeyCode.O))
            transform.localScale -= new Vector3(_ScaleFactor, _ScaleFactor, _ScaleFactor);
    }
}
