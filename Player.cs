using System;


namespace CatAndMouse
{
    enum State
    {
        Winner,
        Loser,
        Playing,
        NotInGame
    }

    class Player
    {
        public string name;
        public int location;
        public State state = State.NotInGame;
        public int distanceTraveled = 0;

        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }

        public void Move(int steps, int fieldSize)
        {
            if (state == State.NotInGame)
            {
                location = ((steps - 1) % fieldSize + fieldSize) % fieldSize + 1;
                state = State.Playing;
            }
            else
            {
                location = ((location - 1 + steps) % fieldSize + fieldSize) % fieldSize + 1;
                distanceTraveled += Math.Abs(steps);
            }
        }
    }
}
