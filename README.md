# Final Project for Course 6250

**An Computer Games Shopping Application:**   
Final Project for INFO6250 

## Author

Xuyang Li NUID: 001409590
Jiaao Yu  NUID: 001464004

## Project Requirement

1) The Shopping Website done for Assignment 5/6 needs to be extended. The front-end MVC needs to be replaced by Angular.

2) A 10 sec or so game should be available when the user clicks on a button and the page loads.

## Locally Running Instructions

1) Place the "home" folder into the D: drive (for windows). This "home" folder is served as the database for the API.
2) Go to the "ShoppingWebsiteAPI" folder, click the "ShoppingWebsiteAPI.sln" to open the Visual Studio.
3) Click the "IIS Express" button on the toolbar of the Visual Studio to run the API. Write down the IP address of the API.
3) Go to the "ShoppingWebsiteAngular" folder, open the commandline in that folder, run "npm install" to install packages for the client side.
4) Open the file "app-service.service" in the path "ShoppingWebsiteAngular\src\app\shared\services", replaced the "serverUrl" variable with the IP adress of the API.
5) Run "ng serve" int the commandline, open your browser at "localhost:4200". Enjoy the final project.

## API Deployment 

1) Deploy API using visual studio PaaS. 
2) Upload the "Database" and "Rescources" folders (which are under the path "home\site\wwwroot") onto the cloud, by using azure -> APP Service -> azure advanced tools  -> Kudu service -> Debug console -> PowerShell. (Drag the folders into it) 
3) Make sure the "Database" and "Rescources" folders is under the path "D:\home\site\wwwroot" on the cloud.

## Angular Deployment

1) Deploy angular using packer and terraform. (Need to modify the uri variable in app service, according to api address)
2) Edit the template.json, ( "ssh_keypair_name", "ssh_private_key_file"). And zip your dir (ShoppingWebsiteAngular -> website.zip). Run packer build
3) After AWS finished building AMI, edit main.tf (key_name, private_key). Run terraform apply.
4) Then, shopping website on the new instance could be accessed on ipaddress:4200;
5) BTW, after terminate the terminal running terraform , the website from "ng serve" will stop. You should connect to the instance using SSH, and run the shell script from main.tf manully.

