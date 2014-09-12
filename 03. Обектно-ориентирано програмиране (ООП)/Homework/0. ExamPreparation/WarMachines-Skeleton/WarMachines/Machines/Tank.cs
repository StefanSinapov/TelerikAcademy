namespace WarMachines.Machines
{
	using System.Text;
	using WarMachines.Interfaces;
	public class Tank : Machine, ITank, IMachine
	{
		private const double initialHealthPoints = 100;
		private const int AttackPointsModifier = 40;
		private const int DefensePointsModifier = 30;

		public Tank(string initialName, double initialAttackPoints, double initialDefencePoints) :
			base(initialName, initialHealthPoints, initialAttackPoints, initialDefencePoints)
		{
			this.ToggleDefenseMode();
		}

		public bool DefenseMode { get; private set; }

		public void ToggleDefenseMode()
		{
			if(this.DefenseMode)
			{
				this.AttackPoints += AttackPointsModifier;
				this.DefensePoints -= DefensePointsModifier;
			}
			else
			{
				this.AttackPoints -= AttackPointsModifier;
				this.DefensePoints += DefensePointsModifier;
			}
			this.DefenseMode = !this.DefenseMode;
		}
		public override string ToString()
		{
			var result = new StringBuilder();
			string machineAsString = base.ToString();
			string defenceModeAsString = this.DefenseMode ? "ON" : "OFF";
			result.AppendLine(machineAsString);
			result.Append(string.Format(" *Defense: {0}", defenceModeAsString));
			return result.ToString();
		}
	}
}
