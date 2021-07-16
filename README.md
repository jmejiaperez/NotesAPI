**NotesAPI**  
This api comes with openapi included and can be reached at  
```
    localhost:5000/swagger-ui
```  
The api with the endpoints can be reached at  
```
    localhost:5000/[endpoint]
```  
This api contains some very basic endpoints, there is no authentication, and no logging.  
Any exception messages that you will get, they will be forwarded in the response.  
Since this is just for demonstration purposes, i believe this is fine, but if it was for production.  
Then no way i would print out the stack trace.  

There are two ways to run this application.  
1) running it via dotnet run  
2) running it via docker  

**Running on Docker**  
I usually like to run all my apis in a dockerfile, it helps me with my clean up and keeps things nice and tidy.  
To build the image so you can run it locally; you can just copy and paste the following command in the terminal   
```
    docker build -t notesapi:local .
```  
then to run the image, you can copy and paste the command in the terminal    

```
    docker run -p 5000:5000 --network=bridge notesapi:local
```  

now if you want to run the image detached you can do the following command instead  

```
    docker run -d -p 5000:5000 --network=bridge notesapi:local
```  

**Running via dotnet**  
To run the api on a powershell or a command terminal.  
In order to run this api, you will need to download netcore sdk (because you are building the application, then running it) which you can by visiting the following site https://dotnet.microsoft.com/download   
Once you have netcore installed open up a terminal or powershell window in the NotesAPI folder.  
Run the following command in the specified order  
```
    RUN dotnet restore NotesAPI.sln

    RUN dotnet publish -c Release -o app/
```  

After you have ran the commands, cd into the app folder and use the following command to run the api.  
```
    dotnet NotesAPI.dll
```  

**What to expect**  

Once the api is running, the only file that is created during runtime is the NotesDatabase.sqlite.  
This file is not exposed out of the docker image if you run it via docker, but it is exposed if you run the app using dotnet.  
After the database is the table is created, and the api will be ready to consume and persist any data that is sent to it.  
There is no logging, but the stack trace is returning in the response if something went wrong.  
This is only acceptable since its a proof of concept.  

**Seed Data**  
If you feel lazy to create multiple notes to see if the api will create and insert them, well you can definitely utilize the _seed_data.py_ script.   
In order to use this script you need to use the following command  
```
    python seed_data.py 10
```  

In that command, we are saying that we want to create 10 random notes.  
So the script will do just that and perform a call to the notes api to insert a new note.  
After the note is inserted, then a note id is displayed on the screen.  

**Execution**  
You were able to bring up the api, so now its up and running.  
Great, now you want to be able to hit it.  
The notes api comes with different endpoints, I strongly suggest that you visit the swagger documentation that is enabled within the api so that you can get a better idea of what each endpoint does and what data is expected.  
