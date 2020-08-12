using System;
using System.Windows.Forms;
using Match_game_logic;

namespace Match_game_UI
{
    public partial class ConfigForm : Form
    {
        private int m_NumberOfRows = 4;
        private int m_NumberOfColumns = 4;
        private string m_Player1Name = string.Empty;
        private string m_Player2Name = "Computer";
        private eAiModes m_AiMode = eAiModes.Random;

        public ConfigForm()
        {
            InitializeComponent();
        }

        public Game getGame()
        {
            return new Game(m_NumberOfRows, m_NumberOfColumns, m_AiMode, m_Player1Name, m_Player2Name);
        }

        private void friendOrComputerButton_Click(object sender, EventArgs e)
        {
            secondPlayerNameTextBox.Enabled = !secondPlayerNameTextBox.Enabled;
            friendOrComputerButton.Text = secondPlayerNameTextBox.Enabled ? "Against Computer" : "Against a Friend";
            m_AiMode = secondPlayerNameTextBox.Enabled ? eAiModes.Off : eAiModes.Random;
            secondPlayerNameTextBox.Text = secondPlayerNameTextBox.Enabled ? string.Empty : "-Computer-";
            m_Player2Name = secondPlayerNameTextBox.Enabled ? string.Empty : "Computer";
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(getGame());
            this.Close();
            gameForm.ShowDialog();
        }

        private void sizeOfBoardButton_Click(object sender, EventArgs e)
        {
            if(m_NumberOfColumns != 6)
            {
                m_NumberOfColumns += m_NumberOfColumns == 4 && m_NumberOfRows == 5 ? 2 : 1;
            }
            else
            {
                m_NumberOfColumns = 4;
                if(m_NumberOfRows != 6)
                {
                    m_NumberOfRows++;
                }
                else
                {
                    m_NumberOfRows = 4;
                }
            }
            
            sizeOfBoardButton.Text = $"{m_NumberOfRows}x{m_NumberOfColumns}";
        }

        private void firstPlayerNameTextBoxTextChanged(object sender, EventArgs e)
        {
            m_Player1Name = firstPlayerNameTextBox.Text;
        }

        private void secondPlayerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            m_Player2Name = secondPlayerNameTextBox.Text;
        }
    }
}
