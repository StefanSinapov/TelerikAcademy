using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class ExtendetHoldingPen : HoldingPen
	{
		protected override void ExecuteInsertUnitCommand(string[] commandWords)
		{
			switch (commandWords[1])
			{
				case "Tank":
					var tank = new Tank(commandWords[2]);
					this.InsertUnit(tank);
					break;
				case "Marine":
					var marine = new Marine(commandWords[2]);
					this.InsertUnit(marine);
					break;
				case "Parasite":
					this.InsertUnit(new Parasite(commandWords[2]));
					break;
				case "Queen":
					this.InsertUnit(new Queen(commandWords[2]));
					break;
				default:
					base.ExecuteInsertUnitCommand(commandWords);
					break;
			}
		}

		protected override void ExecuteAddSupplementCommand(string[] commandWords)
		{

			switch (commandWords[1])
			{

				case "AggressionCatalyst":
					GetUnit(commandWords[2]).AddSupplement(new AggressionCatalyst());
					break;
				case "PowerCatalyst":
					GetUnit(commandWords[2]).AddSupplement(new PowerCatalyst());
					break;
				case "HealthCatalyst":
					GetUnit(commandWords[2]).AddSupplement(new HealthCatalyst());
					break;
				case "Weapon":
					GetUnit(commandWords[2]).AddSupplement(new Weapon());
					break;
				case "InfestationSpores":
					GetUnit(commandWords[2]).AddSupplement(new InfestationSpores());
					break;
				case "AggressionInhibitor":
					GetUnit(commandWords[2]).AddSupplement(new AggressionInhibitor());
					break;
				default:
					base.ExecuteAddSupplementCommand(commandWords);
					break;
			}
		}

		protected override void ProcessSingleInteraction(Interaction interaction)
		{
			switch (interaction.InteractionType)
			{
				case InteractionType.Attack:
					Unit targetUnit = this.GetUnit(interaction.TargetUnit);

					targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
					break;
				case InteractionType.Infest:
					Unit infestedUnit = this.GetUnit(interaction.TargetUnit);
					infestedUnit.AddSupplement(new InfestationSpores());
					break;
				default:
					base.ProcessSingleInteraction(interaction);
					break;
			}
		}
	}
}
