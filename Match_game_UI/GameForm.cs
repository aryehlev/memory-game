using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Match_game_logic;
using Timer = System.Windows.Forms.Timer;

namespace Match_game_UI
{
    internal class GameForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private Label currentPlayerLabel;
        private Label player1ScoreLabel;
        private Label player2ScoreLabel;
        private Game m_GameToPlay;
        private Timer m_Timer;
        private bool m_IsFirstChoice = true;
        
        public GameForm(Game i_GameToPlay)
        {
            m_GameToPlay = i_GameToPlay;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            currentPlayerLabel = new Label();
            player1ScoreLabel = new Label();
            player2ScoreLabel = new Label();
            m_GameToPlay.Player1.ScoreChange += Player_ScoreChange;
            m_GameToPlay.Player2.ScoreChange += Player_ScoreChange;
            m_GameToPlay.Player1.MyTurn += Player_MyTurn;
            m_GameToPlay.Player2.MyTurn += Player_MyTurn;
            m_GameToPlay.GameOver += m_GameToPlay_GameOver;
            WebClient wc = new WebClient();
            Dictionary<char, Image> imagesByLetters = new Dictionary<char, Image>();
            m_Timer = new Timer();
            m_Timer.Tick += m_Timer_Tick;

            // currentPlayerLabel
            currentPlayerLabel.AutoSize = true;
            currentPlayerLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            Player_MyTurn(m_GameToPlay.WhosTurnIsIt());

            // player1ScoreLabel
            player1ScoreLabel.AutoSize = true;
            player1ScoreLabel.BackColor = Color.Aquamarine;
            this.player1ScoreLabel.Text = $"{m_GameToPlay.Player1.Name}: 0 Pairs";

            // player2ScoreLabel
            player2ScoreLabel.AutoSize = true;
            player2ScoreLabel.BackColor = Color.LightPink;
            this.player2ScoreLabel.Text = $"{m_GameToPlay.Player2.Name}: 0 Pairs";

            // tableLayoutPanel
            int heightOfBoard = m_GameToPlay.GameBoard.GetHeightOfBoard();
            int lengthOfBoard = m_GameToPlay.GameBoard.GetLengthOfBoard();

            tableLayoutPanel.ColumnCount = lengthOfBoard;
            tableLayoutPanel.RowCount = heightOfBoard;

            for (int i = 0; i < lengthOfBoard; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / lengthOfBoard));
            }

            for (int i = 0; i < heightOfBoard; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / heightOfBoard));
            }

            for (int i = 0; i < heightOfBoard; i++)
            {
                for (int j = 0; j < lengthOfBoard; j++)
                {
                    Card card = m_GameToPlay.GameBoard.GetCardByCoordinates(new BoardCoordinates(i, j));
                    CardButton button = null;
                    if (imagesByLetters.ContainsKey(card.Letter))
                    {
                        button = new CardButton(card, imagesByLetters[card.Letter]);
                    }
                    else
                    {
                        byte[] bytes = wc.DownloadData("https://picsum.photos/80");
                        MemoryStream ms = new MemoryStream(bytes);
                        Image imgFromWeb = Image.FromStream(ms);
                        imagesByLetters.Add(card.Letter, imgFromWeb);
                        button = new CardButton(card, imgFromWeb);
                    }

                    button.BackColor = Color.Transparent;
                    button.Image = null;
                    button.Name = $"Card{i}{j}";
                    button.Dock = DockStyle.Fill;
                    button.Click += CardButton_Click;
                    tableLayoutPanel.Controls.Add(button, j, i);
                }
            }
            
            tableLayoutPanel.Controls.Add(currentPlayerLabel);
            tableLayoutPanel.SetColumnSpan(currentPlayerLabel, lengthOfBoard);

            tableLayoutPanel.Controls.Add(player1ScoreLabel);
            tableLayoutPanel.SetColumnSpan(player1ScoreLabel, lengthOfBoard);

            tableLayoutPanel.Controls.Add(player2ScoreLabel);
            tableLayoutPanel.SetColumnSpan(player2ScoreLabel, lengthOfBoard);

            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
            this.Width = 700;
            this.Height = 700;
            this.Name = "GameForm";
            this.Text = "Memory Game";
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            enableClickEvents();
            m_Timer.Enabled = false;
        }

        private void m_GameToPlay_GameOver(Player i_WinningPlayer)
        {
            endOfGameMsgBox(i_WinningPlayer);
        }

        private void Player_ScoreChange(Player i_PlayerToUpdate)
        {
            if(m_GameToPlay.Player1 == i_PlayerToUpdate)
            {
                this.player1ScoreLabel.Text = $"{i_PlayerToUpdate.Name}: {i_PlayerToUpdate.Score} Pairs";
            }
            else
            {
                this.player2ScoreLabel.Text = $"{i_PlayerToUpdate.Name}: {i_PlayerToUpdate.Score} Pairs";
            }
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            Card cardChosen = (sender as CardButton)?.ButtonCard;
            if(cardChosen != null && !cardChosen.Exposed && !m_GameToPlay.WhosTurnIsIt().IsComputer)
            {
                changeCardButtonColorByPlayer((CardButton)sender, m_GameToPlay.WhosTurnIsIt());
                if (m_IsFirstChoice)
                {
                    m_GameToPlay.GameBoard.ExposeCard(cardChosen);
                    m_IsFirstChoice = false;
                }
                else
                {
                    bool wasSuccess = m_GameToPlay.GuessCardAndUpdateScores(cardChosen);
                    onTurnEnd((CardButton)sender, false, wasSuccess);
                    m_IsFirstChoice = true;
                }
            }
        }

        private void changeCardButtonColorByPlayer(CardButton i_CardButtonToChange, Player i_PlayerTurn)
        {
            i_CardButtonToChange.BackColor = i_PlayerTurn == m_GameToPlay.Player1
                                                 ? Color.Aquamarine
                                                 : Color.LightPink;
            i_CardButtonToChange.Update();
        }

        private void onTurnEnd(CardButton i_CardButton, bool i_IsComputer, bool i_GuessedRight)
        {
            if (!i_GuessedRight)
            {
                secondMoveOnFail(i_CardButton, i_IsComputer);
            }
            else
            {
                secondMoveOnSuccess(i_IsComputer);
            }
        }

        private void secondMoveOnFail(CardButton i_CardButton, bool i_IsComputer)
        {
            Thread.Sleep(1000);
            m_GameToPlay.GameBoard.EraseLastMoveFromBoard(i_CardButton.ButtonCard);
            Thread.Sleep(1000);

            if (m_GameToPlay.AiMode == eAiModes.Random && !i_IsComputer)
            {
                doComputerTurn();
            }
        }

        private void secondMoveOnSuccess(bool i_IsComputer)
        {
            if(i_IsComputer && !m_GameToPlay.IsGameOver(out _))
            {
                Thread.Sleep(1000);
                doComputerTurn();
            }
        }

        private void endOfGameMsgBox(Player i_WinningPlayer)
        {
            string message = i_WinningPlayer == null
                                 ? "it was a tie"
                                 : $"{i_WinningPlayer.Name} won with {i_WinningPlayer.Score}";
            message = $"{message} would you like to play again?";
            const string caption = "End Of Game";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                m_GameToPlay = new Game(
                    m_GameToPlay.GameBoard.GetLengthOfBoard(),
                    m_GameToPlay.GameBoard.GetHeightOfBoard(),
                    m_GameToPlay.AiMode,
                    m_GameToPlay.Player1.Name,
                    m_GameToPlay.Player2.Name);
                this.Controls.Remove(tableLayoutPanel);
                this.InitializeComponent();
            }
            else
            {
                this.Close();
            }
        }

        private void doComputerTurn()
        {
            m_Timer.Enabled = true;
            disableClickEvents();
            Player computerPlayerForColorChange = m_GameToPlay.WhosTurnIsIt();
            BoardCoordinates[] nextMovesCoordinates = m_GameToPlay.AiForComputerPlay.GetCardsForNextMove(m_GameToPlay.GameBoard);
            m_GameToPlay.GameBoard.ExposeCard(m_GameToPlay.GameBoard.GetCardByCoordinates(nextMovesCoordinates[0]));
            CardButton firstCardButtonToChange = tableLayoutPanel.Controls.Find($"Card{nextMovesCoordinates[0].Row}{nextMovesCoordinates[0].Column}", true).FirstOrDefault() as CardButton;
            changeCardButtonColorByPlayer(firstCardButtonToChange, computerPlayerForColorChange);
            Thread.Sleep(1000);
            CardButton secondCardButtonToChange = tableLayoutPanel.Controls.Find($"Card{nextMovesCoordinates[1].Row}{nextMovesCoordinates[1].Column}", true).FirstOrDefault() as CardButton;
            changeCardButtonColorByPlayer(secondCardButtonToChange, computerPlayerForColorChange);
            bool wasSuccess = m_GameToPlay.GuessCardAndUpdateScores(m_GameToPlay.GameBoard.GetCardByCoordinates(nextMovesCoordinates[1]));
            onTurnEnd(secondCardButtonToChange, true, wasSuccess);
        }

        private void disableClickEvents()
        {
            foreach(Control control in tableLayoutPanel.Controls)
            {
                if(control is CardButton cardButtonControl)
                {
                    cardButtonControl.Click -= CardButton_Click;
                }
            }
        }

        private void enableClickEvents()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is CardButton cardButtonControl)
                {
                    cardButtonControl.Click += CardButton_Click;
                }
            }
        }

        private void Player_MyTurn(Player i_Player)
        {
            currentPlayerLabel.BackColor = i_Player == m_GameToPlay.Player1 ? Color.Aquamarine : Color.LightPink;
            currentPlayerLabel.Text = $"Current Player: {i_Player.Name}";
        }
    }
}
