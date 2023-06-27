
using System.Collections;
using UnityEngine;
using TMPro;

public class TextDisappear : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public float delaytime;
    public TextMeshProUGUI textMesh2;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        StartCoroutine(DisappearAfterDelay(delaytime));
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        textMesh.enabled = false;
        textMesh2.enabled = true;
    }


}
