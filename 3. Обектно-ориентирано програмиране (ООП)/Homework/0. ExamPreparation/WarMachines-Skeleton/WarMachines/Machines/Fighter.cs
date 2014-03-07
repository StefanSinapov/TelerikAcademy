namespace WarMachines.Machines
{
	using System;
	using System.Text;
	using WarMachines.Interfaces;
	public class Fighter : Machine, IFighter
	{
		private const double initialHealthPoints = 200;

		public Fighter(string initialName, double initialAttackPoints, double initialDefencePoints, bool initialStealthMode) :
			base(initialName, initialHealthPoints, initialAttackPoints, initialDefencePoints)
		{
			this.StealthMode = initialStealthMode;
		}

		public bool StealthMode { get; private set; }

		public void ToggleStealthMode()
		{
			this.StealthMode = !this.StealthMode;
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			string machineAsString = base.ToString();
			string stealthModeAsString = this.StealthMode ? "ON" : "OFF";
			result.AppendLine(machineAsString);
			result.Append(string.Format(" *Stealth: {0}", stealthModeAsString));
			return result.ToString();
		}
	}
}
