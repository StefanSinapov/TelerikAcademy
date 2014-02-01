/*
 * Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) 
 * and use it as a new field for the batteries.
 */

using System;
class Battery
{
	//Fields
	private Type model=Type.none;
	private uint? hoursIdle=null;
	private uint? hoursTalk=null;

	//Constructors
	public Battery()
	{

	}
	public Battery(Type model, uint? hoursIdle=null, uint? hoursTalk=null)
	{
		this.Model = model;
		this.HoursIdle = hoursIdle;
		this.HoursTalk = hoursTalk;
	}

	//Enumeration
	public enum Type
	{
		
		none, LiIon, NiMH, NiCd
	}

	//Properties
	public Type Model
	{
		get { return this.model; }
		set { this.model = value; }
	}
	public uint? HoursIdle
	{
		get { return this.hoursIdle; }
		set 
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException("Hours cannot be smaller than zero");
			this.hoursIdle = value;
		}
	}
	public uint? HoursTalk
	{
		get { return this.hoursTalk; }
		set 
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException("Hours cannot be smaller than zero");
			this.hoursTalk = value; 
		}
	}


}

