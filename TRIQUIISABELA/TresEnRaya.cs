

namespace TRIQUIISABELA
{
    class TresEnRaya
    {

        private int[,] matriz = new int[3, 3];
        private int ganador = -1;

        private int[] ultimoMovimientoMaquina = new int[3];

        public int[,] Matriz { get => matriz; set => matriz = value; }
        public int Ganador { get => ganador; set => ganador = value; }
        public int[] UltimoMovimientoMaquina { get => ultimoMovimientoMaquina; set => ultimoMovimientoMaquina = value; }

        //inicialmente todas las caillas de la matriz tendran -1
        public void inicializarPartida()
        {
           
           //El -1 indica que no se a iniciado ninguna jugada todavia, no hay ganador definido al inicio de la partida
           //Los for recorren cada fila y columna , i fila y j columna
           //Determinar si la casiila esta ocupada en cada jugada
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    matriz[i, j] = -1;
            Ganador = -1;
        }

        public void seleccionarPosicion(int x, int y)
        {
            //Jugador pueda elejir en que casilla colocar su movimiento
            //el if verifica que las coordenas que oprima si existan 
            //matriz verifica si la casilla esta disponible
            if (x >= 0 && x < 3 && y >= 0 && y < 3 && matriz[x, y] == -1 && Ganador == -1)
            {
                matriz[x, y] = 0;
                Ganador = ganaPartida();
                mueveMaquina();
            }
        }

        //Miramos si alguan combinacion gana
        public int ganaPartida()
        {
            //Verifica si hay ganador 
            //aux Almacena valor si alguien gana 
            int aux = -1;

            //Diagonales
            if (matriz[0, 0] != -1 && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
                aux = matriz[0, 0];

            if (matriz[0, 2] != -1 && matriz[0, 2] == matriz[1, 1] && matriz[0, 2] == matriz[2, 0])
                aux = matriz[0, 2];

            //horizontal y vertical
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 0] != -1 && matriz[i, 0] == matriz[i, 1] && matriz[i, 0] == matriz[i, 2])
                    aux = matriz[i, 0];

                if (matriz[0, i] != -1 && matriz[0, i] == matriz[1, i] && matriz[0, i] == matriz[2, i])
                    aux = matriz[0, i];
            }


            return aux;
        }

        public bool tableroLleno()
        {
            //saber si hay casillas llenas o no
            bool tableroCompleto = true;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                        tableroCompleto = false;


            return tableroCompleto;
        }

        public bool finJuego()
        {
            //Verificar si el juego se ha acabado o no
            bool fin = false;
            if (tableroLleno() || ganaPartida() != -1)
                fin = true;

            return fin;

        }

        public void mueveMaquina()
        {

            if (!finJuego())
            {
                //f fila, c columna, v valores iniciales, movimiento maquina sea mayor 
                //Se actualizan las valores con los movimientos que se hacen

                int f = 0;
                int c = 0;
                int v = -99999999;
                int aux;

                for (int i = 0; i < matriz.GetLength(0); i++)
                    for (int j = 0; j < matriz.GetLength(1); j++)
                        if (matriz[i, j] == -1)
                        {
                            matriz[i, j] = 1;
                            aux = minimo();
                            if (aux > v)
                            {
                                v = aux;
                                f = i;
                                c = j;
                            }

                            matriz[i, j] = -1;
                        }
                matriz[f, c] = 1;
                ultimoMovimientoMaquina[0] = f;
                ultimoMovimientoMaquina[1] = c;
            }


        }


        private int maximo()
        {
            //Mira todas la jugadas que se han hecho y busca la que mas le combiene a la ia para poner la prosima jugada
            if (finJuego())
            {
                if (ganaPartida() != -1)
                    return -1;
                else
                    return 0;
            }

            int v = -99999999;
            int aux;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                    {
                        matriz[i, j] = 1;
                        aux = minimo();
                        if (aux > v)
                            v = aux;

                        matriz[i, j] = -1;
                    }

            return v;
        }

        private int minimo()
        {
            if (finJuego())
            {
                if (ganaPartida() != -1)
                    return 1;
                else
                    return 0;
            }

            int v = 99999999;
            int aux;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                    {
                        matriz[i, j] = 0;
                        aux = maximo();
                        if (aux < v)
                            v = aux;

                        matriz[i, j] = -1;
                    }

            return v;
        }
    }
}