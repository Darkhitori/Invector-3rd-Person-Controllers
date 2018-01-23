using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AISphereSensor")]
	[Tooltip(" ")]
	public class vAISS_SetTagToDetect : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AISphereSensor))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Transform))]
		public FsmObject transform;
		
		public FsmBool everyFrame;

		v_AISphereSensor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			transform = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AISphereSensor>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			var vTrans = transform.Value as Transform;
			if (vTrans == null)
			{
				return;
			}
			
			theScript.SetTagToDetect(vTrans);            
		}

	}
}