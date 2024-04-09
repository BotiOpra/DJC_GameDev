using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject _FlyObject;
    private GameObject _PlaneObject;
    List<GameObject> _CollidedObjects;
    private string _FlyTag = "Fly";
    private string _ObstacleTag = "Obstacle";
    private string _PlaneTag = "Plane";

    private int _currentSceneIndex;

    bool startParticle = true;

    public bool RestartLevel = false;
    public bool ReachedFinish = false;
    public bool? FellInVoid => _FlyObject?.transform.position.y <= _PlaneObject?.transform.position.y;

    public bool? IsFinalLevel => _currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1;

    private ParticleSystem _HurtParticle;

    private SoundManager _SoundManager;

    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        _CollidedObjects = new List<GameObject>();
        _FlyObject = GameObject.FindGameObjectWithTag(_FlyTag);
        _PlaneObject = GameObject.FindGameObjectWithTag(_PlaneTag);

        _SoundManager = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<SoundManager>();
        _HurtParticle = GameObject.FindGameObjectWithTag("HurtParticle").GetComponent<ParticleSystem>();

        //_HurtParticle.transform.parent = _FlyObject.GetComponent<Rigidbody>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (RestartLevel || FellInVoid.Value)
        {
            if(startParticle)
            {
                _HurtParticle.Play();
                _SoundManager.PlayHurtSound();
                startParticle = false;
            }
            

            if (!_HurtParticle.isPlaying)
            {
                _HurtParticle.Stop();
                RestartLevel = false;
                SceneManager.LoadScene(_currentSceneIndex);
                _CollidedObjects.Clear();
            }

        }
        else if (ReachedFinish)
        {
            _SoundManager.PlaySuccessSound();
            if (IsFinalLevel.Value)
                _currentSceneIndex = 0;
            else
                _currentSceneIndex++;
            ReachedFinish = false;
            SceneManager.LoadScene(_currentSceneIndex);
            _CollidedObjects.Clear();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collidedObject = collision.gameObject;
        if (collidedObject.tag == _ObstacleTag)
        {
            _CollidedObjects.Add(collidedObject);
        }

        if (collidedObject.tag == _ObstacleTag || collidedObject.tag == _PlaneTag)
            RestartLevel = true;

        if (collidedObject.tag == "Finish")
            ReachedFinish = true;
    }
}
