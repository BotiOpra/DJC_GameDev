using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float _MovementSpeed;
    public string EnemyTag = "Enemy";
    public ISet<GameObject> CollidedEnemies;
    public 

    void Start()
    {
        CollidedEnemies = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position += Movement * _MovementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            transform.position += new Vector3(0, _MovementSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.Q))
            transform.position -= new Vector3(0, _MovementSpeed * Time.deltaTime, 0);

        

        // decrease enemy health
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var enemyObj in CollidedEnemies.ToList())
            {
                EnemyCharacter enemy = enemyObj.GetComponent<EnemyCharacter>(); 
                enemy.UpdateHealth();
                Debug.Log(enemy.HealthCount);
                if(enemy.IsDead())
                {
                    Destroy(enemyObj);
                    CollidedEnemies.Remove(enemyObj);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(EnemyTag))
        {
            if(!CollidedEnemies.Contains(other.gameObject))
            {
                CollidedEnemies.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(EnemyTag))
        {
            if (CollidedEnemies.Contains(other.gameObject))
            {
                CollidedEnemies.Remove(other.gameObject);
            }
        }
    }
}
