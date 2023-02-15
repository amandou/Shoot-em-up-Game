using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    void Start()
    {
        _sliderText.text = _slider.value.ToString();
        _slider.onValueChanged.AddListener((value) =>
        {
            _sliderText.text = value.ToString("0");
        });
    }
}
