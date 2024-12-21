using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public Text damageText;

    public float moveSpeed = 10;

    public float placmentJitter = 1f;

    RectTransform rectTrans;

    public float totalfadeTime = 3f;

    public float fadeTime;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
      

    }
    // Update is called once per frame
    void Update()
    {
        //rectTrans.localPosition = new Vector2(Random.Range(-placmentJitter, placmentJitter) + pos.x, Random.Range(-placmentJitter, placmentJitter) + pos.y);
        //rectTrans.localPosition = new Vector2 (0f, moveSpeed * Time.deltaTime) ;

        fadeTime += Time.deltaTime;
        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, 1 - (fadeTime / totalfadeTime));
        rectTrans.localPosition = new Vector2(rectTrans.localPosition.x, (moveSpeed * Time.deltaTime) + rectTrans.localPosition.y);
    }

    public void SetDamage(int damageAmount, Vector2 pos)
    {
       fadeTime = 0;
        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, 1);
        damageText.text = damageAmount.ToString();
        rectTrans.localPosition = pos;
    }
}
