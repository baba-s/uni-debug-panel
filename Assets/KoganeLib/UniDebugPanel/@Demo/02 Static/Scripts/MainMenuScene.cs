using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// メインメニュー画面を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class MainMenuScene : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private Button m_subMenuButtonUI = null;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			UniDebugPanelUI.SetDisp
			(
				new UDPData( "ボタン\nロック"		, () => m_subMenuButtonUI.interactable = false	),
				new UDPData( "ボタン\nアンロック"	, () => m_subMenuButtonUI.interactable = true	)
			);

			m_subMenuButtonUI.onClick.AddListener( () => SceneManager.LoadScene( "SubMenuScene" ) );
		}
	}
}
