namespace Ucu.Poo.GameOfLife;
//Se creo esta clase, la cual es la resposable de conocer el datos de los vecinos de cada celda ya que tiene esa informacion
//Su UNICA RESPOSABILIDAD es saber el estado del tablero (vecinos)
public class Board
{
    public bool[,] Casillas { get; private set; } 
    public int Filas { get; private set; }
    public int Columnas { get; private set; }
    
    //CONSTRUCTOR
    public Board(bool[,] TableroInicial)
    {
        this.Casillas = TableroInicial;
        this.Filas = TableroInicial.GetLength(0);
        this.Columnas = TableroInicial.GetLength(1);
    }

    public bool CeldaViva(int PosFila, int PosCol)
    {
        return Casillas[PosFila, PosCol];
    }

    public int CantidadVecinos(int PosFila, int PosCol)
    {
        int Cantidad = 0;

        for (int i = PosFila - 1; i <= PosFila + 1; i++)
        {
            for (int j = PosCol - 1; j <= PosCol + 1; j++)
            {
                if (i >= 0 && i < Filas &&
                    j >= 0 && j < Columnas &&
                    CeldaViva(i,j))
                {
                    Cantidad++;
                }
            }
        }

        if (CeldaViva(PosFila, PosCol))
        {
            Cantidad--;
        }

        return Cantidad;
    }
    public void ActualizarTablero(bool[,] nuevoTablero) //Utilizado por Game cuando reemplaze todo el tablero despues de calcular la sig generacion
    {
        Casillas = nuevoTablero;
        Filas = nuevoTablero.GetLength(0);
        Columnas = nuevoTablero.GetLength(1);
    }
}