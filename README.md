# IRISopen-BusStopDocs
a solution for accessing files and processes on the intranet via Chrome and Edge

this C# program is used as middleware between intranet files and applications, and the IRIS web server. This was needed due to chrome security not allowing access to local files,
even on the intranet.
While this provides excellent security for internet browsing, it adds a unnessasary limitation for intranets. Using a custom protocol handler,
IRIS is able to open links using this handler which opens them with the client's default application
Links on the IRIS Webpage that have the protocol handler: ":IRISopen", will execute the handler application (BusStopDocs) on the intranet and open the requested document or
start the selected process.

**For this to work, a regestry key will need to be added.**

The IRISopen.reg file can be imported into the regestry editor or simply run from the file explorer to add the key and child keys to the system regestry.
This adds the link between the custom handler and the the handler application - another layer of security to stop other custom handlers trying to lauch processes on the
client system.

*The contents of IRISopen.reg:*
                                                
                                                Windows Registry Editor Version 5.00

                                                [HKEY_CURRENT_USER\Software\Classes\IRISopen]
                                                "URL Protocol"="\"\""
                                                @="\"URL:IRISopen Protocol\""

                                                [HKEY_CURRENT_USER\Software\Classes\IRISopen\DefaultIcon]
                                                @="\"BusStopDocs.exe,1\""

                                                [HKEY_CURRENT_USER\Software\Classes\IRISopen\shell]

                                                [HKEY_CURRENT_USER\Software\Classes\IRISopen\shell\open]

                                                [HKEY_CURRENT_USER\Software\Classes\IRISopen\shell\open\command]
                                                @="\"C:\\Program Files\\IRISopen\\BusStopDocs.exe\" \"%1\""


BusStopDocs is installed at **\\file\AppData\IRIS Support Solutions\IRISopen**