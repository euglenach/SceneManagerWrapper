using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Suima.Scenes{
    public partial class SceneManager{
        private static bool isFade;
        
        public static async UniTask FadeLoad(Scene nextScene,float duration,CancellationToken cancellationToken = default){
            if(isFade){ Debug.LogWarning("シーン遷移中は新たにシーン遷移できません"); }
            
            isFade = true;
            var ao = LoadSceneAsync(nextScene);
            ao.allowSceneActivation = false;
            
            var fadeCanvas = new GameObject("FadeCanvas").AddComponent<Canvas>();
            var fadeImage = new GameObject("LoadImage").AddComponent<Image>();
            fadeImage.transform.SetParent(fadeCanvas.transform);
            fadeImage.color = new Color(0,0,0,0);
            fadeImage.GetComponent<RectTransform>().sizeDelta = new Vector2(5000, 5000);
            fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            fadeCanvas.sortingOrder = 999;
            fadeCanvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            Object.DontDestroyOnLoad(fadeCanvas.gameObject);
            
            await fadeImage.DOFade(1, duration).WithCancellation(cancellationToken);
            ao.allowSceneActivation = true;
            await ao;
            await fadeImage.DOFade(0, duration).WithCancellation(cancellationToken);
            Object.Destroy(fadeCanvas.gameObject);
            isFade = false;
        }
    }
}
