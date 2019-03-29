using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

[fsObject(MemberSerialization = fsMemberSerialization.OptOut)]
public class SessionSetup : InstanceCounter
{
	// This class is pretty big, so here I only included a changed method
	
	/* CHANGED METHOD:
	public void GetSetupOutput(ref SessionSetup.SetupOutput outSetupOutput)
	{
		if (this.mVehicle.isPlayerDriver)
		{
			this.mSessionPitStop.currentSetup.input.GetSetupOutput(ref outSetupOutput, (float)this.mVehicle.driver.weight);
		}
		else
		{
			if (this.mAISetupOutput == null)
			{
				this.mAISetupOutput = new SessionSetup.SetupOutput();
				this.CreateAISetupForQualifyingAndRace();
			}
			outSetupOutput.aerodynamics = this.mAISetupOutput.aerodynamics;
			outSetupOutput.speedBalance = this.mAISetupOutput.speedBalance;
			outSetupOutput.handling = this.mAISetupOutput.handling;
		}
	}
	*/

	public void GetSetupOutput(ref SessionSetup.SetupOutput outSetupOutput)
	{
		if (this.mVehicle.isPlayerDriver)
		{
			this.mAISetupOutput = new SessionSetup.SetupOutput();
			this.SetAISetupWithinRange(1f, 1f);
			outSetupOutput.aerodynamics = this.mAISetupOutput.aerodynamics;
			outSetupOutput.speedBalance = this.mAISetupOutput.speedBalance;
			outSetupOutput.handling = this.mAISetupOutput.handling;
			return;
		}
		if (this.mAISetupOutput == null)
		{
			this.mAISetupOutput = new SessionSetup.SetupOutput();
			this.CreateAISetupForQualifyingAndRace();
		}
		outSetupOutput.aerodynamics = this.mAISetupOutput.aerodynamics;
		outSetupOutput.speedBalance = this.mAISetupOutput.speedBalance;
		outSetupOutput.handling = this.mAISetupOutput.handling;
	}
}
