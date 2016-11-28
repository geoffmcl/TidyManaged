# TidyManaged

This is a managed .NET/Mono wrapper for the open source, cross-platform Tidy library, a HTML/XHTML/XML markup parser & cleaner originally created by Dave Raggett, with a long history of contributors...

This is a **fork** of - https://github.com/markbeaton/TidyManaged. The main effort, in this `masvc140` branch, was to re-compile it with MSVC14 (2015), and update the .NET framework used... and using `tidy.dll` 5.3.12, circa 2016.20.14, even though the API's do **not** exactly match...

I'm not going to explain Tidy's "raison d'être" - please read [Dave Raggett's](http://www.w3.org/People/Raggett/tidy/) original web page, the archival [SourceForge project](http://tidy.sourceforge.net/) site, or current - http://www.html-tidy.org/ - site or current - https://github.com/htacg/tidy-html5 - source for more information.

## libtidy

This wrapper is written in C#, and makes use of .NET platform invoke (p/invoke) functionality to interoperate with the Tidy library "libtidy" (written in portable ANSI C).

Therefore, you'll also need a build of the binary appropriate for your platform. If you're after a 32 or 64 bit Windows build, or you want a more recent build for Mac OS X than the one that is bundled with the OS, try these - https://github.com/htacg/tidy-html5/releases/tag/5.2.0 -

Otherwise, grab the latest source from the [GitHub HTML TIdy](https://github.com/htacg/tidy-html5), and roll your own.

## Sample Usage

Here's a quick'n'dirty example using a simple console app. Note: always remember to .Dispose() of your Document instance (or wrap it in a "using" statement), so the interop layer can clean up any unmanaged resources (memory, file handles etc) when done cleaning. See the [Test1/Program.cs](Test1/Program.cs) sample.
    
If this is run in a console, will results in an output:

```html
Test1 app. started...
line 1 column 1 - Warning: missing <!DOCTYPE> declaration
line 1 column 18 - Warning: discarding unexpected </tootle>
line 1 column 7 - Warning: missing </title> before <body>
<!DOCTYPE html>
<html>
<head>
<meta name="generator" content=
"HTML Tidy for HTML5 for Windows version 5.3.12">
<title>test</title>
</head>
<body>
asd
</body>
</html>

Test1 app. ending...
```


## Notes for non-Windows platforms

Thanks to the platform-agnostic nature of ANSI C, and the excellent work of the people at the [Mono Project](http://www.mono-project.com/), you can use this wrapper library anywhere that Mono is supported, assuming you can have (or can build) a version of the underlying Tidy library for your platform. That shouldn't be too hard - it's a default part of a standard Mac OS X install, for example; it probably is for most Linux distributions as well.

Under Mono, you might need to re-map the p/invoke calls to the appropriate library - or you might find it just works. See [this page on DLL mapping](http://www.mono-project.com/Config_DllMap) for more information on achieving this. Note: the .config file needs to be configured for the TidyManaged DLL, NOT your application's binary.

### Example TidyManaged.dll.config
    <configuration>
      <dllmap dll="libtidy.dll" target="/Users/Mark/Code/Tidy/TestHarness/libtidy.dylib"/>
    </configuration>
    

## The API

At this stage, 2009, I've just created a basic mapping of each of the configuration options made available by Tidy to properties of the main Document object - I've renamed a few things here & there, but it should be pretty easy to figure out what each property does (the documentation included in the code includes the original Tidy option name for each property). You can read the [Tidy configuration documentation here](http://tidy.sourceforge.net/docs/quickref.html), but then should read the later [QuickRef](http://api.html-tidy.org/tidy/quickref_5.2.0.html), and onwards as tidy progresses...

## The Future

At some point I'll add a nicer ".NET-style" API layer over the top, as it's a bit clunky (although perfectly usable) at the moment.

It should also be noted this 2009 release naturally only matches exactly the 2009 API of **`libtidy`**. It has been noted another fork, [frandi/TidyHtml5Managed](https://github.com/frandi/TidyHtml5Managed/tree/master) has tried to incorporate some of the later features and options of tidy. This is always an ongoing problem, keeping this `TidyManaged` completely in sync with **`libtidy`** progression! Maybe other forks have progressed this further...

There would certainly could be a scripted way to read current `tidy` configuration, and generate the appropriate `p/Invoke` source file(s), ready for a quick re-compile...

Original: Mark Beaton (markbeaton) - 2009
Edited: Geoff R. McLane (geoffmcl) - 2016

; eof
