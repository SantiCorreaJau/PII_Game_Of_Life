using System;
using System.Threading;

public class Bucle
{

    private ProxGeneracion engine; // Guarda GameOfLifeEngine en un atributo

    public Bucle(ProxGeneracion engine)
    {
        this.engine = engine;
    }


    public void Run(bool[,] initialBoard, int delay = 300) // Método que comienza el loop, toma como argumento el tablero y una variable que vamos
        // a usar para asignarle un delay a la generación de tableros
    {
        bool[,] b = initialBoard; // Crea una referencia y llama b al tablero

        while (true) // Bucle infinito
        {
            PrinterConsola.Render(b);

            b = engine.Next(b); // Sobreescribe el tablero actual por el próximo

            Thread.Sleep(delay); // Pausa la ejecución la cantidad de ms asignada
        }
    }
}
// srp:La clase GameLoop tiene una única responsabilidad:
//coordinar el ciclo principal del juego. No calcula las reglas
// ni imprime el tablero.
//Su único motivo de cambio sería si la manera de orquestar el bucle del juego se modifica.
//expert: GameLoop es el experto en ejecutar el flujo porque tiene las referencias a los dos
//colaboradores necesarios (ConsoleRenderer y GameOfLifeEngine). Como conoce a ambos y recibe
//el tablero inicial, es el que tiene toda la información para encargarse de correr la simulación paso a paso.  