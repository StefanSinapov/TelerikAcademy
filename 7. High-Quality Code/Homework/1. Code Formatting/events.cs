using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

internal class Event : IComparable
{
	public DateTime date;

	public string title;

	public string location;

	public Event(DateTime date, string title, string location)
	{
		this.date = date;
		this.title = title;
		this.location = location;
	}

	public int CompareTo(object obj)
	{
		int num;
		Event other = obj as Event;
		int byDate = this.date.CompareTo(other.date);
		int byTitle = this.title.CompareTo(other.title);
		int byLocation = this.location.CompareTo(other.location);
		bool flag = byDate != 0;
		if (flag)
		{
			num = byDate;
		}
		else
		{
			flag = byTitle != 0;
			num = (flag ? byTitle : byLocation);
		}
		return num;
	}

	public override string ToString()
	{
		bool flag;
		StringBuilder toString = new StringBuilder();
		toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
		toString.Append(string.Concat(" | ", this.title));
		flag = (this.location == null ? true : !(this.location != ""));
		bool flag1 = flag;
		if (!flag1)
		{
			toString.Append(string.Concat(" | ", this.location));
		}
		string str = toString.ToString();
		return str;
	}
}

internal class Program
{
	private static StringBuilder output;

	private static Program.EventHolder events;

	static Program()
	{
		Program.output = new StringBuilder();
		Program.events = new Program.EventHolder();
	}

	public Program()
	{
	}

	private static void AddEvent(string command)
	{
		DateTime date;
		string title;
		string location;
		Program.GetParameters(command, "AddEvent", out date, out title, out location);
		Program.events.AddEvent(date, title, location);
	}

	private static void DeleteEvents(string command)
	{
		string title = command.Substring("DeleteEvents".Length + 1);
		Program.events.DeleteEvents(title);
	}

	private static bool ExecuteNextCommand()
	{
		bool flag;
		string command = Console.ReadLine();
		bool flag1 = command[0] != 'A';
		if (flag1)
		{
			flag1 = command[0] != 'D';
			if (flag1)
			{
				flag1 = command[0] != 'L';
				if (flag1)
				{
					flag1 = command[0] != 'E';
					flag = (flag1 ? false : false);
				}
				else
				{
					Program.ListEvents(command);
					flag = true;
				}
			}
			else
			{
				Program.DeleteEvents(command);
				flag = true;
			}
		}
		else
		{
			Program.AddEvent(command);
			flag = true;
		}
		return flag;
	}

	private static DateTime GetDate(string command, string commandType)
	{
		DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
		DateTime dateTime = date;
		return dateTime;
	}

	private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
	{
		dateAndTime = Program.GetDate(commandForExecution, commandType);
		int firstPipeIndex = commandForExecution.IndexOf('|');
		int lastPipeIndex = commandForExecution.LastIndexOf('|');
		bool flag = firstPipeIndex != lastPipeIndex;
		if (flag)
		{
			eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
			eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
		}
		else
		{
			eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
			eventLocation = "";
		}
	}

	private static void ListEvents(string command)
	{
		int pipeIndex = command.IndexOf('|');
		DateTime date = Program.GetDate(command, "ListEvents");
		string countString = command.Substring(pipeIndex + 1);
		int count = int.Parse(countString);
		Program.events.ListEvents(date, count);
	}

	private static void Main(string[] args)
	{
		while (true)
		{
			bool flag = Program.ExecuteNextCommand();
			if (!flag)
			{
				break;
			}
		}
		Console.WriteLine(Program.output);
	}

	private class EventHolder
	{
		private MultiDictionary<string, Event> byTitle;

		private OrderedBag<Event> byDate;

		public EventHolder()
		{
		}

		public void AddEvent(DateTime date, string title, string location)
		{
			Event newEvent = new Event(date, title, location);
			this.byTitle.Add(title.ToLower(), newEvent);
			this.byDate.Add(newEvent);
			Program.Messages.EventAdded();
		}

		public void DeleteEvents(string titleToDelete)
		{
			bool flag;
			string title = titleToDelete.ToLower();
			int removed = 0;
			IEnumerator<Event> enumerator = this.byTitle[title].GetEnumerator();
			try
			{
				while (true)
				{
					flag = enumerator.MoveNext();
					if (!flag)
					{
						break;
					}
					Event eventToRemove = enumerator.Current;
					removed++;
					this.byDate.Remove(eventToRemove);
				}
			}
			finally
			{
				flag = enumerator == null;
				if (!flag)
				{
					enumerator.Dispose();
				}
			}
			this.byTitle.Remove(title);
			Program.Messages.EventDeleted(removed);
		}

		public void ListEvents(DateTime date, int count)
		{
			bool flag;
			OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(new Event(date, "", ""), true);
			int showed = 0;
			IEnumerator<Event> enumerator = eventsToShow.GetEnumerator();
			try
			{
				while (true)
				{
					flag = enumerator.MoveNext();
					if (!flag)
					{
						break;
					}
					Event eventToShow = enumerator.Current;
					flag = showed != count;
					if (flag)
					{
						Program.Messages.PrintEvent(eventToShow);
						showed++;
					}
					else
					{
						break;
					}
				}
			}
			finally
			{
				flag = enumerator == null;
				if (!flag)
				{
					enumerator.Dispose();
				}
			}
			flag = showed != 0;
			if (!flag)
			{
				Program.Messages.NoEventsFound();
			}
		}
	}

	private static class Messages
	{
		public static void EventAdded()
		{
			Program.output.Append("Event added\n");
		}

		public static void EventDeleted(int x)
		{
			bool flag = x != 0;
			if (flag)
			{
				Program.output.AppendFormat("{0} events deleted\n", x);
			}
			else
			{
				Program.Messages.NoEventsFound();
			}
		}

		public static void NoEventsFound()
		{
			Program.output.Append("No events found\n");
		}

		public static void PrintEvent(Event eventToPrint)
		{
			bool flag = eventToPrint == null;
			if (!flag)
			{
				Program.output.Append(string.Concat(eventToPrint, "\n"));
			}
		}
	}
}