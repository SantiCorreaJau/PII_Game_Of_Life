public class ProxGeneracion
{
    // A partir del tablero actual, aplicando las reglas del juego, genera el siguiente
    public bool[,] Next(bool[,] gameBoard) // Devuelve un tablero de bools, toma como argumento un tablero de bools
    {
        int boardWidth = gameBoard.GetLength(0); // Obtiene las dimensiones del tablero
        int boardHeight = gameBoard.GetLength(1);

        bool[,] cloneboard = new bool[boardWidth, boardHeight]; // Atributo que va a almacenar el próximo tablero
        for (int x = 0; x < boardWidth; x++) // Recorre las filas y columnas del tablero
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0; // Inicializa la variable para contar los vecinos vivos
                for (int i = x - 1; i <= x + 1; i++) // Recorre los vecinos, es decir, comienza 'uno antes' que su posición y termina 'uno después'
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j]) // Si la posición en la que está ubicado, no se 'salió' del tablero,
                                                                                                    // y además está vivo, suma 1 a la variable aliveNeighbors
                        {
                            aliveNeighbors++;
                        }
                    }
                }
                if (gameBoard[x, y]) // Si la célula a la que le estaba contando los vecinos vivos, está viva, le resta 1 a aliveNeighbors porque el sistema de conteo
                                    // ya la hubiera agregado como un vecino vivo, cuando en realidad es ella misma
                {
                    aliveNeighbors--;
                }
                if (gameBoard[x, y] && aliveNeighbors < 2) // Si hay menos de 2 vecinos vivos, la celula estará muerta en el próximo tablero
                {
                    // Celula muere por baja población
                    cloneboard[x, y] = false;
                }
                else if (gameBoard[x, y] && aliveNeighbors > 3) // Si hay más de 3 vecinos vivos, la celula estará muerta en el próximo tablero
                {
                    // Celula muere por sobrepoblación
                    cloneboard[x, y] = false;
                }
                else if (!gameBoard[x, y] && aliveNeighbors == 3) // Si la célula estaba muerta y tiene 3 vecinos vivos, estará viva en el próximo tablero
                {
                    // Celula nace por reproducción
                    cloneboard[x, y] = true;
                }
                else // Si no se cumple ninguno de estos casos, se mantiene como estaba
                {
                    // Celula mantiene el estado que tenía
                    cloneboard[x, y] = gameBoard[x, y];
                }
            }
        }
        return cloneboard; // Returneamos el tablero siguiente
    }
}
//SRP: Esta clase se encarga únicamente de aplicar las reglas del Juego
//de la Vida para pasar de un tablero al siguiente. No lee archivos,
//no imprime en consola y tampoco coordina el loop.
//Si el día de mañana cambiamos la forma en que se muestran los
//resultados o cómo se carga el tablero, esta clase no se toca.

//Expert: GameOfLifeEngine tiene todo lo que necesita para cumplir su tarea:
//recibe el tablero actual y sabe cómo contar vecinos, aplicar las reglas de
// y devolver el nuevo tablero. Nadie más debería encargarse de esa lógica.