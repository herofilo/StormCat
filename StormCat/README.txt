StormCat, by jamoram

Current version: 1.7.1 
Last Update: 2019/09/17

A little tool for:
	1) Creating and managing multiple independent catalogues of Moviestorm addons, both installed and as addon files:
		- Catalogues can be searched for specific assets according to a series of criteria.
		- Asset lists can be exported as Microsoft Excel 2007 workbooks.
	2) Checking the the validity and listing the contents of your valid:
		- Moviestorm addon/content package files (.addon)
		- Moviestorm addons and content packages already installed (folders)
	3) Checking the version of the Sketchup files to be imported in Moviestorm with the Modder's Workshop
	4) Optionally restoring Moviestorm addon files disguised as archive files


WHAT'S NEW (1.7.1):
-----------
* Major overhaul of the User Interface
* (Hopefully) Much better and more complete catalogue management
* New types of "assets" listed and searchable:
	Animations
	Stocks
	Demo/Start Movies
* Addon catalogue table:
	- Double-click: shows contents for selected row
	- New option in contextual menu: export to Excel
	- Added columns (AddonBasicInfo): 
		Description
		Statiscs of assets 
	- Autosave
* Bugs fixed:
	- Searching assets: 
		- when an asset name is specified
		- when the type of addon is specified (official content pack/third-party addon)
	- Some other minor bugs

Please refer to the VERSION HISTORY section for a complete history of changes in the program


HOW TO USE (OBSOLETE, NEEDS EXTENSIVE RE-WRITING):
----------
Simply drag and drop any number of addon files, ZIP archives or folder into the zone labelled of the main form of the application. 
Alternatively, a file or folder can be directly dropped on the program's executable (or an link)
Any potential addon file will be checked to determine whether it will work or not with the current version of Moviestorm.

Any possible cause of problems will identified by the token string '#!?'

The output to the form may be copied to a text editor, thru a copy&paste sequence.

Please also note that the program only checks and reports about the following types of files:
	- Moviestorm addon files (extension .addon)
	- Moviestorm addons and content packages already installed (folders)
	- Sketchup files (extension .skp)
	- Archive files (extensions .zip  .rar  .7z): will look for addon and Sketchup files inside
	- Folders: will be scanned recursively
	
It ignores any other type of files.

Command line: 
------------
MSAddonChecker can be invoked also passing arguments as part of its command line. The accepted syntax for calling the program this way is:
	MSAddonChecker [options...] [source-specifications...]
	Options: 
		-onlyissues | -i : report only files with issues
		-showcontents | -c : show the contents of valid addon files
		-listallanimations | -laa : list all animation files
		-listgestureanimations | -lga : list all gesture and gait animation files
		-listweirdgestures | -lwg : list improper gesture verb definitions
		-compactdupverbs | -cdv : compact duplicate verb names, even if their animation file names differ
		-correctdisguisedaddons | -cda : correct valid addon files disguised as archives, keeping the original archive file
		-correctdisguisedaddons+ | -cda+ : correct valid addon files disguised as archives and delete the original archive file if succeeds.
 
	source-specifications: any mix of files and/or folders you'd like to check

PLEASE NOTE: options specified in the command line take precedence over and nullify processing options saved by default.


KNOWN ISSUES:
-------------
When selecting the 'Report Only Issues' some spurious output may be generated as it tries to inspect folders and the contents of archive files.


REQUIREMENTS
------------
Microsoft .NET runtime version 4.x must be installed for the application to be properly executed. Otherwise, an error will happen on launching.


SOURCE CODE FOR THE APPLICATION COMPONENTS AND THIRD-PARTY LIBRARIES:
---------------------------------------------------------------------
The source code for the application is available from its GitHub repository (https://github.com/herofilo/MSAddonChecker)
The source code for the MSAddonLib library can be downloaded from https://github.com/herofilo/MSAddonLib
SevenZipSharp can be obtained from its home site (https://archive.codeplex.com/?p=sevenzipsharp)
Other libraries will be restored automatically by the Nuget Package Restore system.

CONTACT INFO
------------
Suggestions for improvements and bug reports can be addressed to the email account: ExceptionRaisedSoft@gmail.com


VERSION HISTORY
---------------
* v1.7.1 (20190917):
	- Major overhaul of the User Interface
	- (Hopefully) Much better and more complete catalogue management
	- New types of "assets" listed and searchable:
		Animations
		Stocks
		Demo/Start Movies
	- Addon catalogue table:
		- Double-click: shows contents for selected row
		- New option in contextual menu: export to Excel
		- Added columns (AddonBasicInfo): 
			Description
			Statiscs of assets 
		- Autosave
	- Bugs fixed:
		- Searching assets: 
			- when an asset name is specified
			- when the type of addon is specified (official content pack/third-party addon)
		- Some other minor bugs

* v1.5.0 (20190907) 
	Support for multiple independent catalogues of Moviestorm addons.
	Application name changed to StormCat

* v1.3.0 (20190831): [INTERNAL]
	Syncing version number with MSAddonLib's

* v1.2.1 (20190827):
	Displays the last date of compilation of an addon

* v1.2.0 (20190819):
	- Application setup: Moviestorm folders (installation and user data) can now be explicitly specified (required when it has been installed in its location by default)
	- Processing options by default can now be saved and retrieved.
	  Options saved will apply whenever the application is launched, except if any option is specified in the command line.

* v1.1.0.1 (20190818):
	- ModdersWorkshop excluded from automatic scan of user addons
	- Now correctly identifying valid addons with no Data folder
	- Some minor improvements of the UI
	
* v1.1.0 (20190818):
	- Direct support of installed addons (folders)
	- Fixed a bug in the Gestures/Gaits listing
	- PuppetSummary:
		If no animation files at all, no Animations section is listed
	- New options:
		- Compact the list of verbs by name
		- Restoration of addons disguised as archives (and delete source archive if restoration succeeds)
	- Tooltips for every control in the UI
	- A new button for scanning every addon installed in the system

* v1.0.8 (20190815): 
	- Improper gesture and gait "verbs", ie, animation definitions of gaits and gestures for Props (only Puppets should have these kinds of animations) are detected:
		They are labelled with a '!?' at the end of the model
		A new option in the UI for listing these weird verbs
		NOTE: these verbs are most probably an error
	- Fixed a bug in the listing of Bodyparts contents if no gesture/gaits animations were found for a model

* v1.0.7 (20190814): 
	- Output text: 
		Archive names are preceded by a plus (+) character
		Addon names are preceded by an asterisk (*) character
	- Listing of Gestures/Gaits verbs now includes info about the puppets ('?' meaning this information couldn't be determined - the animation file referenced in the verbs couldn't be found inside the addon)
	- Decal listing improvements:
		- Only decals whose files actually exists in the addon are listed
		- No more duplicates
		- Decals are now listed ordered by type and name
	- Verbs: duplicated verbs are listed as a single line, specifying the number of iterations
	- Options in the UI for listing animation files: 
		List All Animation Files
		List Gesture/Gaits Animations Files for Bodyparts

* v1.0.6 (20190813): 
	- a nasty bug regarding the information about Puppet Interactive verbs has been fixed

* v1.0.5 (20190812) [INTERNAL]: 
	- a quick hack for checking Moviestorm addons and content packages already installed (folders) (can be slow)

* v1.0.0 (20190811): 
	- highly enhanced, with lots of new information about the contents of addon and with a more convenient presentation and format 

* v0.9.5.1 (20190502) [INTERNAL]:
	- Relocated SevenZipSharp.dll so it can be included as part of the source code distribution.

* v0.9.5 (20190501):
	- Addon files: detailed information (names) of demo movies and stock assets
	- Output contextual menú: copy to clipboard, clear, wordwrap on/off, increase/decrease font size
	- Addon files: when bad and option ShowContents, add blank line after

* v0.9.2 (20190501):
	- Fixed an error when Description is null and Blurb not null
	- Checks if the addon includes stock assets

* v0.9.1 (20190501):
	- Some corrections to the README file
	- Some optimizations analyzing the contents of the addons
	- Checks the addon has contents data 
	- Checks if the addon includes demo movies

* v0.9.0 (20190501):
	- Much cleaner and elegant output generation
	- Added an error identifying token string to the output

* v0.8.0 (20190501):
	- added: option 'Show contents of addon files'
	- added: read options from command line

* v0.7.0 (20171129):
	- added filter: report only files with issues
	- additional info about addons: publisher and licencing status
	- minor UI enhancements

* v0.6.0 (20171129):
	- added support for .RAR and 7z archives
	- detection of addon files disguised as archives

* v0.5.1 (20171128):
	- added support for Sketchup files and checking of their version

* v0.5.0 (20171128): first public release



