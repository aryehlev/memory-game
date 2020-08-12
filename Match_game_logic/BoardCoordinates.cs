namespace Match_game_logic
{
    public struct BoardCoordinates
    {
        private int m_Row;
        private int m_Column;

        public BoardCoordinates(int i_Row = -1, int i_Column = -1)
        {
            this.m_Row = i_Row;
            this.m_Column = i_Column;
        } 
        
        public int Row
        {
            get
            {
                return this.m_Row;
            }

            set
            {
                this.m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.m_Column;
            }

            set
            {
                this.m_Column = value;
            }
        }
    }
}
