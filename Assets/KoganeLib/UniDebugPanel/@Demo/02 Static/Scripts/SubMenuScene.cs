using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// サブメニュー画面を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class SubMenuScene : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private Button m_logButtonUI		= null;
		[SerializeField] private Button m_mainMenuButtonUI	= null;

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
				new UDPData( "ボタン1\nロック"		, () => m_logButtonUI		.interactable = false	),
				new UDPData( "ボタン1\nアンロック"	, () => m_logButtonUI		.interactable = true	),
				new UDPData( "ボタン2\nロック"		, () => m_mainMenuButtonUI	.interactable = false	),
				new UDPData( "ボタン2\nアンロック"	, () => m_mainMenuButtonUI	.interactable = true	)
			);

			m_logButtonUI		.onClick.AddListener( () => print( "押された" ) );
			m_mainMenuButtonUI	.onClick.AddListener( () => SceneManager.LoadScene( "MainMenuScene" ) );
		}
	}
}
