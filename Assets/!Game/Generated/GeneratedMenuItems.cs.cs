
// this is a GENERATED file. any modifications will be overwritten by the logic generating this file.
#if UNITY_EDITOR
using Core.Gameplay.Info;
using UnityEditor;
#endif
                                
public class ContainersMenuItems
{
#if UNITY_EDITOR

[MenuItem("Intermarum/Containers (Generate)/SerializableContainer")]
public static void GenerateSerializableContainer()
{
    GenericContainer.CreateAsset<SerializableContainer>();
}
[MenuItem("Intermarum/Containers (Generate)/ToolsInfoContainer")]
public static void GenerateToolsInfoContainer()
{
    GenericContainer.CreateAsset<ToolsInfoContainer>();
}
[MenuItem("Intermarum/Containers (Generate)/TestContainer")]
public static void GenerateTestContainer()
{
    GenericContainer.CreateAsset<TestContainer>();
}
#endif
}