using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharecterAnimator : MonoBehaviour
{
    [SerializeField] List<Sprite> walkDownSprites;
    [SerializeField] List<Sprite> walkUpSprites;
    [SerializeField] List<Sprite> walkRightSprites;
    [SerializeField] List<Sprite> walkLeftSprites;


    [SerializeField] List<Sprite> swimDownSprites;
    [SerializeField] List<Sprite> swimUpSprites;
    [SerializeField] List<Sprite> swimRightSprites;
    [SerializeField] List<Sprite> swimLeftSprites;


    [SerializeField] List<Sprite> torchDownSprites;
    [SerializeField] List<Sprite> torchUpSprites;
    [SerializeField] List<Sprite> torchRightSprites;
    [SerializeField] List<Sprite> torchLeftSprites;

    [SerializeField] List<Sprite> holdRockDownSprites;
    [SerializeField] List<Sprite> holdRockUpSprites;
    [SerializeField] List<Sprite> holdRockRightSprites;
    [SerializeField] List<Sprite> holdRockLeftSprites;


    [SerializeField] List<Sprite> attackDownSprites;
    [SerializeField] List<Sprite> attackUpSprites;
    [SerializeField] List<Sprite> attackRightSprites;
    [SerializeField] List<Sprite> attackLeftSprites;



    [SerializeField] List<Sprite> well1DownSprites;
    [SerializeField] List<Sprite> well1UpSprites;
    [SerializeField] List<Sprite> well1RightSprites;
    [SerializeField] List<Sprite> well1LeftSprites;

    [SerializeField] List<Sprite> well2DownSprites;
    [SerializeField] List<Sprite> well2UpSprites;
    [SerializeField] List<Sprite> well2RightSprites;
    [SerializeField] List<Sprite> well2LeftSprites;


    [SerializeField] List<Sprite> well3DownSprites;
    [SerializeField] List<Sprite> well3UpSprites;
    [SerializeField] List<Sprite> well3RightSprites;
    [SerializeField] List<Sprite> well3LeftSprites;


    [SerializeField] List<Sprite> well4DownSprites;
    [SerializeField] List<Sprite> well4UpSprites;
    [SerializeField] List<Sprite> well4RightSprites;
    [SerializeField] List<Sprite> well4LeftSprites;


    [SerializeField] List<Sprite> well5DownSprites;
    [SerializeField] List<Sprite> well5UpSprites;
    [SerializeField] List<Sprite> well5RightSprites;
    [SerializeField] List<Sprite> well5LeftSprites;



    [SerializeField] List<Sprite> well6DownSprites;
    [SerializeField] List<Sprite> well6UpSprites;
    [SerializeField] List<Sprite> well6RightSprites;
    [SerializeField] List<Sprite> well6LeftSprites;

    [SerializeField] List<Sprite> well7DownSprites;
    [SerializeField] List<Sprite> well7UpSprites;
    [SerializeField] List<Sprite> well7RightSprites;
    [SerializeField] List<Sprite> well7LeftSprites;

    [SerializeField] List<Sprite> well8DownSprites;
    [SerializeField] List<Sprite> well8UpSprites;
    [SerializeField] List<Sprite> well8RightSprites;
    [SerializeField] List<Sprite> well8LeftSprites;

    [SerializeField] List<Sprite> well9DownSprites;
    [SerializeField] List<Sprite> well9UpSprites;
    [SerializeField] List<Sprite> well9RightSprites;
    [SerializeField] List<Sprite> well9LeftSprites;

    [SerializeField] List<Sprite> FishDownSprites;
    [SerializeField] List<Sprite> FishUpSprites;
    [SerializeField] List<Sprite> FishRightSprites;
    [SerializeField] List<Sprite> FishLeftSprites;


    [SerializeField] List<Sprite> surfSprites;
    [SerializeField] FacingDirection defaultDir = FacingDirection.Down;


    PlayerController player;

    // Parameters
    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }
    public bool IsJumping { get; set; }

    public bool IsSwimming { get; set; }

    public bool IsFishing { get; set; }

    public bool IsSHoldingTorch{ get; set; }

    public bool IsHoldingRock { get; set; }

    public bool IsHoldingBottomLeftPiece{ get; set; }

    public bool IsHoldingMiddleLeftPiece { get; set; }

    public bool IsHoldingUpperLeftPiece { get; set; }

    public bool IsHoldingUpperRightPiece { get; set; }

    public bool IsHoldingMiddleRightPiece { get; set; }

    public bool IsHoldingTailPiece { get; set; }

    public bool IsHoldingLowerTailPiece { get; set; }

    public bool IsHoldingLowerRightPiece { get; set; }
    public bool IsSHoldingFreezeItem { get; set; }

    public bool IsHoldingWell1Piece { get; set; }

    public bool IsHoldingWell2Piece { get; set; }

    public bool IsHoldingWell3Piece { get; set; }

    public bool IsHoldingWell4Piece { get; set; }

    public bool IsHoldingWell5Piece { get; set; }

    public bool IsHoldingWell6Piece { get; set; }

    public bool IsHoldingWell7Piece { get; set; }

    public bool IsHoldingWell8Piece { get; set; }

    public bool IsHoldingWell9Piece { get; set; }

    public bool isPlayer;


    // States
    [Header("Walk")]
    SpriteAnimator walkDownAnim;
    SpriteAnimator walkUpAnim;
    SpriteAnimator walkRightAnim;
    SpriteAnimator walkLeftAnim;

    [Header("Swim")]
    SpriteAnimator swimDownAnim;
    SpriteAnimator swimUpAnim;
    SpriteAnimator swimRightAnim;
    SpriteAnimator swimLeftAnim;

    [Header("Attack")]
   public SpriteAnimator attackDownAnim;
   public SpriteAnimator attackUpAnim;
   public SpriteAnimator attackRightAnim;
   public SpriteAnimator attackLeftAnim;

    [Header("Torch")]
    SpriteAnimator torchDownAnim;
    SpriteAnimator torchUpAnim;
    SpriteAnimator torchRightAnim;
    SpriteAnimator torchLeftAnim;

    [Header("Freeze Item")]
    SpriteAnimator freezeDownAnim;
    SpriteAnimator freezeUpAnim;
    SpriteAnimator freezeRightAnim;
    SpriteAnimator freezeLeftAnim;

    [Header("Rock Item")]
    SpriteAnimator rockDownAnim;
    SpriteAnimator rockUpAnim;
    SpriteAnimator rockRightAnim;
    SpriteAnimator rockLeftAnim;


    [Header("well1 Item")]
    SpriteAnimator well1DownAnim;
    SpriteAnimator well1UpAnim;
    SpriteAnimator well1RightAnim;
    SpriteAnimator well1LeftAnim;


    [Header("well2 Item")]
    SpriteAnimator well2DownAnim;
    SpriteAnimator well2UpAnim;
    SpriteAnimator well2RightAnim;
    SpriteAnimator well2LeftAnim;



    [Header("well3 Item")]
    SpriteAnimator well3DownAnim;
    SpriteAnimator well3UpAnim;
    SpriteAnimator well3RightAnim;
    SpriteAnimator well3LeftAnim;



    [Header("well4 Item")]
    SpriteAnimator well4DownAnim;
    SpriteAnimator well4UpAnim;
    SpriteAnimator well4RightAnim;
    SpriteAnimator well4LeftAnim;


    [Header("well5 Item")]
    SpriteAnimator well5DownAnim;
    SpriteAnimator well5UpAnim;
    SpriteAnimator well5RightAnim;
    SpriteAnimator well5LeftAnim;


    [Header("well6 Item")]
    SpriteAnimator well6DownAnim;
    SpriteAnimator well6UpAnim;
    SpriteAnimator well6RightAnim;
    SpriteAnimator well6LeftAnim;

    [Header("well7 Item")]
    SpriteAnimator well7DownAnim;
    SpriteAnimator well7UpAnim;
    SpriteAnimator well7RightAnim;
    SpriteAnimator well7LeftAnim;


    [Header("well8 Item")]
    SpriteAnimator well8DownAnim;
    SpriteAnimator well8UpAnim;
    SpriteAnimator well8RightAnim;
    SpriteAnimator well8LeftAnim;

    [Header("well9 Item")]
    SpriteAnimator well9DownAnim;
    SpriteAnimator well9UpAnim;
    SpriteAnimator well9RightAnim;
    SpriteAnimator well9LeftAnim;

    [Header("Fishing")]
    SpriteAnimator fishDownAnim;
    SpriteAnimator fishUpAnim;
    SpriteAnimator fishRightAnim;
    SpriteAnimator fishLeftAnim;


    protected SpriteAnimator currentAnim;
   protected bool wasPreviouslyMoving;

    // Refrences
    SpriteRenderer spriteRenderer;



    protected virtual void Start()
    {

        
        spriteRenderer = GetComponent<SpriteRenderer>();

        walkDownAnim = new SpriteAnimator(walkDownSprites, spriteRenderer);
        walkUpAnim = new SpriteAnimator(walkUpSprites, spriteRenderer);
        walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);

        swimDownAnim = new SpriteAnimator(swimDownSprites, spriteRenderer);
        swimUpAnim = new SpriteAnimator(swimUpSprites, spriteRenderer);
        swimRightAnim = new SpriteAnimator(swimRightSprites, spriteRenderer);
        swimLeftAnim = new SpriteAnimator(swimLeftSprites, spriteRenderer);


        torchDownAnim = new SpriteAnimator(torchDownSprites, spriteRenderer);
        torchUpAnim = new SpriteAnimator(torchUpSprites, spriteRenderer);
        torchRightAnim = new SpriteAnimator(torchRightSprites, spriteRenderer);
        torchLeftAnim = new SpriteAnimator(torchLeftSprites, spriteRenderer);

        attackUpAnim = new SpriteAnimator(attackUpSprites,spriteRenderer);
        attackDownAnim = new SpriteAnimator(attackDownSprites,spriteRenderer);
        attackLeftAnim = new SpriteAnimator(attackLeftSprites,spriteRenderer);
        attackRightAnim = new SpriteAnimator(attackRightSprites,spriteRenderer);

        rockUpAnim = new SpriteAnimator(holdRockUpSprites, spriteRenderer);
        rockDownAnim = new SpriteAnimator(holdRockDownSprites, spriteRenderer);
        rockLeftAnim = new SpriteAnimator(holdRockLeftSprites, spriteRenderer);
        rockRightAnim = new SpriteAnimator(holdRockRightSprites, spriteRenderer);

        well1UpAnim = new SpriteAnimator(well1UpSprites, spriteRenderer);
        well1DownAnim = new SpriteAnimator(well1DownSprites, spriteRenderer);
        well1LeftAnim = new SpriteAnimator(well1LeftSprites, spriteRenderer);
        well1RightAnim = new SpriteAnimator(well1RightSprites, spriteRenderer);


        well2UpAnim = new SpriteAnimator(well2UpSprites, spriteRenderer);
        well2DownAnim = new SpriteAnimator(well2DownSprites, spriteRenderer);
        well2LeftAnim = new SpriteAnimator(well2LeftSprites, spriteRenderer);
        well2RightAnim = new SpriteAnimator(well2RightSprites, spriteRenderer);


        well3UpAnim = new SpriteAnimator(well3UpSprites, spriteRenderer);
        well3DownAnim = new SpriteAnimator(well3DownSprites, spriteRenderer);
        well3LeftAnim = new SpriteAnimator(well3LeftSprites, spriteRenderer);
        well3RightAnim = new SpriteAnimator(well3RightSprites, spriteRenderer);


        well4UpAnim = new SpriteAnimator(well4UpSprites, spriteRenderer);
        well4DownAnim = new SpriteAnimator(well4DownSprites, spriteRenderer);
        well4LeftAnim = new SpriteAnimator(well4LeftSprites, spriteRenderer);
        well4RightAnim = new SpriteAnimator(well4RightSprites, spriteRenderer);

        well5UpAnim = new SpriteAnimator(well5UpSprites, spriteRenderer);
        well5DownAnim = new SpriteAnimator(well5DownSprites, spriteRenderer);
        well5LeftAnim = new SpriteAnimator(well5LeftSprites, spriteRenderer);
        well5RightAnim = new SpriteAnimator(well5RightSprites, spriteRenderer);

        well6UpAnim = new SpriteAnimator(well6UpSprites, spriteRenderer);
        well6DownAnim = new SpriteAnimator(well6DownSprites, spriteRenderer);
        well6LeftAnim = new SpriteAnimator(well6LeftSprites, spriteRenderer);
        well6RightAnim = new SpriteAnimator(well6RightSprites, spriteRenderer);

        well7UpAnim = new SpriteAnimator(well7UpSprites, spriteRenderer);
        well7DownAnim = new SpriteAnimator(well7DownSprites, spriteRenderer);
        well7LeftAnim = new SpriteAnimator(well7LeftSprites, spriteRenderer);
        well7RightAnim = new SpriteAnimator(well7RightSprites, spriteRenderer);

        well8UpAnim = new SpriteAnimator(well8UpSprites, spriteRenderer);
        well8DownAnim = new SpriteAnimator(well8DownSprites, spriteRenderer);
        well8LeftAnim = new SpriteAnimator(well8LeftSprites, spriteRenderer);
        well8RightAnim = new SpriteAnimator(well8RightSprites, spriteRenderer);

        well9UpAnim = new SpriteAnimator(well9UpSprites, spriteRenderer);
        well9DownAnim = new SpriteAnimator(well9DownSprites, spriteRenderer);
        well9LeftAnim = new SpriteAnimator(well9LeftSprites, spriteRenderer);
        well9RightAnim = new SpriteAnimator(well9RightSprites, spriteRenderer);

        fishUpAnim = new SpriteAnimator(FishUpSprites, spriteRenderer);
        fishDownAnim = new SpriteAnimator(FishDownSprites, spriteRenderer);
        fishLeftAnim = new SpriteAnimator(FishLeftSprites, spriteRenderer);
        fishRightAnim = new SpriteAnimator(FishRightSprites, spriteRenderer);


        SetFacingDir(defaultDir);

        currentAnim = walkDownAnim;
    }

    protected virtual void Update()
    {
        
        var prevAnim = currentAnim;

       
        {
            if (MoveX == 1)
                currentAnim = walkRightAnim;
            else if (MoveX == -1)
                currentAnim = walkLeftAnim;
            else if (MoveY == 1)
                currentAnim = walkUpAnim;
            else if (MoveY == -1)
                currentAnim = walkDownAnim;


            if (IsHoldingRock == true)
            {
                if (MoveX == 1)
                    currentAnim = rockRightAnim;
                else if (MoveX == -1)
                    currentAnim = rockLeftAnim;
                else if (MoveY == 1)
                    currentAnim = rockUpAnim;
                else if (MoveY == -1)
                    currentAnim = rockDownAnim;
            }

            if (IsHoldingWell1Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well1RightAnim;
                else if (MoveX == -1)
                    currentAnim = well1LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well1UpAnim;
                else if (MoveY == -1)
                    currentAnim = well1DownAnim;
            }

            if (IsHoldingWell2Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well2RightAnim;
                else if (MoveX == -1)
                    currentAnim = well2LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well2UpAnim;
                else if (MoveY == -1)
                    currentAnim = well2DownAnim;
            }

            if (IsHoldingWell3Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well3RightAnim;
                else if (MoveX == -1)
                    currentAnim = well3LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well3UpAnim;
                else if (MoveY == -1)
                    currentAnim = well3DownAnim;
            }

            if (IsHoldingWell4Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well4RightAnim;
                else if (MoveX == -1)
                    currentAnim = well4LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well4UpAnim;
                else if (MoveY == -1)
                    currentAnim = well4DownAnim;
            }

            if (IsHoldingWell5Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well5RightAnim;
                else if (MoveX == -1)
                    currentAnim = well5LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well5UpAnim;
                else if (MoveY == -1)
                    currentAnim = well5DownAnim;
            }

            if (IsHoldingWell6Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well6RightAnim;
                else if (MoveX == -1)
                    currentAnim = well6LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well6UpAnim;
                else if (MoveY == -1)
                    currentAnim = well6DownAnim;
            }

            if (IsHoldingWell7Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well7RightAnim;
                else if (MoveX == -1)
                    currentAnim = well7LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well7UpAnim;
                else if (MoveY == -1)
                    currentAnim = well7DownAnim;
            }

            if (IsHoldingWell8Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well8RightAnim;
                else if (MoveX == -1)
                    currentAnim = well8LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well8UpAnim;
                else if (MoveY == -1)
                    currentAnim = well8DownAnim;
            }

            if (IsHoldingWell9Piece == true)
            {
                if (MoveX == 1)
                    currentAnim = well9RightAnim;
                else if (MoveX == -1)
                    currentAnim = well9LeftAnim;
                else if (MoveY == 1)
                    currentAnim = well9UpAnim;
                else if (MoveY == -1)
                    currentAnim = well9DownAnim;
            }

            if (IsSHoldingFreezeItem == true)
            {
                if (MoveX == 1)
                    currentAnim = freezeRightAnim;
                else if (MoveX == -1)
                    currentAnim = freezeLeftAnim;
                else if (MoveY == 1)
                    currentAnim = freezeUpAnim;
                else if (MoveY == -1)
                    currentAnim = freezeDownAnim;
            }

            if (IsSHoldingTorch == true)
            {
                if (MoveX == 1)
                    currentAnim = torchRightAnim;
                else if (MoveX == -1)
                    currentAnim = torchLeftAnim;
                else if (MoveY == 1)
                    currentAnim = torchUpAnim;
                else if (MoveY == -1)
                    currentAnim = torchDownAnim;
            }

            if (IsFishing == true)
            {
                if (MoveX == 1)
                    currentAnim = fishRightAnim;
                else if (MoveX == -1)
                    currentAnim = fishLeftAnim;
                else if (MoveY == 1)
                    currentAnim = fishUpAnim;
                else if (MoveY == -1)
                    currentAnim = fishDownAnim;
            } 
            if(IsSwimming == true)
            {
                if (MoveX == 1)
                    currentAnim = swimRightAnim;
                else if (MoveX == -1)
                    currentAnim = swimLeftAnim;
                else if (MoveY == 1)
                    currentAnim = swimUpAnim;
                else if (MoveY == -1)
                    currentAnim = swimDownAnim;
            }

           

            if (currentAnim != prevAnim || IsMoving != wasPreviouslyMoving)
                currentAnim.Start();

            if (IsMoving)
                currentAnim.HandleUpdate();
            else
                spriteRenderer.sprite = currentAnim.Frames[0];

        } 

        wasPreviouslyMoving = IsMoving;
    }


    public void SetFacingDir(FacingDirection dir)
    {
        if (dir == FacingDirection.Right)
            MoveX = 1f;
        else if (dir == FacingDirection.Left)
            MoveX = -1f;
        else if (dir == FacingDirection.Down)
            MoveY = -1f;
        else if (dir == FacingDirection.Up)
            MoveY = 1f;
    }


 
    public FacingDirection DefultDirection 
    {
        get => defaultDir;
    }
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
