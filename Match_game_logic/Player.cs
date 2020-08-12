using System;

namespace Match_game_logic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly bool r_IsComputer;
        private bool m_IsMyTurn;
        private int m_Score;

        public event Action<Player> ScoreChange;

        public event Action<Player> MyTurn;

        public Player(string i_Name, bool i_IsComputer, bool i_IsMyTurn)
        {
            this.r_Name = i_Name;
            this.m_Score = 0;
            this.r_IsComputer = i_IsComputer;
            this.m_IsMyTurn = i_IsMyTurn;
        }

        public int Score
        {
            get
            {
                return this.m_Score;
            }

            set
            {
                this.m_Score = value;
                this.OnScoreChange();
            }
        }

        public string Name
        {
            get
            {
                return this.r_Name;
            }
        }

        public bool IsMyTurn
        {
            get
            {
                return this.m_IsMyTurn;
            }

            set
            {
                this.m_IsMyTurn = value;
                if(value)
                {
                    OnMyTurn();
                }
            }
        }

        public bool IsComputer
        {
            get
            {
                return this.r_IsComputer;
            }
        }

        protected virtual void OnScoreChange()
        {
            ScoreChange?.Invoke(this);
        }

        protected virtual void OnMyTurn()
        {
            MyTurn?.Invoke(this);
        }
    }
}
