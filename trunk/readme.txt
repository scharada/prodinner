prodinner 

http://prodinner.codeplex.com

requires: .net 4, asp.net mvc 3, VS2010, sql server

------------
first create the database by executing the db.sql script 

(open it in sql management studio, hit f5)
(you are going to get some errors like: "can not drop the database prodinner" or "only user processes can be killed" it's ok )
the script tries to kill all connections to prodinner, drop the db, and create it, after it inserts some data

------------

start the solution (ProDinner.sln)

if it asks you to create a virtual directory on you IIS, click yes (if you don't have IIS, or you got problems with it you can edit the WebUI\WebUI.csproj with notepad and change the line <UseIIS>True</UseIIS> to <UseIIS>False</UseIIS> save, close vs open sln file again)

edit the connection string from WebUI\web.config 
(if it's needed, probably you will need to change the Data Source, now it's .\sqlexpress, also username and password, now they are UID=sa;pwd=1)

you can also edit the connection string in Tests\app.config if you want to run the unit tests

in WebUI\web.config edit the line :  <add key="storagePath" value="D:\ProDinner\WebUI\pictures\"/> change the D:\ProDinner to where you have your prodinner folder

****************
at this moment everything should work but you might get generic GDI+ error when trying to upload image, to get rid of this error do this:
go to properties of \WebUI\pictures folder and in security tab add full control rights for the IIS_IUSRS
(on Win7 and 2008 server it's properties-> security tab -> Edit button -> Add button -> Advanced button -> Find Now button -> select IIS_IUSRS from the search results -> OK button -> OK button -> Full Control checkbox -> OK -> OK )

(last 2 steps are for saving images, and the last one sometimes is not needed)

--------------

there is also a video tutorial for this project set up instructions, look on the http://prodinner.codeplex.com

To support the project follow it (little star button above the green Download button), rate it, post discussions if any problems






