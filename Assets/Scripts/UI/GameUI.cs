using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private Button retryButton;

	private void Start()
	{
		OnClickAddListener();
	}

	private void OnEnable()
	{
		UpdateLevelText();
		Subscribe();
	}

	private void OnDisable()
	{
		GameManager.QuitControl(Unsubscribe);
	}

	#region Event Subscribe/Unsubscribe

	private void Subscribe()
	{
		EventManager.Instance.UpdateLevelText += UpdateLevelText;
	}

	private void Unsubscribe()
	{
		EventManager.Instance.UpdateLevelText -= UpdateLevelText;
	}

	#endregion

	private void OnClickAddListener()
	{
		retryButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
	}

	private void UpdateLevelText()
	{
		levelText.SetText(EventManager.Instance.GetSavedLevelID().ToString());
	}
}
