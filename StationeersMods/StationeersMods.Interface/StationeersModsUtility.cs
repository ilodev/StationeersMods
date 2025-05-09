using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Objects;
using Assets.Scripts.Util;
using UnityEngine;

namespace StationeersMods.Interface
{
    public class StationeersModsUtility
    {

        public static Material GetMaterial(StationeersColor color, ShaderType shaderType)
        {
            ref List<ColorSwatch> customColors = ref Singleton<GameManager>.Instance.CustomColors;
            ColorSwatch customColor = customColors[(int)color];
            switch (shaderType)
            {
                case ShaderType.NORMAL:
                    return customColor.Normal;
                case ShaderType.EMISSIVE:
                    return customColor.Emissive;
                case ShaderType.CUTABLE:
                    return customColor.Cutable;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shaderType), shaderType, null);
            }
        }
        
        public static Material GetMaterial(string materialName)
        {
            return (Material) Resources.Load("Objects/Models/Materials/" + materialName, typeof(Material));
        }

        public static Material[] GetBlueprintMaterials(int size) 
        {
            foreach (var prefab in WorldManager.Instance.SourcePrefabs)
            {
                Material blueprintMaterial = prefab?.Blueprint?.GetComponent<MeshRenderer>()?.materials?[0];
                if (blueprintMaterial != null)
                {
                    var materials = new Material[size];
                    Array.Fill(materials, blueprintMaterial, 0, size);
                    return materials;
                }
            }
            
            // Assuming at least one of the objects will have a blueprint material or it will fail
            return new Material[size];
        }

        public static Thing FindPrefab(string prefabName)
        {
            return WorldManager.Instance.SourcePrefabs.Find((Thing prefab) => prefab != null && prefabName.Equals(prefab.PrefabName));
        }
        
        public static Item FindTool(StationeersTool tool)
        {
            return FindPrefab(tool.PrefabName).GetComponent<Item>();
        }
    }
}