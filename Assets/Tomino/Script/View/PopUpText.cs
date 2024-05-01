using System.Collections.Generic;
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

        [SerializeField] Animator animator;
        
        [Header("PopUp Colors")]
        [Tooltip("Warna di pasang ke Popup sesuai jumlah baris yang ter-\"Clear\" pemain")]
        [SerializeField] Color[] colors;

        private void Start()
        {
            ResetAnimator();
        }
        public void PopUp(int rowsCleared)
        {
            switch (rowsCleared)
            {
                case 0:
                    animator.Play("HIDE", 0, 0f);
                    break;
                case 1:
                    popUpText.color = colors[0];
                    EnableLayersCount(1);
                    animator.Play("RESET", 0, 0f);
                    animator.Play("FadeInOut", 1, 0f);
                    break;
                case 2:
                    popUpText.color = colors[1];
                    EnableLayersCount(3);
                    animator.Play("RESET", 0, 0f);
                    animator.Play("FadeInOut", 1, 0f);
                    animator.Play("MoveUp", 2, 0f);
                    break;
                case 3:
                    popUpText.color = colors[2];
                    EnableLayersCount(4);
                    animator.Play("RESET", 0, 0f);
                    animator.Play("FadeInOut", 1, 0f);
                    animator.Play("BounceIn", 3, 0f);
                    break;
                case 4:
                    popUpText.color = colors[3];
                    EnableLayersCount(5);
                    animator.Play("RESET", 0, 0f);
                    animator.Play("FadeInOut", 1, 0f);
                    animator.Play("BounceIn", 3, 0f);
                    animator.Play("Growing", 4, 0f);
                    break;
            }
            if(rowsCleared != 0) popUpText.text = game.Score.RowsClearedScore(rowsCleared).ToString();
        }
        void EnableLayersCount(int count)
        {
            ResetAnimator();
            for (int i = 0; i < count; i++)
            {
                animator.SetLayerWeight(i, 1);
            }
        }
        public void ResetAnimator()
        {
            for (int i = 0; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
            animator.Play("HIDE", 0, 0);
        }
    }
}