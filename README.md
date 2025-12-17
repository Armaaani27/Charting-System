# Medical Charting System

**Description:**
A C# application that simulates an electronic medical record (EMR) system for healthcare providers. The program allows users to create, view, and update lists of patients and physicians, as well as manage appointments.

**Tech Used:**  
C#, .NET MAUI Framework

**Key Features:**  
- Add, edit, and delete patient records with demographic and clinical information  
- Record diagnoses and prescriptions  
- Search and filter patient charts by name or ID  
- Data validation to ensure accurate record entry  
- Data persistence via RESTful API  
- Simple, intuitive user interface

**How to Run:**
How to Run
- Ensure the following are installed on your system:
  - .NET SDK (8.0 or later)
  - Visual Studio 2022 (17.8 or later recommended)
  - .NET MAUI workload
  - Android Studio (for Android emulator)
  - Xcode (macOS only, for iOS simulator)
  - Install the MAUI workload if not already installed:
- dotnet workload install maui
- Clone the Repository
  - git clone https://github.com/Armaaani27/ChartingSystem.git
  - cd ChartingSystem
- dotnet restore
- Run the API backend
- cd API.ChartingSystem
  - dotnet run
- Open ChartingSystem.sln in Visual Studio
- Select a target platform (Android Emulator, iOS Simulator, or Windows)
- Click Run
