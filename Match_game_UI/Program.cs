using System.Windows.Forms;
using Match_game_logic;

namespace Match_game_UI
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }
    }
}
