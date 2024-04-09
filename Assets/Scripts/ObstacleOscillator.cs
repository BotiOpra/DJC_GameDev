using UnityEngine;

public class ObstacleOscillator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _OscillationSpeed;
    private GameObject _PlaneObject;
    private string _PlaneTag = "Plane";


    private float _PlaneYPos;
    private float _ObstacleHeight;

    private int _Direction;

    void Start()
    {
        _Direction = 1;
        _PlaneObject = GameObject.FindGameObjectWithTag(_PlaneTag);
        _PlaneYPos = _PlaneObject.transform.position.y;
        
        _ObstacleHeight = transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        float yPos = transform.position.y;

        if (yPos - _ObstacleHeight/2 <= _PlaneYPos)
            _Direction = 1;
        //if(yPos == 30)
        else if(yPos >= 15) _Direction = -1;

        transform.position = new Vector3(transform.position.x, yPos + _Direction * _OscillationSpeed * Time.deltaTime, transform.position.z);
    }
}
