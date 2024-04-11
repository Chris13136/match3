using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePiece : MonoBehaviour {
    
    //The x pos
    private int x;
    public int X
    {
        get { return x;}
        set{
            if(IsMoveable()){
                x = value;
            }
        }
    }

    //The y pos
    private int y;
    public int Y
    {
        get { return y;}
        set{
            if(IsMoveable()){
                y = value;
            }
        }
    }

    //A enum type of PieceType
    private Grid.PieceType type;
    public Grid.PieceType Type
    {
        get {return type;}
    }

    //The grid 
    private Grid grid;
    public  Grid GridRef
    {
        get {return grid;}
    }

    private MoveablePiece moveableComponent;
    public  MoveablePiece MoveableComponent
    {
        get {return moveableComponent;}
    }

    private ColorPiece colorComponent;
    public  ColorPiece ColorComponent
    {
        get {return colorComponent;}
    }

    void Awake()
    {
        moveableComponent = GetComponent<MoveablePiece>();
        colorComponent    = GetComponent<ColorPiece>();
    }
    void Start() {
    }

    void Update() {
    }

    
    public void Init(int _x, int _y, Grid _grid, Grid.PieceType _type)
    {
        x    = _x;
        y    = _y;
        grid = _grid;
        type = _type;
    }

    public bool IsMoveable(){
        return moveableComponent != null;
    }

    public bool IsColored(){
        return colorComponent != null;
    }
    
}