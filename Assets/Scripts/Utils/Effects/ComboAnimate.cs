using System.Collections;
using TMPro;
using UnityEngine;

public class ComboAnimate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] Gradient gradient;

    private float moveSpeed = 200f;
    public void SetCombo(int value)
    {
        comboText.color = gradient.Evaluate(Random.Range(0, 100));
        comboText.text = $"Combo X {value}";
    }
    private void OnEnable()
    {
        StartCoroutine(MoveUp());
    }
    IEnumerator MoveUp()
    {
        WaitForSeconds interval = new WaitForSeconds(0.10f);
        float i = 1f;
        while (i > 0)
        {
            i -= 0.05f;
            comboText.color = new Color(comboText.color.r, comboText.color.g, comboText.color.b, i);
            yield return interval;
        }
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}
