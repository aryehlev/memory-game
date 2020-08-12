using System;

namespace Match_game_logic
{
    public class Card
    {
        private char m_Letter;
        private bool m_Exposed;

        public event Action Expose;

        public event Action UnExpose;
       
        public Card(char i_Letter)
        {
            this.m_Letter = i_Letter;
            this.m_Exposed = false;
        }

        public char Letter
        {
            get
            {
                return this.m_Letter;
            }

            set
            {
                this.m_Letter = value;
            }
        }

        public bool Exposed
        {
            get
            {
                return this.m_Exposed;
            }

            set
            {
                this.m_Exposed = value;
                if(value)
                {
                    this.OnExpose();
                }
                else
                {
                    this.OnUnExpose();
                }
            }
        }

        protected virtual void OnUnExpose()
        {
            this.UnExpose?.Invoke();
        }

        protected virtual void OnExpose()
        {
            this.Expose?.Invoke();
        }
    }
}
