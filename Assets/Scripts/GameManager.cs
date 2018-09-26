using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Square[,] allSquares = new Square[8, 8];
    //private List<Square[]> columns = new List<Square[]>();
    //private List<Square[]> rows = new List<Square[]>();
    private List<Square> emptySquares = new List<Square>();
    public Piece currentPieceSelection;
    public bool allowSquareSelection = false;
    public int[] currentSquareSelection = new int[2];
	void Start ()
    {
        Square[] allSquaresOnDim = GameObject.FindObjectsOfType<Square>();
        foreach(Square t in allSquaresOnDim)
        {
            allSquares[t.indRow, t.indCol] = t;
        }
    }

    public void GameBtnHandler()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    internal void CheckSelection()
    {
        allowSquareSelection = true;
        if(currentSquareSelection[1]<8&&currentSquareSelection[0]<8&&currentSquareSelection[1]>-1&&currentSquareSelection[0]>-1)
        {
            currentPieceSelection.transform.SetParent(allSquares[currentSquareSelection[0], currentSquareSelection[1]].gameObject.transform, false);

            allSquares[currentSquareSelection[0], currentSquareSelection[1]].SetPieceCoordinates();
            allowSquareSelection = false;
            currentPieceSelection = null;
            currentSquareSelection[0] = 8;
            currentSquareSelection[1] = 8;
        }
    }
}
