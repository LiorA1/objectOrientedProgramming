namespace Ex05.Logic
{
    // $G$ CSS-999 (-5) this should have been a struct
    public class Chip
    {
        private ePlayerNum m_PlayerNum;
        private eRepresentation m_Representation;

        public Chip()
        {
            m_PlayerNum = ePlayerNum.Empty;
            m_Representation = eRepresentation.Empty;
        }

        public Chip(ePlayerNum i_PlayerNum)
        {
            m_PlayerNum = i_PlayerNum;

            if (i_PlayerNum == ePlayerNum.Player1)
            {
                m_Representation = eRepresentation.Player1;
            }
            else if (i_PlayerNum == ePlayerNum.Player2)
            {
                m_Representation = eRepresentation.Player2;
            }
            else if (i_PlayerNum == ePlayerNum.Computer)
            {
                m_Representation = eRepresentation.Computer;
            }
            else
            {
                m_Representation = eRepresentation.Empty;
            }
        }

        public Chip(ePlayerNum i_PlayerNum, eRepresentation i_Representation)
        {
            m_PlayerNum = i_PlayerNum;
            m_Representation = i_Representation;
        }

        public ePlayerNum PlayerNum
        {
            get { return m_PlayerNum; }
            set { m_PlayerNum = value; }
        }

        public eRepresentation Representation
        {
            get { return m_Representation; }
            set { m_Representation = value; }
        }
    }
}
