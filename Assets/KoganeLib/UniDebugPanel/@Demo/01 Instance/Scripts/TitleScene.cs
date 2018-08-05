using UnityEngine;
using UnityEngine.UI;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// タイトル画面を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class TitleScene : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private UniDebugPanelUI	m_debugPanelUI	= null;
		[SerializeField] private Button				m_startButtonUI	= null;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			m_debugPanelUI.DoSetDisp
			(
				new UDPData( "ロック"		, () => m_startButtonUI.interactable = false	),
				new UDPData( "アンロック"	, () => m_startButtonUI.interactable = true		)
			);

			m_startButtonUI.onClick.AddListener( () => print( "押された" ) );
		}
	}
}
