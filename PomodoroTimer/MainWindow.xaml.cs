using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PomodoroTimer
{
	public partial class MainWindow : Window
	{
		private DispatcherTimer timer;
		private TimeSpan timeLeft;
		private bool isRunning = false;
		private bool isBreak = false;

		private int totalCycles = 4;        // Total cycles selected by user
		private int completedCycles = 0;    // How many are finished

		public MainWindow()
		{
			InitializeComponent();

			timer = new DispatcherTimer();
			timeLeft = TimeSpan.FromMinutes(0.2); // Initial test value
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += TimerTick;
		}

		private void OnStartTimer(object sender, RoutedEventArgs e)
		{
			if (!isRunning)
			{
				isRunning = true;
				timer.Start();
				btnTimer.FontFamily = new FontFamily("Agent FB");

				// Read the selected cycle count from ComboBox
				if (cycleSelector.SelectedItem is ComboBoxItem selectedItem)
				{
					totalCycles = int.Parse(selectedItem.Content.ToString());
					completedCycles = 0;
					isBreak = false;
					timeLeft = TimeSpan.FromMinutes(25); // Reset work time
				}
			}
			else
			{
				isRunning = false;
				timer.Stop();
				btnTimer.FontFamily = new FontFamily("Blackadder ITC");
			}

			btnTimer.Content = isRunning ? timeLeft.ToString(@"mm\:ss") : "Paused";
		}

		private async void TimerTick(object sender, EventArgs e)
		{
			if (timeLeft.TotalSeconds > 0)
			{
				timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
				btnTimer.Content = timeLeft.ToString(@"mm\:ss");
			}
			else
			{
				timer.Stop();
				btnTimer.FontFamily = new FontFamily("Blackadder ITC");

				if (!isBreak)
				{
					// Finished a work session
					completedCycles++;

					if (completedCycles >= totalCycles)
					{
						btnTimer.Content = "All cycles complete!";
						isRunning = false;
						return;
					}

					btnTimer.Content = "Break Time!";
					await Task.Delay(1000);
					timeLeft = TimeSpan.FromMinutes(5);
					isBreak = true;
				}
				else
				{
					btnTimer.Content = "Work Time!";
					await Task.Delay(1000);
					timeLeft = TimeSpan.FromMinutes(25);
					isBreak = false;
				}

				btnTimer.Content = timeLeft.ToString(@"mm\:ss");
				timer.Start();
				btnTimer.FontFamily = new FontFamily("Agent FB");
			}
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			if (isRunning)
			{
				timeLeft = TimeSpan.FromMinutes(25);
				btnTimer.Content = timeLeft.ToString(@"mm\:ss");
			}
		}

		private void btnMin_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
