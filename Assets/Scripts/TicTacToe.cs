using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour
{
    // UI elements
    [SerializeField] Button[] gameButtons;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Text winText;

    // Variables
    int[] squareValues;

    enum PlayerTurn
    {
        Player1 = 1,
        Player2 = 4
    }

    PlayerTurn playerTurn;

    int winner;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in gameButtons)
        {
            button.interactable = false;
        }
        squareValues = new int[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    // Initialize the game
    public void StartGame()
    {
        for (int i = 0; i < gameButtons.Length; i++)
        {
            gameButtons[i].interactable = true;
            gameButtons[i].GetComponentInChildren<TMP_Text>().text = "";
            squareValues[i] = 0;
        }

        startButton.interactable = false;

        playerTurn = PlayerTurn.Player1;

        winner = 0;
        winText.text = "";
    }

    void EndGame()
    {
        foreach (var button in gameButtons)
        {
            button.interactable = false;
        }

        startButton.interactable = true;
    }

    // Try to select a square for the current player
    public void SelectSquare(int index)
    {
        if (squareValues[index] == 0)
        {
            squareValues[index] = (int)playerTurn;

            // Update the text of the selected square
            if (playerTurn == PlayerTurn.Player1)
            {
                gameButtons[index].GetComponentInChildren<TMP_Text>().text = "X";
                CheckForWin();
                playerTurn = PlayerTurn.Player2;
            }
            else
            {
                gameButtons[index].GetComponentInChildren<TMP_Text>().text = "O";
                CheckForWin();
                playerTurn = PlayerTurn.Player1;
            }
            gameButtons[index].interactable = false;
        }
    }

    void CheckForWin()
    {
        bool tie;

        if (squareValues[0] + squareValues[1] + squareValues[2] == (int)playerTurn * 3 ||
            squareValues[3] + squareValues[4] + squareValues[5] == (int)playerTurn * 3 ||
            squareValues[6] + squareValues[7] + squareValues[8] == (int)playerTurn * 3 ||
            squareValues[0] + squareValues[3] + squareValues[6] == (int)playerTurn * 3 ||
            squareValues[1] + squareValues[4] + squareValues[7] == (int)playerTurn * 3 ||
            squareValues[2] + squareValues[5] + squareValues[8] == (int)playerTurn * 3 ||
            squareValues[0] + squareValues[4] + squareValues[8] == (int)playerTurn * 3 ||
            squareValues[6] + squareValues[4] + squareValues[2] == (int)playerTurn * 3)
        {
            winner = (int)playerTurn;

            if (winner == (int)PlayerTurn.Player1)
            {
                winText.text = "X Wins";
            }
            else
            {
                winText.text = "O Wins";
            }

            EndGame();
        }

        if (winner == 0)
        {
            tie = true;

            for (int i = 0; i < squareValues.Length; i++)
            {
                if (squareValues[i] == 0)
                {
                    tie = false;
                }
            }
            if (tie)
            {
                winText.text = "Draw";
                EndGame();
            }
        }
    }
}
