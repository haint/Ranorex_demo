
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace DHSAutomation.Common
{

	public class SystemTime
	{
		static short currYear = (short) DateTime.Now.Year;
		static short currMonth = (short) DateTime.Now.Month;
		static short currDay = (short) DateTime.Now.Day;
		
		
		[StructLayout(LayoutKind.Sequential)]
		public struct SYSTEMTIME
		{
			public short wYear;
			public short wMonth;
			public short wDayOfWeek;
			public short wDay;
			public short wHour;
			public short wMinute;
			public short wSecond;
			public short wMilliseconds;
		}
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool SetSystemTime(ref SYSTEMTIME st);
		public SystemTime()
		{

		}
		
		public static void ChangeSystemTime (int year,int month,int day)
		{
			SYSTEMTIME st = new SystemTime.SYSTEMTIME();
			st.wYear = (short)year;
			st.wMonth =(short) month;
			st.wDay = (short)day;
			
			
			
			st.wHour = (short)DateTime.UtcNow.Hour;
			st.wMinute=(short)DateTime.UtcNow.Minute;
			st.wSecond=(short)DateTime.UtcNow.Second;
			
			SetSystemTime(ref st);
		}
		
		public static void RestoreSystemTime ()
		{
			SYSTEMTIME st = new SystemTime.SYSTEMTIME();
			st.wYear = currYear;
			st.wMonth = currMonth;
			st.wDay = currDay;
			st.wHour = (short)DateTime.UtcNow.Hour;
			st.wMinute=(short)DateTime.UtcNow.Minute;
			st.wSecond=(short)DateTime.UtcNow.Second;
			SetSystemTime(ref st);
		}		

	}
}
