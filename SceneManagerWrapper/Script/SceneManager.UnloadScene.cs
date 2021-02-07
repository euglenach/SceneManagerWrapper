using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Suima.Scenes{
    public partial class SceneManager{
        public static AsyncOperation UnloadSceneAsync(Scene scene){
            return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene.ToString());
        }
        public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options){
            return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene.ToString(),options);
        }
    }
}
