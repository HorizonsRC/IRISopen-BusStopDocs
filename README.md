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

                                                [HKEY_LOCAL_MACHINE\Software\Classes\IRISopen]
                                                "URL Protocol"="\"\""
                                                @="\"URL:IRISopen Protocol\""

                                                [HKEY_LOCAL_MACHINE\Software\Classes\IRISopen\DefaultIcon]
                                                @="\"BusStopDocs.exe,1\""

                                                [HKEY_LOCAL_MACHINE\Software\Classes\IRISopen\shell]

                                                [HKEY_LOCAL_MACHINE\Software\Classes\IRISopen\shell\open]

                                                [HKEY_LOCAL_MACHINE\Software\Classes\IRISopen\shell\open\command]
                                                @="\"\\\\file\\AppData\\IRIS Support Solutions\\IRISopen\\BusStopDocs.exe\" \"%1\""


BusStopDocs is installed at **\\file\AppData\IRIS Support Solutions\IRISopen**

## changes to IRIS

changes had to be made to IRIS to be able to handle the protocol. Namely these changes were made in the DocumentGrid.ascx located at
"~\Controls\Document\Views\DocumentsGrid orig.ascx"
On line 16 the '<a>' tag should be changed.
  - the orgiginal line reads:     <a href="<%# ((EDRMSDocument)Container.DataItem).URL %>"
  - this needs to be changed to:  <a href= "irisopen:<%# HttpUtility.UrlEncode(((EDRMSDocument)Container.DataItem).URL.ToString()) %>"

The new link not only needs to include the custom protocol, but the existing URL needs to be turned to a string and encoded.
This is so it is handled correctly by the BusStopDocs application.
  



