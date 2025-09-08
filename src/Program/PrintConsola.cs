using System;
using System.Text;

public class PrintConsola
{
    public void Render(bool[,] b) // No devuelve nada, toma como argumento un tablero al que llama 'b'
    {
        int width = b.GetLength(0); // Incializa como argumento las dimensiones del tablero
        int height = b.GetLength(1);

//        Console.Clear(); // Limpia la consola
        StringBuilder s = new StringBuilder(); // 
        for (int y = 0; y < height; y++) // Recorre cada célula
        {
            for (int x = 0; x < width; x++) 
            {
                if (b[x, y]) // Si esta viva, imprime X
                {
                    s.Append("|X|");
                }
                else
                {
                    s.Append("___"); // Si está muerta, imprime '___'
                }
            }
            s.Append("\n"); // Le agrega un salto de línea una vez termina con cada fila
        }
        Console.WriteLine(s.ToString()); // Convierte a string y lo imprime
    }
}
// SRP: Esta clase se dedica únicamente a mostrar el tablero en la consola.
// No sabe nada de cómo se calculan las reglas del juego ni de cómo
// se cargó el tablero desde un archivo. Si mañana tuvieramos ganas de mostrarlo en una
// alguna otra manera en vez de consola, la única clase que habría que cambiar es esta.

//Expert: ConsoleRenderer tiene todo lo que necesita para cumplir su rol: recibe el tablero
//y sabe cómo recorrerlo e imprimirlo celda por celda. Nadie más debería encargarse de cómo
//se dibuja, porque este es el experto en mostrar las cosas por pantalla.
