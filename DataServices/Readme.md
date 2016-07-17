1. Open "Developer Command Prompt for VS2015"
2. run "dnvm" 
3. run "dotnet ef migrations add CreateTree"  -- for add migrations
4. run "dotnet ef database update"

The above need to add the string in project.json

"commands": {
    "web": "Microsoft.AspNet.Server.Krestrel",
    "ef": "EntityFramework.Commands"
  },

refer to : http://www.bricelam.net/2014/09/14/migrations-on-k.html