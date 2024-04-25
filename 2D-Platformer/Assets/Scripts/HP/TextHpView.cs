using UnityEngine;
using UnityEngine.UI;

public class TextHpView : HpView
{
    [SerializeField] Text _hpText;

    protected override void DrawValue(float current, float max) => _hpText.text = $"{current}/{max}";
}
