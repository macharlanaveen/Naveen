Use below link to explore MySQL ORM provider
https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
SCAFFOLDING Link for MYSQL
https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html

PM> Scaffold-DbContext "server=127.0.0.1;port=3306;user=root;password=N@veen9100;database=naveendb" MySql.Data.EntityFrameworkCore -o DataModel -f
Build started...
Build succeeded.

Screen 1 :-

HttpGet : GetMovie

UrlPath ; https://localhost:44308/api/Movie/GetMovie

Response : with 200 Status Code

{
  "data": [
    {
      "idMovie": 14,
      "plot": "No.01",
      "dateOfRelease": "2022-03-20T00:00:00",
      "poster": "\\images\\naveen\\57803ce0-6f2b-4a7b-ab45-546897ea8615_download.jpg",
      "producerId": 1,
      "producerName": "Brothers",
      "actorResponse": [
        {
          "idActor": 1,
          "actorName": "Mahesh Babu"
        },
        {
          "idActor": 2,
          "actorName": "Prabhas"
        }
      ]
    },
    {
      "idMovie": 17,
      "plot": "No.01",
      "dateOfRelease": "2022-03-21T00:00:00",
      "poster": "\\images\\naveen\\57803ce0-6f2b-4a7b-ab45-546897ea8615_download.jpg",
      "producerId": 1,
      "producerName": "Brothers",
      "actorResponse": [
        {
          "idActor": 1,
          "actorName": "Mahesh Babu"
        },
        {
          "idActor": 2,
          "actorName": "Prabhas"
        }
      ]
    }
  ],
  "message": "Movie Data Retrived Successfully.",
  "validationMessages": [],
  "isSuccessful": true,
  "isBusinessError": false,
  "isSystemError": false,
  "systemErrorMessage": null,
  "businessErrorMessage": null
}

Screen 2 :-

HttpPost : AddMovie

UrlPath ; https://localhost:44308/api/Movie/AddMovie

Request Body : 
{
  "movieRequest": {
    "plot": "string",
    "dateOfRelease": "2022-03-21T05:45:58.496Z",
    "poster": "string",
    "producerId": 0
  },
  "actorId": [
    0
  ]
}

Response :  with 200 Status Code

{
  "data": 1,
  "message": "Movie data Saved Successfully.",
  "validationMessages": [],
  "isSuccessful": true,
  "isBusinessError": false,
  "isSystemError": false,
  "systemErrorMessage": null,
  "businessErrorMessage": null
}

Screen 3 :-

HttpPut : UpdateMovie

UrlPath ; https://localhost:44308/api/Movie/UpdateMovie

Request Body : 

{
  "updateMovieRequest": {
    "idMovie": 0,
    "plot": "string",
    "dateOfRelease": "2022-03-21T05:52:12.820Z",
    "poster": "string",
    "producerId": 0,
    "actorId": [
      0
    ]
  }
}

Response :  with 200 Status Code

{
  "data": 1,
  "message": "Movie data Updated Successfully.",
  "validationMessages": [],
  "isSuccessful": true,
  "isBusinessError": false,
  "isSystemError": false,
  "systemErrorMessage": null,
  "businessErrorMessage": null
}

HttPost : UploadFile

Request : PathName and File

Urlpath : https://localhost:44308/api/Movie/UploadFile

Response : with 200 Status Code

{
  "path": [
    "\\images\\naveen\\50399e7b-9a56-4223-999f-8945f525d977_3d-wallpaper-swan-pink-tree-260nw-1687707232.jpg" : Inserted in "Poster" Column from "Movie" Table.
  ]
}

HttpPost : AddActor

Urlpath : https://localhost:44308/api/Actor/AddActor

Request Body : 
 
 {
  "bio": "Salman Khan",
  "dateOfBirth": "2022-03-21T06:01:28.340Z",
  "gender": "Male"
}

Response : with 200 Status Code

{
  "data": 1,
  "message": "Actor Data Saved Successfully.",
  "validationMessages": [],
  "isSuccessful": true,
  "isBusinessError": false,
  "isSystemError": false,
  "systemErrorMessage": null,
  "businessErrorMessage": null
}

HttpPost : AddProducer

Urlpath : https://localhost:44308/api/Producer/AddProducer

Request Body : 
 
 {
  "bio": "string",
  "dateOfBirth": "2022-03-21T06:25:40.898Z",
  "companyName": "string",
  "gender": "string"
}

Response : with 200 Status Code

{
  "data": 1,
  "message": "Producer Data Saved Successfully.",
  "validationMessages": [],
  "isSuccessful": true,
  "isBusinessError": false,
  "isSystemError": false,
  "systemErrorMessage": null,
  "businessErrorMessage": null
}







