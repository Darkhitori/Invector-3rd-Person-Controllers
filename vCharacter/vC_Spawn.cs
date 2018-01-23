using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vGameController")]
	[Tooltip(" ")]
	public class vC_Spawn : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vGameController))] 
		public FsmOwnerDefault gameObject;
		
		public enum Spawn
		{
			no_parameters,
			spawnPoint
		}
		
		public Spawn methods;
		
		public FsmGameObject spawnPoint;
		
		public FsmBool everyFrame;

		vGameController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods = Spawn.no_parameters;
			spawnPoint = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vGameController>();


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
			case Spawn.no_parameters:
				theScript.Spawn();
				break;
			case Spawn.spawnPoint:
				theScript.Spawn(spawnPoint.Value.transform);
				break;
			}
			
			            
		}

	}
}