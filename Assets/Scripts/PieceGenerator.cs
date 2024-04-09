using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject WhitePiecePrefab;
    [SerializeField] private GameObject BlackPiecePrefab;

    private GameObject ReferencePiece;

    // Start is called before the first frame update
    void Start()
    {
        ReferencePiece = GameObject.FindGameObjectWithTag("Reference");

        float pieceHeight = WhitePiecePrefab.transform.localScale.y;
        float tileSize = 1.75f;
        float referencePieceX = ReferencePiece.transform.localPosition.x;
        float referencePieceZ = ReferencePiece.transform.localPosition.z;

        float blackReferenceZ = referencePieceZ + tileSize * 6;

        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                Instantiate(WhitePiecePrefab, new Vector3(referencePieceX - j*tileSize, pieceHeight, referencePieceZ + i * tileSize), Quaternion.identity);
                Instantiate(BlackPiecePrefab, new Vector3(referencePieceX - j*tileSize, pieceHeight, blackReferenceZ + i * tileSize), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
