using System;

public class Program
{
	public static void Main()
	{	
		var person = new Person();
		person.name = "Paul Mehra";

		var alarm = new AlarmClock();
		alarm.AlarmClockEvent += person.HandleAlarm;
	}
}

public class Person
{
	public string name { get; set; }

	public void HandleAlarm(object sender, Alarmevent e)
	{
		Console.WriteLine("Get out of bed it's {0}", e.time);
	}

}

public class AlarmClock
{
	public event AlarmClockEventHandeler AlarmClockEvent;

	public void Alarm()
	{
		Console.WriteLine("Alarm went off!");
		AlarmClockEventHandeler alarm = AlarmClockEvent;
		if (AlarmClockEvent != null)
		{
			alarm(this, new Alarmevent(DateTime.Now));
		}

	}
}

public delegate void AlarmClockEventHandeler(object source, Alarmevent e);

public class Alarmevent : EventArgs
{
	public DateTime time { get; set; }

	public Alarmevent(DateTime time)
	{
		this.time = time;
	}
}