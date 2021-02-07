using UnityEngine.SceneManagement;

namespace Suima.Scenes{
    public partial class SceneManager{
        public static void CreateScene(Scene sceneName){
            UnityEngine.SceneManagement.SceneManager.CreateScene(sceneName.ToString());
        }
        
        public static void CreateScene(Scene sceneName,CreateSceneParameters parameters){
            UnityEngine.SceneManagement.SceneManager.CreateScene(sceneName.ToString(), parameters);
        }
    }
}
