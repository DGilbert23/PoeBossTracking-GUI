# PoeBossTracking-GUI
This WPF application is a very basic application to utilize the Path of Exile boss drop tracking API developed in another joint-effort project (https://github.com/alan-wade/poe-boss-tracker). This is not intended to be the final front end version used to consume this API but was developed quickly so that the API could be practically used for the time being.

The following functionality has been implemented:

 - Allow users to select the boss (by name) that they have defeated. This then dynamically generates many other controls based on the items in the available drop pool for that specific boss as returned by the Spring API
 - Using these generated controls, users can then input the quantity of each item & in-game value. User may then submit the form, call the API to track both the "boss kill" and the item drops associated with that "boss kill" and the value of those drops.

Endpoints exist within the API to support adding new bosses, adding new items, and adding those items to specific boss's possible drop pool. This application does not utilize those endpoints, as it was quickly created to allow for ease of use. Ultimately, we would like for this application to be replaced with a web-based alternative, that has both a user side for the implemented functionality listed above, and an administrative side for those endpoints that are not yet being used.

As of the time of this commit, neither the web api nor the PostgreSQL database are being hosted, due to declined interest in the game it supports. That said, I intend to revist this project as a whole at some point in the future.


