using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Battleunit : MonoBehaviour
{
   
    [SerializeField] Animator battleUnitAnim;

    [SerializeField] bool isPlayerUnit;

    [SerializeField] Transform animParent;

    [SerializeField] BattleHud hud;

    public Creature Creature { get { return theCreature; } set {theCreature = value;}}

    [SerializeField] Creature theCreature;


    private void OnEnable()
    {
        battleUnitAnim.SetBool("IsPlayer", IsPlayerUnit);
    }

   
 

   
    public bool IsPlayerUnit {
        get { return isPlayerUnit; }

     
    }

    public bool CanUseMoves()
    {
        foreach (Move move in Creature.Moves)
        {
            if(move.Base.Name == "Hit")
            {
                continue;
            }
            if(Creature.MP <= move.Base.MPCost)
            {
                return true;
            }
        }
        return false;
    }

    public BattleHud  Hud {
        get{ return hud;  }
        }
   
    public Image image;
    Vector3 originalPos;
    Color originalColor;

    public void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.position;
        originalColor = image.color;
    }
    public void SetUp(Creature creature)
    {
        Creature = creature;
        if (isPlayerUnit)
            GetComponent<Image>().sprite = creature.Base.RightSprite;
        else
            GetComponent<Image>().sprite = creature.Base.Leftsprite;

        hud.gameObject.SetActive(true);
        hud.SetData(creature);

        transform.localScale = creature.Base.creatureSize;
        image.color = originalColor;
        PlayEnterAnimation();
    }

    public void Clear()
    {
        hud.gameObject.SetActive(false);
    }

    public void PlayEnterAnimation()
    {
        if (isPlayerUnit)
            image.transform.localPosition = new Vector3(-200, originalPos.x);
        else
            image.transform.localPosition = new Vector3(200f, originalPos.x);

        image.transform.DOLocalMoveY(originalPos.y, 0f);
    }

    public void PlayAttackAnimation(string curMove)
    {
        if (string.IsNullOrEmpty(curMove) == false)
        {
            if (GlobalSettings.HasParameter(curMove, battleUnitAnim) == true)
            {
                battleUnitAnim.SetTrigger(curMove);
                return;
            } else
            {
                Debug.Log($"Move Anim has not been set {curMove}, isplayer {isPlayerUnit}" );
            }
           
        }
        var sequence = DOTween.Sequence();
        if (isPlayerUnit)
            sequence.Append(image.transform.DOLocalMoveY(originalPos.x - 5f, 0.25f));
        else
            sequence.Append(image.transform.DOLocalMoveY(originalPos.x - 5f, 0.25f));

        sequence.Append(image.transform.DOLocalMoveY(originalPos.x + 50, .25f));
    }

    public void PLayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.red, 0.5f));
        sequence.Append(image.DOColor(originalColor, 0.1f));

    }

    public void PlayDeathAnim()
    {
        var sequance = DOTween.Sequence();
        sequance.Append(image.transform.DOLocalMoveY(originalPos.y, 0.5f));
        sequance.Join(image.DOFade(0f, 0.5f));
    }

    public IEnumerator PlayCaptureAnimation ()
    {
        var sequance = DOTween.Sequence();
        sequance.Append(image.DOFade(0, .5f));
        sequance.Join(transform.DOLocalMoveY(originalPos.y + 50f, 0.5f));
        sequance.Join(transform.DOScale(new Vector3(0.3f, 0.3f, 1f), 0.5f));
        yield return sequance.WaitForCompletion();
    }

    public IEnumerator PlayBreakOutAnimation()
    {
        var sequance = DOTween.Sequence();
        sequance.Append(image.DOFade(1, .5f));
        sequance.Join(transform.DOLocalMoveY(originalPos.y, 0.5f));
        sequance.Join(transform.DOScale(new Vector3(1f, 1, 1f), 0.5f));
        yield return sequance.WaitForCompletion();
    }

    
}
