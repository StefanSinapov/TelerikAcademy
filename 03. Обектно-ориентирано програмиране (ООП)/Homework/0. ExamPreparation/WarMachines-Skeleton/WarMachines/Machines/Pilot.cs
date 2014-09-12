using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WarMachines.Interfaces;
namespace WarMachines.Machines
{

	public class Pilot : IPilot
	{
		//Fields
		private string name;
		private IList<IMachine> machines;

		//Constructor
		public Pilot(string name)
		{
			this.Name = name;
			this.machines = new List<IMachine>();
		}

		public string Name
		{
			get { return this.name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Pilot name cannot be null");

				this.name = value;
			}
		}

		public void AddMachine(IMachine machine)
		{
			if (machine == null)
				throw new ArgumentNullException("Machine cannot be null");

			this.machines.Add(machine);
		}

		public string Report()
		{
			var result = new StringBuilder();

			string pilotName = this.Name;
			string machinesCount = this.machines.Count == 0 ? "no" : this.machines.Count.ToString();
			string machinesPluralOrNot = this.machines.Count == 1 ? "machine" : "machines";
			result.AppendLine(string.Format("{0} - {1} {2}", pilotName, machinesCount, machinesPluralOrNot));

			var orderedMachines = this.machines
											.OrderBy(m => m.HealthPoints)
											.ThenBy(m => m.Name);
			foreach (var machine in orderedMachines)
			{
				result.AppendLine(machine.ToString());
			}

			return result.ToString().TrimEnd();
		}
	}
}
