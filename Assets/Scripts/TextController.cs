using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextController : MonoBehaviour
{
    public TMP_Text text;
    private int gold;

    private void Start()
    {
        text.text = $"{gold}";
    }

    public void AddGold()
    {
        text.transform.DOScale(1, 0.4f).ChangeStartValue(new Vector3(2,2,2));
        text.text = $"{++gold}";
    }
}
