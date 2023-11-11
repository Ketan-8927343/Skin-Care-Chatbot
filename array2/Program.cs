using System;
namespace Asign2
{
    class Program
    {
        static void print_board(char[][] board)
        {
            int i, j;
            Console.WriteLine("\nGame Board");
            Console.WriteLine("=================");
            for (i = 0; i <= 2; i++)
            {
                for (j = 0; j <= 2; j++)
                {
                    Console.Write("|| {0} ", board[i][j]);
                }
                Console.WriteLine("||\n=================");
            }
        }
        static bool game(char[][] board, int row, int Column)
        {
            if (row >= 1 && row <= 3 && Column >= 1 && Column <= 3)
            {
                if (board[row - 1][Column - 1] == ' ')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static bool win(char[][] board, int Verson)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (board[i][0] != ' ' && board[i][0] == board[i][1] && board[i][1] == board[i][2])
                {
                    if (board[i][0] == 'O')
                    {
                        Console.WriteLine("Participant A Won!");
                    }
                    else
                    {
                        if (Verson == 1)
                            Console.WriteLine("Participant B Won!");
                        else
                            Console.WriteLine("Computer Won!");
                    }
                    return true;
                }
            }
            for (int j = 0; j <= 2; j++)
            {
                if (board[0][j] != ' ' && board[0][j] == board[1][j] && board[1][j] == board[2][j])
                {
                    if (board[0][j] == 'O')
                    {
                        Console.WriteLine("Participant A Won!");
                    }
                    else
                    {
                        if (Verson == 1)
                            Console.WriteLine("Participant B Won!");
                        else
                            Console.WriteLine("Computer Won!");
                    }
                    return true;
                }
            }
            if (board[0][0] != ' ' && board[0][0] == board[1][1] && board[1][1] == board[2][2])
            {
                if (board[0][0] == 'O')
                {
                    Console.WriteLine("Participant A Won!");
                }
                else
                {
                    if (Verson == 1)
                        Console.WriteLine("Participant  Won!");
                    else
                        Console.WriteLine("Computer Won!");
                }
                return true;
            }
            if (board[0][2] != ' ' && board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                if (board[0][2] == 'O')
                {
                    Console.WriteLine("Participant A Won!");
                }
                else
                {
                    if (Verson == 1)
                        Console.WriteLine("Participant B Won!");
                    else
                        Console.WriteLine("Computer Won!");
                }
                return true;
            }
            int count = 0;
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i][j] == ' ')
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Game Draw!");
                return true;
            }
            return false;
        }
        static void FlushKey()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }
        static int left_row(char[][] board, int row)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (board[row][j] == ' ')
                    return j;
            }
            return -1;
        }
        static int left_column(char[][] board, int Column)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][Column] == ' ')
                    return j;
            }
            return -1;
        }
        static int leftcell(char[][] board)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][j] == ' ')
                    return j;
            }
            return -1;
        }
        static int leftcell2(char[][] board)
        {
            if (board[0][2] == ' ')
                return 0;
            else if (board[1][1] == ' ')
                return 1;
            else if (board[2][0] == ' ')
                return 2;
            else
                return -1;
        }
        static int count_zero(char[][] board, int row)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[row][j] == 'O')
                    c++;
            }
            return c;
        }
        static int count_column(char[][] board, int Column)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][Column] == 'O')
                    c++;
            }
            return c;
        }
        static int count_zeros_dia(char[][] board)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][j] == 'O')
                    c++;
            }
            return c;
        }
        static int count_zero2(char[][] board)
        {
            int c = 0;

            if (board[0][2] == 'O')
                c++;
            if (board[1][1] == 'O')
                c++;
            if (board[2][0] == 'O')
                c++;
            return c;
        }
        static int count_cross_row(char[][] board, int row)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[row][j] == 'X')
                    c++;
            }
            return c;
        }
        static int count_cross_Column(char[][] board, int Column)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][Column] == 'X')
                    c++;
            }
            return c;
        }
        static int count_cross_dia(char[][] board)
        {
            int c = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (board[j][j] == 'X')
                    c++;
            }
            return c;
        }
        static int count_cross_dia2(char[][] board)
        {
            int c = 0;

            if (board[0][2] == 'X')
                c++;
            if (board[1][1] == 'X')
                c++;
            if (board[2][0] == 'X')
                c++;
            return c;
        }
        static int[] next_move(char[][] board)
        {
            int[] move = new int[2];
            for (int i = 0; i <= 2; i++)
            {
                int l = left_row(board, i);
                if (count_cross_row(board, i) == 2 && l >= 0)
                {
                    move[0] = i;
                    move[1] = l;
                    return move;
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                int l = left_column(board, i);
                if (count_cross_Column(board, i) == 2 && l >= 0)
                {
                    move[0] = l;
                    move[1] = i;
                    return move;
                }
            }
            int local = leftcell(board);
            if (count_cross_dia(board) == 2 && local >= 0)
            {
                move[0] = local;
                move[1] = local;
                return move;
            }
            local = leftcell2(board);
            if (count_cross_dia2(board) == 2 && local >= 0)
            {
                if (local == 0)
                {
                    move[0] = 0;
                    move[1] = 2;
                }
                else if (local == 1)
                {
                    move[0] = 1;
                    move[1] = 1;
                }
                else
                {
                    move[0] = 2;
                    move[1] = 0;
                }
                return move;
            }
            for (int i = 0; i <= 2; i++)
            {
                int l = left_row(board, i);
                if (count_zero(board, i) == 2 && l >= 0)
                {
                    move[0] = i;
                    move[1] = l;
                    return move;
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                int l = left_column(board, i);
                if (count_column(board, i) == 2 && l >= 0)
                {
                    move[0] = l;
                    move[1] = i;
                    return move;
                }
            }
            int local2 = leftcell(board);
            if (count_zeros_dia(board) == 2 && local2 >= 0)
            {
                move[0] = local2;
                move[1] = local2;
                return move;
            }
            local2 = leftcell2(board);
            if (count_zero2(board) == 2 && local2 >= 0)
            {
                if (local2 == 0)
                {
                    move[0] = 0;
                    move[1] = 2;
                }
                else if (local2 == 1)
                {
                    move[0] = 1;
                    move[1] = 1;
                }
                else
                {
                    move[0] = 2;
                    move[1] = 0;
                }
                return move;
            }
            for (int i = 0; i <= 2; i++)
            {
                int l = left_row(board, i);
                if (count_cross_row(board, i) == 1 && l >= 0)
                {
                    move[0] = i;
                    move[1] = l;
                    return move;
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                int l = left_column(board, i);
                if (count_cross_Column(board, i) == 1 && l >= 0)
                {
                    move[0] = l;
                    move[1] = i;
                    return move;
                }
            }
            local = leftcell(board);
            if (count_cross_dia(board) == 1 && local >= 0)
            {
                move[0] = local;
                move[1] = local;
                return move;
            }
            local = leftcell2(board);
            if (count_cross_dia2(board) == 1 && local >= 0)
            {
                if (local == 0)
                {
                    move[0] = 0;
                    move[1] = 2;
                }
                else if (local == 1)
                {
                    move[0] = 1;
                    move[1] = 1;
                }
                else
                {
                    move[0] = 2;
                    move[1] = 0;
                }
                return move;
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i][j] == ' ')
                    {
                        move[0] = i;
                        move[1] = j;
                        return move;
                    }
                }
            }
            return move;
        }
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("*****  Tic-Tac-Toe Game  *****");
                int Verson;
                do
                {
                    Console.WriteLine("1. Basic Verson\n2. Advanced Verson");
                    Console.Write("\nSelect verson either 1 or 2:");
                    Verson = Console.Read();
                    Verson -= 48;
                    bool round = true;
                    int row, Column;
                    char[][] board = new char[3][];
                    board[0] = new char[] { ' ', ' ', ' ' };
                    board[1] = new char[] { ' ', ' ', ' ' };
                    board[2] = new char[] { ' ', ' ', ' ' };
                    if (Verson == 1)
                    {
                        Console.WriteLine("O for Participant A and X for Participant B");
                        print_board(board);

                        do
                        {
                            if (round)
                                Console.WriteLine("Its Participant A's round");
                            else
                                Console.WriteLine("Its Participant B's round");
                            Console.Write("Enter row from 1 to 3: ");
                            FlushKey();
                            row = Console.Read();
                            row -= 48;
                            Console.Write("Enter column from 1 to 3: ");
                            FlushKey();
                            Column = Console.Read();
                            Column -= 48;
                            if (game(board, row, Column))
                            {
                                if (round)
                                    board[row - 1][Column - 1] = 'O';
                                else
                                    board[row - 1][Column - 1] = 'X';
                                round = !round;
                                print_board(board);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        while (!win(board, Verson));
                    }
                    else if (Verson == 2)
                    {
                        Console.WriteLine("O for Participant A and X for Computer");

                        print_board(board);

                        do
                        {
                            if (round)
                            {
                                Console.WriteLine("Its Participant A's round");
                                Console.Write("Enter the row from 1 to 3: ");
                                FlushKey();
                                row = Console.Read();
                                row -= 48;
                                Console.Write("Enter the column from 1 to 3: ");
                                FlushKey();
                                Column = Console.Read();
                                Column -= 48;
                            }
                            else
                            {
                                Console.WriteLine("Its Computer's round");
                                int[] move = next_move(board);
                                row = move[0] + 1;
                                Column = move[1] + 1;
                            }
                            if (game(board, row, Column))
                            {
                                if (round)
                                    board[row - 1][Column - 1] = 'O';
                                else
                                    board[row - 1][Column - 1] = 'X';
                                round = !round;
                                print_board(board);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        while (!win(board, Verson));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Verson");
                    }
                    FlushKey();
                }
                while (Verson != 1 && Verson != 2);
                Console.Write("Play Again? (Y or N): ");
                choice = Console.ReadLine();
            }
            while (!choice.ToLower().Equals("n"));
            Console.WriteLine("Thanks");
            Console.ReadKey();
        }
    }
}
