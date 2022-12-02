using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClickGauge : MonoBehaviour
{
    public Image gaugeImage;

    public float drainSpeed = 1;
    public float addAmount = 0.2f;

    private void Start()
    {
        StartCoroutine(RandomRoutine());
    }

    public void OnClick()
    {
        if (!gaugeImage.gameObject.activeSelf) return;
        
        gaugeImage.fillAmount += addAmount;
        if (gaugeImage.fillAmount >= 1)
        {
            gaugeImage.gameObject.SetActive(false);
        }
    }

    private IEnumerator RandomRoutine()
    {
        while (true)
        {
            if (!gaugeImage)
            {
                yield break;
            }
            
            if (gaugeImage.gameObject.activeSelf)
            {
                gaugeImage.fillAmount -= Time.deltaTime * drainSpeed;
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(3f, 10f));
                gaugeImage.gameObject.SetActive(true);
                gaugeImage.fillAmount = 0.75f;
            }
        }
    }
}
