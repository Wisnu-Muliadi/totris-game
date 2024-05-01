using UnityEngine;
using Text = UnityEngine.UI.Text;

namespace Tomino.View
{
    /// <summary>
    /// ngatur popup
    /// </summary>
    public class PopUpText : MonoBehaviour
    {
        public Game game;
        public Text popUpText;
        private void Start()
        {
            Debug.Log(popUpText.text);
            Debug.Log(game != null);
        }
        public void PopUp(int rowsCleared)
        {
            if (rowsCleared > 0)
            {
                popUpText.text = game.Score.RowsClearedScore(rowsCleared).ToString();
                Debug.Log("Rows Cleared" + rowsCleared);
            }
        }
    }
}