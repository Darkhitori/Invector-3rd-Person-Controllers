using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vDecalManager")]
	[Tooltip(" ")]
	public class vDM_CreateDecal : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vDecalManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		public FsmVector3 position;
		public FsmVector3 normal;
		
		public FsmBool everyFrame;

		vDecalManager theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			position = new Vector3(0,0,0);
			normal = new Vector3(0,0,0);
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vDecalManager>();


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
			
			theScript.CreateDecal(target.Value, position.Value, normal.Value);            
		}

	}
}