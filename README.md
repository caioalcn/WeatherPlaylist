# WeatherPlaylist

[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://lbesson.mit-license.org/)
[![Twitter Follow](https://img.shields.io/twitter/follow/caiowk.svg?style=social)](https://twitter.com/caiowk)  
[![Ask Me Anything !](https://img.shields.io/badge/Ask%20me-anything-1abc9c.svg)](https://GitHub.com/Naereen/ama)
![Language](https://img.shields.io/badge/Language-C%23-red)

This API was created for study purpose, you can find the challenger in https://github.com/ifood/vemproifood-backend.

The WeatherPlaylist is an **RESTFul API** developed in dotnet core, that recive as parameters either city name or lat long coordinates and returns a list of playlists suggestion according to the current temperature. **Feel free to contribute** :smile:.

## Bussines Model

- If temperature (celcius) is above 30 degrees, suggest tracks for party
- In case temperature is between 15 and 30 degrees, suggest pop music tracks
- If it's a bit chilly (between 10 and 14 degrees), suggest rock music tracks
- Otherwise, if it's freezing outside, suggests classical music tracks

## Setup

To run the project you need to set the API's tokens in the User Secrets. Here you can get the [Open Weather](https://openweathermap.org/api) token, and here for the [Spotify](https://developer.spotify.com/).
```
  {
   "OpenWeatherConfig": {
     "ApiToken": "YOUR-OPENWEATHER-API-TOKEN"
    },
  
   "SpotifyConfig": {
      "ApiToken": "YOUR-SPOTIFY-API-TOKEN"
   } 
  }
```

## REST API Examples:

### Home 

`Request: GET /`

    http://localhost:5001/
    
`Response:`
    
    {
    "app": "Playlist.API",
    "version": "1.0.0",
    "status": "OK",
    "message": "Welcome To WeatherPlaylist"
    }
    
    
    
 `Request: GET /playlist`
 
    http://localhost:5001/playlist
    
`Response:`
    
    {
      "playlists": {
          "href": "https://api.spotify.com/v1/search?query=Pop&type=playlist&market=US&offset=0&limit=5",
          "items": [
             {
                 "collaborative": false,
                 "description": "",
                 "href": "https://api.spotify.com/v1/playlists/1gxG8eion6raC6PynemKMj",
                 "id": "1gxG8eion6raC6PynemKMj",
                 "name": "Yep",
                 "snapshot_id": "NTUzLDNlNWNmM2FmMzRlYzcwZjM3MmU0NTdjMzVmOTg3MzQ5YjY5OWM3NjI=",
                 "tracks": {
                     "href": "https://api.spotify.com/v1/playlists/1gxG8eion6raC6PynemKMj/tracks",
                     "total": 626
                 },
                 "type": "playlist",
                 "uri": "spotify:playlist:1gxG8eion6raC6PynemKMj"
             }, ...]
        },
      "temperature": 23.77000000000004
    }
    
`Error Response:`

    {
      "error": {
          "status": 401,
          "message": "The access token expired"
      }
    }
