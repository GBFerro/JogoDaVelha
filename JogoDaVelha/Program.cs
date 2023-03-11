string[,] board = { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };
int rowLenght = board.GetLength(0), colLenght = board.GetLength(1);
int[] boardPosition = new int[2];

void PrintBoard()
{
    for (int row = 0; row < rowLenght; row++)
    {
        Console.Write($" {row +1} ");
        Console.Write("  ");
        for (int col = 0; col < colLenght; col++)
        {
            if (col < 2)
            {
                Console.Write(board[row, col] + " | ");
            }
            else
            {
                Console.WriteLine(board[row, col]);
            }

        }
        if (row < 2)
        {
            Console.Write("   ");
            Console.Write(" ---");
            Console.Write("+---");
            Console.Write("+---");
            Console.WriteLine();
        }
    }
    Console.WriteLine();
    Console.Write("   ");
    Console.WriteLine("  1   2   3");
}

int[] ChoosePosition()
{
    int[] positionVector = new int[2];

    Console.WriteLine("");

    Console.WriteLine("Digite a linha no tabuleiro: ");
    positionVector[0] = int.Parse(Console.ReadLine())-1;

    Console.WriteLine("Digite a coluna no tabuleiro: ");
    positionVector[1] = int.Parse(Console.ReadLine())-1;

    if (((positionVector[0] > 2) || (positionVector[0] < 0)) || ((positionVector[1] > 2)|| positionVector[1] < 0))
    {
        Console.WriteLine("Digite uma posição válida");
        return ChoosePosition();
    }

    if (IsEmpty(board[positionVector[0], positionVector[1]]))
    {
        return positionVector;
    }

    Console.Clear();
    
    PrintBoard();
    
    Console.WriteLine();
    Console.WriteLine("Digite uma coordenada vazia");
    
    return ChoosePosition();
}

bool IsEmpty(string isEmpty)
{
    if (isEmpty == "-")
    {
        return true;
    }
    return false;
}

bool RoundCheckWinner(int round)
{
    if (round >= 5)
    {
        return true;
    }
    return false;
}

bool RoundCount(int round)
{
    if (round >= 9)
    {
        return true;
    }
    return false;
}

bool IsWinner(string[,] board)
{
    for (int i = 0; i < 3; i++)
    {
        if ((board[0, i].Equals(board[1, i])) && (board[1, i].Equals(board[2, i])) && !(board[0, i].Equals("-")))
        {
            return true;
        }
        else if ((board[i, 0].Equals(board[i, 1])) && (board[i, 1].Equals(board[i, 2])) && !(board[i, 0].Equals("-")))
        {
            return true;
        }
    }
    if ((board[0, 0].Equals(board[1, 1])) && (board[1, 1].Equals(board[2, 2])) && !(board[0, 0].Equals("-")) ||
        (board[0, 2].Equals(board[1, 1])) && (board[1, 1].Equals(board[2, 0])) && !(board[0, 2].Equals("-")))
    {
        return true;
    }
    return false;
}

bool ChangePlayer(int round)
{
    if (round % 2 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

void GameStart()
{
    string player;
    int round = 0;
    bool game = true;
    do
    {
        if (ChangePlayer(round))
        {
            player = "Jogador 1";
            Console.WriteLine($"{player}: ");
        }
        else
        {
            player = "Jogador 2";
            Console.WriteLine($"{player}: ");
        }
        PrintBoard();
        boardPosition = ChoosePosition();

        if (ChangePlayer(round))
        {
            board[boardPosition[0], boardPosition[1]] = "X";
        }
        else
        {
            board[boardPosition[0], boardPosition[1]] = "O";
        }

        round++;
        if (RoundCheckWinner(round))
        {
            if (IsWinner(board))
            {
               
                Console.WriteLine($"O {player} venceu!!!");
                Console.WriteLine("Aperte qualquer tecla");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("    ___    ___     ___     ___     ___     ___    _  _     ___   \r\n   | _ \\  /   \\   | _ \\   /   \\   | _ )   | __|  | \\| |   / __|  \r\n   |  _/  | - |   |   /   | - |   | _ \\   | _|   | .` |   \\__ \\  \r\n  _|_|_   |_|_|   |_|_\\   |_|_|   |___/   |___|  |_|\\_|   |___/  \r\n_| \"\"\" |_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| \r\n\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-' ");
                game = false;
                break;
            }
        }

        if (RoundCount(round))
        {
            Console.WriteLine("DEU VELHA!!!");
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("   ___     ___    _   _           __   __   ___     _      _  _     ___   \r\n  |   \\   | __|  | | | |    o O O \\ \\ / /  | __|   | |    | || |   /   \\  \r\n  | |) |  | _|   | |_| |   o       \\ V /   | _|    | |__  | __ |   | - |  \r\n  |___/   |___|   \\___/   TS__[O]  _\\_/_   |___|   |____| |_||_|   |_|_|  \r\n_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| {======|_| \"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| \r\n\"`-0-0-'\"`-0-0-'\"`-0-0-'./o--000'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-'\"`-0-0-' ");
            break;
        }
        Console.Clear();
    } while (game);
}

GameStart();

