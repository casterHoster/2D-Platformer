using UnityEngine;

public class Skill
{
    private float _range;

    private bool _isActive;

   public float Range { get => _range; }
   public bool IsActive { get => _isActive; }

    public Skill(float range)
    {
        _range = range;
    }

    public void ChangeActivity()
    {
        _isActive = !_isActive;
    }
}
