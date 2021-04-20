# TVmaze API Client (.NET/C#) [![Build status](https://img.shields.io/appveyor/ci/plneto/tvmaze-api-client.svg)](https://ci.appveyor.com/project/plneto/tvmaze-api-client/branch/master) [![Test status](https://img.shields.io/appveyor/tests/plneto/tvmaze-api-client.svg)](https://ci.appveyor.com/project/plneto/tvmaze-api-client/branch/master) [![NuGet Version](http://img.shields.io/nuget/v/TvMaze.Api.Client.svg?style=flat)](https://www.nuget.org/packages/TvMaze.Api.Client/) [![NuGet Downloads](https://img.shields.io/nuget/dt/TvMaze.Api.Client.svg)](https://www.nuget.org/packages/TvMaze.Api.Client/)

#### :warning: Work in progress

A client written in .NET/C# for the TVmaze API - https://www.tvmaze.com/api

## Usage:

```c#
var client = new TvMazeClient();

// Search for shows
var searchResult = client.Search.ShowSearchAsync("query");

// Get show main information
var showInformation = client.Shows.GetShowMainInformationAsync(showId);
```

## Endpoints Implemented:

### Search
| Endpoint              | Status    |
| --------------------- |:--------: |
| Show Search           | ✅        |
| Show Single Search    | ✅        |
| Show Lookup           | ✅        |
| People Search         | ❌        |

### Schedule
| Endpoint             | Status    |
| -------------------- |:---------:|
| Schedule             | ❌        |
| Web/Stream Schedule  | ❌        |
| Full Schedule        | ❌        |

### Shows
| Endpoint              | Status    |
| --------------------- |:---------:|
| Show Main Information | ✅        |
| Show Episode List     | ✅        |
| Episode By Number     | ✅        |
| Episodes By Date      | ✅        |
| Show Seasons          | ✅        |
| Season Episodes       | ✅        |
| Show Cast             | ✅        |
| Show Crew             | ✅        |
| Show AKA's            | ❌        |
| Show Images           | ✅        |
| Show Index            | ❌        |

### Episodes
| Endpoint                 | Status    |
| ------------------------ |:---------:|
| Episode Main Information | ✅        |


### People
| Endpoint                 | Status    |
| ------------------------ |:---------:|
| Person Main Information  | ❌        |
| Person Cast Credits      | ❌        |
| Person Crew Credits      | ❌        |

### Updates
| Endpoint      | Status    |
| ------------- |:---------:|
| Show Updates  | ✅        |

