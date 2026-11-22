using UnityEngine;

public class ArmThrowSwing : MonoBehaviour
{
    public Transform armBone;
    public Vector3 windUpAngle = new Vector3(60f, 0f, 0f);
    public Vector3 throwAngle = new Vector3(-90f, 0f, 0f);
    public float windUpDuration = 0.2f;
    public float throwDuration = 0.15f;
    public float returnDuration = 0.3f;

    private Quaternion initialRotation;
    private float timer = 0f;
    private bool isSwinging = false;

    void Start()
    {
        if (armBone != null)
        {
            initialRotation = armBone.localRotation;
        }
    }

    void Update()
    {
        if (!isSwinging && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (armBone != null)
            {
                initialRotation = armBone.localRotation;
            }
            isSwinging = true;
            timer = 0f;
        }
    }

    void LateUpdate()
    {
        if (armBone == null || !isSwinging) return;

        timer += Time.deltaTime;
        Vector3 currentEuler;

        if (timer < windUpDuration)
        {
            float t = timer / windUpDuration;
            currentEuler = Vector3.Lerp(Vector3.zero, windUpAngle, t);
        }
        else if (timer < windUpDuration + throwDuration)
        {
            float t = (timer - windUpDuration) / throwDuration;
            currentEuler = Vector3.Lerp(windUpAngle, throwAngle, t);
        }
        else if (timer < windUpDuration + throwDuration + returnDuration)
        {
            float t = (timer - windUpDuration - throwDuration) / returnDuration;
            currentEuler = Vector3.Lerp(throwAngle, Vector3.zero, t);
        }
        else
        {
            armBone.localRotation = initialRotation;
            isSwinging = false;
            return;
        }

        armBone.localRotation = initialRotation * Quaternion.Euler(currentEuler);
    }
}
