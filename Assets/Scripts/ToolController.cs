using Live2D.Cubism.Core;
using UnityEngine;
using Sirenix.OdinInspector;
using Core.Gameplay.Info;
using UnityEngine.UI;

public class ToolController : MonoBehaviour
{
    public Transform m_girlContainer;
    public CubismModel m_cubismModel;
    public string m_generatedJson;
    public Sprite m_background;

    [Required]
    public Image backgroundImage;

    [Button]
    public void Setup()
    {
        GenericContainer.Instance.TryGetValue(nameof(ToolsInfoContainer), out var container);
        var toolsInfoContainer = container as ToolsInfoContainer;

        toolsInfoContainer.LoadCharacters(m_generatedJson);

        var spawnedModel = Instantiate(m_cubismModel, m_girlContainer);
        spawnedModel.transform.localPosition = new Vector3(0, 0, 0);

        backgroundImage.sprite = m_background;
    }


}
