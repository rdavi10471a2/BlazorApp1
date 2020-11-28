# BlazorApp1
Basic implementation of a getneric page state service that uses a direct reference to the page (Counter Page)
Shows uisng OnInitializedAsync to relaod cached items from service as well as as a basic implementation of using a stored value of when the page
was last loaded to allow for *refresh* of cached resources (DB query results and such) in the Counter2 page.

This is intended for use in a dashboard type application where data is static and you only want to pay to fetch it once and then keep it around.
