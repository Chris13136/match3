using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour{
    
    public enum PieceType
    {
        NORMAL,
        COUNT ,
    };

    [System.Serializable]
    public struct piecePrefabDict
    {
        public PieceType type;
        public GameObject prefab;
    };

    public int xDim;
    public int yDim;

    private Dictonary<PieceType, GameObject> piecePrefabDict;

    private GamePiece[,] pieces;

    public PiecePrefab[] piecePrefabs;
    public GameObject backgroundPrefab;

    void Start() {
        piecePrefabDict = new Dictonary<PieceType, GameObject>();

        // Making the Dictonary from the user inputed prefabs
        for( int i = 0; i < piecePrefabs.Length; i++){
            if(!piecePrefabDict.ContainsKey (piecePrefabs[i].type))
            piecePrefabDict.Add (piecePrefabs [i].type, piecePrefabs[i].prefab)
        }

        //Setting up the background image grid
        for(int x = 0; x < xDim; x++){
            for(int y = 0; y < yDim; y++){
                GameObject background = (GameObject)Instantiate(backgroundPrefab, GetWorldPosition(x,y), Quaterion.identity);
                background.transform.parent = transform;
            }
        }

        //Putting our pieces on the grid
        pieces = new GamePiece[xDim, yDim];
        for(int x = 0; x < xDim; x++){
            for(int y = 0; y < yDim; y++){
                    GameObject newPiece = (GameObject)Instantiate(piecePrefabDict[PieceType.NORMAL], Vector3.zero, Quaterion.identity)
                    newPiece.name = "Piece(" + x + "," + y + ")";
                    newPiece.transform.parent = transform;

                    pieces[x,y] = newPiece.GetComponent<GamePiece>();
                    pieces.Init(x, y, this, PieceType.NORMAL);
            }
        }
    }

    void Update(){

    }

    /*
    This is a function that allows the grid to be in the middle on the screen and makes indexing easier.
    */
    public Vector2 GetWorldPosition(int x, int y){
        return new Vector2(transform.position.x - xDim/2.0f + x, transform.position.y + yDim/2.0f - y)
    }

}