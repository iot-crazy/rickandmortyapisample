# rickandmortyapisample
Rick And Morty API Sample

# Description
An example of creating a local replica data in the Rick & Morty API for local querying.

# Notes for reviewers
1. This is a skeleton sample only and is not intended for production. There are various aspects which would be done differently which I am happy to discuss.
2. For the sake of simplicity, a single table database was used, normalisation would be an obvious improvement
3. Episodes wer omitted, again for the sake of simplicity and time saving

# Getting Started
1. Clone the repository
2. Open in Visual Studio 2019 or better
3. Execute the solution using the docker compose configuration

Upon execution, the consoel app will start to retrieve the data from the API and save in the local DB. This app will close upon completion.

# API URLs
localhost/Api/Characters <- lists all characters
localhost/Api/Character/id <- returns the character with the given id

# Any more?
Have a look around my other repositories for a variety of my hobby related code
