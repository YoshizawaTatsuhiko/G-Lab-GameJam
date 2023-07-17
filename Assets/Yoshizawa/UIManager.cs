using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 日本語対応
public class UIManager : MonoBehaviour
{
    [SerializeField] private LifeManager _life = null;
    [SerializeField] private Text _lifeText = null;

    private void Update()
    {
        if(_lifeText) _lifeText.text = $"Life : {_life.Life}";
    }
}
