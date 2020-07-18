using UnityEngine;

public class LearnLerf : MonoBehaviour
{
    public float a = 0;
    public float b = 10;

    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.7f* Time.deltaTime );
    }
}
