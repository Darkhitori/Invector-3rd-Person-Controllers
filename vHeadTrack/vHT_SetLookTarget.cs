using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHeadTrack")]
	[Tooltip("Set vLookTarget. Set Simple target ")]
	public class vHT_SetLookTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHeadTrack))] 
		public FsmOwnerDefault gameObject;
		
		public enum SetLookTarget
		{
			lTarget_priority,
			target
		}
		
		public SetLookTarget methods;
		
		[ObjectType(typeof(vLookTarget))]
		public FsmObject lTarget;
		
		public FsmGameObject target;
		
		public FsmBool priority;
		
		public FsmBool everyFrame;

		vHeadTrack theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods =  SetLookTarget.lTarget_priority;
			lTarget = null;
			target = null;
			priority = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vHeadTrack>();


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
			
			
			switch(methods)
			{
			case  SetLookTarget.lTarget_priority:
				var vTarget = lTarget.Value as vLookTarget;
				if (vTarget == null)
				{
					return;
				}
				theScript.SetLookTarget(vTarget, priority.Value);
				break;
			case  SetLookTarget.target:
				theScript.SetLookTarget(target.Value.transform);
				break;
			}
			            
		}

	}
}