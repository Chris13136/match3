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

    private ClearablePiece clearableComponent;
    public  ClearablePiece ClearableComponent
    {
        get {return clearableComponent;}
    }

    void Awake()
    {
        moveableComponent = GetComponent<MoveablePiece>();
        colorComponent    = GetComponent<ColorPiece>();
        clearableComponent= GetComponent<ClearablePiece>();
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

    void OnMouseEnter(){
        grid.EnterPiece(this);
    }

    void OnMouseDown(){
        grid.PressPiece(this);
    }

    void OnMouseUp(){
        grid.ReleasePiece();
    }

    public bool IsMoveable(){
        return moveableComponent != null;
    }

    public bool IsColored(){
        return colorComponent != null;
    }

    public bool IsClearable(){
        return clearableComponent != null;
    }
    
}