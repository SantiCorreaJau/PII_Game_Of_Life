namespace Ucu.Poo.GameOfLife;

using System;
using System.IO; //ESTO NOS PERMITE TRABAJAR CON ARCHIVOS

public class TextBoardReader
{           //LA UNICA RESPONSABILIDAD QUE TIENE ESTA CLASE ES LEER EL ARCHIVO Y DEVOLVER UNA MATRIZ
            // Devuelve la matriz bool[,] leyendo un archivo con "1" y "0"
    public bool[,] Read(string path)        
    {
        string url = path; // la variable original
        string content = File.ReadAllText(url);  
        string[] contentLines = content.Split('\n');  //al leer cada lina se genera un \n por el salto de linea y con esto se lo sacamos
        bool[,] board = new bool[contentLines.Length, contentLines[0].Length]; //creamos la matriz para representar el tablero
        for (int y = 0; y < contentLines.Length; y++) //recorremos las filas (y) del archivo 
        {
            for (int x = 0; x < contentLines[y].Length; x++) // y acá recorremos cada caracter dentro de la fila (y)
            {
                if (contentLines[y][x] == '1') 
                {
                    board[x, y] = true; // si el numerito en el que está parado es =1, su valor es true
                                        // sino no hacemos nada porque false es el valor por defecto.
                }
            }
        }
        return board;  //devolvemos lo que es el tablero
    }
}

