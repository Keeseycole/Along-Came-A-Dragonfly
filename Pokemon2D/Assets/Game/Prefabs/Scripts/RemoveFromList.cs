using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromList : MonoBehaviour
{
    public EnemyDoor objToRemove;

    public KillQuest killQuest;

    public EnemyWaterPuzzle enemyWaterPuzzle;

    public AutoCannon cannon;

    public CannonManager cannonManager;

    public Lava lavaTile;

    public LightningTrigger lightningTrigger;

    public BattleEventManager battleManagerenemies1;

    public ThunderCutsceneManager wave2Enemies;

    SailCutsceneManager sailCutsceneEnemies;

    BeachPrisonCutsceneManager beachPrisonCutscxebeEnemies;

    public Rescue1CutsceneManager rescue1Enemies;

    public Rescue2CutsceneManager rescue2Enemies;

    public Rescue3Cutescene rescue3Enemies;

    public Rescue4Cutscene rescue4Enemies;

    public SilderFightCutsceneManager soliderfightEnemies;

    public SoilderDefenceSystemCutscene thetriggers;

    public MeetOphinusCutsceneManager trigger;

    public MarianaFoodCutsceneManager marianaFoodCutscenetrigger;

    public MeetKingJastusCotsceneManager meetKingJastusCutsceneManager;

    public DragonflyCutsceneManager dragonflySceneMan;

    public MeetMarianaCutsceneManager meetMarianaCotscene;

    public OpeningCutsceneManager openingCutscene;

    public ReptileIceDungCutsceneManager reptileIceDung;

    public MarciusRescueCutsceneManager marcRescueCutscene;

    public MarciusReturnCutsceneManager marcReturnCutscene;

    public AsheriansAttackCutscenesManager asheriansAttackCutscene;

    public MarianaDeathCutsceneManager marianaDeathCutscene;

    public CastleOnFireCutsceneManager castleOnFireCutsceneManager;

    public KingJastusFireCutsceneManager kingJastusFire;

    public OphinusFlashbackCutsceneManager ophinusFlashback;

    public OphinusCrystelCutsceneManager ophinusCrystelCutscene;

    public ArriveInPastCutscene arrivePastCutscene;

    public ReptilianCrystelManager reptilCrystelManager;

    public ReptilianDefeatManager reptileDefeatManager;

    public HiddenCastleManager hiddenCastleCutscene;

    public FishStatue1Manager FishStatueCutscene1;

    public FishStatue2Manager FishStatueCutscene2;

    public FishStatue3Manager FishStatueCutscene3;

    public FishStatue4Manager FishStatueCutscene4;

    public FishStatue5Manager FishStatueCutscene5;

    public IntoThePortalCutscene intoThePortalCutscene;

    public OtherworldPotralCutscene otherworldPortalCutscene;

    public ArriveFutureCutsceneManager arriveFutureCutscene;

    public StatueManager statueManager;

    public DarkCatfishManager darkCarfishManager;

    public DarkCatfishDefeat darkCatfishDefeat;

    public DarkEarthTurtleDefeatManager darkEarthTurtleDefeat;

    public wellRebuiltCutsceneManager wellRebuiltPuzzleMan;

    public DarkIceSnailManager darkIceSnailCutscene;

    public DarkIceSnailDefeatCutscene darkIceSnailDefeatCutscene;

    public IceSnailEnemies iceSnailEnemies;

    public BallnHoleManager ballnHoleman;

    public FireLionManager fireLionMan;

    public FireLionDefeatManager fireLionDefeat;

    public elricFoundCutsceneManager elricFoundCutsceneMan;

    public ElricImprisonedManager elricImprisonedMan;

    public FoundBigKeyCutsceneManager foundBigKey;

    public ElricEscapePrisonCutscene elricEscapeMan;

    public ElricLeavePrisonManager elricLeaveMan;

    public DarkElricHideManager darkElricHideMan;

    public DarkEkricDefeatManager darkElricDefeatMan;

    public ElricDarkManager elricDarkMan;

    public PortalFutureManager portalFutureMan;

    public IntoTheFuturePortalManager intoPortalFutureMan;

    public IceSnailRescuedCutsceneManager iceSnaiRescued;

    public PipeCutsceneManager pipeCutsceneManager;

    public PipeactiveSwitch pipeSwitch;

    public Island1RescueManager island1Rescue;
    private void Start()
    {
        sailCutsceneEnemies = FindObjectOfType<SailCutsceneManager>();
        beachPrisonCutscxebeEnemies = FindObjectOfType<BeachPrisonCutsceneManager>();
        intoThePortalCutscene = FindObjectOfType<IntoThePortalCutscene>();
    }
    private void OnDestroy()
    {

        if (objToRemove != null)
        {
            objToRemove.Enemies.Remove(gameObject);
        }


        if (killQuest != null)
        {
            killQuest.Enemies.Remove(gameObject);
        }


        if (enemyWaterPuzzle != null)
        {
            enemyWaterPuzzle.Enemies.Remove(gameObject);
        }

        if(cannon != null)
        {
            cannonManager.Cannons.Remove(gameObject);
        }

        if (lavaTile != null)
        {
            lavaTile.lava.Remove(gameObject);
        }

        if (lightningTrigger != null)
        {
            lightningTrigger.Enemies.Remove(gameObject);
        }

        if (battleManagerenemies1 != null)
        {
            battleManagerenemies1.Wave1Enemies.Remove(gameObject);
        }

        if (wave2Enemies != null)
        {
            wave2Enemies.trigger.Remove(gameObject);
        }

        if (wave2Enemies != null)
        {
            wave2Enemies.Wave2Enemies.Remove(gameObject);
        }

        if (sailCutsceneEnemies != null)
        {
            sailCutsceneEnemies.enemies.Remove(gameObject);
        }

        if (beachPrisonCutscxebeEnemies != null)
        {
            beachPrisonCutscxebeEnemies.enemies.Remove(gameObject);
        }

        if (rescue1Enemies != null)
        {
            rescue1Enemies.enemies.Remove(gameObject);
        }

        if (rescue2Enemies != null)
        {
            rescue2Enemies.enemies.Remove(gameObject);
        }

        if (rescue3Enemies != null)
        {
            rescue3Enemies.enemies.Remove(gameObject);
        }

        if (rescue4Enemies != null)
        {
            rescue4Enemies.enemies.Remove(gameObject);
        }

        if (soliderfightEnemies != null)
        {
            soliderfightEnemies.Trigger.Remove(gameObject);
        }

        if(thetriggers != null)
        {
            thetriggers.triggers.Remove(gameObject);
        }

        if (trigger != null)
        {
            trigger.meetOphinusTrigger.Remove(gameObject);
        }

        if (marianaFoodCutscenetrigger != null)
        {
            marianaFoodCutscenetrigger.marianaFoodTrigger.Remove(gameObject);
        }

        if (meetKingJastusCutsceneManager != null)
        {
            meetKingJastusCutsceneManager.MeetKingJastusTrigger.Remove(gameObject);
        }

        if (dragonflySceneMan != null)
        {
            dragonflySceneMan.dragonflyTrigger.Remove(gameObject);
        }


        if (meetMarianaCotscene != null)
        {
            meetMarianaCotscene.meetMarianaTrigger.Remove(gameObject);
        }

        if (openingCutscene != null)
        {
            openingCutscene.OpeningCutsceneTrigger.Remove(gameObject);
        }


        if (reptileIceDung != null)
        {
            reptileIceDung.ReptileIceTrigger.Remove(gameObject);
        }

        if (marcRescueCutscene != null)
        {
            marcRescueCutscene.trigger.Remove(gameObject);
        }

        if (marcReturnCutscene != null)
        {
            marcReturnCutscene.trigger.Remove(gameObject);
        }

        if (asheriansAttackCutscene != null)
        {
            asheriansAttackCutscene.trigger.Remove(gameObject);
        }

        if (marianaDeathCutscene != null)
        {
            marianaDeathCutscene.trigger.Remove(gameObject);
        }


        if (castleOnFireCutsceneManager != null)
        {
            castleOnFireCutsceneManager.trigger.Remove(gameObject);
        }

        if (kingJastusFire != null)
        {
            kingJastusFire.trigger.Remove(gameObject);
        }

        if (ophinusFlashback != null)
        {
            ophinusFlashback.trigger.Remove(gameObject);
        }

        if (ophinusCrystelCutscene != null)
        {
            ophinusCrystelCutscene.trigger.Remove(gameObject);
        }

        if (arrivePastCutscene != null)
        {
            arrivePastCutscene.trigger.Remove(gameObject);
        }


        if (reptilCrystelManager != null)
        {
            reptilCrystelManager.trigger.Remove(gameObject);
        }


        if (reptileDefeatManager != null)
        {
            reptileDefeatManager.enemies.Remove(gameObject);
        }


        if (hiddenCastleCutscene != null)
        {
            hiddenCastleCutscene.trigger.Remove(gameObject);
        }

        if (FishStatueCutscene1 != null)
        {
            FishStatueCutscene1.trigger.Remove(gameObject);

        }

        if (FishStatueCutscene2 != null)
        {
            FishStatueCutscene2.trigger.Remove(gameObject);
        }

        if (FishStatueCutscene3 != null)
        {
            FishStatueCutscene3.trigger.Remove(gameObject);
        }


        if (FishStatueCutscene4 != null)
        {
            FishStatueCutscene4.trigger.Remove(gameObject);
        }

        if (FishStatueCutscene5 != null)
        {
            FishStatueCutscene5.trigger.Remove(gameObject);
        }

        if (intoThePortalCutscene != null)
        {
            intoThePortalCutscene.trigger.Remove(gameObject);
        }

        if (otherworldPortalCutscene != null)
        {
           // otherworldPortalCutscene.trigger.Remove(gameObject);
        }


        if (arriveFutureCutscene != null)
        {
            arriveFutureCutscene.trigger.Remove(gameObject);
        }

        if (darkCarfishManager != null)
        {
            darkCarfishManager.trigger.Remove(gameObject);
        }


        if (darkCatfishDefeat != null)
        {
            darkCatfishDefeat.enemies.Remove(gameObject);
        }


        if (wellRebuiltPuzzleMan != null)
        {
            wellRebuiltPuzzleMan.trigger.Remove(gameObject);
        }


        if (darkEarthTurtleDefeat != null)
        {
            darkEarthTurtleDefeat.enemies.Remove(gameObject);
        }


        if (darkIceSnailCutscene != null)
        {
            darkIceSnailCutscene.trigger.Remove(gameObject);
        }

        if (iceSnailEnemies != null)
        {
            iceSnailEnemies.enemies.Remove(gameObject);
        }

        if (darkIceSnailDefeatCutscene != null)
        {
            darkIceSnailDefeatCutscene.enemies.Remove(gameObject);
        }

        if (ballnHoleman != null)
        {
            ballnHoleman.Enemies.Remove(gameObject);
        }

        if (fireLionMan != null)
        {
            //fireLionMan.trigger.Remove();
        }

        if (fireLionDefeat != null)
        {
            fireLionDefeat.enemies.Remove(gameObject);
        }

        if (elricFoundCutsceneMan != null)
        {
            elricFoundCutsceneMan.enemies.Remove(gameObject);
        }

        if (elricImprisonedMan != null)
        {
            elricImprisonedMan.enemies.Remove(gameObject);
        }

        if (foundBigKey != null)
        {
            foundBigKey.enemies.Remove(gameObject);
        }


        if (elricEscapeMan != null)
        {
            elricEscapeMan.enemies.Remove(gameObject);
        }

        if (elricLeaveMan != null)
        {
            elricLeaveMan.enemies.Remove(gameObject);
        }

        if (darkElricHideMan != null)
        {
            darkElricHideMan.enemies.Remove(gameObject);
        }

        if (darkElricDefeatMan != null)
        {
            darkElricDefeatMan.enemies.Remove(gameObject);
        }

        if (elricDarkMan != null)
        {
            elricDarkMan.enemies.Remove(gameObject);
        }


        if (portalFutureMan != null)
        {
            portalFutureMan.enemies.Remove(gameObject);
        }

        if (intoPortalFutureMan != null)
        {
            intoPortalFutureMan.trigger.Remove(gameObject);
        }


        if (iceSnaiRescued != null)
        {
            iceSnaiRescued.enemies.Remove(gameObject);
        }


        if (pipeCutsceneManager != null)
        {
            pipeCutsceneManager.enemies.Remove(gameObject);
        }

        if (pipeSwitch != null)
        {
            pipeSwitch.Trigger.Remove(gameObject);
        }

        if (island1Rescue != null)
        {
            island1Rescue.enemies.Remove(gameObject);
        }
    }



   
}
