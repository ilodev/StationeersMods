using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeersMods.Shared;
using UnityEditor;

namespace StationeersMods.Editor
{
    internal class AssemblyEditor : SelectionEditor
    {
        /// <summary>
        /// Cached list of candidate Assembly Definitions found
        /// </summary>
        List <string> _candidatesCache = new List<string>();
        
        public override void DrawHelpBox()
        {
            EditorGUILayout.HelpBox("Add asmdefs from your project to be exported into your mod.", MessageType.Info, true);
        }

        public override List<string> GetCandidates(ExportSettings settings)
        {
            if (_candidatesCache == null)
                _candidatesCache = AssetUtility.GetAssets("t:AssemblyDefinitionAsset").ToList(); 
            return _candidatesCache;
        }

        public override List<string> GetSelections(ExportSettings settings)
        {
            return settings.Assemblies.ToList();
        }

        public void ClearCandidates()
        {
            _candidatesCache = null;
        }
    }
}