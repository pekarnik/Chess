using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Square : MonoBehaviour,IPointerDownHandler
{
    public int indRow;
    public int indCol;
    private int number;
    private Piece pieceInSquare;
    internal void SetPieceCoordinates()
    {
        pieceInSquare = GetComponentInChildren<Piece>();
        pieceInSquare.indRow = indRow;
        pieceInSquare.indCol = indCol;
    }

    private void Start()
    {
        if(gameObject.transform.childCount!=0)
        {
            SetPieceCoordinates();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager theCanvas = GameObject.FindObjectOfType<GameManager>();
        if(theCanvas.allowSquareSelection&&gameObject.transform.childCount==0)
        {
            theCanvas.currentSquareSelection[0] = indRow;
            theCanvas.currentSquareSelection[1] = indCol;
            theCanvas.CheckSelection();
        }
        else
        {
            if(this.gameObject.transform.childCount!=0)
            {
                pieceInSquare.SelectPiece();
            }
        }
    }

   
}
