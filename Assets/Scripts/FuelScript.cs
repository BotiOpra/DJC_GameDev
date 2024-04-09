using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int _JumpCount;
    [SerializeField] TMP_Text _CountText;

    void Start()
    {
        _JumpCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        _CountText.text = _JumpCount.ToString();
    }
}
