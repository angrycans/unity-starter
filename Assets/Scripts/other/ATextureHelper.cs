using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATextureHelper : MonoBehaviour {
	private static ATextureHelper _instance;
    public static ATextureHelper Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ATextureHelper();
                if(_instance == null)
                {
                    Debug.LogError("TextureHelper创建失败");
                    return null;
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// 游戏中创建一个纯色图
    /// </summary>
    /// <param name="tinct"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="format"></param>
    /// <param name="useMipmap"></param>
    /// <param name="isLinear"></param>
    /// <returns></returns>
    public Texture2D CreatTextureInGame(Color tinct, int width = 256, int height = 256, TextureFormat format = TextureFormat.RGBA32, bool useMipmap = false, bool isLinear = false)
    {
        Texture2D texture = new Texture2D(width, height, format, useMipmap, isLinear);
        if(texture == null)
        {
            Debug.LogError("贴图创建失败");
            return null;
        }
        //Color[] colors = new Color[width * height](tinct);
        Color[] colors = new Color[width * height] ;
      
            for (int j = 0; j < width * height; j++)
            {
                colors[j] = tinct;
            }
        if(colors == null)
        {
            Debug.LogError("Color[]创建失败");
            return null;
        }
        texture.SetPixels(colors);
        texture.Apply();
        return texture;
    }

    /// <summary>
    /// 编辑器中创建一个纯色图，并保存到目录
    /// </summary>
    /// <param name="tinct"></param>
    /// <param name="assetPath"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="format"></param>
    /// <param name="useMipmap"></param>
    /// <param name="isLinear"></param>
    public void CreateTextureInEditor(Color tinct, string assetPath, int width = 256, int height = 256, TextureFormat format = TextureFormat.RGBA32, bool useMipmap = false, bool isLinear = false)
    {
        Texture2D texture =  CreatTextureInGame(tinct, width, height, format, useMipmap, isLinear);
        if(texture == null)
        {
            Debug.LogError("获取贴图失败");
            return;
        }
        UnityEditor.AssetDatabase.CreateAsset(texture, assetPath);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }
}
