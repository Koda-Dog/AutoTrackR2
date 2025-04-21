AutoTrackR2 - Star Citizen Kill-Tracking Tool
AutoTrackR2 is a powerful and customizable kill-tracking tool for Star Citizen. Designed with gankers and combat enthusiasts in mind, it integrates seamlessly with the game to log, display, and manage your kills, providing detailed information and optional API integration for advanced tracking.

🚀 Features
Log File Integration: Point to Star Citizen's live game.log to track kills, death, other way's to die and Vehicle-SoftKills in real-time.

API Integration (Optional):
Configure a desired API to send kill data for external tracking or display.
Secure your data with an optional API key.
To set up your own server, see: https://expressjs.com/

Video Clipping (Optional):
Set a path to your clipping software to rename video events automatically. (except suicides and Vehicle-SoftDeath)

Visor Wipe Integration:
Automates visor wiping using an AutoHotkey script (visorwipe.ahk).
Requires AutoHotkey v2.
Script must be placed in C:\Users\<Username>\AppData\Local\AutoTrackR2\.
(except suicides and Vehicle-SoftDeath and all FPS events)

Video Record Integration:
Customize the videorecord.ahk script for your specific video recording keybinds.
Requires AutoHotkey v2.
Script must be placed in C:\Users\<Username>\AppData\Local\AutoTrackR2\
(except suicides and Vehicle-SoftDeath)

Offline Mode:
Disables API submissions. The tool will still scrape and display information from the RobertsSpaceIndustries website for the profile of whomever you have killed.

Custom Themes:
Easily add or modify themes by adjusting the ThemeSlider_ValueChanged function in ConfigPage.xaml.cs.
Update the ThemeSlider maximum value in ConfigPage.xaml to reflect the number of themes added.

Sound output:
In the event of a kill, soft death, vehicle destruction or PlayerSpawn a mp3 file is played. 
Thanks to https://www.voicebosch.com/soundbiter/ for providing the samples.


📁 Configuration
Log File:
Specify the path to Star Citizen's game.log.

API Settings (Optional):

API URL: Provide the endpoint for posting kill data.

API Key: Secure access to the API with your unique key.

Video Clipping Path (Optional):
Set the directory where your clipping software saves kills.

Visor Wipe Setup:
Place visorwipe.ahk in C:\Users\<Username>\AppData\Local\AutoTrackR2\.
AutoHotkey v2* is required.

Video Recording Setup:
Modify videorecord.ahk to use the keybinds of your video recording software.
Place videorecord.ahk in C:\Users\<Username>\AppData\Local\AutoTrackR2\.
AutoHotkey v2* is required.

*AutoHotkey v2: https://www.autohotkey.com/v2/

Offline Mode Slider:
Enable to disable API submission. Restart the tracker to apply changes.

SoundON Slider:
Enable or disable Soundeffects.

VehicleDestruction Slide:
Activates the live display for VehicleDestruction.

OtherLog Slider:
Activate the logging of the ‘Other way to die’ events.
There will also no wipe or Video Recording if disabled.
Suicide event will never be Recorded.

Sound output:
You can change these by repleacing the files in the programme folder /Assets in which you have installed AutoTrackR2 or just delete the one you don't like.

🛡️ Privacy & Data Usage
No Personal Data Collection:
AutoTrackR2 does not collect or store personal or system information, other than common file paths to manage necessary files.

Access and Permissions:
The tool reads its own config.ini and the game.log from Star Citizen. It will also create a CSV file of all your logged kills, stored locally on your machine in the AppData folder.

Optional Data Submission:
Data is only sent to an API if explicitly configured by the user. Offline Mode disables all outgoing submissions.

Killfeed Scraping:
The program scrapes the profile page of killed players to display their information locally. This feature remains active even in Offline Mode.

Limitations:
Own ships are only registered when switching to Nav mode.
Snubs and vehicles are not recognised.

⚙️ Installation
Download the latest release from the releases page.
Follow the setup instructions included in the installer.
Configure the tool using the settings outlined above.

❗Update
Log-Files 2.06-stable and older will be automatically backup into _backup_Kill-log.csv and converted.

💡 Customization
To customize themes or behaviors:

Add Themes:
Update the ThemeSlider_ValueChanged function in ConfigPage.xaml.cs with your desired colors and logos.
Adjust the ThemeSlider maximum value in ConfigPage.xaml to match the number of themes.

Modify AHK Scripts:
Edit visorwipe.ahk and videorecord.ahk to fit your specific keybinds and preferences.

📞 Support
For questions, issues, or feature requests, please visit discord.gg/griefernet.

🔒 License
AutoTrackR2 is released under the GNU v3 License.
