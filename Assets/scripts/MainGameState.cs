using UnityEngine;
using System.Collections;
using SLEngine.GameState;
using SLEngine.Debug;

public class MainGameState : GameState {
	private CharacterInputProcessor m_characterInputProcessor;

	public override void Init (GameStateManager pStateMgr)
	{
		base.Init (pStateMgr);
		m_characterInputProcessor = new CharacterInputProcessor ();
	}

	public override void Update (float deltaTime)
	{
		base.Update (deltaTime);
	}
}
