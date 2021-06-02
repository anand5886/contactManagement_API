**Web API**
1. Web API's HRMS.API are developed using .NET Core 3.1
2. It has 5 projects: 
					HRMS.API - Controllers and configuration for jwt tokens. Also has logic to publish the API's using AWS lambda.
					HRMS.Business - Business logic (if any)
					HRMS.Data - EF model classes and db context classes.
								Design supports multi tenants- Same client app can be hosted for multiple client.
								Each client will have seperate tenant database (ex. HRMS_CLIENT0001 and HRMS_CLIENT0002). 
								Connection to tenant will be resolved based on tenant id from client App.
					HRMS.Entity - Entity (DTO) objects
					HRMS.Test - Unit test case project
					
**How to run the app**
1. Application can be ran using Visual Studio.

**Hosting**
1. Web API's are hosted on AWS as serverless lambda function
2. https://master.d23f71t0w5hi48.amplifyapp.com/
3. Credentials:- 
				user name: anand24agrawal@gmail.com
				 password: mytestpwd 