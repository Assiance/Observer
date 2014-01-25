using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


// attach this custom inspector to all MySpecialComponent components
[CustomEditor(typeof(TeleportNode))]
public class TeleporterPropGUI : Editor
{
    int index = 0;
    string[] Nodes;
    public void OnSceneGUI()
    {
        foreach (TeleportNode n in TeleportNode.NodesRef)
            n.DrawLinks();
    }
    public override void OnInspectorGUI()
    {

        TeleportNode tar = (TeleportNode) target;

        index = TeleportNode.Nodes.IndexOf(tar.DestinationNode);
        if (index == -1) index = TeleportNode.NodeNames.Count;

        if (TeleportNode.NodeNames.Count == 0)
        {
            index = 0;
            Nodes = new string[1];
            Nodes[0] = "Run Game to update List";
        }
        else
        {
            
            Nodes = new string[TeleportNode.NodeNames.Count + 1];
            TeleportNode.NodeNames.CopyTo(Nodes);
            //for (int i = 0; i < TeleportNode.NodeNames.Count; i++)
            //{
            //    Nodes[i] = TeleportNode.NodeNames.ToArray()[i];
            //}

            Nodes[TeleportNode.NodeNames.Count] = "None";
            //Debug.Log(TeleportNode.NodeNames.Count.ToString() + Nodes[TeleportNode.NodeNames.Count]);
        }
        
        //else
        //    Nodes = TeleportNode.NodeNames.ToArray();

        
       
        
       
        base.OnInspectorGUI();
        
        //Rect r = EditorGUILayout.BeginHorizontal();
        index = EditorGUILayout.Popup("Destination Node:", index, Nodes, EditorStyles.popup);

        if (index != TeleportNode.NodeNames.Count)
        {
            tar.DestinationNode = TeleportNode.Nodes[index];
            if (tar.DestinationNode != TeleportNode.Nodes[index])
            {
                EditorUtility.SetDirty(tar.DestinationNode);
                GUI.changed = true;
            }
        }
        else
            if (Nodes.Length > 1)
            {
                tar.DestinationNode = null;
                //EditorUtility.SetDirty(tar.DestinationNode);
            }

    
    }
}
