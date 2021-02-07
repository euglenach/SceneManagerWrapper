using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Suima.Scenes{
    /// <summary>
    /// 参考: http://negi-lab.blog.jp/SceneNameEnumCreator
    /// </summary>
    public class SceneEnumCreater{
        private const string ItemName = "Tools/CreateSceneEnum";
        private static readonly string FileName = Path.GetFileName(CsFilePath());

        [MenuItem(ItemName, true)]
        public static bool CanCreate() =>
            !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;

        [MenuItem(ItemName)]
        public static void Create(){
            if(!CanCreate()) return;

            CreateScript();
        }

        private static string CsFilePath(){
            var dir = Directory.GetDirectories("Assets", "SceneManagerWrapper", SearchOption.AllDirectories)
                               .First();
            return Directory.GetFiles(dir, "Scene.cs")
                            .First();
        }

        private static void CreateScript(){
            var builder = new StringBuilder();

            builder.AppendLine("namespace Suima.Scenes{")
                   .AppendLine("\t/// <summary>")
                   .AppendLine("\t/// シーン名を管理する Enum")
                   .AppendLine("\t/// </summary>")
                   .AppendLine($"\tpublic enum Scene{{");

            foreach(var n in EditorBuildSettings.scenes.Select(c => Path.GetFileNameWithoutExtension(c.path))
                                                .Distinct()
                                                .Select(c => new{var = RemoveInvalidChars(c), val = c})){
                builder.AppendLine($"\t\t{n.var},");
                Debug.Log("Scene:" + n.var);
            }

            builder.AppendLine("\t}");
            builder.AppendLine("}");

            if(!Directory.Exists(FileName)){ Directory.CreateDirectory(FileName); }

            File.WriteAllText(CsFilePath(), builder.ToString(), Encoding.UTF8);
            AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
        }

        public static string RemoveInvalidChars(string str){
            Array.ForEach(INVALUD_CHARS, c => str = str.Replace(c, string.Empty));
            return str;
        }

        private static readonly string[] INVALUD_CHARS = {
            " ", "!", "\"", "#", "$", "%", "&", "\'", "(", ")", "-", "=", "^", "~", "\\", "|", "[", "{", "@", "`", "]",
            "}", ":", "*", ";", "+", "/", "?", ".", ">", "<", ",",
        };
    }
}