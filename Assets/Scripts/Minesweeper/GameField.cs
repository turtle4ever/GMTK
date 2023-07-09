using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Sprite Default;
    [SerializeField] private Sprite[] Numbered; 
    [SerializeField] private Sprite Mine;
    [SerializeField] private Sprite Exploded;
    [SerializeField] private Sprite Flagged;
    [SerializeField] private int FieldSizeX;
    [SerializeField] private int FieldSizeY;
    private GameObject[,] Map;
    private bool[,] Visited;
    private int Mines;

    // FloodFill
    int[] DirLin = new int[8] {-1, -1, 0, 1, 1, 1, 0, -1};
    int[] DirCol = new int[8] {0, 1, 1, 1, 0, -1, -1, -1};


    int GetMinesAround((int, int)Pos){
        int mines = 0;
        for(int i=0; i<8; i++){
            if(!InBounds((Pos.Item1+DirCol[i], Pos.Item2+DirLin[i]))) continue;
            if(Map[Pos.Item2+DirLin[i], Pos.Item1+DirCol[i]].GetComponent<Block>().IsMine)
                mines++;
        }
        return mines;
    }

    bool InBounds((int, int)Pos){
            return (0<=Pos.Item1 && Pos.Item1<FieldSizeX && 0<=Pos.Item2 && Pos.Item2<FieldSizeY);
    }   

    void FloodFill((int, int) Pos){
        if(Visited[Pos.Item2, Pos.Item1]) return;
        if(Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsMine || Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsFlag)
            return;
        
        int MinesAround = GetMinesAround(Pos);
        Map[Pos.Item2, Pos.Item1].GetComponent<SpriteRenderer>().sprite = Numbered[MinesAround];

        Debug.Log(Pos);

        Visited[Pos.Item2, Pos.Item1] = true;
        if(MinesAround > 0) return;
        for(int i=0; i<8; i++){
            (int, int) NewPos = (Pos.Item1+DirCol[i], Pos.Item2+DirLin[i]);
            if(InBounds(NewPos))
               FloodFill(NewPos);
        }
    }

    bool IsClear(){
        int cleared = 0;
        for(int i=0; i<FieldSizeY; i++)
            for(int j=0; j<FieldSizeX; j++)
                cleared += Convert.ToInt32(Visited[i,j]);
        if(cleared+Mines == FieldSizeX*FieldSizeY)
            return true;
        return false;
    }

    void ShowMines(){
        for(int i=0; i<FieldSizeY; i++)
            for(int j=0; j<FieldSizeX; j++)
                if(Map[i, j].GetComponent<Block>().IsMine)
                    Map[i, j].GetComponent<SpriteRenderer>().sprite = Mine;
    }

    void Awake(){
        Map = new GameObject[FieldSizeY,FieldSizeX];
        Visited = new bool[FieldSizeY, FieldSizeX];
        for(int i=0; i<FieldSizeY; i++)
            for(int j=0; j<FieldSizeX; j++){
                Map[i,j] = new GameObject("Block");
                Block script = Map[i,j].AddComponent<Block>();
                if(UnityEngine.Random.value < 0.15){
                    Mines++;
                    script.IsMine = true;
                }
                
                SpriteRenderer _SpriteRenderer = Map[i,j].AddComponent<SpriteRenderer>();
                BoxCollider2D Collider = Map[i,j].AddComponent<BoxCollider2D>();

                Map[i,j].transform.localScale = new Vector3(6, 6, 1);
                Map[i,j].transform.position = new Vector2(j, i);
                Collider.size = new Vector2(1/6f, 1/6f);
                _SpriteRenderer.sprite = Default;

                script.ClickBlock += BlockClicked;
                script.SetFlag += SetFlag;
            }
    }

    private void BlockClicked((int, int)Pos){
        if(Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsMine == true){
            ShowMines();
            Map[Pos.Item2, Pos.Item1].GetComponent<SpriteRenderer>().sprite = Exploded;
            UI.SetActive(true);
        }
        else{
            FloodFill(Pos);
            if(IsClear()){
                ShowMines();
                UI.SetActive(true);
            }
        }
    }

    private void SetFlag((int, int)Pos){
        if( Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsFlag)
            Map[Pos.Item2, Pos.Item1].GetComponent<SpriteRenderer>().sprite = Default;
        else
            Map[Pos.Item2, Pos.Item1].GetComponent<SpriteRenderer>().sprite = Flagged;
        Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsFlag = !Map[Pos.Item2, Pos.Item1].GetComponent<Block>().IsFlag;
    }

}
