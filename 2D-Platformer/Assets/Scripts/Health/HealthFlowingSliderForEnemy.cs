public class HealthFlowingSliderForEnemy : HealthFlowingSlider
{
    private void Update()
    {
        _slider.transform.position = _ownerTransform.position + _offset;
    }
}
