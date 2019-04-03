using KoganeLib.UniDebugPanel.Internal;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
#pragma warning disable 0414

namespace KoganeLib.UniDebugPanel
{
	/// <summary>
	/// デバッグパネルの UI を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed partial class UniDebugPanelUI : MonoBehaviour
	{
		//====================================================================================
		// 定数
		//====================================================================================
		private const string ENABLE_SYMBOL_NAME = "ENABLE_DEBUG_PANEL";

		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private GameObject			m_closeBaseUI	= null;
		[SerializeField] private GameObject			m_openBaseUI	= null;
		[SerializeField] private Button				m_closeButtonUI	= null;
		[SerializeField] private Button				m_openButtonUI	= null;
		[SerializeField] private LayoutGroup		m_layoutUI		= null;
		[SerializeField] private UniDebugButtonUI	m_buttonUI		= null;
		[SerializeField] private CanvasGroup		m_canvasGroup	= null;
		[SerializeField] private GameObject			m_root			= null;

		//====================================================================================
		// 変数
		//====================================================================================

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		private void Awake()
		{
#if ENABLE_DEBUG_PANEL

			m_closeButtonUI.onClick.AddListener( () => SetState( false ) );
			m_openButtonUI .onClick.AddListener( () => SetState( true  ) );
#else
			Destroy( gameObject );
#endif
		}

		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			m_root			.SetActive( true  );
			m_openBaseUI	.SetActive( false );
			m_closeBaseUI	.SetActive( true  );

			SetState( false );
		}

		/// <summary>
		/// ステートを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		private void SetState( bool isOpen )
		{
			m_openBaseUI	.SetActive(  isOpen );
			m_closeBaseUI	.SetActive( !isOpen );
		}

		/// <summary>
		/// 表示するかどうかを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public void SetVisible( bool isVisible )
		{
			var alpha = isVisible ? 1 : 0;
			m_canvasGroup.alpha = alpha;
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public void SetDisp( params UDPData[] list )
		{
			foreach ( Transform n in m_layoutUI.transform )
			{
				Destroy( n.gameObject );
			}

			m_buttonUI.gameObject.SetActive( true );

			for ( int i = 0; i < list.Length; i++ )
			{
				var data	= list[ i ];
				var obj		= Instantiate( m_buttonUI, m_layoutUI.transform );

				obj.SetDisp( data );
			}

			m_buttonUI.gameObject.SetActive( false );
		}
	}
}