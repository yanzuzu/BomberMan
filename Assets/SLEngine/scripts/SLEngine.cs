using UnityEngine;
using System.Collections;
using SLEngine.GameState;

namespace SLEngine
{
	public class SLEngine : MonoBehaviour {

		GameStateManager m_stateManager;

		void Awake () 
		{
			DontDestroyOnLoad (this);
			m_stateManager = new GameStateManager ();
		}

		void Start()
		{
			m_stateManager.ChangeState (new MainGameState (),"MainGame");
		}

		void Update () 
		{
			m_stateManager.UpdateState (Time.deltaTime);
		}

		void FixedUpdate()
		{
			m_stateManager.FixedUpdateState ();
		}
	}
}
