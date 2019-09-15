using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuApp
{
    public class Program
    {
        public static void DisplayBoard(string boardstring)
        {
            string[] boardRows = { "", "", "", "", "", "", "", "", "" };
            char[] boardArray = boardstring.ToCharArray();

            for (int index = 0; index < boardstring.Length; index++)
            {
                boardRows[index / 9] = boardRows[index / 9] + " " + boardArray[index];
                if (index % 9 == 2 || index % 9 == 5)
                {
                    boardRows[index / 9] = boardRows[index / 9] + " |";
                }
            }
            Console.WriteLine("-------------------------");
            for (int index = 0; index < 9; index++)
            {
                Console.WriteLine("|" + boardRows[index] + " |");
                if (index == 2 || index == 5)
                {
                    Console.WriteLine("-------------------------");
                }
            }
            Console.WriteLine("-------------------------");
        }

        public static char[,] ConvertStringToBoard(string boardstring)
        {
            int row = 9;
            int col = 9;

            char[,] board = new char[row, col];

            int offset = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    board[i, j] = boardstring[offset];

                    offset++;
                }
            }
            return board;
        }

        public static string ConvertBoardToString(char[,] board)
        {
            string boardstring = "";

            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    boardstring = boardstring + board[i, j];
                }

            }

            return boardstring;
        }

        public static string Solve(string boardstring)
        {
            DisplayBoard(boardstring);
            return boardstring;
        }

        public static List<char> IsInRow(List<char> arrayListOfPossibleValues, char[,] board, int indexRow)
        {
            int col = 9;

            for (int i = 0; i < col; i++)
            {
                for (int value = 0; value < arrayListOfPossibleValues.Count(); value++)
                {
                    if (arrayListOfPossibleValues[value] == board[indexRow, i])
                    {
                        arrayListOfPossibleValues.RemoveAt(value);
                    }
                }
            }

            return arrayListOfPossibleValues;
        }

        public static List<char> IsInCol(List<char> arrayListOfPossibleValues, char[,] board, int indexCol)
        {
            int row = 9;

            for (int i = 0; i < row; i++)
            {
                for (int value = 0; value < arrayListOfPossibleValues.Count(); value++)
                {
                    if (arrayListOfPossibleValues[value] == board[i, indexCol])
                    {
                        arrayListOfPossibleValues.RemoveAt(value);
                    }
                }
            }

            return arrayListOfPossibleValues;
        }

        public static List<char> IsInBox(List<char> arrayListOfPossibleValues, char[,] board, int indexRow, int indexCol)
        {
            int r = indexRow - indexRow % 3;
            int c = indexCol - indexCol % 3;

            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    for (int value = 0; value < arrayListOfPossibleValues.Count(); value++)
                    {
                        if (arrayListOfPossibleValues[value] == board[i, j])
                        {
                            arrayListOfPossibleValues.RemoveAt(value);
                        }
                    }
                }
            }

            return arrayListOfPossibleValues;
        }


        public static void CheckEmptyCells(char[,] board)
        {
            bool isThereEmptyCell = true;

            while (isThereEmptyCell)
            {

                for (int row = 0; row <= board.GetUpperBound(0); row++)
                {
                    for (int col = 0; col <= board.GetUpperBound(1); col++)
                    {
                        if (board[row, col].Equals('0'))
                        {
                            int indexRow = row;
                            int indexCol = col;

                            char[] listOfPossibleValues = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                            List<char> arrayListOfPossibleValues = listOfPossibleValues.ToList();

                            arrayListOfPossibleValues = IsInRow(arrayListOfPossibleValues, board, indexRow);
                            arrayListOfPossibleValues = IsInCol(arrayListOfPossibleValues, board, indexCol);
                            arrayListOfPossibleValues = IsInBox(arrayListOfPossibleValues, board, indexRow, indexCol);

                            if (arrayListOfPossibleValues.Count() == 1)
                            {
                                board[indexRow, indexCol] = arrayListOfPossibleValues[0];
                                goto BREAKOUTERLOOP;
                            }
                        }

                        if (row == 8 && col == 8)
                        {
                            isThereEmptyCell = false;
                        }
                    }
                }

            BREAKOUTERLOOP:
                ;

            }
        }

        public static string SudokuSolver(string unsolved)
        {
            char[,] board = new char[9, 9];

            board = ConvertStringToBoard(unsolved);

            CheckEmptyCells(board);

            String boardString = ConvertBoardToString(board);

            return boardString;

        }

        public static void Main(string[] args)
        {
            

        }
    }
}
