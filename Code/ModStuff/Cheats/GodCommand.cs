﻿using UnityEngine;

namespace ModStuff.Cheats
{
	public class GodCommand : DebugCommand
	{
		public override string RunCommand(string[] args)
		{
			isActive = !isActive;

			if (isActive)
			{
				ToggleOn();
				return DebugManager.LogToConsole("Godmode is now <color=green>active</color> for Ittle.");
			}

			ToggleOff();
			return DebugManager.LogToConsole("Godmode is now <color=red>deactivated</color> for Ittle.");
		}

		private void ToggleOn()
		{
			if (!isActive) return;

			GameObject playerObj = VarHelper.PlayerObj;

			// Disable hurtbox
			playerObj.transform.Find("Hittable").GetComponent<EntityHittable>().Disable = true;

			// Disable void planes
			Envirodeathable envirodeathable = playerObj.GetComponent<Envirodeathable>();
			if (envirodeathable != null) Object.Destroy(envirodeathable);

			// Full heal
			Killable killable = playerObj.transform.Find("Hittable").GetComponent<Killable>();
			killable.CurrentHp = killable.MaxHp;

			PlayerSpawner.RegisterSpawnListener(delegate
			{
				DebugManager.LogToFile("[Cheat] God mode active for Ittle");
				ToggleOn();
			});
		}

		private void ToggleOff()
		{
			GameObject playerObj = VarHelper.PlayerObj;

			// Enable hurtbox
			playerObj.transform.Find("Hittable").GetComponent<EntityHittable>().Disable = false;

			// Enable void planes
			Entity entity = playerObj.GetComponent<Entity>();
			EntityEnvirodeathable entityEnvirodeathable = playerObj.transform.Find("Envirodeath").GetComponent<EntityEnvirodeathable>();
			entityEnvirodeathable.Enable(entity);
		}

		public static string GetHelp()
		{
			return "Toggles Ittle invincibility. While active, you take no hit knockback and can't fall into pits.";
		}
	}
}