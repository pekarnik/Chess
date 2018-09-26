using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour,IPointerDownHandler
{
    private int number;
    private RawImage pieceTexture;
    public int indRow;
    public int indCol;
    public int PieceTextureNumber
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
            ApplyStyleFromHolder(number);
        }
    }
    //public void SetEmpty()
    //{
    //    squareCanvas.enabled = false;
    //    pieceTexture.enabled = false;
    //}

    //public void SetVisible()
    //{
    //    squareCanvas.enabled = true;
    //    pieceTexture.enabled = true;
    //}

    private void ApplyStyleFromHolder(int index)
    {
        pieceTexture.texture = SquarePieceHolder.Instance.SquareStyles[index].NewTexture;
    }

    // Use this for initialization
    void Start ()
    {
        pieceTexture = GetComponentInChildren<RawImage>();
	}
	// Update is called once per frame
	void Update () {
		
	}
    internal void SelectPiece()
    {
        GameManager theCanvas = GameObject.FindObjectOfType<GameManager>();
        theCanvas.currentPieceSelection = this;
        theCanvas.CheckSelection();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectPiece();
    }

}
