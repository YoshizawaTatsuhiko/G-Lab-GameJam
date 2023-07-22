using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 日本語対応
public class GameManager : MonoBehaviour
{
    [SerializeField] private LifeManager _life = null;
    [SerializeField] private Text _lifeText = null;
    [SerializeField] private GameObject _resultPanel = null;
    private Text _resultText = null;
    private float _survivalTime = 0f;

    private void Start()
    {
        _resultPanel.SetActive(false);

        if (_resultPanel.TryGetComponent(out Text t)) _resultText = t;
    }

    private void Update()
    {
        if (!_life || !_resultPanel) throw new System.Exception("assignされていない項目があります。");

        if(_lifeText) _lifeText.text = $"Life : {_life.Life}";

        if (_life.Life > 0) _survivalTime += Time.deltaTime;
        else
        {
            _resultPanel.SetActive(true);

            if (_resultText) _resultText.text = $"貴方は「{_survivalTime.ToString("F2")}秒間」\n守りきれた！";
        }
    }
}
