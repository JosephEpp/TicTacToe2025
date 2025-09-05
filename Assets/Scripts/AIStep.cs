using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIStep : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    TicTacToe gameScript;

    [SerializeField] int[] squareValues;

    int sqauresFull;

    //[SerializeField] List<int> openSquares;

    PlayerTurn playerTurn, playerOpponent;

    enum AILevel
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    [SerializeField] AILevel aiLevel;

    void Start()
    {
        gameScript = gameManager.GetComponent<TicTacToe>();
        squareValues = new int[9];
        sqauresFull = 0;
        //openSquares = new List<int>();
        aiLevel = AILevel.Level1;
    }

    public void SetLevel(int level)
    {
        aiLevel = (AILevel)Enum.Parse(typeof(AILevel), Enum.GetName(typeof(AILevel), level));
    }

    public void DoAIStep()
    {
        // Read the board
        gameScript.ReadBoard(ref squareValues);
        //openSquares.Clear();

        // Make a list of all indexes for the open squares
        // for (int i = 0; i < squareValues.Length; i++)
        // {
        //     if (squareValues[i] == 0)
        //     {
        //         openSquares.Add(i);
        //     }
        // }

        // Choose a random open square

        //Select a random square
        SelectRandomSquare();

        //gameScript.SelectSquare(openSquares[Random.Range(0, openSquares.Count)]);
    }

    private void SelectRandomSquare()
    {
        bool validSquare = false;
        while (validSquare == false && sqauresFull != 9)
        {
            int index = UnityEngine.Random.Range(0, squareValues.Count());

            //Check if the square is empty
            if (squareValues[index] == 0)
            {
                //If the square is empty, fill it
                gameScript.SelectSquare(index);
                sqauresFull += 1;
                validSquare = true;
            }
        }
    }

    private void CheckForPossibleWin()
    {

    }
}