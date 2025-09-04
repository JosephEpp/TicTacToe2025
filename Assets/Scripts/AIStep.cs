using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStep : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    TicTacToe gameScript;

    int[] squareValues;

    List<int> openSquares;

    void Start()
    {
        gameScript = gameManager.GetComponent<TicTacToe>();
        squareValues = new int[9];
        openSquares = new List<int>();
    }
    public void DoAIStep()
    {
        // Read the board
        gameScript.ReadBoard(ref squareValues);
        openSquares.Clear();

        // Make a list of all indexes for the open squares
        for (int i = 0; i < squareValues.Length; i++)
        {
            if (squareValues[i] == 0)
            {
                openSquares.Add(i);
            }
        }

        // Choose a random open square
        gameScript.SelectSquare(openSquares[Random.Range(0, openSquares.Count)]);
    }
}