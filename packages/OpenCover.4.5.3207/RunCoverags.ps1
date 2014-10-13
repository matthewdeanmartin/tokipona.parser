cd C:\Users\mmartin\code\BasicTypes\packages\OpenCover.4.5.3207
#.\openCover.Console.exe
cls

#&"C:\Users\mmartin\code\myCareersResearch\Web\MyCareer\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe" "C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\BasicTypes.dll"

cd C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\

#C:\Users\mmartin\code\myCareersResearch\Web\MyCareer\packages\NUnit.Runners.2.6.3\tools

&"C:\Users\mmartin\code\BasicTypes\packages\OpenCover.4.5.3207\openCover.Console.exe"  `
    -register:user `
    "-target:C:\Users\mmartin\code\BasicTypes\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe" `
    "-targetargs:C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\BasicTypes.dll /basepath=C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\  /noshadow " `
    "-targetdir:C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\"

#cls
&"C:\Users\mmartin\code\BasicTypes\packages\OpenCover.4.5.3207\ReportGenerator_1.9.1.0\bin\ReportGenerator.exe" `
    -reports:C:\Users\mmartin\code\BasicTypes\BasicTypes\bin\Debug\results.xml `
    -targetdir:C:\Users\mmartin\code\BasicTypes\packages\OpenCover.4.5.3207 `
    -reporttypes:HtmlSummary