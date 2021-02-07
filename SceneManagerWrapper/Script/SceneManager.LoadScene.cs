using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Suima.Scenes{
    public static partial class SceneManager{
        public static void LoaScene(Scene nextScene){
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene.ToString());
        }

        public static AsyncOperation LoadSceneAsync(Scene nextScene){
            return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene.ToString());
        }
        
        public static AsyncOperation LoadSceneAsync(Scene nextScene,LoadSceneParameters parameters){
            return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene.ToString(),parameters);
        }
    }
}
