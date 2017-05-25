# CoreScheduler

CoreScheduler is a GUI, toolset, and job manager for Quartz.Net

It started as a side project, and morphed into something that is almost useable.

**BY NO MEANS IS THIS PROJECT COMPLETE**

## Basic Feature List:

- Allows jobs to be run from scripts, instead of precompiled managed code.
  - Currently supports Python, C# (integrated and standalone), and Windows Batch files
  - Scripts can have file, or script dependencies
  - Scripts are executed on the fly by IronPython or CSScript.
  - Support for new job types is relatively easy, using a attribute based API.
  - All scripts are sandboxed in their on AppDomains for added security.
- Sensitive information like Network Credentials and SQL Connection strings can be passed dynamically into a script's execution context. No more hard coding passwords!
- Packaging of jobs for import/export, including encryption for sensitive dependencies.
- Advanced scheduling using Quartz.Net's implementation of CRON, and a UI to easily build advanced CRON strings.
- Syntax Highlighting built into the file manager, to help with on the fly edits.
- Advanced Logging allows each individual script to log different levels of information, and presents it in a easy to read and understand interface.

### C# Job Types. In order to support older systems, there are two types of C# jobs: integrated and standalone.

#### Integrated Jobs

Integrated jobs get all the advanced features listed above. A script context object is passed to the entry method of the script. This object contains logging utilities, sensitive information, and any other utilities that may need to be passed.

#### Standalone Jobs

Standalone jobs are executed purely through CSScript. They recieve no integration, and are here for legacy support.
