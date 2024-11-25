# DogsAndOriginAPI

DogsAndOriginAPI is a RESTful API built with .NET that allows you to manage information about dog breeds and their origins. This project supports full CRUD (Create, Read, Update, Delete) operations for managing data.

## Features

- Add new dog breeds with their origins.
- Retrieve details about existing dog breeds.
- Update existing breeds and their associated origins.
- Delete dog breeds and their origin.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (optional, for containerized deployment)
- [Git](https://git-scm.com/) (to clone the repository)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ArslanIdrees257/Hutchison.git
   cd DogsAndOriginAPI

	2.	Restore dependencies:

dotnet restore


	3.	Build the project:

dotnet build


	4.	Run the API:

dotnet run


	5.	Test the API locally:
	•	Visit http://localhost:<port> in your browser or use a tool like Postman to test the endpoints.

API Endpoints

HTTP Method	Endpoint	Description
GET	/api/dogs	Get all dog breeds.
POST	/api/dogs	Add a new dog breed and its origins.
PUT	/api/dogs/{origin}	Update a breed’s origins.
DELETE	/api/dogs/{dog}	Delete a specific dog breed.

Example Request and Response

GET /api/dogs

Request:

GET /api/dogs HTTP/1.1
Host: localhost:<port>

Response:

{
  "husky": ["british", "spanish"],
  "labrador": ["atlantic", "french"]
}

Deployment

Local Deployment

	1.	Run Locally:

dotnet run


	2.	Access the API:
	•	Open a browser or API testing tool and navigate to:

http://localhost:<port>/api/dogs



Deployment with Docker

	1.	Build the Docker image:

docker build -t dogs-and-origin-api .


	2.	Run the container:

docker run -p 8080:80 dogs-and-origin-api


	3.	Access the API:

http://localhost:8080/api/dogs



Deployment to Render

	1.	Push the code to GitHub.
	2.	Configure the Dockerfile in Render:
	•	Use the Dockerfile at the project root.
	•	Follow Render’s deployment guide for Docker-based services.


License

This project is licensed under the MIT License. See the LICENSE file for details.

Contact

For questions or support, contact:
	•	Name: Muhammad Arslan Idrees
	•	Email: Arslanidrees257@gmail.com
	•	GitHub: ArslanIdrees257
