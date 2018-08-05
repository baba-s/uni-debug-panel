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
		// 変数(static)
		//====================================================================================
		private static UniDebugPanelUI m_instance;

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

			if ( m_instance != null )
			{
				Destroy( gameObject );
				return;
			}

			m_instance = this;

			m_closeButtonUI.onClick.AddListener( () => DoSetState( false ) );
			m_openButtonUI .onClick.AddListener( () => DoSetState( true  ) );
#else
			Destroy( gameObject );
#endif
		}

		/// <summary>
		/// 破棄される時に呼び出されます
		/// </summary>
		private void OnDestroy()
		{
#if ENABLE_DEBUG_PANEL

			if ( m_instance == this )
			{
				m_instance = null;
			}
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

			DoSetState( false );
		}

		/// <summary>
		/// ステートを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		private void DoSetState( bool isOpen )
		{
			m_openBaseUI	.SetActive(  isOpen );
			m_closeBaseUI	.SetActive( !isOpen );
		}

		/// <summary>
		/// 表示するかどうかを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public void DoSetVisible( bool isVisible )
		{
			var alpha = isVisible ? 1 : 0;
			m_canvasGroup.alpha = alpha;
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public void DoSetDisp( params UDPData[] list )
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

		//====================================================================================
		// 関数(static)
		//====================================================================================
		/// <summary>
		/// ステートを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public static void SetState( bool isOpen )
		{
			m_instance.DoSetState( isOpen );
		}

		/// <summary>
		/// 表示するかどうかを設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public static void SetVisible( bool isVisible )
		{
			m_instance.DoSetVisible( isVisible );
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		[Conditional( ENABLE_SYMBOL_NAME )]
		public static void SetDisp( params UDPData[] list )
		{
			m_instance.DoSetDisp( list );
		}
	}
}