using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _JumpSpeed;

    [SerializeField] public float _JumpForce;
    [SerializeField] public float _JumpInterval;
    float jumpTimer;

    bool _JumpBlocked;

    FuelScript _fuelSphere;

    private Rigidbody _Rigidbody;

    private SoundManager _SoundManager;

    private ParticleSystem _JumpParticle;

    void Start()
    {
        _MovementSpeed = 3.0f;
        _Rigidbody = GetComponent<Rigidbody>();

        _fuelSphere = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelScript>();
        _SoundManager = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<SoundManager>();

        _JumpForce = 10;
        _JumpInterval = 0.25f;

        _JumpParticle = GameObject.FindGameObjectWithTag("JumpParticle").GetComponent<ParticleSystem>();
        _JumpParticle.transform.parent = _Rigidbody.transform;
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer += Time.deltaTime;
        if (!_JumpBlocked && Input.GetKeyDown(KeyCode.Space))
        {
            _JumpParticle.Play();
            _SoundManager.PlayJumpSound();
            if (jumpTimer > _JumpInterval)
            {
                jumpTimer = 0;
                _Rigidbody.velocity = Vector3.up * _JumpForce;
            }
            _fuelSphere._JumpCount--;
            if (_fuelSphere._JumpCount == 0)
                _JumpBlocked = true;
        }
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(_MovementSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(_MovementSpeed * Time.deltaTime, 0, 0);
    }
}
