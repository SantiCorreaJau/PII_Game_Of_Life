using System;
using Ucu.Poo.GameOfLife;

public class Program
{
    public static void Main(string[] args)
    {
        LectorTexto reader = new LectorTexto(); // Crea el lector del tablero
        ProxGeneracion engine = new ProxGeneracion(); // Crea el motor
        PrintConsola renderer = new PrintConsola(); // Crea el que muestra el estado actual en la pantalla
        Bucle loop = new Bucle(renderer, engine); // Crea la clase que dirije el juego
        
        string path = "board.txt"; // Ruta del archivo
        bool[,] board = reader.Read(path); // Carga el archivo de texto e inicializa el primer tablero

        loop.Run(board, 300); // Comienza el bucle con delay 300ms
    }
}