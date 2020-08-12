﻿using System;

namespace Match_game_logic
{ 
    public class Game
    {
        private readonly GameBoard r_GameBoard;
        private readonly eAiModes r_AiMode;
        private readonly AiForComputerPlay r_ComputerAi;
        private Player m_Player1;
        private Player m_Player2;

        public event Action<Player> GameOver;
        
        public Game(
            int i_NumberOfRows,
            int i_NumberOfColumns,
            eAiModes i_AiMode,
            string i_NameOfPlayer1,
            string i_NameOfPlayer2 = "Computer")
        {
            this.r_GameBoard = new GameBoard(i_NumberOfRows, i_NumberOfColumns);
            this.m_Player1 = new Player(i_NameOfPlayer1, false, true);
            this.m_Player2 = new Player(i_NameOfPlayer2, i_AiMode != eAiModes.Off, false);
            this.r_AiMode = i_AiMode;
            this.r_ComputerAi = null;
            
            if (i_AiMode != eAiModes.Off)
            {
                this.r_ComputerAi = new AiForComputerPlay(i_AiMode);
            }
        } 
        
        public Player Player1
        {
            get
            {
                return this.m_Player1;
            }

            set
            {
                this.m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return this.m_Player2;
            }

            set
            {
                this.m_Player2 = value;
            }
        } 
        
        public GameBoard GameBoard
        {
            get
            {
                return this.r_GameBoard;
            }
        }

        public eAiModes AiMode
        {
            get
            {
                return this.r_AiMode;
            }
        }

        public AiForComputerPlay AiForComputerPlay
        {
            get
            {
                return this.r_ComputerAi;
            }
        }

        public Player WhosTurnIsIt()
        {
            return this.Player1.IsMyTurn ? this.Player1 : this.Player2;
        }

        public bool GuessCardAndUpdateScores(Card i_Card)
        {
            bool wasSuccessfulGuess = this.r_GameBoard.GuessCard(i_Card);
            
            if (wasSuccessfulGuess)
            {
                if (this.Player1.IsMyTurn)
                {
                    this.Player1.Score++;
                }
                else
                {
                    this.Player2.Score++;
                }
            }
            else
            {
                this.Player1.IsMyTurn = !this.Player1.IsMyTurn;
                this.Player2.IsMyTurn = !this.Player2.IsMyTurn;
            }

            if(this.IsGameOver(out Player o_WinningPlayer))
            {
                OnGameOver(o_WinningPlayer);
            }

            return wasSuccessfulGuess;
        }

        public bool IsGameOver(out Player o_WinningPlayer)
        {
            bool isGameOver = false;
            o_WinningPlayer = null;

            if (this.r_GameBoard.IsBoardFullyExposed())
            {
                isGameOver = true;
                if (this.Player1.Score > this.Player2.Score)
                {
                    o_WinningPlayer = this.Player1;
                }
                else if (this.Player1.Score < this.Player2.Score)
                {
                    o_WinningPlayer = this.Player2;
                }
            }

            return isGameOver;
        }

        protected virtual void OnGameOver(Player i_WinningPlayer)
        {
            this.GameOver?.Invoke(i_WinningPlayer);
        }
    }
}
