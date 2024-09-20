using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Level/Game Scene")]
public class SceneDetails : ScriptableObject
{
    public List<SceneDetails> Connectedscenes { get { return connectedScenes;} }
    [SerializeField] List<SceneDetails> connectedScenes;
    [SerializeField] string sceneName;
    [SerializeField] Image battleBackround;
    private LevelManager levelManager;

   

    public bool IsLoaded { get; private set; }

    public Image BattleBackround
    {
        get { return battleBackround; }
    }


    List<SavableEntity> savableEntities;

    static char[] delimiterChars = { '.' };


    public void SetLevelManager(LevelManager levelMan)
    {
        levelManager = levelMan; 

      
    }
  //  static string GetAssetPath(SceneDetails sceneDetails)
   // {
    //    string currentPath = UnityEditor.AssetDatabase.GetAssetPath(sceneDetails);
    //    currentPath = currentPath.Replace("Assets/Resources/SceneDetails/", "Assets/Scenes/");
    //    currentPath = currentPath.Split(delimiterChars)[0];
    //    return currentPath;
   // }
   
}
