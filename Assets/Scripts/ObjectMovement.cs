using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{
    public Transform target;
    public float duration = 2f;
    public float pauseDuration = 1f;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(MoveLoop());
    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToTarget());
            yield return new WaitForSeconds(pauseDuration);
            yield return StartCoroutine(MoveToStartingPosition());
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    private IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startingPosition, target.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = target.position;
    }

    private IEnumerator MoveToStartingPosition()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(target.position, startingPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = startingPosition;
    }
}
