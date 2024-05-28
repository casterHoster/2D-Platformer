using UnityEngine;

public class Skill
{
   public float Range { get; }
   public bool IsActive { get; private set; }

    public Skill(float range)
    {
        Range = range;
    }

    public void ChangeActivity()
    {
        IsActive = !IsActive;
    }
}
