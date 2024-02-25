using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinsCountDrawer : MonoBehaviour
{
    [SerializeField] private Text _textCoinsCount;


    public void DrawCoinsCount(int value) => _textCoinsCount.text = value.ToString();
}
