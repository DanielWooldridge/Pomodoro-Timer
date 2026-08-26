# Pomodoro Timer

A desktop Pomodoro Timer built with C#, .NET 8, and WPF.

The application provides a simple way to structure focused work sessions using the Pomodoro Technique, with configurable session cycles and a custom desktop interface.

## Features

* 25-minute focus sessions
* 5-minute break sessions
* Choose between 1–8 Pomodoro cycles
* Start and pause the timer
* Reset the current timer
* Automatic transitions between work and break sessions
* Completion message when all selected cycles are finished
* Custom borderless Windows interface
* Custom dark and pink gradient UI
* Animated circular timer button
* Minimize and close controls
* Drag the borderless window around the desktop

## Design

The user interface was designed and refined using **Microsoft Blend for Visual Studio**, which was used to help explore the visual design, layout, styling, animations, and overall presentation of the application.

The final interface was implemented using WPF and XAML, with Blend helping during the design and prototyping process.

## Preview

<img width="852" height="448" alt="PomodoroTimer Screenshot" src="https://github.com/user-attachments/assets/4005f343-2568-446c-91c5-25e8e169666c" />

## How It Works

The application follows a standard Pomodoro-style workflow:

```text
Select number of cycles
        |
        v
  25-minute focus
        |
        v
    5-minute break
        |
        v
   More cycles?
     /     \
   Yes      No
    |        |
    v        v
  Focus    Complete
  again
```

Each completed focus session counts toward the number of cycles selected by the user. Once all selected cycles have been completed, the application displays a completion message.

## Technology

| Technology      | Purpose                           |
| --------------- | --------------------------------- |
| C#              | Application logic                 |
| .NET 8          | Runtime and application framework |
| WPF             | Desktop UI framework              |
| XAML            | UI layout and styling             |
| Microsoft Blend | UI design and prototyping         |
| DispatcherTimer | Countdown and timer functionality |

## Project Structure

```text
Pomodoro-Timer/
|
├── PomodoroTimer/
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── AssemblyInfo.cs
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   └── PomodoroTimer.csproj
│
├── PomodoroTimer.sln
├── .gitattributes
└── README.md
```

## Getting Started

### Prerequisites

You will need:

* Windows
* .NET 8 SDK
* Visual Studio 2022 or another compatible .NET development environment
* WPF development support

### Clone the Repository

```bash
git clone https://github.com/DanielWooldridge/Pomodoro-Timer.git
cd Pomodoro-Timer
```

### Run the Application

```bash
dotnet run --project PomodoroTimer/PomodoroTimer.csproj
```

Alternatively, open `PomodoroTimer.sln` in Visual Studio and run the project.

## Usage

### Select Your Cycles

Use the Cycles dropdown to choose between 1 and 8 Pomodoro cycles.

### Start the Timer

Click the main timer button to start a 25-minute focus session.

### Pause the Timer

Click the timer while it is running to pause the countdown. Click it again to resume.

### Take a Break

Once a focus session reaches zero, the application automatically switches to a five-minute break.

When the break finishes, the next focus session begins automatically.

### Reset the Timer

Use the Reset Timer button to reset the current session to its initial 25-minute duration.

## Configuration

The default timer durations are:

```text
Focus: 25 minutes
Break: 5 minutes
Cycles: 1–8
```

The focus and break durations are currently defined in the application source code rather than exposed as configurable settings.

## Future Improvements

* [ ] Customisable focus duration
* [ ] Customisable break duration
* [ ] Long breaks after multiple Pomodoro sessions
* [ ] Persistent user preferences
* [ ] Session statistics
* [ ] Daily and weekly productivity tracking
* [ ] Sound notifications
* [ ] Desktop notifications
* [ ] Keyboard shortcuts
* [ ] System tray support
* [ ] Improved accessibility
* [ ] Multiple themes
* [ ] Application icon
* [ ] Installer or packaged release
* [ ] Automated tests



## Author

Created by Daniel Wooldridge.

---

Built with C#, .NET 8, WPF, and Microsoft Blend for Visual Studio.
