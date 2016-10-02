using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLEngine.Debug;

namespace SLEngine.Inputs
{
	public class TouchProcessor {
		private List<ITouchListener> m_touches = new List<ITouchListener>();

		private bool m_isMouseDown = false;
		private Vector3 m_lastMousePos = Vector3.zero;
		#region PUBLIC METHOD
		public void Register(ITouchListener listener )
		{
			if (m_touches.Contains (listener)) {
				SLDebug.LogWarning (string.Format("this listener = {0} is repeat" , listener));
				return;
			}
			m_touches.Add (listener);
		}
			
		public void UpdateInput()
		{
			for (int i = 0; i < Input.touchCount; i++) {
				Touch touchData = Input.GetTouch(i);
				if (touchData.phase == TouchPhase.Began) {
					for (int k = 0; k < m_touches.Count; k++) {
						m_touches [k].TouchBegin (touchData.position);
					}
				}

				if (touchData.phase == TouchPhase.Moved) {
					for (int k = 0; k < m_touches.Count; k++) {
						m_touches [k].TouchMove (touchData.position, touchData.deltaPosition);
					}
				}

				if (touchData.phase == TouchPhase.Ended || touchData.phase == TouchPhase.Canceled) {
					for (int k = 0; k < m_touches.Count; k++) {
						m_touches [k].TouchEnd (touchData.position);
					}
				}
			}


			if (m_isMouseDown) {
				for (int k = 0; k < m_touches.Count; k++) {
					m_touches [k].TouchMove (Input.mousePosition,Input.mousePosition - m_lastMousePos);
				}
			}

			if (Input.GetMouseButtonDown (0)) {
				for (int k = 0; k < m_touches.Count; k++) {
					m_touches [k].TouchBegin (Input.mousePosition);
				}
				m_lastMousePos = Input.mousePosition;
				m_isMouseDown = true;
			}
				
			if (Input.GetMouseButtonUp (0) && m_isMouseDown ) {
				m_isMouseDown = false;
				for (int k = 0; k < m_touches.Count; k++) {
					m_touches [k].TouchEnd (Input.mousePosition);
				}
			}
		}
		#endregion
			
	}
}
