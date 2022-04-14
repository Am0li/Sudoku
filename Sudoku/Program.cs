using System;

class Sudoku
{
    static bool is_row_valid(int[,] board,int number,int row)
    {
        for(int i = 0; i < 9; i++)
        {
            if(board[row, i]==number)
            {
                return false;
            }
        }
        return true;
    }
    static bool is_column_valid(int[,] board, int number, int column)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i, column] == number)
            {
                return false;
            }
        }
        return true;
    }

    static bool is_box_valid(int[,] board, int number,int row, int column)
    {
        row -= row % 3;
        column -= column % 3;
        for(int i=row;i<row+3;i++)
        {
            for(int j=column;j<column+3;j++)
            {
                if (board[i, j] == number)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool is_place_valid(int[,] board, int number, int row, int column)
    {
        return is_box_valid(board, number, row, column) && is_column_valid(board, number, column) && is_row_valid(board, number, row);
    }
    static bool solver(int[,] board)
    {
        for(int row=0;row<9;row++)
        {
            for(int column=0;column<9;column++)
            {
                if (board[row, column] == 0)
                {
                    for (int number = 1; number <= 9; number++)
                    {
                        if(is_place_valid(board,number,row,column))
                        {
                            board[row, column] = number;
                            if (solver(board))
                            {
                                return true;
                            }
                            else
                            {
                                board[row, column] = 0;
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }
    static void showboard(int[,] board)
    {
        for(int row=0;row<9;row++)
        {
            if(row%3==0&&row!=0)
            {
                Console.WriteLine("----------");
            }
            for(int column=0;column<9;column++)
            {
                if (column % 3 == 0 && column != 0)
                {
                    Console.Write("|");
                }
                Console.Write(board[row,column]);
            }
            Console.WriteLine();
        }

    }
    static void Main(string[] args)
    {
        int[,] board =
        {
            { 2, 0, 6, 0, 0, 9, 0, 3, 0},
            { 0, 0, 0, 0, 7, 0, 0, 9, 0},
            { 7, 9, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 5, 3, 0, 0, 0, 1, 0},
            { 0, 0, 0, 1, 0, 0, 0, 8, 7},
            { 1, 7, 0, 0, 5, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 4, 0, 0},
            { 0, 5, 8, 0, 0, 6, 0, 0, 0},
            { 0, 0, 0, 0, 2, 0, 6, 0, 1}
        };
        Console.WriteLine(solver(board));
        showboard(board);
        
    }
}
