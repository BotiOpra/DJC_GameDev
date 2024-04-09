using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int _HealthCount;

    void Start()
    {
        _HealthCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        _HealthCount -= 1;
    }

    public bool IsDead()
    {
        return _HealthCount == 0;
    }

    public int HealthCount => _HealthCount;
}
