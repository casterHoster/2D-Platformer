using System.Collections;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;

    private SpriteRenderer _skillView;

    private void Awake()
    {
        _vampirism.IsActivated += ActivateSkillView;
    }

    private void Start()
    {
        _skillView = GetComponent<SpriteRenderer>();
        _skillView.enabled = false;
    }

    private void ActivateSkillView(float skillTime)
    {

        StartCoroutine(CoutTime(skillTime));
    }

    private IEnumerator CoutTime(float skillTime)
    {
        _skillView.enabled = true;
        yield return new WaitForSeconds(skillTime);
        _skillView.enabled = false;
    }
}
