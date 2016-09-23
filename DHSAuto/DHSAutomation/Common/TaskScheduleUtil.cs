
using System;
using Microsoft.Win32.TaskScheduler;

namespace RS1Automation.Utilities
{
	/// <summary>
	/// Description of TaskScheduleUtil.
	/// </summary>
	public class TaskScheduleUtil
	{
		public TaskScheduleUtil()
		{
		}
		public static void createTaskRuningAtStart(string name,string executePath, string workingDirectory)
		{
			using (TaskService ts = new TaskService())
			{
				TaskDefinition td = ts.NewTask();
				td.Principal.RunLevel = TaskRunLevel.Highest;
				td.RegistrationInfo.Description = "name";
//				BootTrigger bt = new BootTrigger();
//				bt.Delay = TimeSpan.FromSeconds(30);
				//td.Triggers.Add(bt);			
				LogonTrigger lt = new LogonTrigger();
				lt.Delay = TimeSpan.FromSeconds(30);
				td.Triggers.Add(lt);
				
				td.Actions.Add(new ExecAction(executePath,"",workingDirectory));
				td.Settings.DisallowStartIfOnBatteries=false;
				td.Settings.AllowDemandStart = true;
				td.Settings.StopIfGoingOnBatteries = false;	
				// Register the task in the root folder
				ts.RootFolder.RegisterTaskDefinition(name, td);
			}
				
				
		}
		public static void createTaskRuningAtStartAllUser(string name,string executePath, string workingDirectory)
		{
			createTaskRuningAtStart(name,executePath,workingDirectory,"Users",null);
		}
		public static void createTaskRuningAtStart(string name,string executePath, string workingDirectory, string userName, string password)
		{
			using (TaskService ts = new TaskService())
			{
				TaskDefinition td = ts.NewTask();
				td.Principal.RunLevel = TaskRunLevel.Highest;
				td.RegistrationInfo.Description = "name";
				
//				BootTrigger bt = new BootTrigger();
//				bt.Delay = TimeSpan.FromSeconds(30);
				//td.Triggers.Add(bt);			
				LogonTrigger lt = new LogonTrigger();
				lt.Delay = TimeSpan.FromSeconds(30);
				td.Triggers.Add(lt);
				
				td.Actions.Add(new ExecAction(executePath,"",workingDirectory));
				td.Settings.DisallowStartIfOnBatteries=false;
				td.Settings.AllowDemandStart = true;
				td.Settings.StopIfGoingOnBatteries = false;	
				// Register the task in the root folder
				ts.RootFolder.RegisterTaskDefinition(name, td,TaskCreation.CreateOrUpdate,userName,password,TaskLogonType.Group,null);
			}
				
				
		}
		
		public static void deleteTaskRunningAtStart(string name)
		{
			using (TaskService ts = new TaskService())
			{
				  ts.RootFolder.DeleteTask(name,false);
			}
		}
	}
}
