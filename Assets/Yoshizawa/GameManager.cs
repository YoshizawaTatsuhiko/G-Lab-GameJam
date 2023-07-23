using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 日本語対応
public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    public bool IsPause { get; private set; } = false;

    [SerializeField] private LifeManager _life = null;
    [SerializeField] private Text _lifeText = null;
    [SerializeField] private GameObject _resultPanel = null;
    private static GameManager _instance = null;
    private Text _resultText = null;
    private float _survivalTime = 0f;

    private void Awake()
    {
        if (!_instance) _instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        IsPause = false;
        _resultPanel.SetActive(false);
        _resultText = _resultPanel.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (!_life)
        {
            _lifeText.text = "Life : 0";
            _resultPanel.SetActive(true);
            if (_resultText) _resultText.text = $"貴方は[{_survivalTime.ToString("F2")}秒]守れた！";
            IsPause = true;
        }
        else
        {
            _lifeText.text = $"Life : {_life.Life}";
        }

        if (_life.Life > 0) _survivalTime += Time.deltaTime;
    }
}
