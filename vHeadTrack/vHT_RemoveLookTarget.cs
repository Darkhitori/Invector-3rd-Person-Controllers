using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHeadTrack")]
	[Tooltip(" ")]
	public class vHT_RemoveLookTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHeadTrack))] 
		public FsmOwnerDefault gameObject;
		
		public enum RemoveLookTarget
		{
			vLookTarget_lTarget,
			Transform_target
		}
		
		public RemoveLookTarget methods;
		
		[ObjectType(typeof(vLookTarget))]
		public FsmObject lTarget;
		
		public FsmGameObject target;
		
		public FsmBool everyFrame;

		vHeadTrack theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods = RemoveLookTarget.vLookTarget_lTarget;
			lTarget = null;
			target = null;
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
			case RemoveLookTarget.vLookTarget_lTarget:
				var vTarget = lTarget.Value as vLookTarget;
				if (vTarget == null)
				{
					return;
				}
				theScript.RemoveLookTarget(vTarget);
				break;
			case RemoveLookTarget.Transform_target:
				theScript.RemoveLookTarget(target.Value.transform);
				break;
			}
			            
		}

	}
}