using System;

namespace Suima.Scenes{
    public partial class SceneManager{
        public static Scene NowScene => (Scene)Enum.Parse(typeof(Scene), UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        public static int SceneCount => UnityEngine.SceneManagement.SceneManager.sceneCount;
        public static int SceneCountInBuildSettings => UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
    }
}
