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

    bool selectedSquare;

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

        selectedSquare = false;

        switch (aiLevel)
        {
            case AILevel.Level1:
                ChooseRandomOpenSquare();
                break;
            case AILevel.Level2:
                CheckForPossibleWin();
                if (!selectedSquare)
                {
                    ChooseRandomOpenSquare();
                }
                break;
            case AILevel.Level3:
                CheckForPossibleWin();
                if (!selectedSquare)
                {
                    CheckForPossibleBlock();
                }
                if (!selectedSquare)
                {
                    ChooseRandomOpenSquare();
                }
                break;
            case AILevel.Level4:
                break;
            case AILevel.Level5:
                break;
            default:
                break;
        }
    }

    void ChooseRandomOpenSquare()
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

        selectedSquare = true;
    }

    void CheckForPossibleWin()
    {
        if (squareValues[0] + squareValues[1] + squareValues[2] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(1);
            gameScript.SelectSquare(2);

            selectedSquare = true;
        }

        if (squareValues[3] + squareValues[4] + squareValues[5] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(3);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(5);

            selectedSquare = true;
        }

        if (squareValues[6] + squareValues[7] + squareValues[8] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(6);
            gameScript.SelectSquare(7);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[0] + squareValues[3] + squareValues[6] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(3);
            gameScript.SelectSquare(6);

            selectedSquare = true;
        }

        if (squareValues[1] + squareValues[4] + squareValues[7] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(1);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(7);

            selectedSquare = true;
        }

        if (squareValues[2] + squareValues[5] + squareValues[8] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(2);
            gameScript.SelectSquare(5);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[0] + squareValues[4] + squareValues[8] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[2] + squareValues[4] + squareValues[6] == (int)playerTurn * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(2);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(6);

            selectedSquare = true;
        }
    }

    void CheckForPossibleBlock()
    {
        if (squareValues[0] + squareValues[1] + squareValues[2] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(1);
            gameScript.SelectSquare(2);

            selectedSquare = true;
        }

        if (squareValues[3] + squareValues[4] + squareValues[5] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(3);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(5);

            selectedSquare = true;
        }

        if (squareValues[6] + squareValues[7] + squareValues[8] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(6);
            gameScript.SelectSquare(7);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[0] + squareValues[3] + squareValues[6] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(3);
            gameScript.SelectSquare(6);

            selectedSquare = true;
        }

        if (squareValues[1] + squareValues[4] + squareValues[7] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(1);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(7);

            selectedSquare = true;
        }

        if (squareValues[2] + squareValues[5] + squareValues[8] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(2);
            gameScript.SelectSquare(5);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[0] + squareValues[4] + squareValues[8] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(0);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(8);

            selectedSquare = true;
        }

        if (squareValues[2] + squareValues[4] + squareValues[6] == (int)playerOpponent * 2 &&
            !selectedSquare)
        {
            gameScript.SelectSquare(2);
            gameScript.SelectSquare(4);
            gameScript.SelectSquare(6);

            selectedSquare = true;
        }
    }
}
