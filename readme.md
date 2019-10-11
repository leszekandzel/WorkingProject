# Application description and installations instruction

It is a simple application indicating the route between source and destination including stops in between.
It uses google maps api to find the right connection. Depending on the application mode (google suggestions or memorized locations) it uses google maps api in order to fetch the locations suggestions.
Since it is now a prototype, no installer is provided. The application should work "as is" after compiling without a need of installing any database. Just make sure, that the user has "write" access to the folder where exec is located (the file with search history will be created there).
App is using log4net in a very limited way, logging exceptions to the console. In case changes of logging configuration, the "write" permissions to the log folder and file should be given to the user.

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

DirectionsCheckTemplateUrl indicates the google maps api url to calculate if the requested directions can be found

