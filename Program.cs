using System;

class Game
{
    static void Main()
    {
        ConsoleGame consoleGame = new ConsoleGame();

        while (true)
        {
            consoleGame.Update();
        }
    }
}

class GameField
{
    private int width;
    private int height;

    public GameField(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        Console.SetCursorPosition(0, 0); // Рисование верхней границы
        for (int i = 0; i < width; i++)
        {
            Console.Write("#");
        }

        Console.SetCursorPosition(0, height - 1); // Рисование нижней границы
        for (int i = 0; i < width; i++)
        {
            Console.Write("#");
        }

        for (int i = 1; i < height - 1; i++) // Рисование левой и правой границ
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");

            Console.SetCursorPosition(width - 1, i);
            Console.Write("#");
        }
    }
}

class ConsoleGame
{
    private int posX;
    private int posY;
    private GameField gameField;

    public ConsoleGame()
    {
        posX = 10;
        posY = 10;
        gameField = new GameField(40, 20); // Задайте размеры поля по вашему усмотрению
    }

    public void Update()
    {
        Console.Clear();
        gameField.Draw();
        Draw();
        HandleInput();
    }

    private void Draw()
    {
        Console.SetCursorPosition(posX, posY);
        Console.Write("@");
    }

    private void HandleInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        int prevPosX = posX;
        int prevPosY = posY;

        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                posY--;
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                posX--;
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                posY++;
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                posX++;
                break;
            default:
                break; // Если нажата другая клавиша, ничего не делаем
        }

        if (posX < 1 || posX >= 40 - 1 || posY < 1 || posY >= 20 - 1) // Проверка на выход за границы поля
        {
            // Возвращаемся к предыдущей позиции
            posX = prevPosX;
            posY = prevPosY;
        }
    }
}
