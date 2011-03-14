prodinner on vs dev server (on IIS works much faster, but there are additional configuration steps)

http://prodinner.codeplex.com

requires: .net 4, asp.net mvc 3, VS2010, sql server

------------
first create the database by executing the db.sql script 

(open it in sql management studio, hit f5)
(you are going to get some errors like: "can not drop the database prodinner" or "only user processes can be killed" it's ok )
the script tries to kill all connections to prodinner, drop the db, and create it, after it inserts some data

------------

start the solution (ProDinner.sln)

edit the connection string from WebUI\web.config 
(if it's needed, probably you will need to change the Data Source, now it's .\sqlexpress, also username and password, now they are UID=sa;pwd=1)

in WebUI\web.config edit the line :  <add key="storagePath" value="D:\ProDinner\WebUI\pictures\"/> change the D:\ProDinner to where you have your prodinner folder

--------------

I am also going to make a video tutorial for this project set up instructions, look on the http://prodinner.codeplex.com

If you want to support the project follow it (little star button above the green Download button), rate it, post discussions if any problems






