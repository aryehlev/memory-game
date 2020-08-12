using System.Drawing;
using System.Windows.Forms;
using Match_game_logic;

namespace Match_game_UI
{
    internal class CardButton : Button
    {
        private Card m_ButtonCard;
        private Image m_ImageToShow;

        public CardButton(Card i_Card, Image i_ImageToShow)
        { 
            m_ButtonCard = i_Card;
            m_ImageToShow = i_ImageToShow;
            this.ButtonCard.Expose += this.ButtonCard_Expose;
            this.ButtonCard.UnExpose += this.ButtonCard_UnExpose;
        }

        internal Card ButtonCard
        {
            get
            {
                return m_ButtonCard;
            }
        }

        internal Image ImageToShow
        {
            get
            {
                return m_ImageToShow;
            }
        }

        private void ButtonCard_Expose()
        {
            this.Image = ImageToShow;
            this.Update();
        }

        private void ButtonCard_UnExpose()
        {
            this.Image = null;
            this.BackColor = Color.Transparent;
            this.Update();
        }
    }
}
