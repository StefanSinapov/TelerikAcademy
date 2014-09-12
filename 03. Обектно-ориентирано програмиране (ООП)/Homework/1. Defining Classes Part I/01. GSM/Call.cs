/*
 * 8. Create a class Call to hold a call performed through a GSM.
 * It should contain date, time, dialed phone number and duration (in seconds).
 */
using System;
class Call
{
	//Fields
	private DateTime date;
	private string phoneNumber;
	private decimal durration=0m;

	//Constructors
	public Call(DateTime date, string phoneNumber, decimal durration)
	{
		this.Date = date;
		this.PhoneNumber = phoneNumber;
		this.Durration = durration;
	}
	
	//Properties
	public decimal Durration
	{
		get { return this.durration; }
		set
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException("durration cant be negativ");
			this.durration = value;
		}
	}
	public string PhoneNumber
	{
		get { return this.phoneNumber; }
		set { this.phoneNumber = value; }
	}
	public DateTime Date
	{
		get { return this.date; }
		set { this.date = value; }
	}

	//override
	public override string ToString()
	{
		return string.Format("{0:g} - {1} - {2} seconds", this.Date, this.PhoneNumber, this.Durration);
	}
}

