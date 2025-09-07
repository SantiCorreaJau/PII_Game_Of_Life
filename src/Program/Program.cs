using System;
using Ucu.Poo.GameOfLife;

public class Program
{
    public static void Main(string[] args)
    {
        TextBoardReader reader = new TextBoardReader(); // Crea el lector del tablero
        GameOfLifeEngine engine = new GameOfLifeEngine(); // Crea el motor
        ConsoleRenderer renderer = new ConsoleRenderer(); // Crea el que muestra el estado actual en la pantalla
        GameLoop loop = new GameLoop(renderer, engine); // Crea la clase que dirije el juego
        
        string path = "ruta_del_archivo.txt"; // Ruta del archivo
        bool[,] board = reader.Read(path); // Carga el archivo de texto e inicializa el primer tablero

        loop.Run(board, 300); // Comienza el bucle con delay 300ms
    }
}