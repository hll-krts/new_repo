using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoreSlideShow : MonoBehaviour
{
    [SerializeField] private Sprite[] loreSlides;
    [SerializeField] private GameObject Text;
    private int slideIndex = 0;
    [SerializeField] private Image slide;

    private void Start()
    {
        Text.SetActive(true);
        SetImage();
    }

    public void ChangeSlide()
    {
        if (slideIndex == loreSlides.Length - 1)
        {
            SceneManager.LoadSceneAsync(2);
        }
        else
        {
            slideIndex++;
            SetImage();
        }

        if (Text.activeSelf)
        {
            Text.SetActive(false);
        }

    }
    public void SetImage()
    {
        slide.sprite = loreSlides[slideIndex];
    }
}
