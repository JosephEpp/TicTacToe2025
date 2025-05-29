using System;
using System.Collections.Generic;
using UnityEngine;

public class AIStep : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    TicTacToe gameScript;

    int[] squareValues;

    List<int> openSquares;

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
        openSquares = new List<int>();
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
        playerTurn = gameScript.GetPlayer();
        if (playerTurn == PlayerTurn.Player1)
        {
            playerOpponent = PlayerTurn.Player2;
        }
        else
        {
            playerOpponent = PlayerTurn.Player1;
        }
        openSquares.Clear();

        if (aiLevel == 0)
        {
            ChooseOpenSquare();
        }
    }

    void ChooseOpenSquare()
    {
        // Make a list of all indexes for the open squares
        for (int i = 0; i < squareValues.Length; i++)
        {
            if (squareValues[i] == 0)
            {
                openSquares.Add(i);
            }
        }

        // Choose a random open square
        gameScript.SelectSquare(openSquares[UnityEngine.Random.Range(0, openSquares.Count)]);
    }
}
