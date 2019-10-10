#Application description and installations instruction

It is a simple application indicating the route between source and destination including stops in between.
It uses google maps api to find the right connection. Depending on the application mode (google suggestions or memorized locations) it uses google maps api in order to fetch the locations suggestions.

## Important
The IE does not seem to be compatible with google maps. This is why some strange behaviour occurs. To be investigated.

## Applicaiton modes
The application can either memorize searched locations or can fetch suggestions from google maps maps

### Memorize locations mode
In order to use this mode the UseLocalSearchRepository setting in applications setting file needs to be set to "1" or to "YES"
In this case the setting SearchHistoryLocationString indicates the location of memorized locations

### Fetch locations from google maps api
In order to use this mode the UseLocalSearchRepository setting in applications setting file needs to be set to "0" or to "NO"
In this case the setting LocationsTemplateUrl indicates the google maps search location url in specified format
Also MinimumSearchStringLength indicates the minimum lenght of given search prefix in order to call google location api

## Other applicaiton settings
GoogleKey indicates the application key to be passed in order to fetch the locations and show the map
DirectionsTemplateUrl indicates the google maps direction url in specified format


