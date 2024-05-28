using System.Collections;
using TMPro;
using UnityEngine;

public class SkillTimer : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private TextMeshProUGUI _timer;

    private void Awake()
    {
        _vampirism.IsActivated += StartCount;
    }

    private void StartCount(float startTime)
    {
        _timer.enabled = true;
        StartCoroutine(CountDown(startTime));
    }

    private IEnumerator CountDown(float startTime)
    {
        _timer.text = startTime.ToString();

        while (startTime > 0)
        {
            yield return new WaitForSeconds(1);
            startTime--;
            _timer.text = startTime.ToString();
        }

        _timer.enabled = false;
    }
}
